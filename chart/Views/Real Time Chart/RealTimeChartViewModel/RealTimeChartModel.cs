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
    /// <summary>Represents a single real-time data point.</summary>
    public class RealTimeChartModel
    {
        /// <summary>Gets or sets the timestamp of the data point.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the numeric value.</summary>
        public double Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RealTimeChartModel"/> class.
        /// </summary>
        /// <param name="date">The date associated with the chart data point.</param>
        /// <param name="value">The numeric value corresponding to the chart data point.</param>
        public RealTimeChartModel(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }
    }
}
