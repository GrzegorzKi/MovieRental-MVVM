using System.Collections.Concurrent;
using System.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MovieRental.ViewModel;

public abstract class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo {

    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string? propertyName = null) {
        if (!EqualityComparer<T>.Default.Equals(field, newValue)) {
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            ValidateAsync(field, propertyName);
            return true;
        }
        return false;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
        ValidateAsync();
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected virtual void OnPropertyChangedValidate<T>(T newValue, [CallerMemberName] string? propertyName = null) {
        ValidateAsync(newValue, propertyName);
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion INotifyPropertyChanged


    #region INotifyDataErrorInfo
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    private readonly ConcurrentDictionary<string, List<string>> _errors = new ConcurrentDictionary<string, List<string>>();

    public Task ValidateAsync(object? instance = null, string? propertyName = null) {
        return Task.Run(() => Validate(instance, propertyName));
    }

    // https://stackoverflow.com/a/37255232/11400707
    private readonly object _lock = new();
    public void Validate(object? instance = null, string? propertyName = null) {
        lock (_lock) {
            instance ??= this;

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(this, null, null);
            if (propertyName != null) {
                validationContext.MemberName = propertyName;
                Validator.TryValidateProperty(instance, validationContext, validationResults);

                // TODO Check if this works
                if (validationResults.Count == 0) {
                    _errors.TryRemove(propertyName, out _);
                    OnErrorsChanged(propertyName);
                }
            } else {
                Validator.TryValidateObject(instance, validationContext, validationResults, true);

                foreach (var kv in _errors.ToList()) {
                    if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key))) {
                        _errors.TryRemove(kv.Key, out _);
                        OnErrorsChanged(kv.Key);
                    }
                }
            }

            var q = from r in validationResults
                    from m in r.MemberNames
                    group r by m into g
                    select g;

            foreach (var prop in q) {
                var messages = prop.Select(r => r.ErrorMessage!).ToList();

                if (_errors.ContainsKey(prop.Key)) {
                    _errors.TryRemove(prop.Key, out _);
                }
                _errors.TryAdd(prop.Key, messages);
                OnErrorsChanged(prop.Key);
            }
        }
    }

    public void OnErrorsChanged(string propertyName) {
        var handler = ErrorsChanged;
        handler?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    public IEnumerable GetErrors(string? propertyName) {
        List<string>? errorsForName;
        if (propertyName != null && _errors.TryGetValue(propertyName, out errorsForName)) {
            return errorsForName;
        }
        return new List<string>();
    }

    public bool HasErrors {
        get => _errors.Any(kv => kv.Value != null && kv.Value.Count > 0);
    }

    #endregion INotifyDataErrorInfo

}
