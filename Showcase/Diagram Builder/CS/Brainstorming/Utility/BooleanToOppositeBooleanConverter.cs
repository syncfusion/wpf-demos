// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToOppositeBooleanConverter.cs" company="">
//   
// </copyright>
// <summary>
//   The boolean to opposite boolean converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Brainstorming.Utility
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    ///     The boolean to opposite boolean converter.
    /// </summary>
    public class BooleanToOppositeBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">
        /// The value that is produced by the binding source.
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
        /// A converted value.The true value return as false and the false value return as true
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool)value;
            return !val;
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
        /// A converted value.The true value return as false and the false value return as true
        /// </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool)value;
            return !val;
        }
    }
}