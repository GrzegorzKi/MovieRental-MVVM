using MovieRental.Model;
using MovieRental.ViewModel;

namespace MovieRental.DesignTimeViewModel;

public class SampleMovieViewModel : MovieViewModel {

    public SampleMovieViewModel() : base(new Model.Movie(1,"The Shawshank Redemption","1994","crime, drama","Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion.",-1)) {
        Validate();
    }
}
