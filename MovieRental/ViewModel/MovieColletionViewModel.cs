using MovieRental.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MovieRental.ViewModel;

public class MovieColletionViewModel : ViewModelBase {
    protected ObservableCollection<MovieViewModel> _movieList;
    public ObservableCollection<MovieViewModel> MovieList {
        get => _movieList;
        set => SetProperty(ref _movieList, value);
    }

    protected MovieViewModel? _selectedMovie;
    public MovieViewModel? SelectedMovie {
        get => _selectedMovie;
        set => SetProperty(ref _selectedMovie, value);
    }

    public MovieColletionViewModel() {
        _movieList = new ObservableCollection<MovieViewModel>(MainWindow._context.Movies
            .Select(e => new MovieViewModel(e)));
    }

    internal MovieColletionViewModel(IEnumerable<Movie> movies) {
        _movieList = new ObservableCollection<MovieViewModel>(movies.Select(e => new MovieViewModel(e)));
    }

    public void refreshMovieList() {
        //
        // TODO: It would be advisable to modify collection itself
        // in respond to database changes (add/update/remove) than refreshing
        // the whole collection (e.g. with Dispatcher)
        // See: https://stackoverflow.com/a/17996744
        //
        MovieList = new ObservableCollection<MovieViewModel>(MainWindow._context.Movies
            .Select(e => new MovieViewModel(e)));
    }
}
