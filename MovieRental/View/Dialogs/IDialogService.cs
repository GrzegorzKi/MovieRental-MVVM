using System.Windows;

namespace MovieRental.View.Dialogs;

public interface IDialogService {
    public bool Confirm(string message, string caption = "Confirm");
    public void Show(string message, string caption = "");
    public void Success(string message, string caption = "");
}
