#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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

namespace syncfusion.datagriddemos.wpf
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
}
