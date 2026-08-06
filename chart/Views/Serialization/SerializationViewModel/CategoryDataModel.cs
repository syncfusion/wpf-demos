#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a category/value pair used for serialization demos.</summary>
    public class CategoryDataModel
    {
        /// <summary>Gets or sets the category name.</summary>
        public string Category { get; set; }

        /// <summary>Gets or sets the numeric value for the category.</summary>
        public double Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryDataModel"/> class.
        /// </summary>
        public CategoryDataModel(string category, double value)
        {
            Category = category; Value = value;
        }
        
    }
}
