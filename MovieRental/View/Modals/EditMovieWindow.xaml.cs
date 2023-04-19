using MovieRental.Model;
using System;
using System.Windows;

namespace MovieRental.View.Modals;

public partial class EditMovieWindow {

    private MovieModel? _movieModel;

    public EditMovieWindow(MovieModel? movie = null) {
        InitializeComponent();

        if (movie != null) {
            Title = "Edit movie";
            btnDelete.Visibility = Visibility.Visible;

            _movieModel = movie;

            txtId.Text = movie.Id.ToString();
            txtTitle.Text = movie.Title;
            txtYear.Text = movie.Year;
            txtGenre.Text = movie.Genre;
            txtPlot.Text = movie.Plot;
            txtCopies.Text = movie.Copies.ToString();
        } else {
            Title = "Add movie";
        }
    }

    private void btnSave_Click(object sender, RoutedEventArgs e) {
        try {
            if (_movieModel != null) {
                // TODO: Update model in database
            } else {
                MovieModel newMovie = new MovieModel(
                    Convert.ToInt32(txtId.Text),
                    txtTitle.Text,
                    txtYear.Text,
                    txtGenre.Text,
                    txtPlot.Text,
                    Convert.ToInt32(txtCopies.Text)
                );

                // TODO: Insert model to database
            }

            Close();
        } catch (Exception exception) {
            Console.WriteLine($"Error updating database:\n{exception}");
            MessageBox.Show(this, exception.Message);
        }
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e) {
        Close();
    }

    private void btnDelete_Click(object sender, RoutedEventArgs e) {
        if (_movieModel == null) {
            // TODO Handle deleting the model
        }
    }
}
