#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents tooltip data containing player performance details.</summary>
    public class AnnotationToolTipModel
    {
        /// <summary>Gets or sets the over number.</summary>
        public double Over { get; set; }

        /// <summary>Gets or sets the runs scored in the over.</summary>
        public double Runs { get; set; }

        /// <summary>Gets or sets the player’s name.</summary>
        public string PlayerName { get; set; }

        /// <summary>Gets or sets the player’s score.</summary>
        public string Score { get; set; }
    }
}
