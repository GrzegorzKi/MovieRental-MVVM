using MovieRental.Model;
using System;
using System.Windows;

namespace MovieRental.View.Modals;

public partial class EditCustomerWindow : Window {

    private CustomerModel? _customerModel;

    public EditCustomerWindow(CustomerModel? customer = null) {
        InitializeComponent();

        if (customer != null) {
            Title = "Edit customer";
            btnDelete.Visibility = Visibility.Visible;

            _customerModel = customer;

            txtId.Text = customer.Id.ToString();
            txtFName.Text = customer.FirstName;
            txtLName.Text = customer.LastName;
            txtAddress.Text = customer.Address;
            txtPhone.Text = customer.Phone;
        } else {
            Title = "Add customer";
        }
    }

    private void btnSave_Click(object sender, RoutedEventArgs e) {
        try {
            if (_customerModel != null) {
                // TODO: Update model in database
            } else {
                CustomerModel newCustomer = new CustomerModel(
                    Convert.ToInt32(txtId.Text),
                    txtFName.Text,
                    txtLName.Text,
                    txtAddress.Text,
                    txtPhone.Text
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
        if (_customerModel == null) {
            // TODO Handle deleting the model
        }
    }
}
