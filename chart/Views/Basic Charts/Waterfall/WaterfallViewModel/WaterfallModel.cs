#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a department entry in a waterfall chart.</summary>
    public class WaterfallModel
    {
        /// <summary>Gets or sets the department name.</summary>
        public string Department { get; set; }

        /// <summary>Gets or sets the value contributing to the total.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets a value indicating whether this item is a summary.</summary>
        public bool IsSummary { get; set; }
    }
}
