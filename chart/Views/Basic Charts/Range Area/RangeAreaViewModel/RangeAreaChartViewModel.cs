#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class RangeAreaChartViewModel : IDisposable
    {
        public ObservableCollection<RangeAreaChartModel> RangeAreaData { get; set; }
        public RangeAreaChartViewModel()
        {
            RangeAreaData = new ObservableCollection<RangeAreaChartModel>
            {
                new RangeAreaChartModel(new DateTime(2022, 05, 01), 36, 13),
                new RangeAreaChartModel(new DateTime(2022, 05, 02), 33, 16),
                new RangeAreaChartModel(new DateTime(2022, 05, 03), 32, 15),
                new RangeAreaChartModel(new DateTime(2022, 05, 04), 32, 13),
                new RangeAreaChartModel(new DateTime(2022, 05, 05), 34, 13),
                new RangeAreaChartModel(new DateTime(2022, 05, 06), 37, 14),
                new RangeAreaChartModel(new DateTime(2022, 05, 07), 38, 16),
                new RangeAreaChartModel(new DateTime(2022, 05, 08), 35, 22),
                new RangeAreaChartModel(new DateTime(2022, 05, 09), 31, 16),
                new RangeAreaChartModel(new DateTime(2022, 05, 10), 32, 13),
                new RangeAreaChartModel(new DateTime(2022, 05, 11), 30, 16),
                new RangeAreaChartModel(new DateTime(2022, 05, 12), 28, 12),
                new RangeAreaChartModel(new DateTime(2022, 05, 13), 34, 10),
                new RangeAreaChartModel(new DateTime(2022, 05, 14), 38, 14),
                new RangeAreaChartModel(new DateTime(2022, 05, 15), 40, 17),
                new RangeAreaChartModel(new DateTime(2022, 05, 16), 39, 18),
                new RangeAreaChartModel(new DateTime(2022, 05, 17), 38, 18),
                new RangeAreaChartModel(new DateTime(2022, 05, 18), 38, 17),
                new RangeAreaChartModel(new DateTime(2022, 05, 19), 37, 19),
                new RangeAreaChartModel(new DateTime(2022, 05, 20), 36, 21),
                new RangeAreaChartModel(new DateTime(2022, 05, 21), 35, 18),
                new RangeAreaChartModel(new DateTime(2022, 05, 22), 36, 17),
                new RangeAreaChartModel(new DateTime(2022, 05, 23), 34, 16),
                new RangeAreaChartModel(new DateTime(2022, 05, 24), 36, 17),
                new RangeAreaChartModel(new DateTime(2022, 05, 25), 38, 18),
                new RangeAreaChartModel(new DateTime(2022, 05, 26), 39, 20),
                new RangeAreaChartModel(new DateTime(2022, 05, 27), 40, 21),
                new RangeAreaChartModel(new DateTime(2022, 05, 28), 38, 21),
                new RangeAreaChartModel(new DateTime(2022, 05, 29), 33, 21),
                new RangeAreaChartModel(new DateTime(2022, 05, 30), 34, 18),
                new RangeAreaChartModel(new DateTime(2022, 05, 31), 37, 17),
            };
        }

        public void Dispose()
        {
            if(RangeAreaData !=null)
                RangeAreaData.Clear();
        }
    }
}
