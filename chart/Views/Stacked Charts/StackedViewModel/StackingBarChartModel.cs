#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents yearly device sales for stacked bar series.</summary>
    public class StackingBarChartModel
    {
        /// <summary>Gets or sets the year label.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets the iPod sales value.</summary>
        public double iPod { get; set; }

        /// <summary>Gets or sets the iPhone sales value.</summary>
        public double iPhone { get; set; }

        /// <summary>Gets or sets the iPad sales value.</summary>
        public double iPad { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StackingBarChartModel"/> class.
        /// </summary>
        public StackingBarChartModel(string year, double ipod, double iphone, double ipad)
        {
            Year = year;
            iPod = ipod;
            iPhone = iphone;
            iPad = ipad;
        }

    }
}
