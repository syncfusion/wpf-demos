// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeTypeToHorizontalAlignmentConverter.cs" company="">
//   
// </copyright>
// <summary>
//   The node type to horizontal alignment converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Brainstorming.Utility
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    ///     The node type to horizontal alignment converter.
    /// </summary>
    internal class NodeTypeToHorizontalAlignmentConverter : IValueConverter
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
        /// A converted value.if the value is left, which returns the HorizontalAlignment as left. otherwise, returns the
        ///     HorizontalAlignment as right
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string type = value.ToString();
            return type.Contains("left") ? HorizontalAlignment.Left : HorizontalAlignment.Right;
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
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}