using System;  
using System.Globalization;
using System.Windows.Data; 
namespace syncfusion.stockanalysisdemo.wpf
{
    public class PathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Stock data = value as Stock;
                if (data.CurrentClose <= 151)
                    return "#DC2626";
                else
                    return "#047857";
            }
            return "#047857";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
