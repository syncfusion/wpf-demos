#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CellSelectionDemo
{
    internal class SelectionModeConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo info)
        {
            int? index = value as int?;
            switch (index)
            {
                case 0:
                    return GridSelectionMode.Single;
                case 1:
                    return GridSelectionMode.Multiple;
                case 2:
                    return GridSelectionMode.Extended;
                case 3:
                    return GridSelectionMode.None;
                default:
                    return null;
            }
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo info)
        {
            throw new NotImplementedException();
        }
    }

    internal class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleValue = (double)value;
            return "$" + doubleValue.ToString("0.00");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
