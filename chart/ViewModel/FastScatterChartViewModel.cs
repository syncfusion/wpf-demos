#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class FastScatterChartViewModel
    {
        public int DataCount = 1000;

        private Random randomNumber;

        public ObservableCollection<FastScatterChartModel> DataCollection { get; set; }

        public FastScatterChartViewModel()
        {
            randomNumber = new Random();
            DataCollection = GenerateData();
        }

        public ObservableCollection<FastScatterChartModel> GenerateData()
        {
            ObservableCollection<FastScatterChartModel> datas = new ObservableCollection<FastScatterChartModel>();

            DateTime date = new DateTime(2000, 1, 1);
            double value = 100;
            for (int i = 0; i < this.DataCount; i++)
            {
                datas.Add(new FastScatterChartModel(date, value));
                date = date.Add(TimeSpan.FromDays(5));

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
    }
}
