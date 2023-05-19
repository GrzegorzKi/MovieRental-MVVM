using MovieRental.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MovieRental.View;

public partial class UnreturnedView : UserControl {
    public UnreturnedView() {
        InitializeComponent();
    }

    private void SwitchToCustomer(object sender, RoutedEventArgs e) {
        if (sender is ListBoxItem item && item.DataContext is RentedMovieViewModel rentedMovieVM) {
            var command = item.Tag as ICommand;
            if (command != null && command.CanExecute(rentedMovieVM.CustomerId)) {
                command.Execute(rentedMovieVM.CustomerId);
            }
        }
    }

    private void SwitchToMovie(object sender, RoutedEventArgs e) {
        if (sender is ListBoxItem item && item.DataContext is RentedMovieViewModel rentedMovieVM) {
            var command = item.Tag as ICommand;
            if (command != null && command.CanExecute(rentedMovieVM.MovieId)) {
                command.Execute(rentedMovieVM.MovieId);
            }
        }
    }
}
