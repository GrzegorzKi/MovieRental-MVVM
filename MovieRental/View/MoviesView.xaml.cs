using MovieRental.View.Modals;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MovieRental.View;

public partial class MoviesView : UserControl {
    public MoviesView() {
        InitializeComponent();
    }

    private void AddMovie(object sender, RoutedEventArgs e) {
        var editModal = new EditCustomerWindow() {
            Owner = Window.GetWindow(this)
        };

        if (editModal.ShowDialog() == true) {
            ViewModel.refreshMovieList();
        }
    }

    private void OnKeyEnterEditMovie(object sender, KeyEventArgs e) {
        if (e.Key == Key.Enter) {
            EditMovie(sender, e);
        }
    }

    private void EditMovie(object sender, RoutedEventArgs e) {
        var editModal = new EditMovieWindow(ViewModel.SelectedMovie?.MovieModel) {
            Owner = Window.GetWindow(this)
        };

        if (editModal.ShowDialog() == true) {
            ViewModel.refreshMovieList();
        }
    }
}
