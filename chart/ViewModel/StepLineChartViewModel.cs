#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class StepLineChartViewModel
    {
        public StepLineChartViewModel()
        {
            this.Intensity = new ObservableCollection<StepLineChartModel>();
            DateTime yr = new DateTime(2000, 5, 1);
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(0), uk = 416, jp = 180 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(1), uk = 490, jp = 240 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(2), uk = 470, jp = 370 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(3), uk = 500, jp = 200 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(4), uk = 449, jp = 229 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(5), uk = 470, jp = 210 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(6), uk = 437, jp = 337 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(7), uk = 458, jp = 258 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(8), uk = 500, jp = 300 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(9), uk = 473, jp = 173 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(10), uk = 520, jp = 220 });
            Intensity.Add(new StepLineChartModel() { Year = yr.AddYears(11), uk = 480, jp = 309 });

        }

        public ObservableCollection<StepLineChartModel> Intensity
        {
            get;
            set;
        }
    }
}
