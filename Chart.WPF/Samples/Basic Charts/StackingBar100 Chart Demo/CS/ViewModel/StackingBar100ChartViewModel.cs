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

namespace StackingBar100Chart
{
    public class StackingBar100ChartViewModel
    {
        public StackingBar100ChartViewModel()
        {
            this.EarthquakeDetails = new ObservableCollection<Earthquake>();

            EarthquakeDetails.Add(new Earthquake() { YEAR = 2003, Mag5 = 120, Mag6 = 140, Mag7 = 133, Mag8 = 90 });
            EarthquakeDetails.Add(new Earthquake() { YEAR = 2004, Mag5 = 151, Mag6 = 141, Mag7 = 123, Mag8 = 89 });
            EarthquakeDetails.Add(new Earthquake() { YEAR = 2005, Mag5 = 169, Mag6 = 140, Mag7 = 87, Mag8 = 67 });
            EarthquakeDetails.Add(new Earthquake() { YEAR = 2006, Mag5 = 171, Mag6 = 142, Mag7 = 95, Mag8 = 72 });
            EarthquakeDetails.Add(new Earthquake() { YEAR = 2007, Mag5 = 187, Mag6 = 123, Mag7 = 78, Mag8 = 56 });
            EarthquakeDetails.Add(new Earthquake() { YEAR = 2008, Mag5 = 176, Mag6 = 168, Mag7 = 88, Mag8 = 78 });
            EarthquakeDetails.Add(new Earthquake() { YEAR = 2009, Mag5 = 189, Mag6 = 144, Mag7 = 65, Mag8 = 69 });
            EarthquakeDetails.Add(new Earthquake() { YEAR = 2010, Mag5 = 117, Mag6 = 75, Mag7 = 39, Mag8 = 54 });
            //EarthquakeDetails.Add(new Earthquake() { YEAR = 2011, Mag5 = 180, Mag6 = 136, Mag7 = 69, Mag8 = 78 });
            //EarthquakeDetails.Add(new Earthquake() { YEAR = 2012, Mag5 = 130, Mag6 = 90, Mag7 = 75, Mag8 = 93 });
        }
        public ObservableCollection<Earthquake> EarthquakeDetails
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
