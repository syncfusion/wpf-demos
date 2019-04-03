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

namespace RangeArea
{
    public class RangeAreaChartViewModel
    {
        public RangeAreaChartViewModel()
        {
            this.Inflation = new ObservableCollection<Inflation>();
            Inflation.Add(new Inflation() { Month = "Jan", Min = 2.08, Max = 4.28});
            Inflation.Add(new Inflation() { Month = "Feb", Min = 2.42, Max = 4.03 });
            Inflation.Add(new Inflation() { Month = "Mar", Min = 2.78, Max = 3.98 });
            Inflation.Add(new Inflation() { Month = "Apr", Min = 2.57, Max = 3.94 });
            Inflation.Add(new Inflation() { Month = "May", Min = 2.69, Max = 4.18 });
            Inflation.Add(new Inflation() { Month = "Jun", Min = 2.69, Max = 5.02 });
            Inflation.Add(new Inflation() { Month = "Jul", Min = 2.36, Max = 5.6 });
            Inflation.Add(new Inflation() { Month = "Aug", Min = 1.97, Max = 5.37 });
            Inflation.Add(new Inflation() { Month = "Sep", Min = 2.76, Max = 4.94 });
            Inflation.Add(new Inflation() { Month = "Oct", Min = 3.04, Max = 3.66 });
            Inflation.Add(new Inflation() { Month = "Nov", Min = 4.31, Max = 1.07 });
            Inflation.Add(new Inflation() { Month = "Dec", Min = 4.08, Max = 0.49 });
            
        }

        public ObservableCollection<Inflation> Inflation
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
