using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// A Value converter that adds a specified prefix and/or suffix string to an input value.
    /// </summary>
    public class PrefixSuffixConverter : DependencyObject, IValueConverter
    {
        /// <summary>
        /// Gets or sets the string that is prepended to the input value
        /// </summary>
        public string PrefixString
        {
            get { return (string)GetValue(PrefixStringProperty); }
            set { SetValue(PrefixStringProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="PrefixString"/> depedency property
        /// </summary>
        public static readonly DependencyProperty PrefixStringProperty =
            DependencyProperty.Register("PrefixString", typeof(string), typeof(PrefixSuffixConverter), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets the string that is appended to the input value
        /// </summary>
        public string SuffixString
        {
            get { return (string)GetValue(SuffixStringProperty); }
            set { SetValue(SuffixStringProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SuffixString"/> depedency property
        /// </summary>
        public static readonly DependencyProperty SuffixStringProperty =
            DependencyProperty.Register("SuffixString", typeof(string), typeof(PrefixSuffixConverter), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Converts the input value to a string and concatenated the <see cref="PrefixString"/> and <see cref="SuffixString"/>.
        /// </summary>
        /// <param name="value">The input value is to be formatted. This is a binding source.</param>
        /// <param name="targetType">The type of the binding target property (not used).</param>
        /// <param name="parameter">Optional converter parameter.</param>
        /// <param name="culture">The language of the conversion. Not used</param>
        /// <returns>A formatted  string in the form of "Prefix[Value]Suffix". Return an empty string if the input value is null.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            return PrefixString + value.ToString() + SuffixString;
        }

        /// <summary>
        /// This method is not implemented and will throw an exception if used. Converted back from the formatted string is not supported.
        /// </summary>
        /// <param name="value">The value that is produced by the binding targets.</param>
        /// <param name="targetType">The type to convert.</param>
        /// <param name="parameter">Optional parameter.</param>
        /// <param name="culture">The culture to use in the conversion. Not used</param>
        /// <exception cref="NotImplementedException">Thrown because converting back is not supported by this converter</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
