using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MovieRental;

public partial class App : Application {

    protected override void OnStartup(StartupEventArgs e) {
        base.OnStartup(e);

        // https://stackoverflow.com/a/39348804
        ToolTipService.ShowOnDisabledProperty.OverrideMetadata(
            typeof(FrameworkElement),
            new FrameworkPropertyMetadata(true));
    }
}
