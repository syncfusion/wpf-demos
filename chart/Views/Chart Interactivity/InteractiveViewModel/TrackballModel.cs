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
    /// <summary>Represents a sales data point for multiple persons on a specific date.</summary>
    public class TrackballModel
    {
        /// <summary>Gets or sets the date of the data point.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the value for Person 1.</summary>
        public double Person1 { get; set; }

        /// <summary>Gets or sets the value for Person 2.</summary>
        public double Person2 { get; set; }

        /// <summary>Gets or sets the value for Person 3.</summary>
        public double Person3 { get; set; }
    }
}
