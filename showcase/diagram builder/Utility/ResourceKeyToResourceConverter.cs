// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResourceKeyToResourceConverter.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the resource key to resource converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DiagramBuilder.Utility
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;
    using System.Windows.Shapes;

    /// <summary>
    ///     Represents the resource key to resource converter.
    /// </summary>
    internal class ResourceKeyToResourceConverter : IMultiValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="values">
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
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
            {
                return null;
            }

            FrameworkElement element = values[0] as FrameworkElement;
            DependencyObject dobject = element.Parent;
            object resourceKey = values[1];
            resourceKey = string.Format("{0}Style", resourceKey);
            object resource = element.TryFindResource(resourceKey);
            if (dobject != null && resource != null)
            {
                if (dobject is Grid)
                {
                    if ((dobject as Grid).Children.Count > 1)
                    {
                        BrushConverter converter = new BrushConverter();
                        if ((dobject as Grid).Children[0] is TextBlock)
                        {
                            TextBlock tt = (dobject as Grid).Children[0] as TextBlock;
                            foreach (Setter set in (resource as Style).Setters)
                            {
                                if (set.Property == FrameworkElement.TagProperty)
                                {
                                    Brush brush = (Brush)converter.ConvertFromString(set.Value.ToString());
                                    tt.Foreground = brush;
                                }
                            }
                        }
                        else if ((dobject as Grid).Children[0] is Path)
                        {
                            Path tt = (dobject as Grid).Children[0] as Path;
                            foreach (Setter set in (resource as Style).Setters)
                            {
                                if (set.Property == FrameworkElement.TagProperty)
                                {
                                    Brush brush = (Brush)converter.ConvertFromString(set.Value.ToString());
                                    tt.Fill = brush;
                                }
                            }
                        }
                    }
                }
            }

            return resource;
        }

        /// <summary>
        /// Converts a value
        /// </summary>
        /// <param name="value">
        /// The value that is produced by the binding target.
        /// </param>
        /// <param name="targetTypes">
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
        /// <exception cref="NotImplementedException">
        /// </exception>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}