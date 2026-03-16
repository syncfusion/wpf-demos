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
    /// <summary>Represents a multi-series data point for performance testing.</summary>
    public class TestingValues
    {
        /// <summary>Gets or sets the X value.</summary>
        public double X { get; set; }

        /// <summary>Gets or sets the Y value.</summary>
        public double Y { get; set; }

        /// <summary>Gets or sets the Y1 value.</summary>
        public double Y1 { get; set; }

        /// <summary>Gets or sets the Y2 value.</summary>
        public double Y2 { get; set; }

        /// <summary>Gets or sets the Y3 value.</summary>
        public double Y3 { get; set; }
    }

    /// <summary>Represents a financial data record with date and price values.</summary>
    public class FinancialDataModel
    {
        /// <summary>Gets or sets the date associated with the data point.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the X value.</summary>
        public double X { get; set; }

        /// <summary>Gets or sets the Y value.</summary>
        public double Y { get; set; }

        /// <summary>Gets or sets the Y1 value.</summary>
        public double Y1 { get; set; }

        /// <summary>Gets or sets the Y2 value.</summary>
        public double Y2 { get; set; }

        /// <summary>Gets or sets the Y3 value.</summary>
        public double Y3 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialDataModel"/> class.
        /// </summary>
        public FinancialDataModel() 
        { 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialDataModel"/> class with specified values.
        /// </summary>
        /// <param name="date">Represents the date.</param>
        /// <param name="x">Represents the x value.</param>
        /// <param name="y">Represents the y value.</param>
        /// <param name="y1">Represents the y1 value.</param>
        /// <param name="y2">Represents the y2 value.</param>
        /// <param name="y3">Represents the y3 value.</param>
        public FinancialDataModel(DateTime date, double x, double y, double y1, double y2, double y3)
        {
            Date = date;
            X = x;
            Y = y;
            Y1 = y1;
            Y2 = y2;
            Y3 = y3;
        }
    }
}
