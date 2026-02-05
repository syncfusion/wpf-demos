#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for StackingAreaChartDemo.xaml
    /// </summary>
    public partial class StackingAreaChartDemo : DemoControl 
    {
        public StackingAreaChartDemo()
        {
            InitializeComponent();
            var colorModel = new ChartColorModel();
            var customBrushes = new List<Brush>();

            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xD7, 0x52, 0xC7)));
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x96, 0xD7, 0x59)));
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xAE, 0xE0)));

            colorModel.CustomBrushes = customBrushes;
            StackingAreaChart.ColorModel = colorModel;
            StackingAreaChart.Palette = ChartColorPalette.Custom;
        }

        protected override void Dispose(bool disposing)
        {
            StackingAreaChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.statista.com/statistics/236101/global-sales-of-the-confectionery-sector-of-nestle-by-segment/") { UseShellExecute = true });
        }

        private void NumericalAxis_LabelCreated(object sender, LabelCreatedEventArgs e)
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
    } 
}
