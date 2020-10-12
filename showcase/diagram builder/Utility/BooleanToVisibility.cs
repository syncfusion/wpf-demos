// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToVisibility.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the boolean to visibility converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.Utility
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    ///     Represents the boolean to visibility converter.
    /// </summary>
    public class BooleanToVisibility : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">
        /// The value produced by the binding source.
        /// </param>
        /// <param name="targetType">
        /// The type to convert to.
        /// </param>
        /// <param name="parameter">
        /// The converter parameter to use.
        /// </param>
        /// <param name="culture">
        /// The culture to use in the converter.
        /// </param>
        /// <returns>
        /// Returns a converted value.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">
        /// The value that is produced by the binding target.
        /// </param>
        /// <param name="targetType">
        /// The type to convert to.
        /// </param>
        /// <param name="parameter">
        /// The converter parameter to use.
        /// </param>
        /// <param name="culture">
        /// The culture to use in the converter.
        /// </param>
        /// <returns>
        /// Returns a converted value.
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility val = (Visibility)value;
            if (val == Visibility.Visible)
            {
                return true;
            }

            return false;
        }
    }
}