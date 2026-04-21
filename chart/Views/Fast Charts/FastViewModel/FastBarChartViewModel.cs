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
    /// <summary>Provides sample data for the fast bar chart demo.</summary>
    public class FastBarChartViewModel : IDisposable
    {
        private DateTime date = new DateTime(1999, 1, 1);

        /// <summary>
        /// Initializes a new instance of the <see cref="FastBarChartViewModel"/> class.
        /// </summary>
        public FastBarChartViewModel()
        {
            List = new ObservableCollection<FastBarChartModel>();
            Random random = new Random();

            for (int i = 0; i < 40; i++)
            {
                List.Add(new FastBarChartModel() { Date = date.AddDays(i), Price = random.Next(1, 20) });
            }
        }

        /// <summary>Gets or sets the collection of date/price data points.</summary>
        public ObservableCollection<FastBarChartModel> List { get; set; }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
           if(List != null)
                List.Clear();
        }
    }
}
