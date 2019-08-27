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
    public class LengthConverter : IValueConverter
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

            string unit = parameter.ToString();
            if (parameter.Equals("CM"))
            {
                return Math.Round(100 * _value,2);
            }
            else if (parameter.Equals("FEET"))
            {
                return Math.Round(3.28 * _value,2);
            }
            else if (parameter.Equals("IN"))
            {
                return Math.Round(39.37 * _value,2);
            }
            else if (parameter.Equals("MM"))
            {
                return Math.Round(1000 * _value,2);
            }
            else if (parameter.Equals("MICRO"))
            {
                return Math.Round((1000 * 1000 * _value),2);
            }
            else if (parameter.Equals("NM"))
            {
                return Math.Round((1000 * 1000 * 1000 * _value),2);
            }
            else if (parameter.Equals("Miles"))
            {
                return Math.Round(0.006 * _value,2);
            }
            else if (parameter.Equals("YD"))
            {
                return Math.Round(1.093 * _value,2);
            }
            else if (parameter.Equals("KM"))
            {
                return Math.Round(0.001 * _value,2);
            }
            else
            {
                return Math.Round(Decimal.Parse(value.ToString()),2);
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

            string unit = parameter.ToString();
            if (parameter.Equals("CM"))
            {
                return Math.Round(_value / 100,2);
            }
            else if (parameter.Equals("FEET"))
            {
                return Math.Round(_value / 3.28,2);
            }
            else if (parameter.Equals("IN"))
            {
                return Math.Round(_value / 39.37,2);
            }
            else if (parameter.Equals("MM"))
            {
                return Math.Round(_value / 1000,2);
            }
            else if (parameter.Equals("MICRO"))
            {
                return Math.Round((_value / (1000 * 1000)),2);
            }
            else if (parameter.Equals("NM"))
            {
                return Math.Round((_value / (1000 * 1000 * 1000)),2);
            }
            else if (parameter.Equals("Miles"))
            {
                return Math.Round(_value / 0.006,2);
            }
            else if (parameter.Equals("YD"))
            {
                return Math.Round(_value / 1.093,2);
            }
            else if (parameter.Equals("KM"))
            {
                return Math.Round(_value / 0.001,2);
            }
            else
            {
                return Math.Round(Decimal.Parse(value.ToString()),2);
            }
        }
    }
}
