using MovieRental.View.Modals;
using MovieRental.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MovieRental.View;

public partial class MoviesView : UserControl {
    public MoviesView() {
        InitializeComponent();
    }

    private void AddMovie(object sender, RoutedEventArgs e) {
        var editModal = new EditMovieWindow() {
            Owner = Window.GetWindow(this)
        };

        editModal.ShowDialog();
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

        editModal.ShowDialog();
    }

    private void SwitchToCustomer(object sender, RoutedEventArgs e) {
        if (sender is ListBoxItem item && item.DataContext is RentedMovieViewModel rentedMovieVM) {
            var command = item.Tag as ICommand;
            if (command != null && command.CanExecute(rentedMovieVM.CustomerId)) {
                command.Execute(rentedMovieVM.CustomerId);
            }
        }
    }

    private void OnKeyEnterSwitchToCustomer(object sender, KeyEventArgs e) {
        if (e.Key == Key.Enter) {
            SwitchToCustomer(sender, e);
        }
    }


    private GridLength _rememberWidth = GridLength.Auto;

    private void GridCollapsed(object sender, RoutedEventArgs e) {
        if (sender is Grid grid) {
            _rememberWidth = grid.ColumnDefinitions[2].Width;
            grid.ColumnDefinitions[2].Width = GridLength.Auto;
        }
    }

    private void GridExpanded(object sender, RoutedEventArgs e) {
        if (sender is Grid grid) {
            grid.ColumnDefinitions[2].Width = _rememberWidth;
        }
    }
}
