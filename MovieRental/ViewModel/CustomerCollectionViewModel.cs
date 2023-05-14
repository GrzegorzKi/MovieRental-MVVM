using MovieRental.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MovieRental.ViewModel;

public class CustomerCollectionViewModel : ViewModelBase {
    protected ObservableCollection<CustomerViewModel> _customerList;
    public ObservableCollection<CustomerViewModel> CustomerList {
        get => _customerList;
        set => SetProperty(ref _customerList, value);
    }

    protected CustomerViewModel? _selectedCustomer;
    public CustomerViewModel? SelectedCustomer {
        get => _selectedCustomer;
        set => SetProperty(ref _selectedCustomer, value);
    }

    public CustomerCollectionViewModel() {
        _customerList = new ObservableCollection<CustomerViewModel>(MainWindow._context.Customers
            .Select(e => new CustomerViewModel(e)));
    }

    internal CustomerCollectionViewModel(IEnumerable<Customer> customers) {
        _customerList = new ObservableCollection<CustomerViewModel>(customers.Select(e => new CustomerViewModel(e)));
    }

    public void refreshCustomerList() {
        CustomerList = new ObservableCollection<CustomerViewModel>(MainWindow._context.Customers
            .Select(e => new CustomerViewModel(e)));
    }
}
