#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ColumnRoundedEdges : DemoControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnRoundedEdges"/> class.
        /// </summary>
        public ColumnRoundedEdges()
        {
            InitializeComponent();
            var colorModel = new ChartColorModel();
            var customBrushes = new List<Brush>();
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x77, 0x5D, 0xD0))); 
            customBrushes.Add(new SolidColorBrush(Color.FromArgb(0xFF, 0x96, 0xD7, 0x59))); 

            colorModel.CustomBrushes = customBrushes;
            columnSeries.ColorModel = colorModel;
            columnSeries.Palette = ChartColorPalette.Custom;
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            columnChart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://www.worldatlas.com/articles/largest-cities-in-the-world-by-land-area.html") { UseShellExecute = true });

        }
    }

    /// <summary>Provides a converter that alternates label background colors based on position.</summary>
    public class LabelTemplateConverter : IValueConverter
    {
        /// <summary>Converts a source value to a value suitable for the binding target.</summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double position = value as double? ?? 0;
            return position % 2 == 0 ? new SolidColorBrush(Color.FromArgb(0xFF, 0x77, 0x5D, 0xD0)) : new SolidColorBrush(Color.FromArgb(0xFF, 0x96, 0xD7, 0x59));
        }

        /// <summary>Converts a binding target value back to a value suitable for the source.</summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>Provides a converter that alternates label foreground colors based on position.</summary>
    public class LabelForegroundConverter : IValueConverter
    {
        /// <summary>Converts a source value to a value suitable for the binding target.</summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double position = value as double? ?? 0;
            return position % 2 == 0 ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Black);
        }

        /// <summary>Converts a binding target value back to a value suitable for the source.</summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
