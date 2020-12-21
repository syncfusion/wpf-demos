#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.datagriddemos.wpf
{
    public class RowStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var rating = (int)value;
            if (rating == 5)
                return Brushes.Transparent;

            Brush brush = rating < 5 ? new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFD356")) :
                                       new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF70FCA0"));
            if (rating > 5)
            {
                rating = rating - 5;
                brush.Opacity = Math.Abs((double)rating * 2) / 10;
            }
            else
                brush.Opacity = Math.Abs((double)rating * 2) / 10;
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
