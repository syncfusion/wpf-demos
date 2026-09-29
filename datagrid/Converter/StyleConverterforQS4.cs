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
    public class StyleConverterforQS4 : IValueConverter
    {
        internal ConditionalFormattingDemo conditionalFormattingDemo;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (conditionalFormattingDemo == null)
                conditionalFormattingDemo = (ConditionalFormattingDemo)Activator.CreateInstance(typeof(ConditionalFormattingDemo));
            double _value;
            if (!String.IsNullOrEmpty(value as string))
            {
                _value = double.Parse(value.ToString(), NumberStyles.Currency);
                if (_value < 6600000 && _value > 1000000)
                    return conditionalFormattingDemo.Resources["Brush3"];
            }
            return new SolidColorBrush();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
