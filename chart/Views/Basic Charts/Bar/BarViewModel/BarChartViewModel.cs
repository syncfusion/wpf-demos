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
    public class BarChartViewModel : IDisposable
    {
        public ObservableCollection<BarChartModel> DefaultBarData { get; }
        public ObservableCollection<BarChartModel> RoundedBarData { get; set; }
        public ObservableCollection<BarChartModel> BarWidthData { get; set; }

        public BarChartViewModel()
        {
            //Default bar data
            this.DefaultBarData = new ObservableCollection<BarChartModel>();
            DefaultBarData.Add(new BarChartModel() { Name = "Gmail", Value = 96.12 });
            DefaultBarData.Add(new BarChartModel() { Name = "YouTube", Value = 94.58 });
            DefaultBarData.Add(new BarChartModel() { Name = "Facebook", Value = 74.54 });
            DefaultBarData.Add(new BarChartModel() { Name = "WhatsApp", Value = 52.25 });
            DefaultBarData.Add(new BarChartModel() { Name = "Twitter", Value = 27.11 });
            DefaultBarData.Add(new BarChartModel() { Name = "Subway Surfers", Value = 22.61 });

            //Rounded bar data
            this.RoundedBarData = new ObservableCollection<BarChartModel>();
            RoundedBarData.Add(new BarChartModel() { Name = "Boat", Value = 9.872 });
            RoundedBarData.Add(new BarChartModel() { Name = "Walk", Value = 3.11 });
            RoundedBarData.Add(new BarChartModel() { Name = "Plane", Value = 9.0437 });
            RoundedBarData.Add(new BarChartModel() { Name = "Bike", Value = 5.237 });
            RoundedBarData.Add(new BarChartModel() { Name = "Car", Value = 8.43 });

            //Bar Spacing
            this.BarWidthData = new ObservableCollection<BarChartModel>();
            BarWidthData.Add(new BarChartModel() { Name = "HealthCare", September2021 = 14.4, September2020 = 3.2 });
            BarWidthData.Add(new BarChartModel() { Name = "Corporate Service", September2021 = 9.5, September2020 = 5.2 });
            BarWidthData.Add(new BarChartModel() { Name = "Education", September2021 = 8.8, September2020 = 9.4 });
            BarWidthData.Add(new BarChartModel() { Name = "Entertainment", September2021 = 7.7, September2020 = 3.0 });
            BarWidthData.Add(new BarChartModel() { Name = "Finance", September2021 = 6.5, September2020 = 1.8 });
        }

        public void Dispose()
        {
           if(DefaultBarData != null)
                DefaultBarData.Clear();

           if(RoundedBarData != null)
                RoundedBarData.Clear();

           if(BarWidthData != null)
                BarWidthData.Clear();
           
        }
    }
}
