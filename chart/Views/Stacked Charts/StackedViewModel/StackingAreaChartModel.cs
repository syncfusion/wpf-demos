#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents yearly sales values for stacked area series.</summary>
    public class StackingAreaChartModel
    {
        /// <summary>Gets or sets the year label.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets the Chocolate sales value.</summary>
        public double Chocolate { get; set; }

        /// <summary>Gets or sets the Sugar Confectionery sales value.</summary>
        public double SugerConfectionery { get; set; }

        /// <summary>Gets or sets the Biscuits sales value.</summary>
        public double Biscuits { get; set; }
    }
}
