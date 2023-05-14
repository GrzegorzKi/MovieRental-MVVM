using MovieRental.Commands;
using MovieRental.Model;
using MovieRental.View.Dialogs;
using System;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class CustomerViewModel : ViewModelBase {
    private readonly IDialogService _dialogService;

    protected Customer _customerModel;

    public event Action? UpdateCustomerCompleted;

    private ICommand? _updateCustomer;
    public ICommand UpdateCustomer => _updateCustomer ??= new RelayCommand(UpdateCustomerExecute, CanUpdateCustomerExecute);

    private ICommand? _deleteCustomer;
    public ICommand DeleteCustomer => _deleteCustomer ??= new RelayCommand(DeleteCustomerExecute, CanDeleteCustomerExecute);

    public CustomerViewModel() {
        // TODO Might want to use IoC solution for that
        _dialogService = new DialogService();
        _customerModel = new Customer();
    }

    public CustomerViewModel(Customer customerModel) {
        // TODO Might want to use IoC solution for that
        _dialogService = new DialogService();
        _customerModel = customerModel;
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
            SetProperty(ref _customerModel, value);
            // Trigger change on all properties (see docs for details)
            OnPropertyChanged(string.Empty);
        }
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
