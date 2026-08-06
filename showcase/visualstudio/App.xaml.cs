using Syncfusion.Licensing;
using Syncfusion.SfSkinManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.visualstudiodemo.wpf.app
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Telemetry.Telemetry.Disable();
            LicenseKeyLocator.FindandRegisterLicenseKey();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            SfSkinManager.ApplyThemeAsDefaultStyle = true;
            var window = Activator.CreateInstance(typeof(VisualStudioDemo)) as Window;
            window.Show();
            base.OnStartup(e);
        }
    }

    public static class LicenseKeyLocator
    {
        public static void FindandRegisterLicenseKey()
        {
            SyncfusionLicenseProvider.RegisterLicense(FindLicenseKey());
        }

        /// <summary>
        /// Helper method to find a syncfusion license key.
        /// </summary>
        /// <returns>License Key</returns>
        private static string FindLicenseKey()
        {
            int levelsToCheck = 12;
            string filePath = @"SyncfusionLicense.txt";

            string rootPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Replace(@"file:///", ""));

            if (string.IsNullOrEmpty(rootPath) || string.IsNullOrEmpty(filePath))
            {
                return string.Empty;
            }

            for (int n = 0; n < levelsToCheck; n++)
            {
                string fileDataPath = System.IO.Path.Combine(rootPath, filePath);
                if (System.IO.File.Exists(fileDataPath))
                    return File.ReadAllText(fileDataPath, Encoding.UTF8);
                DirectoryInfo rootDirectory = Directory.GetParent(rootPath);
                if (rootDirectory == null)
                    break;
                rootPath = rootDirectory.FullName;
            }
            return string.Empty;
        }
    }
}
