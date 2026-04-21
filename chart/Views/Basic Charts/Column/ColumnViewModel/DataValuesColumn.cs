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
    /// <summary>Represents a category with two values for column comparisons.</summary>
    public class DataValuesColumn
    {
        /// <summary>Gets or sets the gadget name.</summary>
        public string Gadget { get; set; }

        /// <summary>Gets or sets the month label.</summary>
        public string Month { get; set; }

        /// <summary>Gets or sets the first value.</summary>
        public double Value1 { get; set; }

        /// <summary>Gets or sets the second value.</summary>
        public double Value2 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataValuesColumn"/> class.
        /// </summary>
        /// <param name="gadget">Represents the gadget name.</param>
        /// <param name="month">Represents the month label.</param>
        /// <param name="value1">Represents the first value.</param>
        /// <param name="value2">Represents the second value.</param>
        public DataValuesColumn(string gadget, string month, double value1, double value2)
        {
            Gadget = gadget;
            Value1 = value1;
            Value2 = value2;
            Month = month;
        }
    }
}
