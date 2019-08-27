#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using Syncfusion.Data;

namespace CustomGroupingDemo
{
    public class CustomSortComparer : IComparer<object>, ISortDirection
    {
        public ListSortDirection SortDirection { get; set; }
        public Comparer _comparer;
        public CustomSortComparer()
        {
            this._comparer = Comparer.Default;
        }

        private int ConverKeyToInt(string Key)
        {
            DayOfWeek dayOfWeek;
            if (Key.Equals("TODAY"))
                return 0;
            else if (Key.Equals("YESTERDAY"))
                return 1;

            if (Enum.TryParse(Key, true, out dayOfWeek))
                return ((int)dayOfWeek * -1) + 7 + 2;
            else if (Key.Equals("LAST WEEK"))
                return 10;
            else if (Key.Equals("TWO WEEKS AGO"))
                return 11;
            else if (Key.Equals("THREE WEEKS AGO"))
                return 12;
            else if (Key.Equals("EARLIER THIS MONTH"))
                return 13;
            else if (Key.Equals("LAST MONTH"))
                return 14;
            else if (Key.Equals("OLDER"))
                return 15;
            return 0;
        }

        public int Compare(object x, object y)
        {
            DateTime namX;
            DateTime namY;
            if (x.GetType() == typeof(SalesByDate))
            {
                namX = ((SalesByDate)x).Date;
                namY = ((SalesByDate)y).Date;
            }
            else if (x.GetType() == typeof(Group))
            {
                int key1, key2;
                key1 = this.ConverKeyToInt((x as Group).Key.ToString());
                key2 = this.ConverKeyToInt((y as Group).Key.ToString());
                var diff = key1.CompareTo(key2);

                if (diff > 0)
                    return SortDirection == ListSortDirection.Ascending ? 1 : -1;
                if (diff == -1)
                    return SortDirection == ListSortDirection.Ascending ? -1 : 1;
                return 0;
            }
            else
            {
                namX = (DateTime)x;
                namY = (DateTime)y;
            }
            var num = this._comparer.Compare(namX, namY);
            if (this.SortDirection == ListSortDirection.Descending)
            {
                num = -num;
            }
            return num;
        }
    }

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
