using MovieRental.Helpers;
using MovieRental.Model;
using MovieRental.View.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class CustomerViewModel : ViewModelBase {
    // TODO Might want to use IoC solution for that
    private readonly IDialogService _dialogService = new DialogService();

    protected Customer _customerModel;
    protected ObservableCollection<RentedMovieViewModel> _rentedMovies;

    public event Action? UpdateCustomerCompleted;

    private ICommand? _updateCustomer;
    public ICommand UpdateCustomer => _updateCustomer ??= new RelayCommand(UpdateCustomerExecute);

    private ICommand? _deleteCustomer;
    public ICommand DeleteCustomer => _deleteCustomer ??= new RelayCommand(DeleteCustomerExecute, CanDeleteCustomerExecute);

    public CustomerViewModel() {
        _customerModel = new Customer();
        _rentedMovies = new ObservableCollection<RentedMovieViewModel>();
    }

    public CustomerViewModel(Customer customerModel) {
        _dialogService = new DialogService();
        _customerModel = customerModel;
        _rentedMovies = new ObservableCollection<RentedMovieViewModel>(customerModel.RentedMovies.Select(e => new RentedMovieViewModel(e)));
    }

    internal void UpdateCustomerExecute() {
        Validate();
        if (HasErrors) return;

        DatabaseDao.UpdateCustomer(CustomerModel);
        UpdateCustomerCompleted?.Invoke();
    }

    internal void DeleteCustomerExecute() {
        var message = $"Delete customer {FirstName} {LastName}?";
        if (RentedMovies.Count > 0) {
            message += "\nWARNING: Customer might have unreturned rented movies!";
        }

        if (_dialogService.Confirm(message)) {
            DatabaseDao.DeleteCustomer(CustomerModel);
            UpdateCustomerCompleted?.Invoke();
        }
    }

    internal bool CanDeleteCustomerExecute() {
        return Id != null;
    }


    public Customer CustomerModel {
        get => _customerModel;
        set {
            if (SetProperty(ref _customerModel, value)) {
                _rentedMovies = new ObservableCollection<RentedMovieViewModel>(_customerModel.RentedMovies.Select(e => new RentedMovieViewModel(e)));
                OnAllPropertiesChangedValidate();
            }
        }
    }

    public ObservableCollection<RentedMovieViewModel> RentedMovies {
        get => _rentedMovies;
        set => SetProperty(ref _rentedMovies, value);
    }

    public int? Id {
        get => _customerModel.Id;
        set {
            _customerModel.Id = value;
            OnPropertyChangedValidate(value);
        }
    }

    [Required]
    public string FirstName {
        get => _customerModel.FirstName;
        set {
            _customerModel.FirstName = value;
            OnPropertyChangedValidate(value);
            OnPropertyChanged(nameof(FullName));
        }
    }

    [Required]
    public string LastName {
        get => _customerModel.LastName;
        set {
            _customerModel.LastName = value;
            OnPropertyChangedValidate(value);
            OnPropertyChanged(nameof(FullName));
        }
    }

    public string FullName {
        get => _customerModel.FirstName + " " + _customerModel.LastName;
    }

    public string Address {
        get => _customerModel.Address;
        set {
            _customerModel.Address = value;
            OnPropertyChangedValidate(value);
        }
    }

    public string Phone {
        get => _customerModel.Phone;
        set {
            _customerModel.Phone = value;
            OnPropertyChangedValidate(value);
        }
    }
}
