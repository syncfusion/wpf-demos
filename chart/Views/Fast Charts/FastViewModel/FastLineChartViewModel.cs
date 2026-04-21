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
    /// <summary>Generates large time-series data for fast line chart rendering.</summary>
    public class FastLineChartViewModel : IDisposable
    {
        /// <summary>Gets or sets the total number of points to generate.</summary>
        public int DataCount = 5000;
        private Random randomNumber;

        /// <summary>Gets or sets the generated data collection.</summary>
        public ObservableCollection<FastLineChartModel> DataCollection { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FastLineChartViewModel"/> class.
        /// </summary>
        public FastLineChartViewModel()
        {
            randomNumber = new Random();
            DataCollection = GenerateData();
        }

        /// <summary>Creates and returns a new data collection.</summary>
        public ObservableCollection<FastLineChartModel> GenerateData()
        {
            ObservableCollection<FastLineChartModel> datas = new ObservableCollection<FastLineChartModel>();
            DateTime date = new DateTime(2000, 1, 1);
            double value = 100;

            for (int i = 0; i < this.DataCount; i++)
            {
                datas.Add(new FastLineChartModel(date, Math.Round(value, 2)));
                date = date.Add(TimeSpan.FromDays(1));

                if (randomNumber.NextDouble() > .5)
                {
                    value += randomNumber.NextDouble();
                }
                else
                {
                    value -= randomNumber.NextDouble();
                }
            }

            return datas;
        }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if(DataCollection != null)
                DataCollection.Clear();
        }
    }
}
