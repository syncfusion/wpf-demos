#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using Syncfusion.Windows;
using Syncfusion.Licensing;
using System.Reflection;
using System.IO;
using System.Text;

namespace PortfolioAnalyzer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Window win;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ShowWindow();
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
            win.Close();
        }
     
        /// <summary>
        /// Shows the window.
        /// </summary>
        void ShowWindow()
        {
            //ResourceDictionary rs = new ResourceDictionary();
            //rs.Source = new Uri("/PortfolioAnalyzer.Infrastructure;component/Brushes.xaml", UriKind.RelativeOrAbsolute);
            //DrawingBrush brush = rs["blackbackground"] as DrawingBrush;
            //win.AllowsTransparency = true;
            win = new Window();
            Label label = new Label();
            label.Content = "Please Wait...Loading Modules...";
            label.FontWeight = FontWeights.Bold;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.FontSize = 14;
            label.Foreground = Brushes.Black;
           
            label.FontFamily = new FontFamily("Verdana");
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.BorderBrush = Brushes.Gray;
            win.BorderThickness = new Thickness(0.8);
            win.WindowStyle = WindowStyle.None;
            //win.Background = brush;
            win.Height = 75;
            win.Width = 309;
            win.ShowInTaskbar = false;
            win.Topmost = true;
            win.Content = label;
            win.Effect = new DropShadowEffect() { BlurRadius = 1, ShadowDepth = 180, Color = Colors.Black };
            WindowChrome.SetWindowChrome(win, new WindowChrome() { UseAeroCaptionButtons = false });
            win.Show();
        }
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

            string rootPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().CodeBase.Replace(@"file:///", ""));

            for (int n = 0; n < levelsToCheck; n++)
            {
                string fileDataPath = System.IO.Path.Combine(rootPath, filePath);
                if (System.IO.File.Exists(fileDataPath))
                    return File.ReadAllText(fileDataPath, Encoding.UTF8);
                rootPath = Directory.GetParent(rootPath).FullName;
            }
            return string.Empty;
        }
    }
}
