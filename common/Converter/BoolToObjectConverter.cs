#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Collections.Generic;
using System.Windows.Media;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// This class converts a boolean value into an other object.
    /// Can be used to convert true/false to visibility, a couple of colors, couple of images, etc.
    /// </summary>
    public class BoolToObjectConverter : DependencyObject, IValueConverter
    {
        /// <summary>
        /// Identifies the <see cref="TrueValue"/> property.
        /// </summary>
        public static readonly DependencyProperty TrueValueProperty =
            DependencyProperty.Register(nameof(TrueValue), typeof(object), typeof(BoolToObjectConverter), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the <see cref="FalseValue"/> property.
        /// </summary>
        public static readonly DependencyProperty FalseValueProperty =
            DependencyProperty.Register(nameof(FalseValue), typeof(object), typeof(BoolToObjectConverter), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the value to be returned when the boolean is true
        /// </summary>
        public object TrueValue
        {
            get { return GetValue(TrueValueProperty); }
            set { SetValue(TrueValueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the value to be returned when the boolean is false
        /// </summary>
        public object FalseValue
        {
            get { return GetValue(FalseValueProperty); }
            set { SetValue(FalseValueProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the output be converted to the binding's target type. 
        /// </summary>
        public bool CanConvertToTargetType
        {
            get { return (bool)GetValue(CanConvertToTargetTypeProperty); }
            set { SetValue(CanConvertToTargetTypeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="CanConvertToTargetType"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CanConvertToTargetTypeProperty =
            DependencyProperty.Register("CanConvertToTargetType", typeof(bool), typeof(BoolToObjectConverter), new PropertyMetadata(true));

        /// <summary>
        /// Converts a boolean value to the <see cref="TrueValue"/> or <see cref="FalseValue"/>.
        /// </summary>
        /// <param name="value">The Boolean value to convert. This is the binding source.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">Optional parameter. Not used.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns>The <see cref="TrueValue"/> if the boolean is true, otherwise the <see cref="FalseValue"/>. </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = value is bool && (bool)value;

            if (TypeConverterHelper.ChanngeTypeToBool(parameter))
            {
                boolValue = !boolValue;
            }

            if (CanConvertToTargetType)
                return TypeConverterHelper.ChangeType(boolValue ? TrueValue : FalseValue, targetType);
            else
                return boolValue? TrueValue : FalseValue;
        }

        /// <summary>
        /// Converts a value from the target back to the boolean.
        /// </summary>
        /// <param name="value">The object to convert back. This is the binding target.</param>
        /// <param name="targetType">The type to convert to (usually boolean).</param>
        /// <param name="parameter">Optional parameter. if it is evaluated tp 'true', the boolean logic is inverted.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns>A boolean value indicating whether the input object matched the <see cref="TrueValue"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = Equals(value, TypeConverterHelper.ChangeType(TrueValue, value.GetType()));

            if (TypeConverterHelper.ChanngeTypeToBool(parameter))
            {
                result = !result;
            }

            return result;
        }
    }


    /// <summary>
    /// Provides internal helper methods for type conversion
    /// </summary>
    internal static class TypeConverterHelper
    {
        /// <summary>
        /// Converts an object to a boolean value by parsing its string representation.
        /// </summary>
        /// <param name="parameter">The object to convert.</param>
        /// <returns> <c>true</c> if the object's string represenation is "true" (case-insensitive); <c>false</c>.</returns>
        internal static bool ChanngeTypeToBool(object parameter)
        {
            var parsed = false;
            if (parameter != null && bool.TryParse(parameter.ToString(), out parsed))
            {
                return parsed;
            }

            return parsed;
        }

        /// <summary>
        /// Converts a value to a specified type without a format provider.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The type to convert the value to.</param>
        /// <returns>The coverted object</returns>
        public static object ChangeType(object value, Type type)
        {
            return ChangeType(value, type, null);
        }

        /// <summary>
        /// Converts a value to a specified type with special handling for a certain types.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="type">The type to convert the value to.</param>
        /// <param name="provider">An IFormatProvider interface implementation.</param>
        /// <returns>The coverted object</returns>
        public static object ChangeType(object value, Type type, IFormatProvider provider)
        {
            if (type == null)
                return value;

            if (value == null)
                return null;

            if (type.FullName.Contains("System.Collections.Generic.IComparer`1[[Syncfusion.Data.Group"))
            {
                return value;
            }
             
            if (type == typeof(ImageSource))
            {
                return value;
            }

            TypeConverter typeConverter = TypeDescriptor.GetConverter(value.GetType());
            if (typeConverter != null && typeConverter.CanConvertTo(type))
                return typeConverter.ConvertTo(value, type);

            if (value is DBNull)
                return DBNull.Value;


            if (type.IsEnum)
            {
                return Enum.Parse(type, Convert.ToString(value));
            }
            return Convert.ChangeType(value, type, provider);
        }
    }
}
