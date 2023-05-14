using MovieRental.Model;
using MovieRental.ViewModel;

namespace MovieRental.DesignTimeViewModel;

public class SampleMovieViewModel : MovieViewModel {

    public SampleMovieViewModel() : base(new Movie(1, "The Shawshank Redemption", "1994", "crime, drama", "", 3)) {}

    public SampleMovieViewModel(Movie movieModel) : base(movieModel) {}
}
