// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeTypeToExpandCollapsePathData.cs" company="">
//   
// </copyright>
// <summary>
//   The node type to expand collapse path data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Brainstorming.Utility
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    ///     The node type to expand collapse path data.
    /// </summary>
    internal class NodeTypeToExpandCollapsePathData : IValueConverter
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
        /// A converted value.if the value is left, which returns the path value as left. otherwise, returns the path
        ///     value as right
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string type = value.ToString();
            return type.Contains("left") ? "M 0 10 L 10 0 L 10 20 Z" : "M 0 0 L 10 10 L 0 20 Z";
        }

        /// <summary>
        /// The convert back.
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