using MovieRental.Helpers;
using MovieRental.Model;
using MovieRental.View.Dialogs;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class CustomerCollectionViewModel : ViewModelBase {
    // TODO Might want to use IoC solution for that
    private readonly IDialogService _dialogService = new DialogService();

    protected ICommand? _clearFilter;
    public ICommand ClearFilter => _clearFilter ??= new RelayCommand(ClearFilterExecute);

    protected ICommand? _returnMovie;
    public ICommand ReturnMovie => _returnMovie ??=
        new RelayCommand<RentedMovieViewModel>(ReturnMovieExecute, CanReturnMovie);

    protected WpfRangeObservableCollection<CustomerViewModel> _customerList;
    public WpfRangeObservableCollection<CustomerViewModel> CustomerList {
        get => _customerList;
        set => SetProperty(ref _customerList, value);
    }
    protected CollectionViewSource _customerListView { get; }
    public ICollectionView CustomerListView { get => _customerListView.View; }

    protected CustomerViewModel? _selectedCustomer;
    public CustomerViewModel? SelectedCustomer {
        get => _selectedCustomer;
        set {
            if (SetProperty(ref _selectedCustomer, value)) {
                SelectedCustomerRentalHistory = _selectedCustomer?.RentedMovies ?? new ObservableCollection<RentedMovieViewModel>();
            }
        }
    }

    protected ObservableCollection<RentedMovieViewModel>? _selectedCustomerRentalHistory;
    public ObservableCollection<RentedMovieViewModel>? SelectedCustomerRentalHistory {
        get => _selectedCustomerRentalHistory;
        set => SetProperty(ref _selectedCustomerRentalHistory, value);
    }

    // TODO Perform filtering logic to show only unreturned movies
    public List<RentedMovieViewModel> SelectedCustomerUnreturnedMovies { get; set; }

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
        _customerList = new WpfRangeObservableCollection<CustomerViewModel>(collection);
        _customerListView = new CollectionViewSource() {
            Source = CustomerList
        };
        _customerListView.Filter += ApplyFilter;
    }

    internal CustomerCollectionViewModel(IEnumerable<Customer> customers) {
        _customerList = new WpfRangeObservableCollection<CustomerViewModel>(customers.Select(e => new CustomerViewModel(e)));
        _customerListView = new CollectionViewSource() {
            Source = CustomerList
        };
        _customerListView.Filter += ApplyFilter;
    }

    public async void RefreshCustomerList() {
        var collection = await DatabaseDao.GetCustomerViewModelsAsync();

        CustomerList.ReplaceRange(collection);
    }

    internal void ApplyFilter(object sender, FilterEventArgs e) {
        CustomerViewModel movieVM = (CustomerViewModel) e.Item;

        if (string.IsNullOrWhiteSpace(Filter) || Filter.Length == 0) {
            e.Accepted = true;
        } else {
            e.Accepted = movieVM.FullName.ToLower().Contains(Filter.ToLower());
        }
    }

    public void ClearFilterExecute() {
        Filter = string.Empty;
    }

    public bool CanReturnMovie([NotNullWhen(true)] RentedMovieViewModel? rentedMovieVM) {
        return rentedMovieVM != null && rentedMovieVM.DateReturned == null;
    }

    public void ReturnMovieExecute(RentedMovieViewModel? rentedMovieVM) {
        if (CanReturnMovie(rentedMovieVM)) {
            rentedMovieVM.ReturnMovieExecute();
        }
    }
}
