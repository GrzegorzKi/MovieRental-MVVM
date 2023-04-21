namespace MovieRental.View.Dialogs;

public interface IDialogService {
    bool Confirm(string message, string caption = "Confirm");
}
