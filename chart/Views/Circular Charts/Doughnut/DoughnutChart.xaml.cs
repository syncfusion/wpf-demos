#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.chartdemos.wpf
{
    public partial class DoughnutChartDemo : DemoControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoughnutChartDemo"/> class.
        /// </summary>
        public DoughnutChartDemo()
        {
            InitializeComponent();
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            chart.Dispose();
            grid.Children.Clear();
            base.Dispose(disposing);
        }
    }

    /// <summary>Provides a converter that returns a highlight color for exploded chart segments.</summary>
    public class ExplodeColorConverter : IValueConverter
    {
        private int previousIndex = -1;

        private Color[] colors = new Color[]
        {
              Color.FromArgb(255, 0, 143, 251),
              Color.FromArgb(255, 43, 210, 110),
              Color.FromArgb(255, 245, 138, 60),
              Color.FromArgb(255, 220, 103, 206),
              Color.FromArgb(255,150, 215, 89),
        };

        /// <summary>Converts a source value to a value suitable for the binding target.</summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int explodeIndex)
            {
                if (explodeIndex >= 0)
                {
                    previousIndex = explodeIndex;
                    return new SolidColorBrush(colors[explodeIndex]);
                }
                else if (explodeIndex == -1)
                {
                    return new SolidColorBrush(colors[previousIndex]);
                }
            }

            return new SolidColorBrush(Colors.Transparent);
        }

        /// <summary>Converts a binding target value back to a value suitable for the source.</summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
