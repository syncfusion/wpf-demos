#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Diagnostics;
using System.Windows;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for StepLineChartDemo.xaml
    /// </summary>
    public partial class StepLineChartDemo : DemoControl
    {
        public StepLineChartDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            SteplineChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://data.worldbank.org/indicator/EG.ELC.FOSL.ZS?end=2010&locations=CA-FR&start=2000") { UseShellExecute = true });
        }
    } 
}
