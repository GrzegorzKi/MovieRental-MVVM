using System.Net;

namespace MovieRental.Model;

public class MovieModel {
    public int? Id { get; set; }
    public string Title { get; set; }
    public string Year { get; set; }
    public string Genre { get; set; }
    public string Plot { get; set; }
    public int Copies { get; set; }

    public MovieModel()
        : this(null, "", "", "", "", 1) { }

    public MovieModel(string title, string year, string genre, string plot, int copies)
        : this(null, title, year, genre, plot, copies) { }

    public MovieModel(int? id, string title, string year, string genre, string plot, int copies) {
        Id = id;
        Title = title;
        Year = year;
        Genre = genre;
        Plot = plot;
        Copies = copies;
    }

    public MovieModel(MovieModel copy) {
        Id = copy.Id;
        Title = copy.Title;
        Year = copy.Year;
        Genre = copy.Genre;
        Plot = copy.Plot;
        Copies = copy.Copies;
    }
}
