using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Tools;  
using Syncfusion.Windows.Shared;
using Microsoft.Win32; 
using Syncfusion.Windows.Tools.Controls;

namespace NotifyIcon_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {       
        public Window1()
        {
            InitializeComponent();
            EventLog();
        }

        private void ChromelessWindow_Loaded(object sender, RoutedEventArgs e)
        {            
            defaults.ShowInTaskBar = true;

            System.Windows.Media.Imaging.BitmapImage bim = new System.Windows.Media.Imaging.BitmapImage();
            bim.BeginInit();
            bim.DecodePixelWidth = 16;
            bim.UriSource = new Uri("pack://application:,,,/NotifyIcon_2008;Component/Icon.ico");
            bim.EndInit();
            defaults.Icon = bim;
        }

        public void EventLog()
        {
            defaults.BalloonTipHidden += new PropertyChangedCallback(defaults_BalloonTipHidden);
            defaults.BalloonTipHiding += new System.ComponentModel.CancelEventHandler(defaults_BalloonTipHiding);
            defaults.BalloonTipOpened += new PropertyChangedCallback(defaults_BalloonTipOpened);
            defaults.BalloonTipOpening += new System.ComponentModel.CancelEventHandler(defaults_BalloonTipOpening);
            defaults.CloseButtonClick += new EventHandler(defaults_CloseButtonClick);
            defaults.SizeChanged += new SizeChangedEventHandler(defaults_SizeChanged);

        }

        void defaults_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AddLog("BalloonTip Size Changed Event Fired");           
        }

        void defaults_CloseButtonClick(object sender, EventArgs e)
        {
            AddLog("Balloontip CloseButton Clicked Event Fired");            
        }

        void defaults_BalloonTipOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AddLog("BalloonTip Opening Event Fired");                   
        }

        void defaults_BalloonTipOpened(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddLog("BalloonTip Open Event Fired");  
        }

        void defaults_BalloonTipHiding(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AddLog("BalloonTip Hiding Event Fired");
        }

        void defaults_BalloonTipHidden(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddLog("BalloonTip Hidden Event Fired");
            button.IsEnabled = true;
        }

        private void AddLog(string eventlog)
        {
            sblayout.EventLogs.Add(eventlog);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            defaults.ShowBalloonTip(50000);
            button.IsEnabled = false;
        } 
    }
    public class ColorToBrushConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new SolidColorBrush((Color)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
