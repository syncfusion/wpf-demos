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

namespace Spline
{
    public class SplineChartViewModel
    {
        public SplineChartViewModel()
        {
            this.Temprature = new ObservableCollection<Temprature>();
            DateTime mth = new DateTime(2011, 1, 1);
            Temprature.Add(new Temprature() { Month = mth.AddMonths(0), min = -1, max = 7, avg = 3, sea = 3 });
            Temprature.Add(new Temprature() { Month = mth.AddMonths(1), min = -1, max = 8, avg = 3.5, sea = 4});
            Temprature.Add(new Temprature() { Month = mth.AddMonths(2), min = 2, max = 12, avg = 7, sea =9 });
            Temprature.Add(new Temprature() { Month = mth.AddMonths(3), min = 8, max = 19, avg = 13.5, sea =14 });
            Temprature.Add(new Temprature() { Month = mth.AddMonths(4), min = 13, max = 25, avg = 19, sea = 20});
            Temprature.Add(new Temprature() { Month = mth.AddMonths(5), min = 18, max = 29, avg = 23.5, sea =25 });
            Temprature.Add(new Temprature() { Month = mth.AddMonths(6), min = 21, max = 31, avg = 26, sea =28 });
            Temprature.Add(new Temprature() { Month = mth.AddMonths(7), min = 20, max = 30, avg = 25, sea =28 });
            Temprature.Add(new Temprature() { Month = mth.AddMonths(8), min = 16, max = 26, avg = 21, sea =25 });
            Temprature.Add(new Temprature() { Month = mth.AddMonths(9), min = 10, max = 20, avg = 15, sea =18 });
            Temprature.Add(new Temprature() { Month = mth.AddMonths(10), min = 4, max = 14, avg = 9, sea =12});
            Temprature.Add(new Temprature() { Month = mth.AddMonths(11), min = 0, max = 8, avg = 3.5, sea = 5});
        }

        public ObservableCollection<Temprature> Temprature
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
        public Array SeriesCollection
        {
            get
            {
                return new ChartTypes[] { ChartTypes.Spline, 
                                          ChartTypes.RotatedSpline
                };
            }
        }

    }

}
