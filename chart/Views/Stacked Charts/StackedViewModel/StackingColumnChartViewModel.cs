#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using System.Windows.Media;

namespace syncfusion.chartdemos.wpf
{
    public class StackingColumnChartViewModel
    {
        public  StackingColumnChartViewModel()
        {
            this.MedalDetails = new ObservableCollection<StackingColumnChartModel>();

            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "Germany", GoldMedals = 229, SilverMedals = 259, BronzeMedals = 282 });
            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "France", GoldMedals = 222, SilverMedals = 253, BronzeMedals = 274 });
            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "Italy", GoldMedals = 216, SilverMedals = 188, BronzeMedals = 213 });
            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "Great Britain", GoldMedals = 285, SilverMedals = 316, BronzeMedals = 315 });
            MedalDetails.Add(new StackingColumnChartModel() { CountryName = "China", GoldMedals = 262, SilverMedals = 199, BronzeMedals = 173 });

        }

        public ObservableCollection<StackingColumnChartModel> MedalDetails { get; set; }

    } 
}
