#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Syncfusion.UI.Xaml.Grid;
using System.Globalization;
using System.Windows;

namespace CutCopyPasteDemo
{
    //Converter for selectionUnit based on the combobox selection
    internal class SelectionUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int? index = value as int?;
            switch (index)
            {
                case 0:
                    return GridSelectionUnit.Cell;
                case 1:
                    return GridSelectionUnit.Row;
                case 2:
                    return GridSelectionUnit.Any;
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    //Converter for selectionModebased on the combobox selection
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
}
