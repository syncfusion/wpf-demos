#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UnitConverterDemo
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
