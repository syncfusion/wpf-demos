using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.navigationdemos.wpf.Converter
{
    public class WeatherConverter: IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((Climate)value == Climate.Sunny)
            {
                return "/syncfusion.navigationdemos.wpf;component/Assets/TabControlExt/sunny.png";
            }
            else if ((Climate)value == Climate.Rainy)
            {
                return "/syncfusion.navigationdemos.wpf;component/Assets/TabControlExt/rainy.png";
            }
            else
            {
                return "/syncfusion.navigationdemos.wpf;component/Assets/TabControlExt/cloudy.png";
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
