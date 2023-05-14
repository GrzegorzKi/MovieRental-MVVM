using MovieRental.Model;
using System;

namespace MovieRental.ViewModel;

public class RentedMovieViewModel : ViewModelBase {
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
