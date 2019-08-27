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

namespace StepArea
{
    public class StepAreaChartViewModel
    {
        public StepAreaChartViewModel()
        {
            this.Power = new ObservableCollection<Power>();
            DateTime yr = new DateTime(2001, 5, 1);
            Power.Add(new Power() { Year = yr.AddYears(0), ind = 371, ger =281, jpn =205, cra =110   });
            Power.Add(new Power() { Year = yr.AddYears(1), ind = 390, ger =290, jpn =222, cra =118  });
            Power.Add(new Power() { Year = yr.AddYears(2), ind = 407, ger =301, jpn =180, cra =120  });
            Power.Add(new Power() { Year = yr.AddYears(3), ind = 424, ger =284, jpn =210, cra =127  });
            Power.Add(new Power() { Year = yr.AddYears(4), ind = 435, ger =355, jpn =259, cra =134 });
            Power.Add(new Power() { Year = yr.AddYears(5), ind = 462, ger =315, jpn =251, cra =139  });
            Power.Add(new Power() { Year = yr.AddYears(6), ind = 487, ger =370, jpn =265, cra =155  });
            Power.Add(new Power() { Year = yr.AddYears(7), ind = 513, ger = 395, jpn = 244, cra = 173 });
                          
                   
        }
              
        public ObservableCollection<Power> Power
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
