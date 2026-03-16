#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents grouped energy sources for 100% stacked charts.</summary>
    public class StackedGroup100Model
    {
        /// <summary>Gets or sets the year label.</summary>
        public string Year { get; set; }

        /// <summary>Gets or sets the fossil fuels share.</summary>
        public double FossilFuels { get; set; }

        /// <summary>Gets or sets the nuclear share.</summary>
        public double Nuclear { get; set; }

        /// <summary>Gets or sets the renewables share.</summary>
        public double Renewables { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StackedGroup100Model"/> class.
        /// </summary>
        /// <param name="year">Represents the year value.</param>
        /// <param name="fossilfuels">Represents the value of fossilfuels.</param>
        /// <param name="nuclear">Represents the value of nuclear.</param>
        /// <param name="renewables">Represents the value of renewables.</param>
        public StackedGroup100Model(string year,double fossilfuels, double nuclear, double renewables)
        {
            Year = year;
            FossilFuels = fossilfuels;
            Nuclear = nuclear;
            Renewables = renewables;

        }

    }
}
