using MovieRental.Model;
using MovieRental.View.Modals;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MovieRental.View;

public partial class CustomersView : UserControl {
    public CustomersView() {
        InitializeComponent();
        DatabaseDao.CustomersChanged += ViewModel.RefreshCustomerList;
    }

    private void AddCustomer(object sender, RoutedEventArgs e) {
        var editModal = new EditCustomerWindow() {
            Owner = Window.GetWindow(this)
        };

        editModal.ShowDialog();
    }

    private void OnKeyEnterEditCustomer(object sender, KeyEventArgs e) {
        if (e.Key == Key.Enter) {
            EditCustomer(sender, e);
        }
    }

    private void EditCustomer(object sender, RoutedEventArgs e) {
        var editModal = new EditCustomerWindow(ViewModel.SelectedCustomer?.CustomerModel) {
            Owner = Window.GetWindow(this)
        };

        editModal.ShowDialog();
    }
}
