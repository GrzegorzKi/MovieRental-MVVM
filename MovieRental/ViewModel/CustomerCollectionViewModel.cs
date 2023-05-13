using System.Collections.ObjectModel;
using System.Linq;

namespace MovieRental.ViewModel;

public class CustomerCollectionViewModel : ViewModelBase {
    private ObservableCollection<CustomerViewModel> _customerList;
    public ObservableCollection<CustomerViewModel> CustomerList {
        get => _customerList;
        set {
            _customerList = value;
            OnPropertyChanged();
        }
    }

    private CustomerViewModel? _selectedCustomer;
    public CustomerViewModel? SelectedCustomer {
        get => _selectedCustomer;
        set => SetProperty(ref _selectedCustomer, value);
    }

    public CustomerCollectionViewModel() {
        _customerList = new ObservableCollection<CustomerViewModel>(MainWindow._context.Customers
            .Select(e => new CustomerViewModel(e)));
    }

    public void refreshCustomerList() {
        CustomerList = new ObservableCollection<CustomerViewModel>(MainWindow._context.Customers
            .Select(e => new CustomerViewModel(e)));
    }
}
