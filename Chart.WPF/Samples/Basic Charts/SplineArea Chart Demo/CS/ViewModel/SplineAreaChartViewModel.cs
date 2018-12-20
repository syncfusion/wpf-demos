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

namespace SplineAreaChart
{
    public class SplineAreaChartViewModel
    {
        public SplineAreaChartViewModel()
        {
            this.Load = new ObservableCollection<Load>();
            DateTime hr = new DateTime(2004, 5, 1,1,00,00);
            //Load.Add(new Load() { Time = hr.AddHours(0), server1 = 33, server2 = 25, server3 = 15, server = 50  });
            //Load.Add(new Load() { Time = hr.AddHours(1), server1 = 38, server2 = 30, server3 = 10, server = 50 });
            Load.Add(new Load() { Time = hr.AddHours(0), server1 = 43, server2 = 33, server3 =12, server = 55});
            Load.Add(new Load() { Time = hr.AddHours(1), server1 = 48, server2 = 28, server3 =20, server = 80});
            Load.Add(new Load() { Time = hr.AddHours(2), server1 = 78, server2 = 70, server3 =50, server = 95});
            Load.Add(new Load() { Time = hr.AddHours(3), server1 = 35, server2 = 20, server3 =10, server = 75});
            Load.Add(new Load() { Time = hr.AddHours(4), server1 = 46, server2 = 40, server3 =15, server = 65});
            Load.Add(new Load() { Time = hr.AddHours(5), server1 = 40, server2 = 20, server3 =10, server = 65});
            //Load.Add(new Load() { Time = hr.AddHours(8), server1 = 65, server2 = 45, server3 =15, server = 76});
            //Load.Add(new Load() { Time = hr.AddHours(9), server1 = 50, server2 = 30, server3 = 15, server = 60 });
        }
        
        public ObservableCollection<Load> Load
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
