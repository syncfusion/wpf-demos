#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a time-based data point used in auto-scrolling charts.</summary>s
    public class ChartAutoScrollingModel
    {
        /// <summary>Gets or sets the timestamp (speed) for the data point.</summary>
        public DateTime Speed { get; set; }

        /// <summary>Gets or sets the rate value at the specified time.</summary>
        public double Rate { get; set; }
    }
}
