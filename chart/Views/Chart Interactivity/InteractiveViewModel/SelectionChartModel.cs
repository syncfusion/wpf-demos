#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a country's population distribution by age group.</summary>
    public class SelectionChartModel
    {
        /// <summary>Gets or sets the country code.</summary>
        public string Country { get; set; }

        /// <summary>Gets or sets the percentage of children.</summary>
        public double Children { get; set; }

        /// <summary>Gets or sets the percentage of adults.</summary>
        public double Adults { get; set; }

        /// <summary>Gets or sets the percentage of elders.</summary>
        public double Elders { get; set; }
    }
}
