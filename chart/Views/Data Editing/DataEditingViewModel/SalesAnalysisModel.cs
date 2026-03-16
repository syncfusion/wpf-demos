#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents yearly sales analysis with customers, income, and annotation text.</summary>
    public class SalesAnalysisModel 
    {
        private string text;

        /// <summary>Gets or sets the annotation or note for the record.</summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private double income;

        /// <summary>Gets or sets the income value.</summary>
        public double Income
        {
            get { return income; }
            set { income = value; }
        }

        private double noOfCustomer;

        /// <summary>Gets or sets the number of customers.</summary>
        public double NoOfCustomer
        {
            get { return noOfCustomer; }
            set { noOfCustomer = value; }
        }

        private string year;

        /// <summary>Gets or sets the year label.</summary>
        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesAnalysisModel"/> class with specified values.
        /// </summary>
        /// <param name="year">Represents the year.</param>
        /// <param name="count">Represents the number of customers.</param>
        /// <param name="income">Represents the income.</param>
        /// <param name="text">Represents the text.</param>
        public SalesAnalysisModel(string year, double count, double income, string text)
        {
            Year = year;
            NoOfCustomer = count;
            Income = income;
            Text = text;
        }
    }
}
