using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.datagriddemos.wpf
{
    public class RangeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var range = value as double?;
            if (parameter == null)
            {
                if (range > 50.9)
                    return true;
                else
                    return false;
            }
            else
            {
                var theme = SfSkinManager.GetTheme(parameter as SfDataGrid);
                if (theme != null && theme.ThemeName.Equals("Windows11Light"))
                {
                    if (range > 50.9)
                        return new SolidColorBrush(Color.FromRgb(226, 159, 81));
                    else
                        return new SolidColorBrush(Color.FromRgb(15, 123, 15));
                }
                else if (theme != null && theme.ThemeName.Equals("Windows11Dark"))
                {

                    if (range > 50.9)
                        return new SolidColorBrush(Color.FromRgb(250, 184, 107));
                    else
                        return new SolidColorBrush(Color.FromRgb(108, 203, 95));

                }
                else
                {
                    if (range > 50.9)
                        return new SolidColorBrush(Colors.Orange);
                    else
                        return new SolidColorBrush(Colors.Green);
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return true;
        }
    }
}
