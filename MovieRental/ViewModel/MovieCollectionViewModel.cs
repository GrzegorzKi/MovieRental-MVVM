using MovieRental.Helpers;
using MovieRental.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class MovieCollectionViewModel : ViewModelBase {

    protected ICommand? _clearFilter;
    public ICommand ClearFilter => _clearFilter ??= new RelayCommand(OnClearFilter);

    protected ObservableCollection<MovieViewModel> _movieList;
    public ObservableCollection<MovieViewModel> MovieList {
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
                SelectedMovieRentalHistory = _selectedMovie?.RentedMovies ?? new ObservableCollection<RentedMovieViewModel>();
            }
        }
    }

    protected ObservableCollection<RentedMovieViewModel>? _selectedMovieRentalHistory;
    public ObservableCollection<RentedMovieViewModel>? SelectedMovieRentalHistory {
        get => _selectedMovieRentalHistory;
        set => SetProperty(ref _selectedMovieRentalHistory, value);
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

    public MovieCollectionViewModel() {
        var collection = DatabaseDao.GetMovieViewModels();
        _movieList = new ObservableCollection<MovieViewModel>(collection);
        _movieListView = new CollectionViewSource {
            Source = MovieList
        };
        _movieListView.Filter += ApplyFilter;
    }

    internal MovieCollectionViewModel(IEnumerable<Movie> movies) {
        _movieList = new ObservableCollection<MovieViewModel>(movies.Select(e => new MovieViewModel(e)));
        _movieListView = new CollectionViewSource {
            Source = MovieList
        };
        _movieListView.Filter += ApplyFilter;
    }

    public async void RefreshMovieList() {
        var collection = await DatabaseDao.GetMovieViewModelsAsync();
        MovieList.Clear();
        foreach (var elem in collection) {
            MovieList.Add(elem);
        }
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
}
