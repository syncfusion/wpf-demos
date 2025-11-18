#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Licensing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace syncfusion.expenseanalysis.wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the App class.
        /// </summary>
        public App()
        {
            string culture = "en-US";
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(culture);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(culture);

            //Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(
                        CultureInfo.CurrentCulture.IetfLanguageTag)));
            LicenseKeyLocator.FindandRegisterLicenseKey();
        }
        
        /// <summary>
        /// Raises the <see cref="Application.Startup"/> event. This method is responsible for creating and displaying the main application window.
        /// </summary>
        /// <param name="e">A <see cref="StartupEventArgs"/> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = Activator.CreateInstance(typeof(ExpenseAnalysisDemo)) as Window;
            window.Show();
            base.OnStartup(e);
        }
    } 

    /// <summary>
    /// A  helper class to locate and register the Syncfusion license key.
    /// </summary>
    public static class LicenseKeyLocator
    {
        /// <summary>
        /// Finds the license key from a file and registers it with the Syncfusion license provider.
        /// </summary>
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
