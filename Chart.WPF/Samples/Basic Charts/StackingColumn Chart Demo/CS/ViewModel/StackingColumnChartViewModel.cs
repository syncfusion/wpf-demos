#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Chart;

namespace StackingColumnChart
{
    public class StackingColumnChartViewModel
    {
        public StackingColumnChartViewModel()
        {
            this.MedalDetails = new ObservableCollection<Medal>();

            //MedalDetails.Add(new Medal() { CountryName = "USA", GoldMedals = 929, SilverMedals = 729, BronzeMedals = 638 });
            MedalDetails.Add(new Medal() { CountryName = "URS", GoldMedals = 395, SilverMedals = 319, BronzeMedals = 296 });
            MedalDetails.Add(new Medal() { CountryName = "Germany", GoldMedals = 247, SilverMedals = 284, BronzeMedals = 320 });
            MedalDetails.Add(new Medal() { CountryName = "Britain", GoldMedals = 207, SilverMedals = 255, BronzeMedals = 253 });
            MedalDetails.Add(new Medal() { CountryName = "France", GoldMedals = 191, SilverMedals = 212, BronzeMedals = 233 });
            MedalDetails.Add(new Medal() { CountryName = "Italy", GoldMedals = 190, SilverMedals = 157, BronzeMedals = 174 });
            //MedalDetails.Add(new Medal() { CountryName = "China", GoldMedals = 163, SilverMedals = 117, BronzeMedals = 105 });
            MedalDetails.Add(new Medal() { CountryName = "Sweden", GoldMedals = 142, SilverMedals = 160, BronzeMedals = 173 });
            MedalDetails.Add(new Medal() { CountryName = "Australia", GoldMedals = 131, SilverMedals = 137, BronzeMedals = 164 });
            MedalDetails.Add(new Medal() { CountryName = "Japan", GoldMedals = 123, SilverMedals = 112, BronzeMedals = 126 });
        }

        public ObservableCollection<Medal> MedalDetails { get; set; }
        public Array PaletteCollection
        {
            get
            {
                return new ChartColorPalette[] { ChartColorPalette.Nature, 
                                          ChartColorPalette.Metro, 
                                          ChartColorPalette.Default, 
                                          ChartColorPalette.DefaultDark,
                                          ChartColorPalette.MixedFantasy
                                        };
            }
        }
    }
}
