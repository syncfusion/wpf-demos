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
    public class SplineChartViewModel
    {
        public SplineChartViewModel()
        {
            this.List = new ObservableCollection<SplineChartModel>();
            DateTime yr = new DateTime(2010, 1, 1);

            List.Add(new SplineChartModel() { XValue = "Jan", YValue1 = 37, YValue2 = 41 });
            List.Add(new SplineChartModel() { XValue = "Feb", YValue1 = 37, YValue2 = 45 });
            List.Add(new SplineChartModel() { XValue = "Mar", YValue1 = 39, YValue2 = 48 });
            List.Add(new SplineChartModel() { XValue = "Apr", YValue1 = 43, YValue2 = 52 });
            List.Add(new SplineChartModel() { XValue = "May", YValue1 = 48, YValue2 = 57 });
            List.Add(new SplineChartModel() { XValue = "Jun", YValue1 = 54, YValue2 = 61 });
            List.Add(new SplineChartModel() { XValue = "Jul", YValue1 = 57, YValue2 = 66 });
            List.Add(new SplineChartModel() { XValue = "Aug", YValue1 = 57, YValue2 = 66 });
            List.Add(new SplineChartModel() { XValue = "Sep", YValue1 = 54, YValue2 = 63 });
            List.Add(new SplineChartModel() { XValue = "Oct", YValue1 = 48, YValue2 = 55 });
            List.Add(new SplineChartModel() { XValue = "Nov", YValue1 = 43, YValue2 = 50 });
            List.Add(new SplineChartModel() { XValue = "Dec", YValue1 = 37, YValue2 = 45 });
        }

        public ObservableCollection<SplineChartModel> List
        {
            get;
            set;
        }
    }
}
