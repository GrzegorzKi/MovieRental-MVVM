using System.Windows;

namespace MovieRental.View.Dialogs {
    public class DialogService : IDialogService {
        public bool Confirm(string message, string caption = "Confirm") {
            return MessageBox.Show(message, caption, MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }

        public void Show(string message, string caption = "") {
            MessageBox.Show(message, caption);
        }

        public void Success(string message, string caption = "") {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    }
}
