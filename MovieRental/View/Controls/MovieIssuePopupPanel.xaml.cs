using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieRental.View.Controls;

public partial class MovieIssuePopupPanel : UserControl {
    public event EventHandler? CancelRaised;

    public MovieIssuePopupPanel() {
        InitializeComponent();
    }

    public string Text {
        get => (string) GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(MovieIssuePopupPanel), new PropertyMetadata(null));


    private void CancelButton_Click(object sender, RoutedEventArgs e) {
        CancelRaised?.Invoke(this, e);
    }
}
