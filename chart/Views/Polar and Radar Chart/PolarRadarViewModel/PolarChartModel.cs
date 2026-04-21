#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents data for polar (year/products) and radar (direction/species) charts.</summary>
    public class PolarChartModel
    {
        // Polar
        /// <summary>Gets or sets the year label.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets the value for Product A.</summary>
        public double ProductA { get; set; }

        /// <summary>Gets or sets the value for Product B.</summary>
        public double ProductB { get; set; }

        /// <summary>Gets or sets the value for Product C.</summary>
        public double ProductC { get; set; }

        // Radar
        /// <summary>Gets or sets the compass direction.</summary>
        public string Direction { get; set; }

        /// <summary>Gets or sets the weed value.</summary>
        public double Weed { get; set; }

        /// <summary>Gets or sets the flower value.</summary>
        public double Flower { get; set; }

        /// <summary>Gets or sets the tree value.</summary>
        public double Tree { get; set; }
    }
}
