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
    /// <summary>Provides datasets for fast column and fast step line charts.</summary>
    public class FastColumnChartViewModel : IDisposable
    {
        private DateTime date = new DateTime(1999, 1, 1);

        /// <summary>Gets or sets the fast column dataset.</summary>
        public ObservableCollection<FastColumnChartModel> List { get; set; }

        /// <summary>Gets or sets the dataset for step line demo.</summary>
        public ObservableCollection<FastColumnChartModel> List2 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FastColumnChartViewModel"/> class.
        /// </summary>
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

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if(List != null)
                List.Clear();

            if(List2 != null)
                List2.Clear();
        }
    }
}
