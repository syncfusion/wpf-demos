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
    /// Interaction logic for BubbleChartDemo.xaml
    /// </summary>
    public partial class GradientBubble : DemoControl
    {
        public GradientBubble()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (BubbleChart != null)
            {
                BubbleChart.Dispose();
                BubbleChart = null;
            }

            grid.Children.Clear();
            base.Dispose(disposing);
        }
        private void LabelCreated(object sender, LabelCreatedEventArgs e)
        {
            double position = e.AxisLabel.Position;
            if (position > 0 && position <= 10000)
            {
                string text = (position / 1000).ToString();
                e.AxisLabel.LabelContent = $"{text}B";
            }
            else
            {
                e.AxisLabel.LabelContent = $"{position}B";
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.kaggle.com/datasets/thedevastator/movies-performance-and-feature-statistics") { UseShellExecute = true });
        }
    }
}
