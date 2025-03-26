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
    public partial class BarChart3DSegmentSpacing : DemoControl
    {
        public BarChart3DSegmentSpacing()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.barChart != null)
            {
                this.barChart.Dispose();
            }

            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://data.worldbank.org/indicator/TX.VAL.MMTL.ZS.UN?end=2022&locations=BO-BR&start=2020&view=chart") { UseShellExecute = true });
        }
    }
}


