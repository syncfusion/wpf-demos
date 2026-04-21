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
    /// <summary>Represents a date/value pair for fast line charts.</summary>
    public class FastLineChartModel
    {
        /// <summary>Gets or sets the data point date.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the numeric value.</summary>
        public double Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FastLineChartModel"/> class.
        /// </summary>
        /// <param name="date">Represents the date.</param>
        /// <param name="value">Represents the value.</param>
        public FastLineChartModel(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }
    }
}
