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
    /// <summary>Represents a doughnut chart data item with optional icon or path.</summary>
    public class DoughnutChartModel
    {
        /// <summary>Gets or sets the category name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the numeric value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the image used for the segment.</summary>
        public Uri Image { get; set; }

        /// <summary>Gets or sets the vector path data used for the segment icon.</summary>
        public string PathData { get; set; }

        /// <summary>Initializes a new instance with a name and value.</summary>
        public DoughnutChartModel(string name, double value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>Initializes a new instance with a name, value, and vector path.</summary>
        public DoughnutChartModel(string name, double value, string path)
        {
            Name = name;
            Value = value;
            PathData = path;
        }

        /// <summary>Initializes a new instance with a name, value, and image.</summary>
        public DoughnutChartModel(string name, double value, Uri image)
        {
            Name = name;
            Value = value;
            Image = image;
        }
    }
}
