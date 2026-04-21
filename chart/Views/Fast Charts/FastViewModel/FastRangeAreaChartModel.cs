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
    /// <summary>Represents a date with high/low temperatures for range area charts.</summary>
    public class FastRangeAreaChartModel
    {
        /// <summary>Gets or sets the date.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the low temperature.</summary>
        public double LowTemperature { get; set; }

        /// <summary>Gets or sets the high temperature.</summary>
        public double HighTemperature { get; set; }
    }
}
