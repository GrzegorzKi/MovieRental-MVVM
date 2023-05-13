using MovieRental.Model;
using System.Windows;
using System.Windows.Input;

namespace MovieRental;

public partial class MainWindow : Window {
    public static readonly ApplicationDataContext _context = new ApplicationDataContext();

    public MainWindow() {
        InitializeComponent();
    }
}
