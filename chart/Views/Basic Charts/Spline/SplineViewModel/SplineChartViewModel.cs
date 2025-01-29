#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
    public class SplineChartViewModel
    {
        public ObservableCollection<SplineChartModel> SplineData { get; set; }
        public ObservableCollection<SplineChartModel> DashedSplineData { get; set; }
        public SplineChartViewModel()
        {
            //Default Spline
            this.SplineData = new ObservableCollection<SplineChartModel>();
            SplineData.Add(new SplineChartModel() { Name = "Jan", High = 43, Low = 37 });
            SplineData.Add(new SplineChartModel() { Name = "Feb", High = 45, Low = 37 });
            SplineData.Add(new SplineChartModel() { Name = "Mar", High = 50, Low = 39 });
            SplineData.Add(new SplineChartModel() { Name = "Apr", High = 55, Low = 43 });
            SplineData.Add(new SplineChartModel() { Name = "May", High = 63, Low = 48 });
            SplineData.Add(new SplineChartModel() { Name = "Jun", High = 68, Low = 54 });
            SplineData.Add(new SplineChartModel() { Name = "Jul", High = 72, Low = 57 });
            SplineData.Add(new SplineChartModel() { Name = "Aug", High = 70, Low = 57 });
            SplineData.Add(new SplineChartModel() { Name = "Sep", High = 66, Low = 54 });
            SplineData.Add(new SplineChartModel() { Name = "Oct", High = 57, Low = 48 });
            SplineData.Add(new SplineChartModel() { Name = "Nov", High = 50, Low = 43 });
            SplineData.Add(new SplineChartModel() { Name = "Dec", High = 45, Low = 37 });

            //Dashed Spline
            this.DashedSplineData = new ObservableCollection<SplineChartModel>();
            DashedSplineData.Add(new SplineChartModel() { Name = "1997", Brazil = 17.76, Sweden = 20.47, Greece = 12.81 });
            DashedSplineData.Add(new SplineChartModel() { Name = "1998", Brazil = 18.17, Sweden = 21.59, Greece = 18.32 });
            DashedSplineData.Add(new SplineChartModel() { Name = "1999", Brazil = 17.39, Sweden = 21.78, Greece = 24.08 });
            DashedSplineData.Add(new SplineChartModel() { Name = "2000", Brazil = 18.90, Sweden = 22.91, Greece = 19.95 });
            DashedSplineData.Add(new SplineChartModel() { Name = "2001", Brazil = 18.74, Sweden = 22.96, Greece = 20.68 });
            DashedSplineData.Add(new SplineChartModel() { Name = "2002", Brazil = 17.45, Sweden = 22.14, Greece = 19.08 });
            DashedSplineData.Add(new SplineChartModel() { Name = "2003", Brazil = 16.86, Sweden = 21.95, Greece = 18.20 });
            DashedSplineData.Add(new SplineChartModel() { Name = "2004", Brazil = 17.91, Sweden = 21.85, Greece = 20.47 });
        }
    }
}
