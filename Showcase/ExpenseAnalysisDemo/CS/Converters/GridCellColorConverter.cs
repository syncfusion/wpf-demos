using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace ExpenseAnalysisDemo
{
    class GridCellColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var source = value as ExpenseData;
            var brushCoverter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)brushCoverter.ConvertFromString("#333333");
            if (source == null)
                return brush;
            if (source.AccountType == AccountType.Positve)
                return Brushes.Green;
            else
                return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
