using MovieRental.Commands;
using MovieRental.Model;
using MovieRental.View;
using MovieRental.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace MovieRental;

public partial class MainWindow : Window {

    private ICommand? _switchToCustomerTab;
    public ICommand SwitchToCustomerTab => _switchToCustomerTab ??= new RelayCommand<CustomerViewModel>(SwitchToCustomerTabExecute);

    private ICommand? _switchToMovieTab;
    public ICommand SwitchToMovieTab => _switchToMovieTab ??= new RelayCommand<MovieViewModel>(SwitchToMovieTabExecute);

    public MainWindow() {
        InitializeComponent();
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
}
