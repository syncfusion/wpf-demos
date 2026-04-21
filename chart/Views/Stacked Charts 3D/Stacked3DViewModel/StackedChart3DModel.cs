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
    /// <summary>Represents versatile data items used across 3D stacked column and bar charts.</summary>
    public class StackedChart3DModel : NotificationObject
    {
        /// <summary>Gets or sets the year label.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets the value for Others.</summary>
        public double Others { get; set; }

        /// <summary>Gets or sets the Machine value.</summary>
        public double Machine { get; set; }

        /// <summary>Gets or sets the Storage value.</summary>
        public double Storage { get; set; }

        /// <summary>Gets or sets the Management value.</summary>
        public double Management { get; set; }

        /// <summary>Gets or sets the Communication value.</summary>
        public double Communication { get; set; }

        /// <summary>Gets or sets the Charging value.</summary>
        public double Charging { get; set; }

        /// <summary>Gets or sets the Q1 value.</summary>
        public double Quarter1 { get; set; }

        /// <summary>Gets or sets the Q2 value.</summary>
        public double Quarter2 { get; set; }

        /// <summary>Gets or sets the Q3 value.</summary>
        public double Quarter3 { get; set; }

        /// <summary>Gets or sets the Q4 value.</summary>
        public double Quarter4 { get; set; }

        /// <summary>Gets or sets the product or item name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets a size metric (e.g., bubble size).</summary>
        public double Size { get; set; }

        /// <summary>Gets or sets the high value.</summary>
        public double High { get; set; }

        /// <summary>Gets or sets the low value.</summary>
        public double Low { get; set; }

        /// <summary>Gets or sets the primary numeric value.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the Asia value.</summary>
        public double Asia { get; set; }

        /// <summary>Gets or sets the Europe value.</summary>
        public double Europe { get; set; }

        /// <summary>Gets or sets the CIS value.</summary>
        public double CIS { get; set; }

        /// <summary>Gets or sets the North America value.</summary>
        public double North { get; set; }

        /// <summary>Gets or sets the Latin America value.</summary>
        public double Latin { get; set; }

        /// <summary>Gets or sets the Pacific value.</summary>
        public double Pacific { get; set; }

        /// <summary>Gets or sets the Africa value.</summary>
        public double Africa { get; set; }

        /// <summary>Gets or sets the Middle East value.</summary>
        public double Middle { get; set; }
    }
}
