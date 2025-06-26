#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
#if STORE
using System.Text.RegularExpressions;
using Syncfusion.SfSkinManager;
#endif

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

        SamplesViewModel dataContext;
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
            dataContext = new SamplesViewModel();
            Window windowToOpen = null;
#if STORE
            string demoID = string.Empty;
            string parameter = e.Args.Length > 0 ? e.Args[0] : null;
            try
            {
                if (parameter != null)
                {
                    string launchUri = parameter;
                    var match = Regex.Match(launchUri, @"demoId=([^&]+)");
                    demoID = match.Success ? match.Groups[1].Value : null;
                    if (demoID != null)
                    {
                        if (!demoID.Contains("-"))
                            windowToOpen = string.IsNullOrEmpty(demoID) ? null : TryLaunchDemoWindow(demoID, dataContext.ShowcaseDemos);
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorLogging.LogError("Product ShowCase\\" + demoID + "\\" + exception.Message + "\n" + exception.StackTrace + "\n" + exception.Source);
            }
#endif
#if !STORE
            windowToOpen = new MainWindow(dataContext);
            ShowWindow(windowToOpen);
#endif
#if STORE
            try
            {
                if (!string.IsNullOrEmpty(demoID) && demoID.Contains("-"))
                {
                    string[] parts = demoID.Split('-');
                    string string1 = parts[0];
                    string string2 = parts[1];

                    // Search through all ProductDemos
                    foreach (var product in dataContext.ProductDemos)
                    {
                        if (product.ToString().ToLower().Contains(string1.ToLower()))
                        {
                            foreach (var demos in product.Demos)
                            {
                                if (string.Equals(demos.DemoViewType.Name, string2, StringComparison.OrdinalIgnoreCase))
                                {
                                    if (demos.DemoLauchMode == DemoLauchMode.Window)
                                    {
                                        windowToOpen = TryLaunchDemoWindow(string2, product.Demos);
                                        windowToOpen.Title = demos.Title;
                                        windowToOpen.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                                    }
                                    else
                                    {
                                        dataContext.SelectedDemo = demos;
                                        dataContext.SelectedProduct = product;
                                        dataContext.NavigationButtonVisibility = Visibility.Collapsed;
                                    }
                                }
                            }
                        }
                    }

                    if (windowToOpen == null)
                    {
                        this.MainWindow = DemosNavigationService.MainWindow;
                        this.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        this.MainWindow.Show();
                    }
                    else
                    {
                        ShowWindow(windowToOpen);
                    }
                }
                else
                {
                    if (windowToOpen == null)
                    {
                        windowToOpen = new MainWindow(dataContext);
                    }
                    ShowWindow(windowToOpen);
                }
            }
            catch (Exception ex)
            {
                ErrorLogging.LogError("Product Sample\\" + dataContext.SelectedProduct.Product + "\\" + dataContext.SelectedSample.SampleName + "@@" + ex.Message + " StackTrace: " + ex.StackTrace + " Exception Source: " + ex.Source);
            }

#endif
            this.MainWindow.Closing += WindowToOpen_Closing;
            base.OnStartup(e);
        }

        private void WindowToOpen_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dataContext != null)
            {
                dataContext.Dispose();
                dataContext = null;
            }
            this.MainWindow.Closing -= WindowToOpen_Closing;
        }

        private void ShowWindow(Window windowToOpen)
        {
            this.MainWindow = windowToOpen;
            windowToOpen.Show();
        }
#if STORE
        private Window TryLaunchDemoWindow(string demoID, List<DemoInfo> demoList)
        {
            Window window = null;
            DemoInfo demoInfo = demoList
        .Where(p => p.DemoViewType.Name.ToLower().Equals(demoID.ToLower()))
        .FirstOrDefault();
            if (demoInfo.IsShowcase)
                window = demoInfo == null ? null : Activator.CreateInstance(demoInfo.DemoViewType) as Window;
            else
            {
                var constructorInfo = demoInfo.DemoViewType?.GetConstructors().FirstOrDefault(cinfo => cinfo.IsPublic && cinfo.GetParameters().Length == 1 && cinfo.GetParameters()[0].Name == "themename");
                if (demoInfo.ThemeMode != ThemeMode.None && constructorInfo != null)
                {
                    window = Activator.CreateInstance(demoInfo.DemoViewType,
                        demoInfo.ThemeMode == ThemeMode.Inherit ? dataContext.SelectedThemeName : DemoBrowserViewModel.DefaultThemeName) as Window;
                }
                else if (demoInfo.DemoViewType != null)
                {
                    window = Activator.CreateInstance(demoInfo.DemoViewType) as Window;
                    if (demoInfo.ThemeMode == ThemeMode.Inherit)
                    {
                        SfSkinManager.SetTheme(window, new Theme() { ThemeName = dataContext.SelectedThemeName });
                    }
                    else if (demoInfo.ThemeMode == ThemeMode.Default)
                    {
                        SfSkinManager.SetTheme(window, new Theme() { ThemeName = DemoBrowserViewModel.DefaultThemeName });
                    }
                }
            }
            return window;
        }
#endif
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (Application.Current.Windows.Count > 0 && (Application.Current.Windows[0].DataContext) != null)
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
            else
            {
                ErrorLogging.LogError("SampleBrowser\\" + "Common" + "\\" + "Error" + "@@" + e.Exception.Message +
                      " StackTrace: " + e.Exception.StackTrace + " Exception Source: " + e.Exception.Source);
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
