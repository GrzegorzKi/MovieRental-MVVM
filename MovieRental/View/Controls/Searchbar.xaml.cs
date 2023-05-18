using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MovieRental.View.Controls;

public partial class Searchbar : UserControl {
    public Searchbar() {
        InitializeComponent();
    }

    public string FilterText {
        get => (string) GetValue(FilterTextProperty);
        set => SetValue(FilterTextProperty, value);
    }

    public static readonly DependencyProperty FilterTextProperty =
        DependencyProperty.Register(nameof(FilterText), typeof(string), typeof(Searchbar), new PropertyMetadata(null));

    public ICommand ClearFilterCommand {
        get => (ICommand) GetValue(ClearFilterCommandProperty);
        set => SetValue(ClearFilterCommandProperty, value);
    }

    public static readonly DependencyProperty ClearFilterCommandProperty =
        DependencyProperty.Register(nameof(ClearFilterCommand), typeof(ICommand), typeof(Searchbar), new PropertyMetadata(null));
}
