#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Windows;
using Syncfusion.Licensing;
using System.Reflection;
using System.IO;
using System.Text;

namespace syncfusion.samplebrowser.wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Directory.SetCurrentDirectory(exeDir);
            AssemblyResolver.Init();
            LicenseKeyLocator.FindandRegisterLicenseKey();
            this.DispatcherUnhandledException += App_DispatcherUnhandledException1;
        }

        private void App_DispatcherUnhandledException1(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            ErrorLogging.LogError(e.Exception.Message + "\n" + e.Exception.StackTrace);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
            SplashScreen splashScreen = new SplashScreen(ResourceAssembly, "wpf-splash-screen.png");
            var window = new MainWindow(new SamplesViewModel());
            this.MainWindow = window;
            splashScreen.Show(true, true);
            window.Show();
            base.OnStartup(e);
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            ErrorWindow.Show(e.Exception.Message + "\n" + e.Exception.StackTrace);
            e.Handled = true;
        }
    }
}
