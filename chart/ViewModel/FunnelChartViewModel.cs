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
    public class FunnelChartViewModel
    {
        public FunnelChartViewModel()
        {
            this.list = new ObservableCollection<FunnelChartModel>();
            DateTime yr = new DateTime(2010, 5, 1);

            list.Add(new FunnelChartModel() { Category = "Iron", Percentage = 36 });
            list.Add(new FunnelChartModel() { Category = "Zinc", Percentage = 32 });
            list.Add(new FunnelChartModel() { Category = "Copper", Percentage = 34 });
            list.Add(new FunnelChartModel() { Category = "Aluminium", Percentage = 41 });
            list.Add(new FunnelChartModel() { Category = "Gold", Percentage = 42 });
            list.Add(new FunnelChartModel() { Category = "Silver", Percentage = 42 });
            list.Add(new FunnelChartModel() { Category = "Diamond", Percentage = 43 });
        }

        public ObservableCollection<FunnelChartModel> list
        {
            get;
            set;
        }
    }
}
