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

namespace StepLine
{
    public class StepLineChartViewModel
    {
        public StepLineChartViewModel()
        {
            this.Intensity = new ObservableCollection<Intensity>();
            DateTime yr = new DateTime(2006, 5, 1);
            Intensity.Add(new Intensity() { Year = yr.AddYears(0), uk = 519, usa = 570, jpn = 378, cra = 463 });
            Intensity.Add(new Intensity() { Year = yr.AddYears(1), uk = 508, usa = 579, jpn = 416, cra = 449 });
            Intensity.Add(new Intensity() { Year = yr.AddYears(2), uk = 502, usa = 563, jpn = 404, cra = 458 });
            Intensity.Add(new Intensity() { Year = yr.AddYears(3), uk = 495, usa = 550, jpn = 390, cra = 450 });
            Intensity.Add(new Intensity() { Year = yr.AddYears(4), uk = 485, usa = 545, jpn = 376, cra = 425 });
            Intensity.Add(new Intensity() { Year = yr.AddYears(5), uk = 470, usa = 525, jpn = 365, cra = 430 });
           
        }

        public ObservableCollection<Intensity> Intensity
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
