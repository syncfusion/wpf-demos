#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a single data point with time and velocity.</summary>
    public class VerticalChartModel
    {
        /// <summary>Gets or sets the timestamp of the data point.</summary>
        public DateTime Time { get; set; }

        /// <summary>Gets or sets the velocity value.</summary>
        public double Velocity { get; set; }
    }
}
