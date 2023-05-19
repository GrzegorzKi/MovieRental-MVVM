using MovieRental.Helpers;
using MovieRental.Model;
using MovieRental.View.Dialogs;
using System;
using System.Windows.Input;

namespace MovieRental.ViewModel;

public class RentedMovieViewModel : ViewModelBase {
    // TODO Might want to use IoC solution for that
    private readonly IDialogService _dialogService = new DialogService();

    protected ICommand? _returnMovieCommand;
    public ICommand ReturnMovieCommand => _returnMovieCommand ??=
        new RelayCommand(ReturnMovieExecute, CanReturnMovie);

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

    public bool CanReturnMovie() {
        return DateReturned == null;
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

    public string DatesInfo {
        get => DateReturned != null
            ? string.Format("From {0} to {1}", DateIssued.ToShortDateString(), DateReturned?.ToShortDateString())
            : string.Format("From {0} (unreturned)", DateIssued.ToShortDateString());
    }
}
