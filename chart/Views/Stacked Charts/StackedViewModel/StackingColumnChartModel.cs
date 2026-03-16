#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a country's medal counts for stacked column charts.</summary>
    public class StackingColumnChartModel
    {
        /// <summary>Gets or sets the country name.</summary>
        public string CountryName { get; set; }

        /// <summary>Gets or sets the number of gold medals.</summary>
        public double GoldMedals { get; set; }

        /// <summary>Gets or sets the number of silver medals.</summary>
        public double SilverMedals { get; set; }

        /// <summary>Gets or sets the number of bronze medals.</summary>
        public double BronzeMedals { get; set; }
    }
}
