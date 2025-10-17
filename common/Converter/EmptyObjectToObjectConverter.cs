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

        public bool CanConvertToTargetType
        {
            get { return (bool)GetValue(CanConvertToTargetTypeProperty); }
            set { SetValue(CanConvertToTargetTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanConvertToTargetType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanConvertToTargetTypeProperty =
            DependencyProperty.Register("CanConvertToTargetType", typeof(bool), typeof(EmptyObjectToObjectConverter), new PropertyMetadata(true));



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