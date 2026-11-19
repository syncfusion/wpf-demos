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
    /// <summary>Represents a dated data point used for range navigator zooming.</summary>
    public class StockZoomingModel
    {
        /// <summary>Gets or sets the data point date.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the Y-value associated with the date.</summary>
        public double YValue { get; set; }
    }
}
