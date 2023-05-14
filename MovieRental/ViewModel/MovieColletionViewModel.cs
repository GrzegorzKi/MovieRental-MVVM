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
        var collection = DatabaseDao.GetMovieViewModels();
        _movieList = new ObservableCollection<MovieViewModel>(collection);
    }

    internal MovieColletionViewModel(IEnumerable<Movie> movies) {
        _movieList = new ObservableCollection<MovieViewModel>(movies.Select(e => new MovieViewModel(e)));
    }

    public async void RefreshMovieList() {
        var collection = await DatabaseDao.GetMovieViewModelsAsync();
        MovieList = new ObservableCollection<MovieViewModel>(collection);
    }
}
