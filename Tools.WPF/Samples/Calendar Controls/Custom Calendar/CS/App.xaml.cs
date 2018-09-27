using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using Syncfusion.Licensing;

namespace LookAndFeel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : System.Windows.Application
    {
        public App()
        {
            SyncfusionLicenseProvider.RegisterLicense(DemoCommon.FindLicenseKey());
        }
    }
}