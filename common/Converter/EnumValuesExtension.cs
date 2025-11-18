#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// A markup extension that returns a collection of values of a specific <see langword="enum"/>
    /// </summary>
    [MarkupExtensionReturnType(typeof(Array))]
    public sealed class EnumValuesExtension : MarkupExtension
    {
        /// <summary>
        /// Gets or sets the <see cref="System.Type"/> of the target <see langword="enum"/>
        /// </summary>
        public Type Type { get; set; }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(Type);
        }
    }

    /// <summary>
    /// A value converter that retrieves the human-readable display name for the enumeration member.
    /// It prioritizes the <see cref="DisplayAttribute.Name"/> or <see cref="DisplayAttribute.ShortName"/> if available;
    /// otherwise, it falls back to the member's default string represenatation
    /// </summary>
    public class EnumDisplayNameConverter : IValueConverter
    {
        /// <summary>
        /// Converts an enum member to its display name.
        /// </summary>
        /// <param name="value">The enum number to convert.</param>
        /// <param name="targetType">The type of the binding target property (not used).</param>
        /// <param name="parameter">Optional parameter. if it evaluates 'true'. the empty/not-empty logic is inverted.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns>The display name from the <see cref="DisplayAttribute"/> or the enum member's name if the attribute is not present</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.ToString() == "")
                return string.Empty;

            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo != null)
            {
                var attributes = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false);
                if (attributes.Length > 0)
                {
                    var attribute = attributes[0] as DisplayAttribute;
                    if (!String.IsNullOrEmpty(attribute.Name))
                        return attribute.Name;
                    else if (!String.IsNullOrEmpty(attribute.ShortName))
                        return attribute.ShortName;
                }
            }
            return Enum.GetName(value.GetType(), value);
        }

        /// <summary>
        /// This method is not implemented and will throw an exception if used. converting from a display name back to the enum number is not supported
        /// </summary>
        /// <param name="value">The value that is produced by the binding targets.</param>
        /// <param name="targetType">The type to convert.</param>
        /// <param name="parameter">Optional parameter.</param>
        /// <param name="culture">The culture to use in the conversion. Not used</param>
        /// <returns>This method does not return a value</returns>
        /// <exception cref="NotImplementedException">Thrown because converting back is not supported by this converter</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
