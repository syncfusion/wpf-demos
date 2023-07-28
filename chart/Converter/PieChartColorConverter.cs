#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.chartdemos.wpf
{

    public class PieChartColorConverter : IValueConverter
    {
        private SolidColorBrush ApplyLight(Color color)
        {
            return new SolidColorBrush(Color.FromArgb(color.A, (byte)(color.R * 0.9), (byte)(color.G * 0.9), (byte)(color.B * 0.9)));
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && (value is ChartAdornment))
            {
                ChartAdornment pieAdornment = value as ChartAdornment;
                int index = pieAdornment.Series.Adornments.IndexOf(pieAdornment);
                SolidColorBrush brush = pieAdornment.Series.ColorModel.GetBrush(index) as SolidColorBrush;
                return ApplyLight(brush.Color);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
