using MovieRental.Model;
using System.Windows;

namespace MovieRental.View.Modals;

public partial class EditMovieWindow {

    public EditMovieWindow(MovieModel? movie = null) {
        InitializeComponent();

        if (movie != null) {
            Title = "Edit movie";
            btnDelete.Visibility = Visibility.Visible;

            ViewModel.MovieModel = new MovieModel(movie);
        } else {
            Title = "Add movie";
        }

        ViewModel.UpdateMovieCompleted += Close;
    }
}
