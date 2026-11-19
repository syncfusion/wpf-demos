using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.SfToastNotification;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.notificationdemos.wpf
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
            string aumid = "ToastNotificationDemo.App";
            string displayName = "ToastNotificationDemo";
            WindowsToastBootstrapper.RemoveShortcutOnUnload = true;
            WindowsToastBootstrapper.Initialize(aumid, displayName);
            var window = new MainWindow(new NotificationDemosViewModel());
            window.Show();
            base.OnStartup(e);
        }
    }
}
