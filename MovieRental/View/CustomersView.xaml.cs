using MovieRental.Model;
using MovieRental.View.Modals;
using MovieRental.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MovieRental.View;

public partial class CustomersView : UserControl {
    public CustomersView() {
        InitializeComponent();
        DatabaseDao.DatabaseChanged += ViewModel.RefreshCustomerList;
    }

    private void AddCustomer(object sender, RoutedEventArgs e) {
        var editModal = new EditCustomerWindow() {
            Owner = Window.GetWindow(this)
        };

        editModal.ShowDialog();
    }

    private void EditCustomer(object sender, RoutedEventArgs e) {
        var editModal = new EditCustomerWindow(ViewModel.SelectedCustomer?.CustomerModel) {
            Owner = Window.GetWindow(this)
        };

        editModal.ShowDialog();
    }

    private void OnKeyEnterEditCustomer(object sender, KeyEventArgs e) {
        if (e.Key == Key.Enter) {
            EditCustomer(sender, e);
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

    private void OnKeyEnterSwitchToMovie(object sender, KeyEventArgs e) {
        if (e.Key == Key.Enter) {
            SwitchToMovie(sender, e);
        }
    }

    private void DeleteCustomer(object sender, RoutedEventArgs e) {
        var selectedCustomer = ViewModel.SelectedCustomer;
        if (selectedCustomer != null && selectedCustomer.DeleteCustomer.CanExecute(null)) {
            selectedCustomer.DeleteCustomer.Execute(null);
        }
    }
}
