#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a column chart data item with optional medal counts.</summary>
    public class ColumnChartModel
    {
        /// <summary>Gets or sets the category name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the primary value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the number of gold medals.</summary>
        public double Gold { get; set; }

        /// <summary>Gets or sets the number of silver medals.</summary>
        public double Silver { get; set; }

        /// <summary>Gets or sets the number of bronze medals.</summary>
        public double Bronze { get; set; }
    }
}
