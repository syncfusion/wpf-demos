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
    public class PagingMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int selectedIndex = (int)value;
            var param = parameter.ToString();
            if (param == "SfDataPager")
            {
                if (selectedIndex == 0)
                    return new Thickness(5, 0, 5, 5);
                else
                    return new Thickness(0, 5, 5, 5);
            }
            else
            {
                if (selectedIndex == 0)
                    return new Thickness(5, 5, 5, 0);
                else
                    return new Thickness(5, 5, 0, 5);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
