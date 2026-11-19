#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a scatter data item with eruption duration and waiting time.</summary>
    public class ScatterChartModel
    {
        /// <summary>Gets or sets the eruption duration.</summary>
        public float Eruptions { get; set; }

        /// <summary>Gets or sets the waiting time between eruptions.</summary>
        public int WaitingTime { get; set; }
    }

    /// <summary>Represents a generic scatter point with value and size.</summary>
    public class ScatterModel
    {
        /// <summary>Gets or sets the value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the value of size.</summary>
        public double Size { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScatterModel"/> class.
        /// </summary>
        /// <param name="value">Represents the value.</param>
        /// <param name="size">Represents the size.</param>
        public ScatterModel(double value, double size)
        {
            Value = value;
            Size = size;
        }
    }
}
