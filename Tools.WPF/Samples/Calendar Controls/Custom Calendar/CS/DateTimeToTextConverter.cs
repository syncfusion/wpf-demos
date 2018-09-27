using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace LookAndFeel
{
    class DateTimeToTextConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime Date = (DateTime)value;
            return Date.ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string date = (string)value;
            DateTime result = DateTime.Parse(date);
            return result;
        }

        #endregion
    }
}
