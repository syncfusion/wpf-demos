#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.chartdemos.wpf
{
    public partial class PerformanceDemo : DemoControl
    {
        Stopwatch stopwatch = new Stopwatch();

        public PerformanceDemo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PerformanceViewModel viewModel = new PerformanceViewModel();
            ObservableCollection<PerformanceModel> collection = viewModel.GenerateData();
            stopwatch.Restart();
            chart1.Series[0].ItemsSource = collection;
        }

        private void Chart_LayoutUpdated(object sender, EventArgs e)
        {
            if (stopwatch != null)
            {
                stopwatch.Stop();
                text.Text = "Total Time Taken : " + stopwatch.ElapsedMilliseconds.ToString() + " ms";
            }
        }

        protected override void Dispose(bool disposing)
        {
            chart1.Dispose();
            base.Dispose(disposing);
        }
    }
}
