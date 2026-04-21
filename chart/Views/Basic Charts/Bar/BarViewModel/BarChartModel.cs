#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a bar chart data item with optional comparison values.</summary>
    public class BarChartModel
    {
        /// <summary>Gets or sets the category name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the primary numeric value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the value for September 2021.</summary>
        public double September2021 { get; set; }

        /// <summary>Gets or sets the value for September 2020.</summary>
        public double September2020 { get; set; }
    }
}
