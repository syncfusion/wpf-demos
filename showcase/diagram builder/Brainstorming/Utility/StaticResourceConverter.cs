// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaticResourceConverter.cs" company="">
//   
// </copyright>
// <summary>
//   The static resource converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Brainstorming.Utility
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    ///     The static resource converter.
    /// </summary>
    internal class StaticResourceConverter : IValueConverter
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
        /// A converted value.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary()
            {
                Source = new Uri(@"/Syncfusion.SfDiagram.Wpf;component/Resources/BasicShapes.xaml", UriKind.RelativeOrAbsolute)
            };

            string resourceKey = (string)value;

            return resourceDictionary[resourceKey];
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