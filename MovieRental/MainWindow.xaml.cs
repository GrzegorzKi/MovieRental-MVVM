using MovieRental.View;
using MovieRental.ViewModel;
using System.Windows;

namespace MovieRental;

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
        ViewModel.CustomerTabSwitchRequested += SwitchToCustomerTabExecute;
        ViewModel.MovieTabSwitchRequested += SwitchToMovieTabExecute;
        MovieIssuePopup.CancelRaised += ResetRentalIssue;
    }

    internal void SwitchToCustomerTabExecute(CustomerViewModel? customerVM) {
        CustomersTab.Focus();

        if (customerVM != null) {
            var listBox = CustomersView.CustomersListBox;

            var index = listBox.Items.IndexOf(customerVM);
            if (index >= 0) {
                listBox.SelectedIndex = index;
                listBox.ScrollIntoView(listBox.SelectedItem);
            }
        }
    }

    internal void SwitchToMovieTabExecute(MovieViewModel? movieVM) {
        MoviesTab.Focus();

        if (movieVM != null) {
            var listBox = MoviesView.MoviesListBox;

            var index = listBox.Items.IndexOf(movieVM);
            if (index >= 0) {
                listBox.SelectedIndex = index;
                listBox.ScrollIntoView(listBox.SelectedItem);
            }
        }
    }

    internal void ResetRentalIssue(object? sender, RoutedEventArgs e) {
        ViewModel.ResetRentalIssue();
    }
}
