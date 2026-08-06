#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a player's goal count used for label intersection demos.</summary>
    public class LabelsIntersectionModel
    {
        /// <summary>Gets or sets the player's name.</summary>
        public string PlayersName { get; set; }

        /// <summary>Gets or sets the total number of goals.</summary>
        public double GoalsCount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelsIntersectionModel"/> class.
        /// </summary>
        public LabelsIntersectionModel(string playersName, double goalsCount)
        {
            this.PlayersName = playersName;
            this.GoalsCount = goalsCount;
        }
    } 
}
