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
    /// <summary>Represents a date with high/low values for range area charts.</summary>
    public class RangeAreaChartModel
    {
        /// <summary>Gets or sets the date.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the high value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the low value.</summary>
        public double Size { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RangeAreaChartModel"/> class.
        /// </summary>
        /// <param name="date">Represents the date.</param>
        /// <param name="value">Represents the value.</param>
        /// <param name="size">Represents the size.</param>
        public RangeAreaChartModel(DateTime date, double value, double size)
        {
            Date = date;
            Value = value;
            Size = size;
        }
    }
}
