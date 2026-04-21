#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a category with value and size for grouping in circular charts.</summary>
    public class GroupingModel
    {
        /// <summary>Gets or sets the category name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the numeric value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the size.</summary>
        public double Size { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupingModel"/> class.
        /// </summary>
        /// <param name="name">Represents the category name.</param>
        /// <param name="value">Represents the value.</param>
        /// <param name="size">Represents the value of size.</param>
        public GroupingModel(string name, double value, double size)
        {
            Name = name;
            Value = value;
            Size = size;
        }
    }
}
