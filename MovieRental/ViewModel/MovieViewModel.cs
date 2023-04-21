using MovieRental.Commands;
using MovieRental.Model;
using MovieRental.View.Dialogs;
using System;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class MovieViewModel : ViewModelBase {
    private readonly IDialogService _dialogService;

    protected MovieModel _movieModel;

    public event Action? UpdateMovieCompleted;

    private ICommand? _updateMovie;
    public ICommand UpdateMovie => _updateMovie ??= new RelayCommand(UpdateMovieExecute, CanUpdateMovieExecute);

    private ICommand? _deleteMovie;
    public ICommand DeleteMovie => _deleteMovie ??= new RelayCommand(DeleteMovieExecute, CanDeleteMovieExecute);

    public MovieViewModel() {
        // TODO Might want to use IoC solution for that
        _dialogService = new DialogService();
        _movieModel = new MovieModel();
    }

    internal void UpdateMovieExecute() {
        if (Id == null) {
            // TODO Insert model into database
        } else {
            // TODO Update model in database
        }
        UpdateMovieCompleted?.Invoke();
    }

    internal bool CanUpdateMovieExecute() {
        return true;
    }

    internal void DeleteMovieExecute() {
        if (_dialogService.Confirm($"Delete movie {Title}?")) {
            // TODO Delete model in database
            UpdateMovieCompleted?.Invoke();
        }
    }

    internal bool CanDeleteMovieExecute() {
        return Id != null;
    }


    public MovieModel MovieModel {
        get => _movieModel;
        set => SetProperty(ref _movieModel, value);
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
