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

namespace EmptyPointsDemo
{
    public class EmptyPointsViewModel
    {
        public EmptyPointsViewModel()
        {
            this.Crashes = new ObservableCollection<Crashes>();
            DateTime year = new DateTime(1984, 5, 1);
            Crashes.Add(new Crashes() { Year = year.AddYears(0), count = double.NaN });
            Crashes.Add(new Crashes() { Year = year.AddYears(1), count = 1 });
            Crashes.Add(new Crashes() { Year = year.AddYears(2), count = 1 });
            Crashes.Add(new Crashes() { Year = year.AddYears(3), count = 3 });
            Crashes.Add(new Crashes() { Year = year.AddYears(4), count = 2 });
            Crashes.Add(new Crashes() { Year = year.AddYears(5), count = double.NaN });
            Crashes.Add(new Crashes() { Year = year.AddYears(6), count = 1 });
            Crashes.Add(new Crashes() { Year = year.AddYears(7), count = 1 });
            Crashes.Add(new Crashes() { Year = year.AddYears(8), count = 1 });
            Crashes.Add(new Crashes() { Year = year.AddYears(9), count = 4 });
        }

        public ObservableCollection<Crashes> Crashes
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

        public Array emptypointCollection
        {
            get { return Enum.GetValues(typeof(EmptyPointValue)); }
        }
    }

}
