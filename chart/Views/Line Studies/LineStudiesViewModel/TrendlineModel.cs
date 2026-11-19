#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a stock price data point for trendline calculation.</summary>
    public class TrendlineModel
    {
        /// <summary>Gets or sets the date of the data point.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the stock value at the specified date.</summary>
        public double Value { get; set; }
    }
}
