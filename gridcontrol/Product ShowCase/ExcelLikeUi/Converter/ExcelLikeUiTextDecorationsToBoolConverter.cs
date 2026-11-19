using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace syncfusion.gridcontroldemos.wpf
{
    public class ExcelLikeUiTextDecorationsToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && (TextDecorationCollection)value == TextDecorations.Underline)
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && (bool)value)
                return TextDecorations.Underline;
            return null;

        }
    }
}
