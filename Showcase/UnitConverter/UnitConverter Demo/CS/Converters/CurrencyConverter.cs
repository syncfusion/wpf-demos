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
    public class CurrencyConverter : IValueConverter
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

            if (parameter.Equals("IN"))
            {
                return Math.Round(_value * 64.09,2);
            }
            else if (parameter.Equals("UK"))
            {
                return Math.Round(_value * 0.64, 2);
            }
            else if (parameter.Equals("CH"))
            {
                return Math.Round(_value * 6.21,2);
            }
            else if (parameter.Equals("GM"))
            {
                return Math.Round(_value * 0.8905, 2);
            }
            else if (parameter.Equals("FR"))
            {
                return Math.Round(_value * 5.84686, 2);
            }
            else if (parameter.Equals("DN"))
            {
                return Math.Round((_value * 0.377),2);
            }
            else if (parameter.Equals("RD"))
            {
                return Math.Round(_value * 12.42, 2);
            }
            else if (parameter.Equals("BAN"))
            {
                return Math.Round(_value * 81.3447,2);
            }
            else if (parameter.Equals("BRA"))
            {
                return Math.Round(_value * 2.0309,2);
            }
            else if (parameter.Equals("Ja"))
            {
                return Math.Round(_value * 123.55, 2);
            }
            else
            {
                return Math.Round(_value, 2);
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

            if (parameter.Equals("IN"))
            {
                return Math.Round(_value / 64.09, 2);
            }
            else if (parameter.Equals("UK"))
            {
                return Math.Round(_value / 0.64, 2);
            }
            else if (parameter.Equals("CH"))
            {
                return Math.Round(_value / 6.21, 2);
            }
            else if (parameter.Equals("GM"))
            {
                return Math.Round(_value / 0.8905, 2);
            }
            else if (parameter.Equals("FR"))
            {
                return Math.Round(_value / 5.84686, 2);
            }
            else if (parameter.Equals("DN"))
            {
                return Math.Round((_value / 0.377),2);
            }
            else if (parameter.Equals("RD"))
            {
                return Math.Round(_value / 12.42, 2);
            }
            else if (parameter.Equals("BAN"))
            {
                return Math.Round(_value / 81.3447,2);
            }
            else if (parameter.Equals("BRA"))
            {
                return Math.Round(_value / 2.0309,2);
            }
            else if(parameter.Equals("Ja"))
            {
                return Math.Round(_value / 123.55, 2);
            }
            else
            {
                return Math.Round(_value, 2);
            }
        }
    }
}
