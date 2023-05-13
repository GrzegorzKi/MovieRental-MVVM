using System.Collections.ObjectModel;
using System.Linq;

namespace MovieRental.ViewModel;

public class MovieColletionViewModel : ViewModelBase {
    private ObservableCollection<MovieViewModel> _movieList;
    public ObservableCollection<MovieViewModel> MovieList {
        get => _movieList;
        set {
            _movieList = value;
            OnPropertyChanged();
        }
    }

    private MovieViewModel? _selectedMovie;
    public MovieViewModel? SelectedMovie {
        get => _selectedMovie;
        set => SetProperty(ref _selectedMovie, value);
    }

    public MovieColletionViewModel() {
        _movieList = new ObservableCollection<MovieViewModel>(MainWindow._context.Movies
            .Select(e => new MovieViewModel(e)));
    }

    public void refreshMovieList() {
        MovieList = new ObservableCollection<MovieViewModel>(MainWindow._context.Movies
            .Select(e => new MovieViewModel(e)));
    }
}
