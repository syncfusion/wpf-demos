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
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Chart;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media;
using System.Globalization;

namespace ChartAutoScrollingDemo
{
    class ChartAutoScrollingBehavior : Behavior<Window1>
    {
        private Chart chart;
        DispatcherTimer timer = new DispatcherTimer();
        DateTime i = new DateTime();

        protected override void OnAttached()
        {
            chart = this.AssociatedObject.Chart1;

            this.AssociatedObject.strip1.Text = new FormattedText("Low", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 20, Brushes.Brown);
            this.AssociatedObject.strip2.Text = new FormattedText("High", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 20, Brushes.Brown);

            this.AssociatedObject.btn_start.Click += new System.Windows.RoutedEventHandler(btn_start_Click);
            this.AssociatedObject.btn_stop.Click += new RoutedEventHandler(btn_stop_Click);
            base.OnAttached();
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            timer.Interval = new TimeSpan(1000);
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            i = (this.chart.Areas[0].Series[0].DataSource as ProductDetails)[(this.chart.Areas[0].Series[0].DataSource as ProductDetails).Count - 1].Speed.AddMinutes(1);
            Random rand = new Random();
            (this.chart.Areas[0].Series[0].DataSource as ProductDetails).Add(new Product() { Speed = i, Rate = rand.Next(100, 250) });
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}
