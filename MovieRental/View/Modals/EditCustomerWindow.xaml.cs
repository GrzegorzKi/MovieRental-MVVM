using MovieRental.Model;
using System.Windows;

namespace MovieRental.View.Modals;

public partial class EditCustomerWindow : Window {

    public EditCustomerWindow(CustomerModel? customer = null) {
        InitializeComponent();

        if (customer != null) {
            Title = "Edit customer";
            btnDelete.Visibility = Visibility.Visible;

            ViewModel.CustomerModel = new CustomerModel(customer);
        } else {
            Title = "Add customer";
        }

        ViewModel.UpdateCustomerCompleted += Close;
    }
}
