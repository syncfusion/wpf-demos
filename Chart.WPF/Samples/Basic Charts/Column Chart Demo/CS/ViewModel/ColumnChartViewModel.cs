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

namespace ColumnChart
{
    public class ColumnChartViewModel
    {
        public ColumnChartViewModel()
        {
            this.CO2ReductionDetails = new ObservableCollection<CO2Reduction>();

            CO2ReductionDetails.Add(new CO2Reduction() { Country = "India", Potential = 32.2 });
            CO2ReductionDetails.Add(new CO2Reduction() { Country = "Australia", Potential = 28.4 });
            CO2ReductionDetails.Add(new CO2Reduction() { Country = "China", Potential = 26.3 });
            CO2ReductionDetails.Add(new CO2Reduction() { Country = "USA", Potential = 21.2 });
            CO2ReductionDetails.Add(new CO2Reduction() { Country = "Korea", Potential = 18.5 });
            CO2ReductionDetails.Add(new CO2Reduction() { Country = "Canada", Potential = 17.5 });
            CO2ReductionDetails.Add(new CO2Reduction() { Country = "Germany", Potential = 16.1 });
            CO2ReductionDetails.Add(new CO2Reduction() { Country = "Japan", Potential = 14.5 });
            CO2ReductionDetails.Add(new CO2Reduction() { Country = "France", Potential = 14.3 });
            CO2ReductionDetails.Add(new CO2Reduction() { Country = "Italy", Potential = 12.2 });
        }

        public ObservableCollection<CO2Reduction> CO2ReductionDetails { get; set; }
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
