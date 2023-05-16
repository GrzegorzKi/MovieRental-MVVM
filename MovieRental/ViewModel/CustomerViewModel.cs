using MovieRental.Commands;
using MovieRental.Model;
using MovieRental.View.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class CustomerViewModel : ViewModelBase {
    private readonly IDialogService _dialogService;

    protected Customer _customerModel;
    protected ObservableCollection<RentedMovieViewModel> _rentedMovies;

    public event Action? UpdateCustomerCompleted;

    private ICommand? _updateCustomer;
    public ICommand UpdateCustomer => _updateCustomer ??= new RelayCommand(UpdateCustomerExecute, CanUpdateCustomerExecute);

    private ICommand? _deleteCustomer;
    public ICommand DeleteCustomer => _deleteCustomer ??= new RelayCommand(DeleteCustomerExecute, CanDeleteCustomerExecute);

    public CustomerViewModel() {
        // TODO Might want to use IoC solution for that
        _dialogService = new DialogService();
        _customerModel = new Customer();
        _rentedMovies = new ObservableCollection<RentedMovieViewModel>();
    }

    public CustomerViewModel(Customer customerModel) {
        // TODO Might want to use IoC solution for that
        _dialogService = new DialogService();
        _customerModel = customerModel;
        _rentedMovies = new ObservableCollection<RentedMovieViewModel>(customerModel.RentedMovies.Select(e => new RentedMovieViewModel(e)));
    }

    internal void UpdateCustomerExecute() {
        DatabaseDao.UpdateCustomer(CustomerModel);
        UpdateCustomerCompleted?.Invoke();
    }

    internal bool CanUpdateCustomerExecute() {
        return true;
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
                // Trigger change on all properties
                OnPropertyChanged(string.Empty);
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
            OnPropertyChanged();
        }
    }

    public string FirstName {
        get => _customerModel.FirstName;
        set {
            _customerModel.FirstName = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FullName));
        }
    }

    public string LastName {
        get => _customerModel.LastName;
        set {
            _customerModel.LastName = value;
            OnPropertyChanged();
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
            OnPropertyChanged();
        }
    }

    public string Phone {
        get => _customerModel.Phone;
        set {
            _customerModel.Phone = value;
            OnPropertyChanged();
        }
    }
}
