using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.treegriddemos.wpf
{
    public class FilterLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int? index = value as int?;
            if (index == 0)
                return FilterLevel.All;
            else if (index == 1)
                return FilterLevel.Root;
            else
                return FilterLevel.Extended;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
