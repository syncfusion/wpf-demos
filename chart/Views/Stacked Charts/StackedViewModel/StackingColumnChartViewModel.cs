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
    /// <summary>Provides medal counts for stacked column chart demonstrations.</summary>
    public class StackingColumnChartViewModel : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StackingColumnChartViewModel"/> class.
        /// </summary>
        public StackingColumnChartViewModel()
        {
            this.MedalDetails = new ObservableCollection<StackingColumnChartModel>();

            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "Germany", GoldMedals = 229, SilverMedals = 259, BronzeMedals = 282 });
            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "France", GoldMedals = 222, SilverMedals = 253, BronzeMedals = 274 });
            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "Italy", GoldMedals = 216, SilverMedals = 188, BronzeMedals = 213 });
            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "Great Britain", GoldMedals = 285, SilverMedals = 316, BronzeMedals = 315 });
            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "China", GoldMedals = 262, SilverMedals = 199, BronzeMedals = 173 });

        }

        /// <summary>Gets or sets the country medal totals.</summary>
        public ObservableCollection<StackingColumnChartModel> MedalDetails { get; set; }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if(MedalDetails != null)
                MedalDetails.Clear();
        }  
    } 
}
