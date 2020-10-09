#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Data;
using System.Globalization;
using Syncfusion.UI.Xaml.Grid.Cells;
using System.Windows;
using System.Windows.Data;


namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Date-Range Enum provides the Option for the Date-Time Column Grouping When the GroupMode is Range.
    /// </summary>
    public enum DateRange
    {
        BeyondNextMonth = 0,
        NextMonth = 1,
        LaterofThisMonth = 2,
        ThreeWeeksAway = 3,
        TwoWeeksAway = 4,
        NextWeek = 5,
        Sunday = 6,
        Monday = 7,
        TuesDay = 8,
        WednesDay = 9,
        Thursday = 10,
        Friday = 11,
        Saturday = 12,
        Tomorrow = 13,
        Today = 14,
        Yesterday = 15,
        LastWeek = 23,
        TwoWeeksAgo = 24,
        ThreeWeeksAgo = 25,
        EarlierofthisMonth = 26,
        LastMonth = 27,
        Older = 28
    }

    /// <summary>
    /// GroupingMode provide the options for the Grouping of Date-Time column.
    /// </summary>
    public enum DateGroupingMode
    {
        Range,
        Month,
        Year
    } 
}
