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
    /// <summary>Represents a monthly sales data point for scatter editing.</summary>
    public class ScatterDataEditingModel
    {
        private DateTime month;

        /// <summary>Gets or sets the month of the record.</summary>
        public DateTime Month
        {
            get { return month; }
            set { month = value; }
        }
        
        private double saleCount;

        /// <summary>Gets or sets the sales count for the month.</summary>
        public double SaleCount
        {
            get { return saleCount; }
            set { saleCount = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScatterDataEditingModel"/> class.
        /// </summary>
        /// <param name="actualMonth">Represents the actual month.</param>
        /// <param name="actualSaleCount">Represents the actual sale count.</param>
        public ScatterDataEditingModel(DateTime actualMonth, double actualSaleCount)
        {
            month = actualMonth;
            saleCount = actualSaleCount;
        }
    }
}
