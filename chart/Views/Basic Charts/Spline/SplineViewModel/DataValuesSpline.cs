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
    /// <summary>Represents monthly values for a multi-series spline chart.</summary>
    public class DataValuesSpline
    {
        /// <summary>Gets or sets the month.</summary>
        public DateTime Month { get; set; }

        /// <summary>Gets or sets the first value.</summary>
        public double Value1 { get; set; }

        /// <summary>Gets or sets the second value.</summary>
        public double Value2 { get; set; }

        /// <summary>Gets or sets the third value.</summary>
        public double Value3 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataValuesSpline"/> class.
        /// </summary>
        /// <param name="month">Represents the month.</param>
        /// <param name="value1">Represents the first value.</param>
        /// <param name="value2">Represents the second value.</param>
        /// <param name="value3">Represents the third value.</param>
        public DataValuesSpline(DateTime month, double value1, double value2, double value3)
        {
            Month = month;
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
        }
    }
}
