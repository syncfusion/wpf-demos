#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents an energy production data point with an optional high value.</summary>
    public class EnergyProduction
    {
        /// <summary>Gets or sets the category or code.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the measured value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the high/error value.</summary>
        public double High { get; set; }
    }
}
