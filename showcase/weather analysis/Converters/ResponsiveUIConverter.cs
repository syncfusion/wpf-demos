#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;

namespace syncfusion.weatheranalysis.wpf
{
    public class ResponsiveUIConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Screen screen = Screen.FromHandle(new System.Windows.Interop.WindowInteropHelper(WindowHelper.MainWindow).Handle);
            if (parameter?.ToString() == "Height")
            {
                double windowheight = (double)value;
                double minheight = 624;
                if (windowheight < minheight)
                    return true;
                return false;
            }

            double windowWidth = (double)value;
            
            int screenWidth = screen.Bounds.Width;
            // Calculate the minimum width based on a ratio
            double ratio = 0.6;
            double minWidth = (int)(screenWidth * ratio);

            if (windowWidth < minWidth)
                return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class ColumnWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility progressBarVisibility && progressBarVisibility == Visibility.Collapsed)
            {
                return new GridLength(0, GridUnitType.Auto);
            }

            return new GridLength(1, GridUnitType.Star);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
