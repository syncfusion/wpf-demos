using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.weatheranalysis.wpf
{
    public class LabelVisibility : IValueConverter
    {
        private List<double> valueList = new List<double>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;
            var labelValue = value as string;

            double doubleValue = double.Parse(labelValue);

            this.valueList.Add(doubleValue);

            bool isIndexOdd = this.valueList.Count % 2 != 0;
            return isIndexOdd ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
