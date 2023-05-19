using MovieRental.Helpers;
using MovieRental.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class MovieCollectionViewModel : ViewModelBase {

    protected ICommand? _clearFilter;
    public ICommand ClearFilter => _clearFilter ??= new RelayCommand(OnClearFilter);

    protected WpfRangeObservableCollection<MovieViewModel> _movieList;
    public WpfRangeObservableCollection<MovieViewModel> MovieList {
        get => _movieList;
        set => SetProperty(ref _movieList, value);
    }
    protected CollectionViewSource _movieListView { get; }
    public ICollectionView MovieListView { get => _movieListView.View; }

    protected MovieViewModel? _selectedMovie;
    public MovieViewModel? SelectedMovie {
        get => _selectedMovie;
        set {
            if (SetProperty(ref _selectedMovie, value)) {
                SelectedRentedMovie = null;
                SelectedMovieRentalHistory = _selectedMovie?.RentedMovies ?? new ObservableCollection<RentedMovieViewModel>();
            }
        }
    }

    protected ObservableCollection<RentedMovieViewModel>? _selectedMovieRentalHistory;
    public ObservableCollection<RentedMovieViewModel>? SelectedMovieRentalHistory {
        get => _selectedMovieRentalHistory;
        set {
            if (SetProperty(ref _selectedMovieRentalHistory, value)) {
                _selectedMovieUnreturnedMoviesView.Source = SelectedMovieRentalHistory;
                OnPropertyChanged(nameof(SelectedMovieUnreturnedMovies));
            }
        }
    }

    protected CollectionViewSource _selectedMovieUnreturnedMoviesView;
    public ICollectionView SelectedMovieUnreturnedMovies {
        get => _selectedMovieUnreturnedMoviesView.View;
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
                MovieListView.Refresh();
            }
        }
    }

    public MovieCollectionViewModel()
        : this(DatabaseDao.GetMovieViewModels()) { }

    internal MovieCollectionViewModel(IEnumerable<Movie> movies)
        : this(movies.Select(e => new MovieViewModel(e))) { }

    internal MovieCollectionViewModel(IEnumerable<MovieViewModel> movieVMs) {
        _movieList = new WpfRangeObservableCollection<MovieViewModel>(movieVMs);
        _movieListView = new CollectionViewSource {
            Source = MovieList
        };
        _movieListView.Filter += ApplyFilter;
        _selectedMovieUnreturnedMoviesView = new CollectionViewSource() {
            Source = SelectedMovieRentalHistory
        };
        _selectedMovieUnreturnedMoviesView.Filter += FilterUnreturnedMovie;
    }

    public async void RefreshMovieList() {
        var collection = await DatabaseDao.GetMovieViewModelsAsync();
        MovieList.ReplaceRange(collection);
    }

    internal void ApplyFilter(object sender, FilterEventArgs e) {
        MovieViewModel movieVM = (MovieViewModel) e.Item;

        if (string.IsNullOrWhiteSpace(Filter) || Filter.Length == 0) {
            e.Accepted = true;
        } else {
            e.Accepted = movieVM.Title.ToLower().Contains(Filter.ToLower());
        }
    }

    public void OnClearFilter() {
        Filter = string.Empty;
    }

    internal void FilterUnreturnedMovie(object sender, FilterEventArgs e) {
        RentedMovieViewModel movieVM = (RentedMovieViewModel) e.Item;
        e.Accepted = (movieVM.DateReturned == null);
    }
}
