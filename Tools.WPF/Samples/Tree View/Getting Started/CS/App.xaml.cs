using System.Windows;
using Syncfusion.Licensing;

namespace TreeViewAdvConfigurationDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            SyncfusionLicenseProvider.RegisterLicense(DemoCommon.FindLicenseKey());
        }

    }
}
