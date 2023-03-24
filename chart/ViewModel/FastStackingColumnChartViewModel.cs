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
    public class FastStackingColumnChartViewModel
    {
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

        public ObservableCollection<FastStackingColumnChartMedal> MedalDetails { get; set; }
    }    
}
