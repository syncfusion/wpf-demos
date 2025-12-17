using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.datagriddemos.wpf
{
    public class StyleConverterforQuantity : IValueConverter
    {
       internal ConditionalFormattingDetailsViewDataGridDemo detailsViewDataGridDemo;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (detailsViewDataGridDemo == null)
                detailsViewDataGridDemo = (ConditionalFormattingDetailsViewDataGridDemo)Activator.CreateInstance(typeof(ConditionalFormattingDetailsViewDataGridDemo));
            double _value;
            if (!String.IsNullOrEmpty(value.ToString()))
            {
                _value = double.Parse(value.ToString(), NumberStyles.Currency, culture);
                if (_value < 6)
                    return detailsViewDataGridDemo.Resources["Brush1"];
            }
            return new SolidColorBrush();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
