using System;
using System.Globalization;
using System.Windows.Data;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Returns <see cref="System.Windows.Visibility.Visible"/> when object is not null and <see cref="System.Windows.Visibility.Collapsed"/> when object is null.
    /// </summary>
    public class ObjectNullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return System.Windows.Visibility.Collapsed;
            return System.Windows.Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
