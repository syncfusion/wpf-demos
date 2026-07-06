using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Provides value conversion logic for data binding scenarios.</summary>
    public class DegreeFormatConverter : IValueConverter
    {
        /// <summary>Converts a source value to a value suitable for the binding target.</summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var roundValue = string.Format("{0:0.00}", double.Parse(value.ToString()));
            return roundValue + " °C";
        }

        /// <summary>Converts a binding target value back to a value suitable for the source.</summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
