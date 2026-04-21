#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a spline chart data item with high/low or country series values.</summary>
    public class SplineChartModel
    {
        /// <summary>Gets or sets the category name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the high value.</summary>
        public double High { get; set; }

        /// <summary>Gets or sets the low value.</summary>
        public double Low { get; set; }

        /// <summary>Gets or sets the Brazil series value.</summary>
        public double Brazil { get; set; }

        /// <summary>Gets or sets the Sweden series value.</summary>
        public double Sweden { get; set; }

        /// <summary>Gets or sets the Greece series value.</summary>
        public double Greece { get; set; }
    }
}
