using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.propertygriddemos.wpf
{
    public class DoubleToGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return (Double)((GridLength)(value)).Value;
            }

            return new GridLength(1, GridUnitType.Star);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return new GridLength((Double)value);
            }

            return new GridLength(1, GridUnitType.Star);
        }
    }
}
