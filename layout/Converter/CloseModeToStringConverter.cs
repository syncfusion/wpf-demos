using Syncfusion.Windows.Shared;
using System;
using System.Windows.Data;

namespace syncfusion.layoutdemos.wpf
{
    public class CloseModeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (CloseMode)Enum.Parse(typeof(CloseMode), value.ToString(), true);
        }
    }
}
