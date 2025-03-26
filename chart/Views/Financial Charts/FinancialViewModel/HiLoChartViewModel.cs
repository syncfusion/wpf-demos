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
    public class HiLoChartViewModel : IDisposable
    {
        public ObservableCollection<HiLoChartModel> HiloData { get; set; }
        public HiLoChartViewModel()
        {
            DateTime date = new DateTime(2012, 1, 1);
            HiloData = new ObservableCollection<HiLoChartModel>();
            HiloData.Add(new HiLoChartModel() { Date = date.AddMonths(0), High= 50, Low= 30 });
            HiloData.Add(new HiLoChartModel() { Date = date.AddMonths(1), High= 80, Low= 40 });
            HiloData.Add(new HiLoChartModel() { Date = date.AddMonths(2), High= 65, Low= 35 });
            HiloData.Add(new HiLoChartModel() { Date = date.AddMonths(3), High= 72, Low= 55 });
            HiloData.Add(new HiLoChartModel() { Date = date.AddMonths(4), High= 90, Low= 60 });
            HiloData.Add(new HiLoChartModel() { Date = date.AddMonths(5), High= 80, Low= 32 });
            HiloData.Add(new HiLoChartModel() { Date = date.AddMonths(6), High= 60, Low= 14 });
            HiloData.Add(new HiLoChartModel() { Date = date.AddMonths(7), High= 72, Low= 31 });
            HiloData.Add(new HiLoChartModel() { Date = date.AddMonths(8), High= 79, Low= 28 });
            HiloData.Add(new HiLoChartModel() { Date = date.AddMonths(9), High= 55, Low= 18 });
            HiloData.Add(new HiLoChartModel() { Date = date.AddMonths(10),High= 78, Low= 41 });
            HiloData.Add(new HiLoChartModel() { Date = date.AddMonths(11),High= 65, Low= 24 });
        }

        public void Dispose()
        {
            if (HiloData != null)
                HiloData.Clear();
        }
    }
}
