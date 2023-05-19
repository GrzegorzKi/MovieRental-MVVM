using MovieRental.Helpers;
using MovieRental.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class RentedMovieCollectionViewModel : ViewModelBase {

    protected ICommand? _clearFilter;
    public ICommand ClearFilter => _clearFilter ??= new RelayCommand(ClearFilterExecute);

    protected WpfRangeObservableCollection<RentedMovieViewModel> _rentedMoviesList;
    public WpfRangeObservableCollection<RentedMovieViewModel> RentedMoviesList {
        get => _rentedMoviesList;
        set => SetProperty(ref _rentedMoviesList, value);
    }

    protected CollectionViewSource _rentedMoviesListView;
    public ICollectionView RentedMoviesListView { get => _rentedMoviesListView.View; }

    protected CollectionViewSource _unreturnedMoviesView;
    public ICollectionView UnreturnedMovies { get => _unreturnedMoviesView.View; }

    protected RentedMovieViewModel? _selectedUnreturnedRentedMovie;
    public RentedMovieViewModel? SelectedUnreturnedRentedMovie {
        get => _selectedUnreturnedRentedMovie;
        set => SetProperty(ref _selectedUnreturnedRentedMovie, value);
    }

    protected string _filter = string.Empty;
    public string Filter {
        get => _filter;
        set {
            if (SetProperty(ref _filter, value)) {
                RentedMoviesListView.Refresh();
                UnreturnedMovies.Refresh();
            }
        }
    }


    public RentedMovieCollectionViewModel()
        : this(DatabaseDao.GetRentedMovieViewModels()) {
        DatabaseDao.DatabaseChanged += RefreshRentedMoviesList;
    }

    internal RentedMovieCollectionViewModel(IEnumerable<RentedMovie> customers)
        : this(customers.Select(e => new RentedMovieViewModel(e))) { }

    internal RentedMovieCollectionViewModel(IEnumerable<RentedMovieViewModel> customerVMs) {
        _rentedMoviesList = new WpfRangeObservableCollection<RentedMovieViewModel>(customerVMs);

        _rentedMoviesListView = new CollectionViewSource() {
            Source = RentedMoviesList
        };
        _rentedMoviesListView.Filter += ApplyFilter;

        _unreturnedMoviesView = new CollectionViewSource() {
            Source = RentedMoviesList
        };
        _unreturnedMoviesView.Filter += FilterUnreturnedMovie;
        _unreturnedMoviesView.Filter += ApplyFilter;

        UnreturnedMovies.Refresh();
    }

    public async void RefreshRentedMoviesList() {
        var collection = await DatabaseDao.GetRentedMovieViewModelsAsync();

        RentedMoviesList.ReplaceRange(collection);
    }


    internal void ApplyFilter(object sender, FilterEventArgs e) {
        RentedMovieViewModel movieVM = (RentedMovieViewModel) e.Item;

        if (string.IsNullOrWhiteSpace(Filter) || Filter.Length == 0) {
            e.Accepted &= true;
        } else {
            e.Accepted &= movieVM.MovieTitle.ToLower().Contains(Filter.ToLower());
        }
    }

    public void ClearFilterExecute() {
        Filter = string.Empty;
    }

    internal void FilterUnreturnedMovie(object sender, FilterEventArgs e) {
        RentedMovieViewModel movieVM = (RentedMovieViewModel) e.Item;
        e.Accepted &= (movieVM.DateReturned == null);
    }
}
