using syncfusion.demoscommon.wpf;
using System.Reflection;
using System.Windows;
using Syncfusion.Licensing;
using System.IO;
using System.Text;

namespace syncfusion.avatarviewdemo.wpf
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
            var window = new MainWindow(new AvatarViewDemoViewModel());
            window.Show();
            base.OnStartup(e);
        }
    }
}
