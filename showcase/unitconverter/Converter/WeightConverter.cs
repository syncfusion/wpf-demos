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
    public class WeightConverter : IValueConverter 
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

            if (parameter.Equals("KG"))
            {
                return Math.Round(_value * 0.001,2);
            }
            else if (parameter.Equals("P"))
            {
                return Math.Round(_value * 0.002205,2);
            }
            else if (parameter.Equals("Ounces"))
            {
                return Math.Round(_value * 0.035274,2);
            }
            else if (parameter.Equals("Tons"))
            {
                return Math.Round(_value * 1.10231131092439E-6,2);
            }
            else if (parameter.Equals("mg"))
            {
                return Math.Round(_value * 1000,2);
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

            double _value = Double.Parse(value.ToString());

            if (parameter.Equals("KG"))
            {
                return Math.Round(_value /0.001,2);
            }
            else if (parameter.Equals("P"))
            {
                return Math.Round(_value / 0.002205,2);
            }
            else if (parameter.Equals("Ounces"))
            {
                return Math.Round(_value / 0.035274,2);
            }
            else if (parameter.Equals("Tons"))
            {
                return Math.Round(_value / 1.10231131092439E-6,2);
            }
            else if (parameter.Equals("mg"))
            {
                return Math.Round(_value / 1000,2);
            }
            else
            {
                return Decimal.Parse(_value.ToString());
            }
        }
    }
}
