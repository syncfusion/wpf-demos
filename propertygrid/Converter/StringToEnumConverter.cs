#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Data;
using System.Windows.Controls;
using System.Globalization;
using System.ComponentModel;

namespace syncfusion.propertygriddemos.wpf
{
    public class StringToEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return value;
            ListSortDirection listSortDirection;
            if (Enum.TryParse(value.ToString(), out listSortDirection))
                return listSortDirection;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var comboboxitem = value as ComboBoxItem;
            if (comboboxitem != null)
            {
                if (comboboxitem.Content.ToString() == "None")
                {
                    return null;
                }
                ListSortDirection listSortDirection;
                if (Enum.TryParse(comboboxitem.Content.ToString(), out listSortDirection))
                    return listSortDirection;
            }
            return string.Empty;
        }
    }
}
