#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a single data point used for interactive annotations.</summary>
    public class AnnotationInteractionModel
    {
        /// <summary>Gets or sets the year associated with the data point.</summary>
        public DateTime Year { get; set; }

        /// <summary>Gets or sets the population for the given year.</summary>
        public double Population { get; set; }
    }
}
