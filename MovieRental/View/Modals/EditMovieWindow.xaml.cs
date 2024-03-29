using MovieRental.Model;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace MovieRental.View.Modals;

public partial class EditMovieWindow {

    public EditMovieWindow(Movie? movie = null) {
        InitializeComponent();
        PreviewMouseDown += LoseFocus;

        if (movie != null) {
            Title = "Edit movie";
            btnDelete.Visibility = Visibility.Visible;

            ViewModel.MovieModel = new Movie(movie);
        } else {
            Title = "Add movie";
        }

        ViewModel.UpdateMovieCompleted += OnClose;
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
