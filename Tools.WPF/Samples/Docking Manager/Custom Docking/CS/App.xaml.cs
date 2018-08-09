using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using Syncfusion.Licensing;

namespace utilsOuterDocking
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

    public static class DemoCommon
    {
        /// <summary>
        /// Helper method to find a syncfusion license key from the Common folder
        /// </summary>
        /// <param name="fileName">File name of the syncfusion license key</param>
        /// <returns></returns>
        public static string FindLicenseKey()
        {
            int levelsToCheck = 12;
            string filePath = @"Common\SyncfusionLicense.txt";

            string rootPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().CodeBase.Replace(@"file:///", ""));

            for (int n = 0; n < levelsToCheck; n++)
            {
                string fileDataPath = System.IO.Path.Combine(rootPath, filePath);
                if (System.IO.File.Exists(fileDataPath))
                    return System.IO.File.ReadAllText(fileDataPath, System.Text.Encoding.UTF8);
                rootPath = System.IO.Directory.GetParent(rootPath).FullName;
            }
            return string.Empty;
        }
    }
}