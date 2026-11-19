using syncfusion.demoscommon.wpf;
using System.Windows;

namespace syncfusion.olapchartdemos.wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>Initializes the application</summary>
        public App()
        {
            LicenseKeyLocator.FindandRegisterLicenseKey();
        }

        /// <inheritdoc/>
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new MainWindow(new OlapChartDemosViewModel());
            window.Show();
            base.OnStartup(e);
        }
    }
}
