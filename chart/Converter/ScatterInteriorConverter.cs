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
    public class ScatterInteriorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ydata = (value as ScatterSegment).YData;
            Brush interior;

            interior = ydata >= 25 ? new SolidColorBrush(Color.FromArgb(0xFF, 0x2B, 0xD2, 0x6E)) :
               new SolidColorBrush(Color.FromArgb(0xFF, 0xE3, 0x46, 0x5D)); ;

            return interior;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
