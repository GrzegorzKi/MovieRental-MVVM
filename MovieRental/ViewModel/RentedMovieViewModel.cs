using MovieRental.Model;
using MovieRental.View.Dialogs;
using System;

namespace MovieRental.ViewModel;

public class RentedMovieViewModel : ViewModelBase {
    // TODO Might want to use IoC solution for that
    private readonly IDialogService _dialogService = new DialogService();

    protected RentedMovie _rentedMovieModel;

    public RentedMovieViewModel(RentedMovie rentedMovieModel) {
        _rentedMovieModel = rentedMovieModel;
    }

    public RentedMovie RentedMovieModel {
        get => _rentedMovieModel;
        set {
            if (SetProperty(ref _rentedMovieModel, value)) {
                // Trigger change on all properties
                OnPropertyChanged(string.Empty);
            }
        }
    }

    public void ReturnMovieExecute() {
        var message = $"Return \"{MovieTitle}\"?\n\n" +
                $"Rented by {FirstName} {LastName}\n" +
                $"Rented on {DateIssued}";

        if (_dialogService.Confirm(message)) {
            DatabaseDao.ReturnRentedMovie(_rentedMovieModel);
        }
    }

    public int MovieId {
        get => _rentedMovieModel.MovieId;
    }

    public int CustomerId {
        get => _rentedMovieModel.CustomerId;
    }

    public string FirstName {
        get => _rentedMovieModel.Customer.FirstName;
    }

    public string LastName {
        get => _rentedMovieModel.Customer.LastName;
    }

    public string MovieTitle {
        get => _rentedMovieModel.Movie.Title;
    }

    public DateTime DateIssued {
        get => _rentedMovieModel.DateIssued;
    }

    public DateTime? DateReturned {
        get => _rentedMovieModel.DateReturned;
    }
}
