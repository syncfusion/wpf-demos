#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a single pie chart data item.</summary>
    public class PieChartModel
    {
        /// <summary>Gets or sets the slice name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the slice value.</summary>
        public double Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PieChartModel"/> class.
        /// </summary>
        /// <param name="name">Represents the slice name.</param>
        /// <param name="value">Represents the slice value.</param>
        public PieChartModel(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}
