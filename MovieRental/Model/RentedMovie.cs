using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRental.Model;

[Table("RentedMovie")]
public class RentedMovie {
    public int MovieId { get; set; }
    public int CustomerId { get; set; }
    public DateTime DateIssued { get; set; }
    public DateTime? DateReturned { get; set; }

    public RentedMovie(int movieId, int customerId, DateTime issued, DateTime? returned) {
        MovieId = movieId;
        CustomerId = customerId;
        DateIssued = issued;
        DateReturned = returned;
    }
}
