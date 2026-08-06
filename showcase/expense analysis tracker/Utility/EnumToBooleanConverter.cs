using Syncfusion.Data.Extensions;
using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.expenseanalysis.wpf
{
    /// <summary>
    /// Convert an enum value to a boolean.
    /// </summary>
    public class EnumToBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Converts an enum value to a boolean.
        /// </summary>
        /// <param name="value">The Boolean value to convert. This is the binding source.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">Optional parameter. Not used.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns><c>True</c> if the value equals the parameter; otherwise, returns <c>false</c>.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(parameter);
        }

        /// <summary>
        /// Converts an boolean value to an enum value.
        /// </summary>
        /// <param name="value">The Boolean value to convert. This is the binding source.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">Optional parameter. Not used.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns>The enum value if <c>True</c>; otherwise, <see cref="Binding.DoNothing"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }

    /// <summary>
    /// A value converter that filters a list by taking a specified number of items from the beginning.
    /// </summary>
    public class ItemsSourceTakeFilter : IValueConverter
    {
        /// <summary>
        /// Converts a source list to a subset containing only the first N items.
        /// </summary>
        /// <param name="value">The Boolean value to convert. This is the binding source.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">Optional parameter. Not used.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns>A filtered list containing the first N items, or <c>null</c> if the input is not a list.</returns>  
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is IList)
            {
                var items = (IList)value;
                return items.ToList<object>().Take(int.Parse(parameter.ToString()));
            }
            return null;
        }

        /// <summary>
        /// Not implemented. This converter does not support converting back from the filtered list.
        /// </summary>
        /// <param name="value">The Boolean value to convert. This is the binding source.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">Optional parameter. Not used.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns>Throws <see cref="NotImplementedException"/>.</returns>  
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// A value converter that retrieves an icon resource from a <see cref="ResourceDictionary"/> based on the provided key.
    /// </summary>
    public class IconResourceConverter : IValueConverter
    {
        /// <summary>
        /// Gets or sets the resource dictionary containing icon resources.
        /// </summary>
        public ResourceDictionary Resource { get; set; }

        /// <summary>
        /// Converts a key value to a corresponding resource from the <see cref="Resource"/> dictionary.
        /// </summary>
        /// <param name="value">The Boolean value to convert. This is the binding source.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">Optional parameter. Not used.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns>The resource associated with the key, or the "Daily" resource if the key is null or not found.</returns>  
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Resource[value??""] ?? Resource["Daily"];
        }

        /// <summary>
        /// Not implemented. This converter does not support converting back from the resource to a key.
        /// </summary>
        /// <param name="value">The Boolean value to convert. This is the binding source.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">Optional parameter. Not used.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns>Throws <see cref="NotImplementedException"/>.</returns>  
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// A value converter that calculates the percentage value for chart legend labels.
    /// </summary>
    public class ChartLegendLabelConverter : IValueConverter
    {
        /// <summary>
        /// Converts a  <see cref="CategoryExpense"/> or a collection of them into a percentge value.
        /// </summary>
        /// <param name="value">The Boolean value to convert. This is the binding source.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">Optional parameter. Not used.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns>The percentage value or the sum of percentages, depending on the input types.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is CategoryExpense)
            {
                return (value as CategoryExpense).Percentage;
            }
            if(value is IEnumerable)
            {
                return (value as IEnumerable).OfType<CategoryExpense>().Select(c => c.Percentage).Sum();
            }
            return 0;
        }


        /// <summary>
        /// Not implemented. This converter does not support converting back.
        /// </summary>
        /// <param name="value">The Boolean value to convert. This is the binding source.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">Optional parameter. Not used.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns>Throws <see cref="NotImplementedException"/>.</returns>  
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}