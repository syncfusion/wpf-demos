#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Data;
using System.Windows;

namespace syncfusion.propertygriddemos.wpf
{
    public class SelectedIndexToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int index = (int)value;
            if (index == 0 && parameter.ToString() == "Foreground")
            {
               return Visibility.Visible;
            }
            else if (index == 1 && parameter.ToString() == "Background")
            {
                return Visibility.Visible;
            }
            else if (index == 2 && parameter.ToString() == "OpacityMask")
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
