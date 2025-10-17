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

        public bool CanConvertToTargetType
        {
            get { return (bool)GetValue(CanConvertToTargetTypeProperty); }
            set { SetValue(CanConvertToTargetTypeProperty, value); }
        }

        public static readonly DependencyProperty CanConvertToTargetTypeProperty =
            DependencyProperty.Register("CanConvertToTargetType", typeof(bool), typeof(BoolToObjectConverter), new PropertyMetadata(true));

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

    internal static class TypeConverterHelper
    {
        internal static bool ChanngeTypeToBool(object parameter)
        {
            var parsed = false;
            if (parameter != null && bool.TryParse(parameter.ToString(), out parsed))
            {
                return parsed;
            }

            return parsed;
        }

        public static object ChangeType(object value, Type type)
        {
            return ChangeType(value, type, null);
        }

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
