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
    /// <summary>Represents a date/price pair for fast bar charts.</summary>
    public class FastBarChartModel
    {
        /// <summary>Gets or sets the data point date.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the price value.</summary>
        public double Price { get; set; }
    }
}
