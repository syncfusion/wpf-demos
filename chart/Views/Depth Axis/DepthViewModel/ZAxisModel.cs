#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a 3D chart data item for fruit count by day.</summary>
    public class ZAxisModel
    {
        /// <summary>Gets or sets the name of the fruit.</summary>
        public string FruitsName { get; set; }

        /// <summary>Gets or sets the day label associated with the data point.</summary>
        public string Day { get; set; }

        /// <summary>Gets or sets the count value for the fruit.</summary>
        public double Count { get; set; }
    }
}
