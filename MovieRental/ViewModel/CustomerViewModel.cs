using MovieRental.Commands;
using MovieRental.Model;
using MovieRental.View.Dialogs;
using System;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class CustomerViewModel : ViewModelBase {
    private readonly IDialogService _dialogService;

    protected CustomerModel _customerModel;

    public event Action? UpdateCustomerCompleted;

    private ICommand? _updateCustomer;
    public ICommand UpdateCustomer => _updateCustomer ??= new RelayCommand(UpdateCustomerExecute, CanUpdateCustomerExecute);

    private ICommand? _deleteCustomer;
    public ICommand DeleteCustomer => _deleteCustomer ??= new RelayCommand(DeleteCustomerExecute, CanDeleteCustomerExecute);

    public CustomerViewModel() {
        // TODO Might want to use IoC solution for that
        _dialogService = new DialogService();
        _customerModel = new CustomerModel();
    }

    internal void UpdateCustomerExecute() {
        if (Id == null) {
            // TODO Insert model into database
        } else {
            // TODO Update model in database
        }
        UpdateCustomerCompleted?.Invoke();
    }

    internal bool CanUpdateCustomerExecute() {
        return true;
    }

    internal void DeleteCustomerExecute() {
        if (_dialogService.Confirm($"Delete customer {FirstName} {LastName}?")) {
            // TODO Delete model in database
            UpdateCustomerCompleted?.Invoke();
        }
    }

    internal bool CanDeleteCustomerExecute() {
        return Id != null;
    }


    public CustomerModel CustomerModel {
        get => _customerModel;
        set => SetProperty(ref _customerModel, value);
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
