using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// This class converts a Visibility enumeration to a boolean value.
    /// </summary>
    public class VisibilityToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility visibility && visibility == Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool bl && bl) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
