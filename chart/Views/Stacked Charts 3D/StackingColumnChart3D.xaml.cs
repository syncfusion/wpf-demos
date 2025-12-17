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
using System.Windows;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for StackingColumnChart3D.xaml
    /// </summary>
    public partial class StackingColumnChart3D : DemoControl
    {
        public StackingColumnChart3D()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (this.columnChart != null)
            {
                this.columnChart.Dispose();
            }

            grid.Children.Clear();
            base.Dispose(disposing);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://ourworldindata.org/grapher/patents-electric-vehicles?time=2017..2020") { UseShellExecute = true });
        }

        private void NumericalAxis3D_LabelCreated(object sender, LabelCreatedEventArgs e)
        {
            double position = e.AxisLabel.Position;

            if (position >= 1000 && position <= 999999)
            {
                string text = (position / 1000).ToString("N0");
                e.AxisLabel.LabelContent = $"{text}K";
            }
            else
            {
                e.AxisLabel.LabelContent = $"{position:N0}K";
            }
        }
    }
}
