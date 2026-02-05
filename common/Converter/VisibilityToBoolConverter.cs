#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// This class converts a Visibility enumeration to a boolean value.
    /// </summary>
    public class VisibilityToBoolConverter : IValueConverter
    {
        /// <summary>
        /// Converts a <see cref="Visibility"/> value to boolean.
        /// </summary>
        /// <param name="value">The <see cref="Visibility"/> value to convert . This is a binding source.</param>
        /// <param name="targetType">The type of the binding target property (expected to be boolean).</param>
        /// <param name="parameter">Optional converter parameter.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns><c>true</c> if the input value is <see cref="Visibility.Visible"/>; otherwise, <c>false</c>.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility visibility && visibility == Visibility.Visible;
        }

        /// <summary>
        /// Converts a boolean value back to a <see cref="Visibility"/> value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding targets.</param>
        /// <param name="targetType">The type to convert.</param>
        /// <param name="parameter">Optional parameter.</param>
        /// <param name="culture">The culture to use in the conversion. Not used</param>
        /// <returns><see cref="Visibility.Visible"/> the input value is <c>true</c>. otherwise, <see cref="Visibility.Collapsed"/>. </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is bool bl && bl) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
