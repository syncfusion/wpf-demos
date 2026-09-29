using System;
using System.Globalization;
using System.Windows.Data;

namespace syncfusion.unitconverter.wpf
{
    public class DataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return value;
            if (value == null)
            {
                return null;
            }
            double _value = Double.Parse(value.ToString());

            if (parameter.Equals("B"))
            {
                return _value * 1.099511627776E12;
            }
            else if (parameter.Equals("KB"))
            {
                return _value * 1073741824;
            }
            else if (parameter.Equals("MB"))
            {
                return _value * 1048576;
            }
            else if (parameter.Equals("GB"))
            {
                return _value * 1024;
            }
            else if (parameter.Equals("bit"))
            {
                return _value * 8.796093022208E12;
            }
            else
            {
                return Decimal.Parse(_value.ToString());
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return value;
            if (value == null)
            {
                return null;
            }
            double _value = Double.Parse(value.ToString());

            if (parameter.Equals("B"))
            {
                return _value / 1.099511627776E12;
            }
            else if (parameter.Equals("KB"))
            {
                return _value / 1073741824;
            }
            else if (parameter.Equals("MB"))
            {
                return _value / 1048576;
            }
            else if (parameter.Equals("GB"))
            {
                return _value / 1024;
            }
            else if (parameter.Equals("bit"))
            {
                return _value / 8.796093022208E12;
            }
            else
            {
                return Decimal.Parse(_value.ToString());
            }
        }
    }
}
