#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

namespace BarChart
{
    public class BarChartViewModel
    {
        public BarChartViewModel()
        {
            this.PopulationDetails = new ObservableCollection<Population>();
            PopulationDetails.Add(new Population() { Country = "USA", FY2010 = 310.3 });
            PopulationDetails.Add(new Population() { Country = "Indonesia", FY2010 = 239.8 });
            PopulationDetails.Add(new Population() { Country = "Nigeria", FY2010 = 158.4 });
            PopulationDetails.Add(new Population() { Country = "Bangladesh", FY2010 = 148.6 });
            PopulationDetails.Add(new Population() { Country = "Russia", FY2010 = 142.9 });
            PopulationDetails.Add(new Population() { Country = "Mexico", FY2010 = 113.4 });
            PopulationDetails.Add(new Population() { Country = "Germany", FY2010 = 82.3 });
            PopulationDetails.Add(new Population() { Country = "Egypt", FY2010 = 81.1 });
            PopulationDetails.Add(new Population() { Country = "France", FY2010 = 62.7 });
            PopulationDetails.Add(new Population() { Country = "UK", FY2010 = 62.1 });
        }

        public ObservableCollection<Population> PopulationDetails
        {
            get;
            set;
        }
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
