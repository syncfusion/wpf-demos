#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using System.Windows.Data;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Returns <see cref="System.Windows.Visibility.Visible"/> when object is not null and <see cref="System.Windows.Visibility.Collapsed"/> when object is null.
    /// </summary>
    public class ObjectNullToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts an object to a <see cref="System.Windows.Visibility.Visible"/> value.
        /// </summary>
        /// <param name="value">The object to be evaluated. This is a binding source.</param>
        /// <param name="targetType">The type of the binding target property (not used).</param>
        /// <param name="parameter">Optional parameter. if it evaluates 'true'. the Visibility logic is inverted.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns><see cref="System.Windows.Visibility.Collapsed"/> if the value is null, otherwise <see cref="System.Windows.Visibility.Visible"/>. The result is inverted if the value is true.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return System.Windows.Visibility.Collapsed;
            return System.Windows.Visibility.Visible;
        }

        /// <summary>
        ///  This method is not implemented and will throw an exception if used.
        /// </summary>
        /// <param name="value">The value that is produced by the binding targets.</param>
        /// <param name="targetType">The type to convert.</param>
        /// <param name="parameter">Optional parameter.</param>
        /// <param name="culture">The culture to use in the conversion. Not used</param>
        /// <exception cref="NotImplementedException">Thrown because converting back is not supported by this converter</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
