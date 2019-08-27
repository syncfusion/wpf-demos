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

namespace RangeColumnChart
{
    public class RangeColumnChartViewModel
    {
        public RangeColumnChartViewModel()
        {
            this.TempDetails = new ObservableCollection<Climate>();

            TempDetails.Add(new Climate() { CityName = "Bangalore", MinTemp1 = 13, MaxTemp1 = 23, MinTemp2 = 15, MaxTemp2 = 23 });
            TempDetails.Add(new Climate() { CityName = "Nagpur", MinTemp1 = 25, MaxTemp1 = 40, MinTemp2 = 20, MaxTemp2 = 30 });
            TempDetails.Add(new Climate() { CityName = "Bhopal", MinTemp1 = 23, MaxTemp1 = 36, MinTemp2 = 23, MaxTemp2 = 28 });
            //TempDetails.Add(new Climate() { CityName = "Guwahati", MinTemp1 = 19, MaxTemp1 = 31, MinTemp2 = 24, MaxTemp2 = 33 });
            TempDetails.Add(new Climate() { CityName = "Lucknow", MinTemp1 = 22, MaxTemp1 = 35, MinTemp2 = 23, MaxTemp2 = 35 });
            TempDetails.Add(new Climate() { CityName = "Jaisalmer", MinTemp1 = 24, MaxTemp1 = 40, MinTemp2 = 22, MaxTemp2 = 30 });
            TempDetails.Add(new Climate() { CityName = "Dehradun", MinTemp1 = 14, MaxTemp1 = 32, MinTemp2 = 25, MaxTemp2 = 32 });
            TempDetails.Add(new Climate() { CityName = "Amritsar", MinTemp1 = 13, MaxTemp1 = 34, MinTemp2 = 15, MaxTemp2 = 20 });
            //TempDetails.Add(new Climate() { CityName = "Port Blair", MinTemp1 = 23, MaxTemp1 = 29, MinTemp2 = 25, MaxTemp2 = 27 });
            TempDetails.Add(new Climate() { CityName = "Trivandrum", MinTemp1 = 24, MaxTemp1 = 30, MinTemp2 = 25, MaxTemp2 = 27 });

        }
        
        public ObservableCollection<Climate> TempDetails { get; set; }
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
