#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using System.Windows.Data;

namespace syncfusion.unitconverter.wpf
{
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return value;
            if (value == null)
            {
                return null;
            }
            double _value = (double)value;

            if (parameter.Equals("SEC"))
            {
                return 31536000 * _value;
            }
            else if (parameter.Equals("MS"))
            {
                return 3.1536E10 * _value;
            }
            else if (parameter.Equals("MIN"))
            {
                return 525600 * _value;
            }           
            else if (parameter.Equals("DAY"))
            {
                return _value * 365;
            }
            else if (parameter.Equals("MONTH"))
            {
                return _value * 12;
            }
            else if (parameter.Equals("WEEK"))
            {
                return _value * 52.14;
            }
            else if (parameter.Equals("HR"))
            {
                return _value * 8760;
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

            if (parameter.Equals("SEC"))
            {
                return _value / 31536000;
            }
            else if (parameter.Equals("MS"))
            {
                return _value / 3.1536E10;
            }
            else if (parameter.Equals("MIN"))
            {
                return _value / 525600;
            }
            else if (parameter.Equals("DAY"))
            {
                return _value / 365;
            }
            else if (parameter.Equals("MONTH"))
            {
                return _value / 12;
            }
            else if (parameter.Equals("WEEK"))
            {
                return _value / 52.14;
            }
            else if (parameter.Equals("HR"))
            {
                return _value / 8760;
            }
            else
            {
                return Decimal.Parse(value.ToString());
            }
        }
    }
}
