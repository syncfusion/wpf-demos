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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DashedSplineChart : DemoControl
    {
        public DashedSplineChart()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            SplineChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://tcdata360.worldbank.org/indicators/inv.all.pct?country=BRA&indicator=345&countries=GRC,SWE&viz=line_chart&years=1997,2004") { UseShellExecute = true });
        }
    } 
}
