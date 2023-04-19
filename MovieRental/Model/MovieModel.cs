namespace MovieRental.Model;

public class MovieModel {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Year { get; set; }
    public string Genre { get; set; }
    public string Plot { get; set; }
    public int Copies { get; set; }

    public MovieModel(int id, string title, string year, string genre, string plot, int copies) {
        Id = id;
        Title = title;
        Year = year;
        Genre = genre;
        Plot = plot;
        Copies = copies;
    }
}
