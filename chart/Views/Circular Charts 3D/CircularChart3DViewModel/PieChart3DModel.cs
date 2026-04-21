#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a 3D circular chart data item.</summary>
    public class PieChart3DModel
    {
        /// <summary>Gets or sets the category name.</summary>
        public string Category { get; set; }

        /// <summary>Gets or sets the percentage or value for the slice.</summary>
        public double Percentage { get; set; }

        /// <summary>Gets or sets the continent name (for earth data).</summary>
        public string Continent { get; set; }
    }
}
