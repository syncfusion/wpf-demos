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
    public class FastBarChartViewModel : IDisposable
    {
       private DateTime date = new DateTime(1999, 1, 1);

        public FastBarChartViewModel()
        {
            List = new ObservableCollection<FastBarChartModel>();
            Random random = new Random();

            for (int i = 0; i < 40; i++)
            {
                List.Add(new FastBarChartModel() { Date = date.AddDays(i), Price = random.Next(1, 20) });
            }
        }

        public ObservableCollection<FastBarChartModel> List { get; set; }

        public void Dispose()
        {
           if(List != null)
                List.Clear();
        }
    }
}
