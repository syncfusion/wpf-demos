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
    /// <summary>
    /// Interaction logic for StackingArea100Chart.xaml
    /// </summary>
    public partial class StackingArea100ChartDemo : DemoControl
    {
        public StackingArea100ChartDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            StackingArea100Chart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://data.worldbank.org/indicator/EN.ATM.METH.ZG?end=2010&locations=CA-PE-ET-ML&start=2000&view=chart") { UseShellExecute = true });
        }
    } 
}
