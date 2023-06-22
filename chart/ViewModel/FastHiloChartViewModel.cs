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
    public class FastHiloChartViewModel
    {
        DateTime date = new DateTime(1999, 1, 1);

        public FastHiloChartViewModel()
        {
            List = new ObservableCollection<FastHiloChartModel>();
            Random random = new Random();

            for (int k = 1; k <= 200; k++)
            {
                List.Add(new FastHiloChartModel { Date = date.AddMonths(k), Stock = random.Next(30, 70), Price = random.Next(10, 40) });
            }
        }

        public ObservableCollection<FastHiloChartModel> List { get; set; }
    }
}
