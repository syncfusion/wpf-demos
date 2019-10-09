#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Gauges;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace DigitalGaugeDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        internal DispatcherTimer timer = new DispatcherTimer();
        DateTime datetime;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {


            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
            datetime = DateTime.Now;
            timeGauge.Value = DateTime.Now.ToString("HH-mm");
            secGauge.Value = datetime.Second.ToString();

            dateGauge.Value = datetime.Day.ToString();
            monthGauge.Value = datetime.Month.ToString();
            dayGauge.Value = datetime.DayOfWeek.ToString().Remove(3, datetime.DayOfWeek.ToString().Length - 3).ToUpper();


        }

        void timer_Tick(object sender, object e)
        {
            timeGauge.Value = DateTime.Now.ToString("HH-mm");
            secGauge.Value = DateTime.Now.Second.ToString();
        }
        
    }
}
