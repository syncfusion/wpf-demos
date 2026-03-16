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
    /// <summary>Represents a single time-series data point.</summary>
    public class Data
    {
        /// <summary>Gets or sets the timestamp.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the numeric value at the timestamp.</summary>
        public double Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data"/> class with the specified date and value.
        /// </summary>
        public Data(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }

       
    }
}
