using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRental.Model;

[Table("Movie")]
public class Movie {
    [Key]
    public int? Id { get; set; }
    public string Title { get; set; }
    public string Year { get; set; }
    public string Genre { get; set; }
    public string Plot { get; set; }
    public int Copies { get; set; }

    public virtual ICollection<RentedMovie> RentedMovies { get; } = new List<RentedMovie>();

    [Timestamp]
    public long? RowVersion { get; set; }

    public Movie()
        : this(null, "", "", "", "", 1) { }

    public Movie(string title, string year, string genre, string plot, int copies)
        : this(null, title, year, genre, plot, copies) { }

    public Movie(int? id, string title, string year, string genre, string plot, int copies) {
        Id = id;
        Title = title;
        Year = year;
        Genre = genre;
        Plot = plot;
        Copies = copies;
    }

    public Movie(Movie copy) {
        Id = copy.Id;
        Title = copy.Title;
        Year = copy.Year;
        Genre = copy.Genre;
        Plot = copy.Plot;
        Copies = copy.Copies;
        RentedMovies = new List<RentedMovie>(copy.RentedMovies);
    }
}
