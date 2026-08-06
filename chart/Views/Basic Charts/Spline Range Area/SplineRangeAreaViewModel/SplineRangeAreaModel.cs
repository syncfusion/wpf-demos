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
    /// <summary>Represents a date with high and low values for spline range area charts.</summary>
    public class SplineRangeAreaModel
    {
        /// <summary>Gets or sets the date.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the high value.</summary>
        public double High { get; set; }

        /// <summary>Gets or sets the low value.</summary>
        public double Low { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SplineRangeAreaModel"/> class.
        /// </summary>
        /// <param name="date">Represents the date.</param>
        /// <param name="high">Represents the high value.</param>
        /// <param name="low">Represents the low value.</param>
        public SplineRangeAreaModel(DateTime date, double high, double low)
        {
            Date = date;
            High = high;
            Low = low;
        }
    }
}
