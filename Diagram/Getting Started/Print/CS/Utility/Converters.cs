#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.Windows;
using System.Windows.Data;

namespace GettingStarted_Print.Utility
{

    /// <summary>
    /// Convert the pagesize into inches and centimeters.
    /// </summary>
    public class PageSizeTextConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is Size)
            {
                var size = (Size)values[0];

                string unit = values[1].ToString();
                if (unit == "Inches")
                {
                    //Pixel to inches convertor
                    double pixels = 0.026458333333;
                    double cm = 0.393700787 * pixels;
                    return Math.Round(size.Width * cm, 2) + "''" + " x " + Math.Round(size.Height * cm, 2) + "''";
                }
                else if (unit == "Centimeters")
                {
                    double cm = 0.0264583333;
                    return Math.Round(size.Width * cm, 2) + " cm " + " x " + Math.Round(size.Height * cm, 2) + " cm ";
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
