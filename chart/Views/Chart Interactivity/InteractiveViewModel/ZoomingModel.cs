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
    /// <summary>Represents a single data point for zooming charts.</summary>
    public class ZoomingModel
    {
        /// <summary>Gets or sets the date associated with the data point.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the numeric value for the data point.</summary>
        public double Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZoomingModel"/> class.
        /// </summary>
        /// <param name="dateTime">Represents the date.</param>
        /// <param name="value">Represents the value.</param>
        public ZoomingModel(DateTime dateTime, double value)
        {
            Date = dateTime;
            Value = value;
        }
    } 
}
