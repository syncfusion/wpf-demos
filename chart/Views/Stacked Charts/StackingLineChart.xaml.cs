#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Diagnostics;
using System.Windows;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for StackingLineChartDemo.xaml
    /// </summary>
    public partial class StackingLineChartDemo : DemoControl
    {
        public StackingLineChartDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            StackingLineChart.Dispose();
            base.Dispose(disposing);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://data.worldbank.org/indicator/NY.GDP.MKTP.KD.ZG?amp%3Blocations=US-CN-CM-GB&amp%3Bname_desc=false&amp%3Bstart=2010&end=2015&locations=GB-CM-US-CN&start=2010") { UseShellExecute = true });
        }
    }
}
