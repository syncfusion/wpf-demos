#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a yearly value that may be empty for empty-point demos.</summary>
    public class EmptyPointSupportModel
    {
        /// <summary>Gets or sets the year label.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets the value for the count.</summary>
        public double? Count { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyPointSupportModel"/> class.
        /// </summary>
        /// <param name="year">Represents the year label.</param>
        /// <param name="count">Represents the count.</param>
        public EmptyPointSupportModel(string year, double? count)
        {
            Year = year;
            Count = count;
        }
    }
}
