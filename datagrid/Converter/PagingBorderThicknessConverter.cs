using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.datagriddemos.wpf
{
    public class PagingBorderThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int selectedIndex = (int)value;
            if (selectedIndex == 0)
                return new Thickness(1, 0, 1, 1);
            else
                return new Thickness(0, 1, 1, 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
