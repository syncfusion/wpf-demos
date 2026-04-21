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
    /// <summary>Represents a versatile data item used across 3D axis chart demos.</summary>
    public class Axis3DChartsModel
    {
        /// <summary>Gets or sets the country code or name.</summary>
        public string Country { get; set; }

        /// <summary>Gets or sets the year label.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets a generic numeric value (e.g., counts or totals).</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the match round identifier.</summary>
        public string MatchRound { get; set; }

        /// <summary>Gets or sets the score for India.</summary>
        public double IndiaScore { get; set; }

        /// <summary>Gets or sets the score for Australia.</summary>
        public double AustraliaScore { get; set; }

        /// <summary>Gets or sets the sales rate used in logarithmic axis demos.</summary>
        public double SalesRate { get; set; }

        /// <summary>Gets or sets the date for time-based series.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the growth value for the date.</summary>
        public double Growth { get; set; }
    }
}
