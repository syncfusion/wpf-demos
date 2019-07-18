#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSorting
{   
    public class CustomComparer : IComparer<object>, ISortDirection
    {
        public int Compare(object x, object y)
        {
            var item1 = x as PersonInfo;
            var item2 = y as PersonInfo;
            var value1 = item1.FirstName;
            var value2 = item2.FirstName;
            int c = 0;
            if (value1 != null && value2 == null)
            {
                c = 1;
            }
            else if (value1 == null && value2 != null)
            {
                c = -1;
            }
            else if (value1 != null && value2 != null)
            {
                c = value1.Length.CompareTo(value2.Length);
            }

            if (SortDirection == ListSortDirection.Descending)
                c = -c;

            return c;   
        }

        //Get or Set the SortDirection value
        private ListSortDirection _SortDirection;
        public ListSortDirection SortDirection
        {
            get { return _SortDirection; }
            set { _SortDirection = value; }
        }
    }
}
