#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class HistogramChartViewModel : IDisposable
    {
        public ObservableCollection<HistogramChartModel> HistogramData { get; set; }

        public HistogramChartViewModel()
        {
            HistogramData = new ObservableCollection<HistogramChartModel>();

            HistogramData.Add(new HistogramChartModel(5.250, 0));
            HistogramData.Add(new HistogramChartModel(7.750, 0));
            HistogramData.Add(new HistogramChartModel(0, 0));
            HistogramData.Add(new HistogramChartModel(8.275, 0));
            HistogramData.Add(new HistogramChartModel(9.750, 0));
            HistogramData.Add(new HistogramChartModel(7.750, 0));
            HistogramData.Add(new HistogramChartModel(8.275, 0));
            HistogramData.Add(new HistogramChartModel(6.250, 0));
            HistogramData.Add(new HistogramChartModel(5.750, 0));
            HistogramData.Add(new HistogramChartModel(5.250, 0));
            HistogramData.Add(new HistogramChartModel(23.000, 0));
            HistogramData.Add(new HistogramChartModel(26.500, 0));
            HistogramData.Add(new HistogramChartModel(27.750, 0));
            HistogramData.Add(new HistogramChartModel(25.025, 0));
            HistogramData.Add(new HistogramChartModel(26.500, 0));
            HistogramData.Add(new HistogramChartModel(26.500, 0));
            HistogramData.Add(new HistogramChartModel(28.025, 0));
            HistogramData.Add(new HistogramChartModel(29.250, 0));
            HistogramData.Add(new HistogramChartModel(26.750, 0));
            HistogramData.Add(new HistogramChartModel(27.250, 0));
            HistogramData.Add(new HistogramChartModel(26.250, 0));
            HistogramData.Add(new HistogramChartModel(25.250, 0));
            HistogramData.Add(new HistogramChartModel(34.500, 0));
            HistogramData.Add(new HistogramChartModel(25.625, 0));
            HistogramData.Add(new HistogramChartModel(25.500, 0));
            HistogramData.Add(new HistogramChartModel(26.625, 0));
            HistogramData.Add(new HistogramChartModel(36.275, 0));
            HistogramData.Add(new HistogramChartModel(36.250, 0));
            HistogramData.Add(new HistogramChartModel(26.875, 0));
            HistogramData.Add(new HistogramChartModel(45.000, 0));
            HistogramData.Add(new HistogramChartModel(43.000, 0));
            HistogramData.Add(new HistogramChartModel(46.500, 0));
            HistogramData.Add(new HistogramChartModel(47.750, 0));
            HistogramData.Add(new HistogramChartModel(45.025, 0));
            HistogramData.Add(new HistogramChartModel(56.500, 0));
            HistogramData.Add(new HistogramChartModel(56.500, 0));
            HistogramData.Add(new HistogramChartModel(58.025, 0));
            HistogramData.Add(new HistogramChartModel(59.250, 0));
            HistogramData.Add(new HistogramChartModel(56.750, 0));
            HistogramData.Add(new HistogramChartModel(57.250, 0));
            HistogramData.Add(new HistogramChartModel(46.250, 0));
            HistogramData.Add(new HistogramChartModel(55.250, 0));
            HistogramData.Add(new HistogramChartModel(44.500, 0));
            HistogramData.Add(new HistogramChartModel(45.500, 0));
            HistogramData.Add(new HistogramChartModel(55.500, 0));
            HistogramData.Add(new HistogramChartModel(45.625, 0));
            HistogramData.Add(new HistogramChartModel(55.500, 0));
            HistogramData.Add(new HistogramChartModel(56.250, 0));
            HistogramData.Add(new HistogramChartModel(46.875, 0));
            HistogramData.Add(new HistogramChartModel(43.000, 0));
            HistogramData.Add(new HistogramChartModel(46.250, 0));
            HistogramData.Add(new HistogramChartModel(55.250, 0));
            HistogramData.Add(new HistogramChartModel(44.500, 0));
            HistogramData.Add(new HistogramChartModel(45.425, 0));
            HistogramData.Add(new HistogramChartModel(56.625, 0));
            HistogramData.Add(new HistogramChartModel(46.275, 0));
            HistogramData.Add(new HistogramChartModel(56.250, 0));
            HistogramData.Add(new HistogramChartModel(46.875, 0));
            HistogramData.Add(new HistogramChartModel(43.000, 0));
            HistogramData.Add(new HistogramChartModel(46.250, 0));
            HistogramData.Add(new HistogramChartModel(55.250, 0));
            HistogramData.Add(new HistogramChartModel(44.500, 0));
            HistogramData.Add(new HistogramChartModel(45.425, 0));
            HistogramData.Add(new HistogramChartModel(55.500, 0));
            HistogramData.Add(new HistogramChartModel(46.625, 0));
            HistogramData.Add(new HistogramChartModel(56.275, 0));
            HistogramData.Add(new HistogramChartModel(46.250, 0));
            HistogramData.Add(new HistogramChartModel(56.250, 0));
            HistogramData.Add(new HistogramChartModel(42.000, 0));
            HistogramData.Add(new HistogramChartModel(41.000, 0));
            HistogramData.Add(new HistogramChartModel(63.000, 0));
            HistogramData.Add(new HistogramChartModel(66.500, 0));
            HistogramData.Add(new HistogramChartModel(67.750, 0));
            HistogramData.Add(new HistogramChartModel(65.025, 0));
            HistogramData.Add(new HistogramChartModel(66.500, 0));
            HistogramData.Add(new HistogramChartModel(76.500, 0));
            HistogramData.Add(new HistogramChartModel(78.025, 0));
            HistogramData.Add(new HistogramChartModel(79.250, 0));
            HistogramData.Add(new HistogramChartModel(76.750, 0));
            HistogramData.Add(new HistogramChartModel(77.250, 0));
            HistogramData.Add(new HistogramChartModel(66.250, 0));
            HistogramData.Add(new HistogramChartModel(75.250, 0));
            HistogramData.Add(new HistogramChartModel(74.500, 0));
            HistogramData.Add(new HistogramChartModel(65.625, 0));
            HistogramData.Add(new HistogramChartModel(75.500, 0));
            HistogramData.Add(new HistogramChartModel(76.625, 0));
            HistogramData.Add(new HistogramChartModel(76.275, 0));
            HistogramData.Add(new HistogramChartModel(66.250, 0));
            HistogramData.Add(new HistogramChartModel(66.875, 0));
            HistogramData.Add(new HistogramChartModel(82.000, 0));
            HistogramData.Add(new HistogramChartModel(85.250, 0));
            HistogramData.Add(new HistogramChartModel(87.750, 0));
            HistogramData.Add(new HistogramChartModel(92.000, 0));
            HistogramData.Add(new HistogramChartModel(85.250, 0));
            HistogramData.Add(new HistogramChartModel(87.750, 0));
            HistogramData.Add(new HistogramChartModel(89.000, 0));
            HistogramData.Add(new HistogramChartModel(88.275, 0));
            HistogramData.Add(new HistogramChartModel(89.750, 0));
            HistogramData.Add(new HistogramChartModel(95.750, 0));
            HistogramData.Add(new HistogramChartModel(95.250, 0));
        }

        public void Dispose()
        {
            if(HistogramData != null)
                HistogramData.Clear();
        }
    }
}
