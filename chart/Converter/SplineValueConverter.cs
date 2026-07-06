using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Provides value conversion logic for data binding scenarios.</summary>
    public class SplineValueConverter : IValueConverter
    {
        /// <summary>Converts a source value to a value suitable for the binding target.</summary>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ydata = (value as SplineSegment).YData;
            Brush interior;

            interior = ydata > 0 ?
                new SolidColorBrush(Color.FromArgb(0xFF, 0xFE, 0xBE, 0x19)) :
                new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xAE, 0xE0));

            return interior;
        }

        /// <summary>Converts a binding target value back to a value suitable for the source.</summary>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
