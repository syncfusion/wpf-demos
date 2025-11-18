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
    /// Interaction logic for DoughnutChart3D.xaml
    /// </summary>
    public partial class ExplodeDoughnutChart3D : DemoControl
    {
        public ExplodeDoughnutChart3D()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DoughnutChart != null)
            {
                this.DoughnutChart.Dispose();
            }

            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://en.wikipedia.org/wiki/Continent#Area_and_population") { UseShellExecute = true });
        }
    }
}
