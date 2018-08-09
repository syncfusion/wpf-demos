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
