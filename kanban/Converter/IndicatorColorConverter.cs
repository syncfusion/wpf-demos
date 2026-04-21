#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.kanbandemos.wpf
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// Converts priority level strings to corresponding color brushes for UI display.
    /// </summary>
    public class IndicatorColorConverter : IValueConverter
    {
        /// <summary>
        /// Converts a string value representing a priority level into a color code or brush for UI display.
        /// </summary>
        /// <param name="value">The priority level as a string (e.g., "High", "Low").</param>
        /// <param name="targetType">The target type of the binding (typically a Brush or Color).</param>
        /// <param name="parameter">An optional parameter for the converter (not used).</param>
        /// <param name="culture">The culture information for the conversion (not used).</param>
        /// <returns>
        /// A color code string or a <see cref="SolidColorBrush"/> based on the priority level.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string textValue = value?.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(textValue))
            {
                return null;
            }              

            string colorCode = textValue == "High" ? "#914C00" :
                               textValue == "Medium" ? "#205107" :
                               textValue == "Low" ? "#49454F" :
                               textValue == "Critical" ? "#8B0000" :
                               null;

            return !string.IsNullOrEmpty(colorCode) ? (SolidColorBrush)(new BrushConverter().ConvertFrom(colorCode)) : null;
        }

        /// <summary>
        /// Converts a color value back to its corresponding priority string.
        /// </summary>
        /// <param name="value">The value to convert back.</param>
        /// <param name="targetType">The target type of the conversion.</param>
        /// <param name="parameter">An optional parameter for the converter.</param>
        /// <param name="culture">The culture information for the conversion (not used).</param>
        /// <returns>null</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}