#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Generates sample medal data for fast stacking column charts.</summary>
    public class FastStackingColumnChartViewModel : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FastStackingColumnChartViewModel"/> class.
        /// </summary>
        public FastStackingColumnChartViewModel()
        {
            this.MedalDetails = new ObservableCollection<FastStackingColumnChartMedal>();
            Random rd = new Random();

            for (int i = 0; i < 60; i++)
            {
                MedalDetails.Add(new FastStackingColumnChartMedal()
                {
                    CountryName = i,
                    GoldMedals = rd.Next(0, 30),
                    SilverMedals = rd.Next(30, 40),
                    BronzeMedals = rd.Next(20, 30)
                });
            }
        }

        /// <summary>Gets or sets the medal details collection.</summary>
        public ObservableCollection<FastStackingColumnChartMedal> MedalDetails { get; set; }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if (MedalDetails != null)
                MedalDetails.Clear();
        }
    }    
}
