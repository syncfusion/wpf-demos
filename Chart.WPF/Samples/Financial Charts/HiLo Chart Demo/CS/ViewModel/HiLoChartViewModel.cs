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

namespace HiLoChart
{
    public class HiLoChartViewModel
    {
        public HiLoChartViewModel()
        {
            this.BPDetails = new ObservableCollection<BloodPressure>();
            DateTime date = new DateTime(2012, 4, 1);

            this.BPDetails.Add(new BloodPressure() { Level = "Stage4High", High = 210, Low=120 });
            this.BPDetails.Add(new BloodPressure() { Level = "Stage3High", High = 180, Low = 110 });
            this.BPDetails.Add(new BloodPressure() { Level = "Stage2High", High = 160, Low = 100 });
            this.BPDetails.Add(new BloodPressure() { Level = "Stage1High", High = 140, Low = 90 });
            this.BPDetails.Add(new BloodPressure() { Level = "BorderLineHigh", High = 140, Low = 90 });
            this.BPDetails.Add(new BloodPressure() { Level = "HighNormal", High = 130, Low = 85 });
            this.BPDetails.Add(new BloodPressure() { Level = "Normal", High = 120, Low = 80 });
            this.BPDetails.Add(new BloodPressure() { Level = "LowNormal", High = 110, Low = 75 });
            this.BPDetails.Add(new BloodPressure() { Level = "BorderLineLow", High = 90, Low = 60 });
            this.BPDetails.Add(new BloodPressure() { Level = "TooLow", High = 60, Low = 40 });
            this.BPDetails.Add(new BloodPressure() { Level = "Danger", High = 50, Low = 33 });

        }

        public ObservableCollection<BloodPressure> BPDetails { get; set; }
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
