#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
