using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRental.Model;

[Table("RentedMovie")]
[PrimaryKey(nameof(MovieId), nameof(CustomerId))]
public class RentedMovie {
    public int MovieId { get; set; }
    public int CustomerId { get; set; }

    [ForeignKey("MovieId")]
    public Movie Movie { get; set; } = null!;
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; } = null!;

    [DataType(DataType.DateTime)]
    public DateTime DateIssued { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime? DateReturned { get; set; }

    public RentedMovie(int movieId, int customerId, DateTime dateIssued, DateTime? dateReturned) {
        MovieId = movieId;
        CustomerId = customerId;
        DateIssued = dateIssued;
        DateReturned = dateReturned;
    }

    public RentedMovie(Movie movie, Customer customer, DateTime dateIssued, DateTime? dateReturned) {
        if (movie.Id == null) {
            throw new ArgumentNullException("movie.Id");
        }
        if (customer.Id == null) {
            throw new ArgumentNullException("customer.Id");
        }

        Movie = movie;
        Customer = customer;
        MovieId = (int) movie.Id;
        CustomerId = (int) customer.Id;
        DateIssued = dateIssued;
        DateReturned = dateReturned;
    }
}
