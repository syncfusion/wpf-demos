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
    public class SplineAreaChartViewModel : IDisposable
    {
        public ObservableCollection<SplineAreaChartModel> SplineAreaData { get; }
        public SplineAreaChartViewModel()
        {
            this.SplineAreaData = new ObservableCollection<SplineAreaChartModel>();
            SplineAreaData.Add(new SplineAreaChartModel() { Year = "2010", India = 12, China = 3.2 });
            SplineAreaData.Add(new SplineAreaChartModel() { Year = "2011", India = 8.9, China = 5.6 });
            SplineAreaData.Add(new SplineAreaChartModel() { Year = "2012", India = 9.5, China = 2.6 });
            SplineAreaData.Add(new SplineAreaChartModel() { Year = "2013", India = 10, China = 2.6 });
            SplineAreaData.Add(new SplineAreaChartModel() { Year = "2014", India = 6.7, China = 1.9 });
            SplineAreaData.Add(new SplineAreaChartModel() { Year = "2015", India = 4.9, China = 1.4 });
            SplineAreaData.Add(new SplineAreaChartModel() { Year = "2016", India = 4.9, China = 2 });
            SplineAreaData.Add(new SplineAreaChartModel() { Year = "2017", India = 3.3, China = 1.6 });
            SplineAreaData.Add(new SplineAreaChartModel() { Year = "2018", India = 3.9, China = 2.1 });
        }

        public void Dispose()
        {
           if(SplineAreaData != null)
                SplineAreaData.Clear();
        }
    }
}
