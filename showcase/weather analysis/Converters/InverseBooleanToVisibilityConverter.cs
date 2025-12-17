using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.weatheranalysis.wpf
{
    public class InverseBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool.TryParse(value?.ToString(), out bool val)))
            {
                return val ? Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
