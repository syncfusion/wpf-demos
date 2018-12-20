#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

namespace SelectionDemo
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

    internal class NavigationModeConverter:IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int? index = value as int?;
            switch (index)
            {
                case 0:
                    return NavigationMode.Row;
                case 1:
                    return NavigationMode.Cell;
               
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectionImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is EmployeeInfo)
            {
                var name = value as EmployeeInfo;
                return "Images/" + name.FirstName + ".png";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
