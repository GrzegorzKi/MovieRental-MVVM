using MovieRental.Commands;
using MovieRental.Model;
using MovieRental.View.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class MovieViewModel : ViewModelBase {
    private readonly IDialogService _dialogService;

    protected Movie _movieModel;
    protected ObservableCollection<RentedMovieViewModel> _rentedMovies;

    public event Action? UpdateMovieCompleted;

    private ICommand? _updateMovie;
    public ICommand UpdateMovie => _updateMovie ??= new RelayCommand(UpdateMovieExecute, CanUpdateMovieExecute);

    private ICommand? _deleteMovie;
    public ICommand DeleteMovie => _deleteMovie ??= new RelayCommand(DeleteMovieExecute, CanDeleteMovieExecute);

    public MovieViewModel() {
        // TODO Might want to use IoC solution for that
        _dialogService = new DialogService();
        _movieModel = new Movie();
        _rentedMovies = new ObservableCollection<RentedMovieViewModel>();
    }

    public MovieViewModel(Movie movieModel) {
        // TODO Might want to use IoC solution for that
        _dialogService = new DialogService();
        _movieModel = movieModel;
        _rentedMovies = new ObservableCollection<RentedMovieViewModel>(movieModel.RentedMovies.Select(e => new RentedMovieViewModel(e)));
    }

    internal void UpdateMovieExecute() {
        DatabaseDao.UpdateMovie(MovieModel);
        UpdateMovieCompleted?.Invoke();
    }

    internal bool CanUpdateMovieExecute() {
        return true;
    }

    internal void DeleteMovieExecute() {
        var message = $"Delete movie {Title}?";
        if (RentedMovies.Count > 0) {
            message += "\nWARNING: Movie might be currently rented - make sure all copies got returned!";
        }

        if (_dialogService.Confirm(message)) {
            DatabaseDao.DeleteMovie(MovieModel);
            UpdateMovieCompleted?.Invoke();
        }
    }

    internal bool CanDeleteMovieExecute() {
        return Id != null;
    }


    public Movie MovieModel {
        get => _movieModel;
        set {
            if (SetProperty(ref _movieModel, value)) {
                _rentedMovies = new ObservableCollection<RentedMovieViewModel>(_movieModel.RentedMovies.Select(e => new RentedMovieViewModel(e)));
                // Trigger change on all properties
                OnPropertyChanged(string.Empty);
            }
        }
    }

    public ObservableCollection<RentedMovieViewModel> RentedMovies {
        get => _rentedMovies;
        set => SetProperty(ref _rentedMovies, value);
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
