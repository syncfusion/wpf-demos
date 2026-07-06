using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.sparklinedemos.wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>Initializes the application and registers the license key.</summary>
        public App()
        {
            LicenseKeyLocator.FindandRegisterLicenseKey();
        }

        /// <inheritdoc/>
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new MainWindow(new SparklineDemosViewModel());
            window.Show();
            base.OnStartup(e);
        }
    }
}
