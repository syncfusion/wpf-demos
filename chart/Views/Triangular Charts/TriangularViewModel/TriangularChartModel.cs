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
    /// <summary>Represents a single data item used in pyramid and funnel charts.</summary>
    public class TriangularChartModel
    {
        /// <summary>Gets or sets the category label.</summary>
        public string Category { get; set; }

        /// <summary>Gets or sets the percentage value for the item.</summary>
        public double Percentage { get; set; }

        /// <summary>Gets or sets an optional numeric value associated with the item.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets a formatted percentage text (for display).</summary>
        public string PercentageValue { get; set; }
    }
}
