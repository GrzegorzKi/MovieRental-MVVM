using MovieRental.Commands;
using MovieRental.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class CustomerCollectionViewModel : ViewModelBase {

    protected ICommand? _clearFilter;
    public ICommand ClearFilter => _clearFilter ??= new RelayCommand(OnClearFilter);

    protected ObservableCollection<CustomerViewModel> _customerList;
    protected ObservableCollection<CustomerViewModel> CustomerList {
        get => _customerList;
        set => SetProperty(ref _customerList, value);
    }
    protected CollectionViewSource _customerListView { get; }
    public ICollectionView CustomerListView { get => _customerListView.View; }

    protected CustomerViewModel? _selectedCustomer;
    public CustomerViewModel? SelectedCustomer {
        get => _selectedCustomer;
        set => SetProperty(ref _selectedCustomer, value);
    }

    protected string _filter = string.Empty;
    public string Filter {
        get => _filter;
        set {
            if (SetProperty(ref _filter, value)) {
                CustomerListView.Refresh();
            }
        }
    }

    public CustomerCollectionViewModel() {
        var collection = DatabaseDao.GetCustomerViewModels();
        _customerList = new ObservableCollection<CustomerViewModel>(collection);
        _customerListView = new CollectionViewSource() {
            Source = CustomerList
        };
        _customerListView.Filter += ApplyFilter;
    }

    internal CustomerCollectionViewModel(IEnumerable<Customer> customers) {
        _customerList = new ObservableCollection<CustomerViewModel>(customers.Select(e => new CustomerViewModel(e)));
        _customerListView = new CollectionViewSource() {
            Source = CustomerList
        };
        _customerListView.Filter += ApplyFilter;
    }

    public async void RefreshCustomerList() {
        var collection = await DatabaseDao.GetCustomerViewModelsAsync();
        CustomerList.Clear();
        foreach (var elem in collection) {
            CustomerList.Add(elem);
        }
    }

    internal void ApplyFilter(object sender, FilterEventArgs e) {
        CustomerViewModel movieVM = (CustomerViewModel) e.Item;

        if (string.IsNullOrWhiteSpace(Filter) || Filter.Length == 0) {
            e.Accepted = true;
        } else {
            e.Accepted = movieVM.FullName.ToLower().Contains(Filter.ToLower());
        }
    }

    public void OnClearFilter() {
        Filter = string.Empty;
    }
}
