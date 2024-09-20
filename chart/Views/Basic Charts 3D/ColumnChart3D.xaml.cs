#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System.Diagnostics;
using System.Text;
using System.Windows;


namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ColumnChart3D : DemoControl
    {
        public ColumnChart3D()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.columnChart != null)
            {
                this.columnChart.Dispose();
            }

            base.Dispose(disposing);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.fda.gov/food/food-labeling-nutrition/raw-fruits-poster-text-version-accessible-version") { UseShellExecute = true });
        }
    }
}
