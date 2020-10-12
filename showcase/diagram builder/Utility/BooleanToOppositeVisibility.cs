// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToOppositeVisibility.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the boolean to opposite visibility converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.Utility
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    ///     Represents the boolean to opposite visibility converter.
    /// </summary>
    public class BooleanToOppositeVisibility : IValueConverter
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
                return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        /// <summary>
        /// Converts a value
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
            if (val == Visibility.Collapsed)
            {
                return true;
            }

            return false;
        }
    }
}