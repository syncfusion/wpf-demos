#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.portfolioanalyzerdemo.wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shell;

namespace syncfusion.portfolioanalyzerdemo.wpfapplication
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
            win = new Window();
            Label label = new Label();
            label.Content = "Please Wait...Loading Modules...";
            label.FontWeight = FontWeights.Bold;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.FontSize = 14;
            label.Foreground = System.Windows.Media.Brushes.Black;

            label.FontFamily = new FontFamily("Verdana");
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.BorderBrush = Brushes.Gray;
            win.BorderThickness = new Thickness(0.8);
            win.WindowStyle = WindowStyle.None;
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
        }
    }
}
