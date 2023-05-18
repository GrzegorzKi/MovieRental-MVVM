using System.Windows;
using System.Windows.Controls;

namespace MovieRental.View.Controls;

public partial class MovieIssuePopupPanel : UserControl {
    public event RoutedEventHandler? CancelRaised;

    public MovieIssuePopupPanel() {
        InitializeComponent();
    }

    public string Text {
        get => (string) GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(nameof(Text), typeof(string), typeof(MovieIssuePopupPanel), new PropertyMetadata(null));


    private void CancelButton_Click(object sender, RoutedEventArgs e) {
        CancelRaised?.Invoke(this, e);
    }
}
