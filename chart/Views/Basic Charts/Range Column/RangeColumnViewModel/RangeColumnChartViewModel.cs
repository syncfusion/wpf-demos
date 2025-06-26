#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class RangeColumnChartViewModel : IDisposable
    {
        public ObservableCollection<RangeColumnChartModel> RangeColumnData { get; set; }
        public ObservableCollection<RangeColumnChartModel> RangeBarData { get; set; }
        public RangeColumnChartViewModel()
        {
            RangeColumnData = new ObservableCollection<RangeColumnChartModel>()
            {
                 new RangeColumnChartModel("Jan",13, 3),
                 new RangeColumnChartModel("Feb",14, 3),
                 new RangeColumnChartModel("Mar",17, 6),
                 new RangeColumnChartModel("Apr",20, 8),
                 new RangeColumnChartModel("May",24, 13),
                 new RangeColumnChartModel("Jun",29, 17),
                 new RangeColumnChartModel("Jul",32, 19),
                 new RangeColumnChartModel("Aug",30, 18),
                 new RangeColumnChartModel("Sep",27, 16),
                 new RangeColumnChartModel("Oct",23, 12),
                 new RangeColumnChartModel("Nov",18, 8),
                 new RangeColumnChartModel("Dec",15, 4),
            };

            RangeBarData = new ObservableCollection<RangeColumnChartModel>()
        {
                   new RangeColumnChartModel("Jan",7, 3),
                   new RangeColumnChartModel("Feb",8, 3),
                   new RangeColumnChartModel("Mar",12, 5),
                   new RangeColumnChartModel("Apr",16, 7),
                   new RangeColumnChartModel("May",20, 11),
                   new RangeColumnChartModel("Jun",23, 14),
                   new RangeColumnChartModel("Jul",25, 16),
                   new RangeColumnChartModel("Aug",25, 16),
                   new RangeColumnChartModel("Sep",21, 13),
                   new RangeColumnChartModel("Oct",16, 10),
                   new RangeColumnChartModel("Nov",11, 6),
                   new RangeColumnChartModel("Dec",8, 3),
            };
        }

        public void Dispose()
        {
            if(RangeColumnData != null)
                RangeColumnData.Clear();

            if (RangeBarData != null)
                RangeBarData.Clear();
        }
    }
}
