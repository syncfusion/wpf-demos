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
    /// <summary>Represents a dated stock value for crosshair interaction.</summary>
    public class CrosshairModel
    {
        /// <summary>Gets or sets the data point date.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the stock value at the date.</summary>
        public double StockValue { get; set; }
    }
}
