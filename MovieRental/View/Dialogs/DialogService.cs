using System.Windows;

namespace MovieRental.View.Dialogs {
    public class DialogService : IDialogService {
        public bool Confirm(string message, string caption = "Confirm") {
            return MessageBox.Show(message, caption, MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }
    }
}
