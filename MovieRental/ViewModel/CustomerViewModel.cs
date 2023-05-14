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
        using var context = new AppDbContext();

        if (Id == null) {
            context.Customers.Add(_customerModel);
            context.SaveChanges();
        } else {
            var customer = context.Customers.Find(_customerModel.Id);
            if (customer == null)
                return;
            context.Entry(customer).CurrentValues.SetValues(_customerModel);
            context.SaveChanges();
        }
        UpdateCustomerCompleted?.Invoke();
    }

    internal bool CanUpdateCustomerExecute() {
        return true;
    }

    internal void DeleteCustomerExecute() {
        if (_dialogService.Confirm($"Delete customer {FirstName} {LastName}?")) {
            using var context = new AppDbContext();

            var customer = context.Customers.Find(_customerModel.Id);
            if (customer == null)
                return;
            context.Customers.Remove(customer);
            context.SaveChanges();
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
        }
    }

    public string LastName {
        get => _customerModel.LastName;
        set {
            _customerModel.LastName = value;
            OnPropertyChanged();
        }
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
