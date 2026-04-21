#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents yearly values for multiple categories in a 3D area chart.</summary>
    public class AreaSeriesChart3DModel
    {
        /// <summary>Gets or sets the year label.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets the value for Others.</summary>
        public double Others { get; set; }

        /// <summary>Gets or sets the value for Sandwiches.</summary>
        public double Sandwiches { get; set; }

        /// <summary>Gets or sets the value for Burger.</summary>
        public double Burger { get; set; }

        /// <summary>Gets or sets the value for Pizza.</summary>
        public double Pizza { get; set; }
    }
}
