#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Windows.Data;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    ///  Represents the valueconverters.
    /// </summary>
    public class BooltoSizeFormConverter : IValueConverter
    {
        /// <summary>
        /// Method which is used to set the size.
        /// </summary>
        /// <param name="value">Value in which size to be convert.</param>
        /// <param name="targetType">Specifies the target type.</param>
        /// <param name="parameter">Specifies the object parameter.</param>
        /// <param name="culture">Specifies the culture.</param>
        /// <returns>Returns size</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.Equals(true))
            {
                return "Large";
            }
            else
            {
                return "Small";
            }
        }

        /// <summary>
        /// Method which is used to set back the size.
        /// </summary>
        /// <param name="value">Value in which size to be convert back.</param>
        /// <param name="targetType">Specifies the target type.</param>
        /// <param name="parameter">Specifies the object parameter.</param>
        /// <param name="culture">Specifies the culture.</param>
        /// <returns>Returns size</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
