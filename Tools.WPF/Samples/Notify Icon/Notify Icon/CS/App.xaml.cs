using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Syncfusion.Licensing;

namespace NotifyIcon_2008
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
