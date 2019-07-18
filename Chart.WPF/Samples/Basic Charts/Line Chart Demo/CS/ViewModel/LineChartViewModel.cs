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

namespace LineCharts
{
    public class LineChartViewModel
    {
        public LineChartViewModel()
        {
            this.power = new ObservableCollection<power>();
            DateTime yr = new DateTime(2002, 5, 1);
            power.Add(new power() { Year = yr.AddYears(0), ind = 28, ger = 31, uk = 36, fra = 39 });
            power.Add(new power() { Year = yr.AddYears(1), ind = 24, ger = 28, uk = 32, fra = 36 });
            power.Add(new power() { Year = yr.AddYears(2), ind = 26, ger = 30, uk = 34, fra = 40 });
            power.Add(new power() { Year = yr.AddYears(3), ind = 27, ger = 36, uk = 41, fra = 44 });
            power.Add(new power() { Year = yr.AddYears(4), ind = 32, ger = 36, uk = 42, fra = 45 });
            power.Add(new power() { Year = yr.AddYears(5), ind = 35, ger = 39, uk = 42, fra = 48 });
            power.Add(new power() { Year = yr.AddYears(6), ind = 30, ger = 37, uk = 43, fra = 46 });
            
        }

        public ObservableCollection<power> power
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
