using syncfusion.demoscommon.wpf;
using syncfusion.olapgriddemos.wpf;
using System.Windows;

namespace syncfusion.olapgriddemos.wpf
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
            var window = new MainWindow(new OlapGridDemosViewModel());
            window.Show();
            base.OnStartup(e);
        }
    }
}
