using MovieRental.Helpers;
using MovieRental.Model;
using MovieRental.Validations;
using MovieRental.View.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class MovieViewModel : ViewModelBase {
    // TODO Might want to use IoC solution for that
    private readonly IDialogService _dialogService = new DialogService();

    protected Movie _movieModel;
    protected ObservableCollection<RentedMovieViewModel> _rentedMovies;

    public event Action? UpdateMovieCompleted;

    private ICommand? _updateMovie;
    public ICommand UpdateMovie => _updateMovie ??= new RelayCommand(UpdateMovieExecute);

    private ICommand? _deleteMovie;
    public ICommand DeleteMovie => _deleteMovie ??= new RelayCommand(DeleteMovieExecute, CanDeleteMovieExecute);

    public MovieViewModel() {
        _movieModel = new Movie();
        _rentedMovies = new ObservableCollection<RentedMovieViewModel>();
    }

    public MovieViewModel(Movie movieModel) {
        _movieModel = movieModel;
        _rentedMovies = new ObservableCollection<RentedMovieViewModel>(movieModel.RentedMovies.Select(e => new RentedMovieViewModel(e)));
    }

    internal void UpdateMovieExecute() {
        Validate();
        if (HasErrors) return;

        DatabaseDao.UpdateMovie(MovieModel);
        UpdateMovieCompleted?.Invoke();
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
                OnAllPropertiesChangedValidate();
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
            OnPropertyChangedValidate(value);
        }
    }

    [Required]
    public string Title {
        get => _movieModel.Title;
        set {
            _movieModel.Title = value;
            OnPropertyChangedValidate(value);
        }
    }

    [Required]
    public string Year {
        get => _movieModel.Year;
        set {
            _movieModel.Year = value;
            OnPropertyChangedValidate(value);
        }
    }

    public string Genre {
        get => _movieModel.Genre;
        set {
            _movieModel.Genre = value;
            OnPropertyChangedValidate(value);
        }
    }

    public string Plot {
        get => _movieModel.Plot;
        set {
            _movieModel.Plot = value;
            OnPropertyChangedValidate(value);
        }
    }

    [Required]
    [PositiveInteger]
    public int Copies {
        get => _movieModel.Copies;
        set {
            _movieModel.Copies = value;
            OnPropertyChangedValidate(value);
        }
    }
}
