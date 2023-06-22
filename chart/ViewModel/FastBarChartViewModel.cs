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
    public class FastBarChartViewModel
    {
        DateTime date = new DateTime(1999, 1, 1);

        public FastBarChartViewModel()
        {
            List = new ObservableCollection<FastBarChartModel>();
            Random random = new Random();

            for (int i = 0; i < 50; i++)
            {
                List.Add(new FastBarChartModel() { Date = date.AddDays(i), Price = random.Next(1, 20) });
            }
        }

        public ObservableCollection<FastBarChartModel> List { get; set; }
    }
}
