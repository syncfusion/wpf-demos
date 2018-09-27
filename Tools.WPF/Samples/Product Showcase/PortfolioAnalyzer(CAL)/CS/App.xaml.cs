using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

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
            ResourceDictionary rs = new ResourceDictionary();
            rs.Source = new Uri("/PortfolioAnalyzer.Infrastructure;component/Brushes.xaml", UriKind.RelativeOrAbsolute);
            DrawingBrush brush = rs["blackbackground"] as DrawingBrush;
            //win.AllowsTransparency = true;
            win = new Window();
            Label label = new Label();
            label.Content = "Please Wait...Loading Modules...";
            label.FontWeight = FontWeights.Bold;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.FontSize = 14;
            label.Foreground = Brushes.White;
            label.FontFamily = new FontFamily("Verdana");
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.WindowStyle = WindowStyle.None;
            win.Background = brush;
            win.Height = 75;
            win.Width = 309;
            win.ShowInTaskbar = false;
            win.Topmost = true;
            win.Content = label;
            win.Show();
        }
    }
}
