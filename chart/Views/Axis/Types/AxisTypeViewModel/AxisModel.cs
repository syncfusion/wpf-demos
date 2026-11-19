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
    /// <summary>Represents a versatile data item used across axis type demos.</summary>
    public class AxisModel
    {
        /// <summary>Gets or sets the country name.</summary>
        public string CountryName { get; set; }

        /// <summary>Gets or sets the year label.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets the internet users rate.</summary>
        public double InternetUsersRate { get; set; }

        /// <summary>Gets or sets the match round identifier.</summary>
        public string MatchRound { get; set; }

        /// <summary>Gets or sets India's score.</summary>
        public double IndiaScore { get; set; }

        /// <summary>Gets or sets Australia's score.</summary>
        public double AustraliaScore { get; set; }

        /// <summary>Gets or sets the date value.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the dollar value for currency demos.</summary>
        public double DollerValue { get; set; }

        /// <summary>Gets or sets the sales rate used in log and category axes.</summary>
        public double SalesRate { get; set; }
    }
}
