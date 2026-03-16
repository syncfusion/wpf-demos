#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a single histogram sample with an optional size bucket.</summary>
    public class HistogramChartModel
    {
        /// <summary>Gets or sets the sample value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets an optional size value.</summary>
        public double Size { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HistogramChartModel"/> class.
        /// </summary>
        /// <param name="value">Represents the sample value.</param>
        /// <param name="size">Represents the size value.</param>
        public HistogramChartModel(double value, double size)
        {
            Value = value;
            Size = size;
        }
    }
}
