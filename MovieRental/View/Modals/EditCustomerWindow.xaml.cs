using MovieRental.Model;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace MovieRental.View.Modals;

public partial class EditCustomerWindow {

    public EditCustomerWindow(Customer? customer = null) {
        InitializeComponent();
        PreviewMouseDown += LoseFocus;

        if (customer != null) {
            Title = "Edit customer";
            btnDelete.Visibility = Visibility.Visible;

            ViewModel.CustomerModel = new Customer(customer);
            // ViewModel.Id = ViewModel.CustomerModel.Id;
        } else {
            Title = "Add customer";
        }

        ViewModel.UpdateCustomerCompleted += OnClose;
    }

    private void OnClose() {
        if (ComponentDispatcher.IsThreadModal) {
            try {
                DialogResult = true;
            } catch { /* Actually is in non-modal mode - ignore exception */ }
        }
        Close();
    }


    private void LoseFocus(object sender, MouseButtonEventArgs e) {
        var element = sender as FrameworkElement;
        if (element == null) {
            return;
        }

        FocusManager.SetFocusedElement(FocusManager.GetFocusScope(element), null);
        Keyboard.ClearFocus();
    }
}
