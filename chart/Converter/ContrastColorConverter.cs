using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Provides value conversion logic for data binding scenarios.</summary>
    public class ContrastColorConverter : IValueConverter
    {
        /// <summary>Converts a source value to a value suitable for the binding target.</summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ChartAdornment dataLabel && targetType == typeof(Brush))
            {
                if (dataLabel.Foreground is SolidColorBrush solidColorBrush)
                {
                    var color = solidColorBrush.Color;
                    var colorBrightness = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

                    return colorBrightness < 0.5 ? new SolidColorBrush(Colors.Black) : new SolidColorBrush(Colors.White);
                }
            }

            return new SolidColorBrush(Colors.Black);

        }

        /// <summary>Converts a binding target value back to a value suitable for the source.</summary>s
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
