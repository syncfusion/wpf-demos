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
    /// <summary>Represents a month/value pair for bar charts.</summary>
    public class DataValuesBar
    {
        /// <summary>Gets or sets the month label.</summary>
        public string Month { get; set; }

        /// <summary>Gets or sets the numeric value.</summary>
        public double Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataValuesBar"/> class.
        /// </summary>
        /// <param name="month">Represents the month label.</param>
        /// <param name="value1">Represents the numeric value.</param>
        public DataValuesBar(string month, double value1 )
        {
            Month = month;
            Value = value1;
        }
    }   
}
