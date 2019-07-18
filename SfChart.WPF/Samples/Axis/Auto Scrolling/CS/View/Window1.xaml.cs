#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using Syncfusion.Windows.Shared;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using Syncfusion.Windows.SampleLayout;
using Syncfusion.UI.Xaml.Charts;

namespace ChartAutoScrollingDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : SampleLayoutWindow
    {
        private SfChart chart;
        DispatcherTimer timer = new DispatcherTimer();
        DateTime i = new DateTime();
        Random rand = new Random();

        #region Constructor
        public Window1()
        {
            InitializeComponent();
            chart = Chart1;
            timer.Start();
            timer.Interval = TimeSpan.FromMilliseconds(150);
            timer.Tick += new EventHandler(timer_Tick);
        }
        #endregion  
   
        private void timer_Tick(object sender, EventArgs e)
        {
            int index = (this.chart.Series[0].ItemsSource as ProductDetails).Count - 1;
            
            i = (this.chart.Series[0].ItemsSource as ProductDetails)[index].Speed.AddMinutes(1);

            (this.chart.Series[0].ItemsSource as ProductDetails).Add(new Product() { Speed = i, Rate = rand.Next(100, 250) });
        }
    }
}
