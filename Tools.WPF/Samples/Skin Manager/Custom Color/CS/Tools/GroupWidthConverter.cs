using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Diagnostics;

namespace CustomColor_Demo_2008
{
    [ValueConversion(typeof(double), typeof(double))]
    public class GroupWidthConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double groupWidth = (double)value;

            if (double.IsNaN(groupWidth))
                return 250;

            return groupWidth;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double groupWidth = (double)value;

            if (groupWidth > 245)
                return double.NaN;

            return groupWidth;
        }

        #endregion
    }
}
