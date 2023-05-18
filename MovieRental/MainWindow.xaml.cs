using MovieRental.View;
using System.Linq;
using System.Windows;

namespace MovieRental;

public partial class MainWindow : Window {

    public MainWindow() {
        InitializeComponent();
        ViewModel.CustomerTabSwitchRequested += SwitchToCustomerTabExecute;
        ViewModel.MovieTabSwitchRequested += SwitchToMovieTabExecute;
        MovieIssuePopup.CancelRaised += ResetRentalIssue;
    }

    internal void SwitchToCustomerTabExecute(int? customerID) {
        CustomersTab.Focus();
        var listBox = CustomersView.CustomersListBox;

        if (customerID != null) {
            var list = CustomersView.ViewModel.CustomerList;
            var targetVM = list.First(e => e.Id == customerID);

            var index = listBox.Items.IndexOf(targetVM);

            if (index >= 0) {
                listBox.SelectedIndex = index;
                listBox.ScrollIntoView(listBox.SelectedItem);
            }
        }

        listBox.Focus();
    }

    internal void SwitchToMovieTabExecute(int? movieID) {
        MoviesTab.Focus();
        var listBox = MoviesView.MoviesListBox;

        if (movieID != null) {
            var list = MoviesView.ViewModel.MovieList;
            var targetVM = list.First(e => e.Id == movieID);

            var index = listBox.Items.IndexOf(targetVM);
            if (index >= 0) {
                listBox.SelectedIndex = index;
                listBox.ScrollIntoView(listBox.SelectedItem);
            }
        }

        listBox.Focus();
    }

    internal void ResetRentalIssue(object? sender, RoutedEventArgs e) {
        ViewModel.ResetRentalIssue();
    }
}
