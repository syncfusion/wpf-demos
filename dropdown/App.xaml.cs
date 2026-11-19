
using syncfusion.demoscommon.wpf;
using System.Windows;

namespace syncfusion.dropdowndemos.wpf
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
            var window = new MainWindow(new DropDownDemosViewModel());
            window.Show();
            base.OnStartup(e);
        }
    }
}
