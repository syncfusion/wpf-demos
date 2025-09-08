#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
    public partial class ErrorBarSeriesDemo : DemoControl
    {
        public ErrorBarSeriesDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            sfchart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.owlnet.rice.edu/~msci301/ThermalExpansion.pdf") { UseShellExecute = true });
        }
    }
}

