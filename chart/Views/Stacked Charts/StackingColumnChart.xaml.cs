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
    /// Interaction logic for StackingColumnChartDemo.xaml
    /// </summary>
    public partial class StackingColumnChartDemo : DemoControl
    {
        public StackingColumnChartDemo()
        {
            InitializeComponent();
            var colorModel = new ChartColorModel();
            var customBrushes = new List<Brush>();

            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xFE, 0xBE, 0x19)));
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xAC, 0xAC, 0xAC)));
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0xAA, 0x68, 0x43)));

            colorModel.CustomBrushes = customBrushes;
            StackingColumnChart.ColorModel = colorModel;
            StackingColumnChart.Palette = ChartColorPalette.Custom;
        }
        
        protected override void Dispose(bool disposing)
        {
            StackingColumnChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.statista.com/statistics/1101719/summer-olympics-all-time-medal-list-since-1892/") { UseShellExecute = true });
        }
    } 
}
