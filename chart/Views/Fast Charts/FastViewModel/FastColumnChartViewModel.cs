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
    public class FastColumnChartViewModel : IDisposable
    {
        private DateTime date = new DateTime(1999, 1, 1);
        public ObservableCollection<FastColumnChartModel> List { get; set; }

        public ObservableCollection<FastColumnChartModel> List2 { get; set; }

        public FastColumnChartViewModel()
        {
            //Fast column chart
            List = new ObservableCollection<FastColumnChartModel>();
            Random random = new Random();

            for (int i = 0; i < 60; i++)
            {
                List.Add(new FastColumnChartModel() { Date = date.AddDays(i), Price = random.Next(1, 100) });
            }

            //fast step line chart
            List2 = new ObservableCollection<FastColumnChartModel>();
            Random random1 = new Random();

            for (int i = 0; i < 60; i++)
            {
                List2.Add(new FastColumnChartModel() { Date = date.AddDays(i), Price = random1.Next(1, 134) });
            }
        }

        public void Dispose()
        {
            if(List != null)
                List.Clear();

            if(List2 != null)
                List2.Clear();
        }
    }
}
