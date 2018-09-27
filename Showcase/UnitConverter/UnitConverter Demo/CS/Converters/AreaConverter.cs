using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UnitConverterDemo
{
    public class AreaConverter : IValueConverter
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

            if (parameter.Equals("sin"))
            {
                return _value * 1550.0031;
            }
            else if (parameter.Equals("SF"))
            {
                return _value * 10.76391;
            }
            else if (parameter.Equals("SC"))
            {
                return _value * 10000;
            }
            else if (parameter.Equals("SY"))
            {
                return _value * 1.19599;
            }
            else if (parameter.Equals("smm"))
            {
                return _value * 1000000;
            }   
            else
            {
                return Decimal.Parse(value.ToString());
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

            if (parameter.Equals("sin"))
            {
                return _value / 1550.0031;
            }
            else if (parameter.Equals("SF"))
            {
                return _value / 10.76391;
            }
            else if (parameter.Equals("SC"))
            {
                return _value / 10000;
            }
            else if (parameter.Equals("SY"))
            {
                return _value / 1.19599;
            }
            else if (parameter.Equals("smm"))
            {
                return _value / 1000000;
            }  
            else
            {
                return Decimal.Parse(value.ToString());
            }
        }
    }
}
