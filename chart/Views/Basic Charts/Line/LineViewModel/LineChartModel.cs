#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a data item for line charts with optional country series.</summary>
    public class LineChartModel
    {
        /// <summary>Gets or sets the category label (e.g., year).</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the primary value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the Singapore series value.</summary>
        public double Singapore { get; set; }

        /// <summary>Gets or sets the Saudi Arabia series value.</summary>
        public double SaudiArabia { get; set; }

        /// <summary>Gets or sets the Spain series value.</summary>
        public double Spain { get; set; }
    }
}
