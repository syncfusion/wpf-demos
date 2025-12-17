using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.datagriddemos.wpf
{
    public class GridRowAndColumnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var selectedIndex = (int)value;
            if (parameter != null && parameter.ToString() == "Row")
                return selectedIndex == 0 ? 1 : 0;

            return selectedIndex == 0 ? 0 : 1;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
