#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace CustomColor_Demo_2008
{
    public class ThicknessToDoubles : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new Thickness((double)values[0], (double)values[1], (double)values[2], (double)values[3]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Thickness thickness = (Thickness)value;
            object[] values = new object[4];
            values[0] = thickness.Left;
            values[1] = thickness.Top;
            values[2] = thickness.Right;
            values[3] = thickness.Bottom;
            return values;
        }

        #endregion
    }
}
