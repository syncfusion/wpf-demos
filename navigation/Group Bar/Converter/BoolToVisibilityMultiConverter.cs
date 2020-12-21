#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    ///  Represents the visibility multi converter.
    /// </summary>
    public class BoolToVisibilityMultiConverter : IMultiValueConverter
    {
        /// <summary>
        /// Convert method to change the boolean property to visibility.
        /// </summary>
        /// <param name="values">Value to be convert.</param>
        /// <param name="targetType">Target type in which value to be convert.</param>
        /// <param name="parameter">Parameter which is to be passed to the object.</param>
        /// <param name="culture">Culture in which visibility occcurs.</param>
        /// <returns>Returns visibility.</returns>
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0].ToString() != "{DependencyProperty.UnsetValue}")
            {
                if ((bool)values[0] || (bool)values[1])
                    return Visibility.Visible;
            }
             return  Visibility.Hidden;
        }
        /// <summary>
        /// Convert back method.
        /// </summary>
        /// <param name="value">Value to be convert back.</param>
        /// <param name="targetTypes">Target type in which value to be convert back.</param>
        /// <param name="parameter">Parameter which is to be passed to the object.</param>
        /// <param name="culture">Culture in which visibility occcurs.</param>
        /// <returns></returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
