using System;
using System.Windows.Input;

namespace MovieRental.Helpers;

public class RelayCommand<T> : ICommand {
    protected readonly Action<T?> _execute;
    protected readonly Predicate<T?>? _canExecute;

    public RelayCommand(Action<T?> execute, Predicate<T?>? canExecute = null) {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged {
        add {
            if (_canExecute != null) {
                CommandManager.RequerySuggested += value;
            }
        }
        remove {
            if (_canExecute != null) {
                CommandManager.RequerySuggested -= value;
            }
        }
    }

    public bool CanExecute(object? parameter) {
        return _canExecute == null || _canExecute((T?) parameter);
    }

    public void Execute(object? parameter) {
        _execute((T?) parameter);
    }
}

public class RelayCommand : ICommand {
    protected readonly Action _execute;
    protected readonly Func<Boolean>? _canExecute;

    public RelayCommand(Action execute, Func<Boolean>? canExecute = null) {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged {
        add {
            if (_canExecute != null) {
                CommandManager.RequerySuggested += value;
            }
        }
        remove {
            if (_canExecute != null) {
                CommandManager.RequerySuggested -= value;
            }
        }
    }

    public bool CanExecute(object? parameter) {
        return _canExecute == null || _canExecute();
    }

    public void Execute(object? parameter) {
        _execute();
    }
}

public static class GlobalCommands {
    public static readonly ICommand NullCommand = new RelayCommand(() => { }, () => false);
}
