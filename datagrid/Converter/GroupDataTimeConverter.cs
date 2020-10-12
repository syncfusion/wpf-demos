#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.datagriddemos.wpf
{
    public class GroupDataTimeConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var saleinfo = value as SalesByDate;
            var dt = DateTime.Now;
            var days = (int)Math.Floor((dt - saleinfo.Date).TotalDays);
            var dayofweek = (int)dt.DayOfWeek;
            var diff = days - dayofweek;

            if (days <= dayofweek)
            {
                if (days == 0)
                    return "TODAY";
                if (days == 1)
                    return "YESTERDAY";
                return saleinfo.Date.DayOfWeek.ToString().ToUpper();
            }
            if (diff > 0 && diff <= 7)
                return "LAST WEEK";
            if (diff > 7 && diff <= 14)
                return "TWO WEEKS AGO";
            if (diff > 14 && diff <= 21)
                return "THREE WEEKS AGO";
            if (dt.Year == saleinfo.Date.Year && dt.Month == saleinfo.Date.Month)
                return "EARLIER THIS MONTH";
            if (DateTime.Now.AddMonths(-1).Month == saleinfo.Date.Month)
                return "LAST MONTH";
            return "OLDER";
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
