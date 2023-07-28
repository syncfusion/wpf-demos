#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class  StackingColumnChartViewModel
    {
        public  StackingColumnChartViewModel()
        {
            this.MedalDetails = new ObservableCollection<StackingColumnChartModel>();

            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "USA", GoldMedals = 39, SilverMedals = 31, BronzeMedals = 29 });
            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "Germany", GoldMedals = 24, SilverMedals = 28, BronzeMedals = 32 });
            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "Britain", GoldMedals = 20, SilverMedals = 25, BronzeMedals = 25 });
            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "France", GoldMedals = 19, SilverMedals = 21, BronzeMedals = 23 });
            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "Italy", GoldMedals = 19, SilverMedals = 15, BronzeMedals = 17 });
        }

        public ObservableCollection<StackingColumnChartModel> MedalDetails { get; set; }
    } 
}
