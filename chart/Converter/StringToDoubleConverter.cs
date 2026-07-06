using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Provides value conversion logic for data binding scenarios.</summary>
    public class StringToDoubleConverter : IValueConverter
    {
        /// <summary>Converts a source value to a value suitable for the binding target.</summary>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double doubleValue = 0;
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                doubleValue = double.Parse(value.ToString());
            }
            return doubleValue;
        }

        /// <summary>Converts a binding target value back to a value suitable for the source.</summary>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
