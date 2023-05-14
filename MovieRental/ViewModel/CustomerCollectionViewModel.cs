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
        var collection = DatabaseDao.GetCustomerViewModels();
        _customerList = new ObservableCollection<CustomerViewModel>(collection);
    }

    internal CustomerCollectionViewModel(IEnumerable<Customer> customers) {
        _customerList = new ObservableCollection<CustomerViewModel>(customers.Select(e => new CustomerViewModel(e)));
    }

    public async void RefreshCustomerList() {
        var collection = await DatabaseDao.GetCustomerViewModelsAsync();
        CustomerList = new ObservableCollection<CustomerViewModel>(collection);
    }
}
