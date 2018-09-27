using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using PortfolioManager1.Helpers;

namespace PortfolioManager1.Converter
{
    public class Labelconvertor : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // This is possible during design time load
            if (!(value is Contributions))
                return String.Empty;

            Contributions info = value as Contributions;

            return String.Format("{0} {1}%", info.ExchangeName, info.Value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
