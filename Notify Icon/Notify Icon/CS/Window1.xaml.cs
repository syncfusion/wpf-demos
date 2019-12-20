#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;

namespace NotifyIcon_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {       
        public Window1()
        {
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office2016Colorful);
            InitializeComponent();
            EventLog();
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
            (this.DataContext as NotifyViewModel).EventLog.Add("BalloonTip Size Changed Event Fired");
        }

        void defaults_CloseButtonClick(object sender, EventArgs e)
        {
            (this.DataContext as NotifyViewModel).EventLog.Add("Balloontip CloseButton Clicked Event Fired");
        }

        void defaults_BalloonTipOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (this.DataContext as NotifyViewModel).EventLog.Add("BalloonTip Opening Event Fired");
        }

        void defaults_BalloonTipOpened(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (this.DataContext as NotifyViewModel).EventLog.Add("BalloonTip Open Event Fired");
        }

        void defaults_BalloonTipHiding(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (this.DataContext as NotifyViewModel).EventLog.Add("BalloonTip Hiding Event Fired");
        }

        void defaults_BalloonTipHidden(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (this.DataContext as NotifyViewModel).EventLog.Add("BalloonTip Hidden Event Fired");
            button.IsEnabled = true;
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
