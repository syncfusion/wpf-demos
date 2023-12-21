#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public class DateTimeAxisViewModel
    {
        public ObservableCollection<Axis3DChartsModel> DateTimeData { get; set; }
        public DateTimeAxisViewModel()
        {
            DateTimeData = new ObservableCollection<Axis3DChartsModel>();

            Random rand = new Random();
            double value = 100;
            DateTime date = new DateTime(2022, 1, 1);

            for (int i = 0; i < 100; i++)
            {
                if (rand.NextDouble() > 0.5)
                    value += rand.NextDouble();
                else
                    value -= rand.NextDouble();

                value = Math.Round(value, 3);

                DateTimeData.Add(new Axis3DChartsModel { Growth = value, Date = date });
                date = date.AddDays(1);
            }
        }
    }
}
