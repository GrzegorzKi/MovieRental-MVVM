using System;

namespace MovieRental.Model;

public class RentedMovieModel {
    public int MovieId { get; set; }
    public int CustomerId { get; set; }
    public DateTime DateIssued { get; set; }
    public DateTime? DateReturned { get; set; }

    public RentedMovieModel(int movieId, int customerId, DateTime issued, DateTime? returned) {
        MovieId = movieId;
        CustomerId = customerId;
        DateIssued = issued;
        DateReturned = returned;
    }
}
