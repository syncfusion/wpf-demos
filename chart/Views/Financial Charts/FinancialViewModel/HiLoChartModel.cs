#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a high/low data point for HiLo charts.</summary>
    public class HiLoChartModel
    {
        /// <summary>Gets or sets the date of the record.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the high value.</summary>
        public double High { get; set; }

        /// <summary>Gets or sets the low value.</summary>
        public double Low { get; set; }
    }
}
