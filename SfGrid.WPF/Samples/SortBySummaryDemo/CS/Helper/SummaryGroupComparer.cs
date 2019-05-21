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

namespace SortBySummaryDemo
{
    public class SumAggregateComparer : IComparer<Group>, ISortDirection
    {
        public ListSortDirection SortDirection { get; set; }
        public int Compare(Group x, Group y)
        {
            //To handle the groups that are not in view
            if (x.ItemsCount == 0 && y.ItemsCount == 0)
                return 0;
            else if (x.ItemsCount == 0)
                return -1;
            else if (y.ItemsCount == 0)
                return 1;

            int cmp = 0;
            var xgroupSummarry = Convert.ToDouble((x as Group).GetSummaryValue(x.SummaryDetails.SummaryRow.SummaryColumns[0].MappingName, "Sum"));
            var ygroupSummarry = Convert.ToDouble((y as Group).GetSummaryValue(y.SummaryDetails.SummaryRow.SummaryColumns[0].MappingName, "Sum"));
            cmp = ((IComparable)xgroupSummarry).CompareTo(ygroupSummarry);
            if (this.SortDirection == ListSortDirection.Descending)
                cmp = -cmp;
            return cmp;
        }
    }

    public class AvgAggregateGroupComparer : IComparer<Group>, ISortDirection
    {
        public ListSortDirection SortDirection { get; set; }
        public int Compare(Group x, Group y)
        {
            //To handle the groups that are not in view
            if (x.ItemsCount == 0 && y.ItemsCount == 0)
                return 0;
            else if (x.ItemsCount == 0)
                return -1;
            else if (y.ItemsCount == 0)
                return 1;

            int cmp = 0;
            var xgroupSummarry = Convert.ToDouble((x as Group).GetSummaryValue(x.SummaryDetails.SummaryRow.SummaryColumns[1].MappingName, "Average"));
            var ygroupSummarry = Convert.ToDouble((y as Group).GetSummaryValue(y.SummaryDetails.SummaryRow.SummaryColumns[1].MappingName, "Average"));
            cmp = ((IComparable)xgroupSummarry).CompareTo(ygroupSummarry);
            if (this.SortDirection == ListSortDirection.Descending)
                cmp = -cmp;
            return cmp;
        }
    }
}
