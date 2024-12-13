#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using System;
using System.Collections.Generic;
using System.Linq;

namespace syncfusion.samplebrowser.wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
#if STORE
            string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Directory.SetCurrentDirectory(exeDir);
#else
            if (!DemoBrowserViewModel.IsStoreApp)
            {
                AssemblyResolver.Init();
                LicenseKeyLocator.FindandRegisterLicenseKey();
            }

            this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
#endif        
		}

        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreen splashScreen = new SplashScreen(ResourceAssembly, "wpf-splash-screen.png");
            splashScreen.Show(true, true);
#if TEST
            DemoBrowserViewModel.CanAutomate = true;
#endif
#if STORE
            DemoBrowserViewModel.IsStoreApp = true;
            UpdateStoreAppDirectory();
#endif
            var window = new MainWindow(new SamplesViewModel());
            this.MainWindow = window;
            window.Show();
            base.OnStartup(e);
        }


        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if ((Application.Current.Windows[0].DataContext) != null)
            {
                var demos = (Application.Current.Windows[0].DataContext as DemoBrowserViewModel);
                if (demos.SelectedProduct != null && demos.SelectedSample != null)
                {
                    ErrorLogging.LogError("Product Sample\\" + demos.SelectedProduct.Product + "\\" + demos.SelectedSample.SampleName + "@@" + e.Exception.Message + " StackTrace: " + e.Exception.StackTrace + " Exception Source: " + e.Exception.Source);
                }
                else if (demos.SelectedShowcaseSample != null)
                {
                    ErrorLogging.LogError("Product ShowCase\\" + demos.SelectedShowcaseSample.SampleName + "\\" + demos.SelectedShowcaseSample.SampleName + "@@" + e.Exception.Message + " StackTrace: " + e.Exception.StackTrace + " Exception Source: " + e.Exception.Source);
                }
                else
                {
                    ErrorLogging.LogError("SampleBrowser\\" + "Common" + "\\" + "Error" + "@@" + e.Exception.Message +
                          " StackTrace: " + e.Exception.StackTrace + " Exception Source: " + e.Exception.Source);
                }
            }

            e.Handled = true;
        }

        /// <inheritdoc/>
        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
#if TEST
                AutomationMail.SendBindingErrorReport();
#endif

#if STORE
                var outputDirectory = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                Directory.SetCurrentDirectory(outputDirectory);
                string roamingPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string targetPath = $"{roamingPath}\\Syncfusion WPF Demos";
                if (Directory.Exists(targetPath))
                {
                    Directory.Delete(targetPath, true);
                }
#endif
            }
            catch { }
            base.OnExit(e);
        }

#region Store Application

#if STORE
        /// <summary>
        /// Helps to update the Store application current directory.
        /// </summary>
        private void UpdateStoreAppDirectory()
        {
            try
            {
                string roamingPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string targetPath = $"{roamingPath}\\Syncfusion WPF Demos";
                if (Directory.Exists(targetPath))
                {
                    Directory.Delete(targetPath, true);
                }
                Directory.CreateDirectory(targetPath);
                var outputDirectory = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                DirectoryInfo sourceDirectory = new DirectoryInfo(outputDirectory);
                DirectoryInfo targetDirectory = new DirectoryInfo(targetPath);
                CopyAll(sourceDirectory, targetDirectory);
                Directory.SetCurrentDirectory(targetPath);
                string path = targetPath + "//ReadMe.txt";
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
                using (StreamWriter fileWriter = File.AppendText(path))
                {
                    fileWriter.Write("The files are auto-generated whenever Syncfusion WPF demos are launched and will get deleted when the application gets closed." + "\n");
                    fileWriter.Close();
                }
            }
            catch { }
        }

        /// <summary>
        /// Helps to copy data files from outputDirectory to AppData directory.
        /// </summary>
        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);
            var excludedList = new[] { ".dll", ".exe" };
            var enumerfiles = FilterFiles(source.FullName, excludedList);
            var files = new List<FileInfo>();
            foreach (var file in enumerfiles)
            {
                if (!file.Contains("syncfusion.samplebrowser.wpf.exe") )
                    files.Add(new FileInfo(file));
            }
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }

            foreach (DirectoryInfo sourceSubDirectory in source.GetDirectories())
            {
                DirectoryInfo targetSubDirectory = target.CreateSubdirectory(sourceSubDirectory.Name);
                CopyAll(sourceSubDirectory, targetSubDirectory);
            }
        }

        /// <summary>
        /// Helps to filter files based on filter list
        /// </summary>
        private IEnumerable<string> FilterFiles(string path, params string[] exts)
        {
            return Directory.GetFiles(path).Where(file => !exts.Any(x => !file.Contains("pdfium") && file.EndsWith(x, StringComparison.OrdinalIgnoreCase)));
        }
#endif
#endregion
    }
}
