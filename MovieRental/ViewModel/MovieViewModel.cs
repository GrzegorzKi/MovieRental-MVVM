using MovieRental.Commands;
using MovieRental.Model;
using MovieRental.View.Dialogs;
using System;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class MovieViewModel : ViewModelBase {
    private readonly IDialogService _dialogService;

    protected Movie _movieModel;

    public event Action? UpdateMovieCompleted;

    private ICommand? _updateMovie;
    public ICommand UpdateMovie => _updateMovie ??= new RelayCommand(UpdateMovieExecute, CanUpdateMovieExecute);

    private ICommand? _deleteMovie;
    public ICommand DeleteMovie => _deleteMovie ??= new RelayCommand(DeleteMovieExecute, CanDeleteMovieExecute);

    public MovieViewModel() {
        // TODO Might want to use IoC solution for that
        _dialogService = new DialogService();
        _movieModel = new Movie();
    }

    public MovieViewModel(Movie movieModel) {
        // TODO Might want to use IoC solution for that
        _dialogService = new DialogService();
        _movieModel = movieModel;
    }

    internal void UpdateMovieExecute() {
        if (Id == null) {
            MainWindow._context.Movies.Add(_movieModel);
            MainWindow._context.SaveChanges();
        } else {
            var movie = MainWindow._context.Movies.Find(_movieModel.Id);
            if (movie == null)
                return;
            MainWindow._context.Entry(movie).CurrentValues.SetValues(_movieModel);
            MainWindow._context.SaveChanges();
        }
        UpdateMovieCompleted?.Invoke();
    }

    internal bool CanUpdateMovieExecute() {
        return true;
    }

    internal void DeleteMovieExecute() {
        if (_dialogService.Confirm($"Delete movie {Title}?")) {
            var movie = MainWindow._context.Movies.Find(_movieModel.Id);
            if (movie == null)
                return;
            MainWindow._context.Movies.Remove(movie);
            MainWindow._context.SaveChanges();
            UpdateMovieCompleted?.Invoke();
        }
    }

    internal bool CanDeleteMovieExecute() {
        return Id != null;
    }


    public Movie MovieModel {
        get => _movieModel;
        set {
            SetProperty(ref _movieModel, value);
            // Trigger change on all properties (see docs for details)
            OnPropertyChanged(string.Empty);
        }
    }

    public int? Id {
        get => _movieModel.Id;
        set {
            _movieModel.Id = value;
            OnPropertyChanged();
        }
    }

    public string Title {
        get => _movieModel.Title;
        set {
            _movieModel.Title = value;
            OnPropertyChanged();
        }
    }
    public string Year {
        get => _movieModel.Year;
        set {
            _movieModel.Year = value;
            OnPropertyChanged();
        }
    }
    public string Genre {
        get => _movieModel.Genre;
        set {
            _movieModel.Genre = value;
            OnPropertyChanged();
        }
    }
    public string Plot {
        get => _movieModel.Plot;
        set {
            _movieModel.Plot = value;
            OnPropertyChanged();
        }
    }
    public int Copies {
        get => _movieModel.Copies;
        set {
            _movieModel.Copies = value;
            OnPropertyChanged();
        }
    }
}
