using syncfusion.demoscommon.wpf;
using System.Windows;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            LicenseKeyLocator.FindandRegisterLicenseKey();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new MainWindow(new NavigationDemosViewModel());
            window.Show();
            base.OnStartup(e);
        }
    }
}
