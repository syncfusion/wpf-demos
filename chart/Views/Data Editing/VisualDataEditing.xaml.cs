#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Charts;


namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for VisualDataEditingDemo.xaml
    /// </summary>
    public partial class VisualDataEditingDemo
    {
        public VisualDataEditingDemo()
        {
            InitializeComponent();
            var colorModel = new ChartColorModel();
            var customBrushes = new List<Brush>();
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x96, 0xD7, 0x59)));
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x77, 0x5D, 0xD0)));

            colorModel.CustomBrushes = customBrushes;
            series.ColorModel = colorModel;
            series.Palette = ChartColorPalette.Custom;
        }

        protected override void Dispose(bool disposing)
        {
            DataEditingChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }
    }
}
