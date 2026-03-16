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
    /// <summary>Represents a timestamped visitor count record.</summary>
    public class AIModel
    {
        /// <summary>Gets or sets the observation timestamp.</summary>
        public DateTime DateTime { get; set; }

        /// <summary>Gets or sets the number of visitors.</summary>
        public double Visitors { get; set; }
    }
}
