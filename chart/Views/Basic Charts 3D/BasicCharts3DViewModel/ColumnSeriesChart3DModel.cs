#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents data for 3D column charts with optional series values.</summary>
    public class ColumnSeriesChart3DModel : NotificationObject
    {
        /// <summary>Gets or sets the category name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the primary value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the year label.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets the value for Sudan.</summary>
        public double Sudan { get; set; }

        /// <summary>Gets or sets the value for Togo.</summary>
        public double Togo { get; set; }
    }
}
