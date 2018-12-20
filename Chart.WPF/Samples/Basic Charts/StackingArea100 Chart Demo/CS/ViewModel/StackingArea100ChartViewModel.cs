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

namespace StackingArea100
{
    public class StackingArea100ChartViewModel
    {
        public StackingArea100ChartViewModel()
        {
            this.Accidents = new ObservableCollection<Accidents>();
            DateTime mth = new DateTime(2011, 1, 1);
            Accidents.Add(new Accidents() { Month = mth.AddMonths(6), Bus = 5.6, Car = 2.4, Truck = 1.6, TwoWheeler = 2.3 });
            Accidents.Add(new Accidents() { Month = mth.AddMonths(7), Bus = 4.5, Car = 2.3, Truck = 1.8, TwoWheeler = 5.2 });
            Accidents.Add(new Accidents() { Month = mth.AddMonths(8), Bus = 2.4, Car = 2.2, Truck = 1.5, TwoWheeler = 1.5 });
            Accidents.Add(new Accidents() { Month = mth.AddMonths(9), Bus = 4.5, Car = 2.2, Truck = 1.2, TwoWheeler = 3.5 });
            Accidents.Add(new Accidents() { Month = mth.AddMonths(10), Bus = 7.8, Car = 3.4, Truck = 1.6, TwoWheeler = 3.3 });
            Accidents.Add(new Accidents() { Month = mth.AddMonths(11), Bus = -8.4, Car = 4.2, Truck = 2.3, TwoWheeler = 5.5 });
        }

        public ObservableCollection<Accidents> Accidents
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
