using MovieRental.Helpers;
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
    public ICommand ClearFilter => _clearFilter ??= new RelayCommand(ClearFilterExecute);

    protected WpfRangeObservableCollection<CustomerViewModel> _customerList;
    internal WpfRangeObservableCollection<CustomerViewModel> CustomerList {
        get => _customerList;
        set => SetProperty(ref _customerList, value);
    }
    protected CollectionViewSource _customerListView;
    public ICollectionView CustomerListView { get => _customerListView.View; }

    protected CustomerViewModel? _selectedCustomer;
    public CustomerViewModel? SelectedCustomer {
        get => _selectedCustomer;
        set {
            if (SetProperty(ref _selectedCustomer, value)) {
                SelectedRentedMovie = null;
                SelectedCustomerRentalHistory = _selectedCustomer?.RentedMovies ?? new ObservableCollection<RentedMovieViewModel>();
            }
        }
    }

    protected ObservableCollection<RentedMovieViewModel>? _selectedCustomerRentalHistory;
    public ObservableCollection<RentedMovieViewModel>? SelectedCustomerRentalHistory {
        get => _selectedCustomerRentalHistory;
        set {
            if (SetProperty(ref _selectedCustomerRentalHistory, value)) {
                _selectedCustomerUnreturnedMoviesView.Source = SelectedCustomerRentalHistory;
                OnPropertyChanged(nameof(SelectedCustomerUnreturnedMovies));
            }
        }
    }

    protected CollectionViewSource _selectedCustomerUnreturnedMoviesView;
    public ICollectionView SelectedCustomerUnreturnedMovies {
        get => _selectedCustomerUnreturnedMoviesView.View;
    }

    protected RentedMovieViewModel? _selectedRentedMovie;
    public RentedMovieViewModel? SelectedRentedMovie {
        get => _selectedRentedMovie;
        set => SetProperty(ref _selectedRentedMovie, value);
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


    public CustomerCollectionViewModel()
        : this(DatabaseDao.GetCustomerViewModels()) {
        DatabaseDao.DatabaseChanged += RefreshCustomerList;
    }

    internal CustomerCollectionViewModel(IEnumerable<Customer> customers)
        : this(customers.Select(e => new CustomerViewModel(e))) { }

    internal CustomerCollectionViewModel(IEnumerable<CustomerViewModel> customerVMs) {
        _customerList = new WpfRangeObservableCollection<CustomerViewModel>(customerVMs);
        _customerListView = new CollectionViewSource() {
            Source = CustomerList
        };
        _customerListView.Filter += ApplyFilter;
        _selectedCustomerUnreturnedMoviesView = new CollectionViewSource() {
            Source = SelectedCustomerRentalHistory
        };
        _selectedCustomerUnreturnedMoviesView.Filter += FilterUnreturnedMovie;
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

    internal void FilterUnreturnedMovie(object sender, FilterEventArgs e) {
        RentedMovieViewModel movieVM = (RentedMovieViewModel) e.Item;
        e.Accepted = (movieVM.DateReturned == null);
    }
}
