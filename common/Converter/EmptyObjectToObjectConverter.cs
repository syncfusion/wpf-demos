#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// This class converts an object value into a an object (if the value is null returns the false value).
    /// Can be used to bind a visibility, a color or an image to the value of an object.
    /// </summary>
    public class EmptyObjectToObjectConverter : DependencyObject, IValueConverter
    {
        /// <summary>
        /// Identifies the <see cref="NotEmptyValue"/> property.
        /// </summary>
        public static readonly DependencyProperty NotEmptyValueProperty =
            DependencyProperty.Register(nameof(NotEmptyValue), typeof(object), typeof(EmptyObjectToObjectConverter), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the <see cref="EmptyValue"/> property.
        /// </summary>
        public static readonly DependencyProperty EmptyValueProperty =
            DependencyProperty.Register(nameof(EmptyValue), typeof(object), typeof(EmptyObjectToObjectConverter), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the value to be returned when the object is neither null nor empty
        /// </summary>
        public object NotEmptyValue
        {
            get { return GetValue(NotEmptyValueProperty); }
            set { SetValue(NotEmptyValueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the value to be returned when the object is either null or empty
        /// </summary>
        public object EmptyValue
        {
            get { return GetValue(EmptyValueProperty); }
            set { SetValue(EmptyValueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the value indicating  whether the output should be automatically converted to the binding's target type.
        /// </summary>
        public bool CanConvertToTargetType
        {
            get { return (bool)GetValue(CanConvertToTargetTypeProperty); }
            set { SetValue(CanConvertToTargetTypeProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for CanConvertToTargetType.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty CanConvertToTargetTypeProperty =
            DependencyProperty.Register("CanConvertToTargetType", typeof(bool), typeof(EmptyObjectToObjectConverter), new PropertyMetadata(true));


        /// <summary>
        /// Converts an object to the <see cref="NotEmptyValue"/> or <see cref="EmptyValue"/> based on whether it is considered empty.
        /// </summary>
        /// <param name="value">The object to be evaluated. This is the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">Optional parameter. if it evaluates 'true'. the empty/not-empty logic is inverted.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns>The <see cref="EmptyValue"/> if it is empty, otherwise the <see cref="NotEmptyValue"/>.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isEmpty = CheckValueIsEmpty(value);

            if (TypeConverterHelper.ChanngeTypeToBool(parameter))
            {
                isEmpty = !isEmpty;
            }

            if (CanConvertToTargetType)
                return TypeConverterHelper.ChangeType(isEmpty ? EmptyValue : NotEmptyValue, targetType);
            else
                return isEmpty ? EmptyValue : NotEmptyValue;
        }

        /// <summary>
        /// The method is not implemented and will throw an exception if used.
        /// </summary>
        /// <param name="value">The value is produced by the binding target.</param>
        /// <param name="targetType">The type convert to.</param>
        /// <param name="parameter">Optional parameter to use. </param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns>This method does not return a value</returns>
        /// <exception cref="NotImplementedException">Thrown because converting back is not supported by this converter .</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks value for emptiness.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>True if value is null, false otherwise.</returns>
        protected virtual bool CheckValueIsEmpty(object value)
        {
            return value == null;
        }
    }
}