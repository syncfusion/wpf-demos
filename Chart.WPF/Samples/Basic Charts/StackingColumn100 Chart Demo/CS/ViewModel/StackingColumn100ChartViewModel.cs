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

namespace StackingColumn100Chart
{
    public class StackingColumn100ChartViewModel
    {
        public StackingColumn100ChartViewModel()
        {
            this.ConnectionDetails = new ObservableCollection<InternetConnection>();

            ConnectionDetails.Add(new InternetConnection() { CountryName = "Switzerland", Below512 = 15, Bet512And2 = 21, Bet2And8 = 35, Above8 = 38 });
            ConnectionDetails.Add(new InternetConnection() { CountryName = "USA", Below512 = 16, Bet512And2 = 23, Bet2And8 = 41, Above8 = 29 });
            ConnectionDetails.Add(new InternetConnection() { CountryName = "Germany", Below512 = 17, Bet512And2 = 21, Bet2And8 = 45, Above8 = 27 });
            ConnectionDetails.Add(new InternetConnection() { CountryName = "Australia", Below512 = 19, Bet512And2 = 27, Bet2And8 = 43, Above8 = 21 });
            ConnectionDetails.Add(new InternetConnection() { CountryName = "UK", Below512 = 15, Bet512And2 = 20, Bet2And8 = 38, Above8 = 18 });
            ConnectionDetails.Add(new InternetConnection() { CountryName = "France", Below512 = 14, Bet512And2 = 25, Bet2And8 = 28, Above8 = 14 });
            ConnectionDetails.Add(new InternetConnection() { CountryName = "Spain", Below512 = 14, Bet512And2 = 28, Bet2And8 = 25, Above8 = 14 });
            ConnectionDetails.Add(new InternetConnection() { CountryName = "Italy", Below512 = 17, Bet512And2 = 27, Bet2And8 = 19, Above8 = 15 });
            ConnectionDetails.Add(new InternetConnection() { CountryName = "Brazil", Below512 = 31, Bet512And2 = 40, Bet2And8 = 38, Above8 = 29 });

        }

        public ObservableCollection<InternetConnection> ConnectionDetails { get; set; }
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
