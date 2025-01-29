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
    /// Interaction logic for AreaSeriesChart3DDemo.xaml
    /// </summary>
    public partial class Column3DSegmentSpacing : DemoControl
    {
        public Column3DSegmentSpacing()
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
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://data.worldbank.org/indicator/MS.MIL.XPND.GD.ZS?end=2020&locations=TG-SD&start=2016&view=chart") { UseShellExecute = true });
        }
    }
}
