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
    public class BarChartViewModel
    {
        public BarChartViewModel()
        {
            CategoricalDatas = new ObservableCollection<BarChartModel>();
            CategoricalDatas.Add(new BarChartModel("Gold", 6));
            CategoricalDatas.Add(new BarChartModel("Plastic", 12));
            CategoricalDatas.Add(new BarChartModel("Silver", 19));
            CategoricalDatas.Add(new BarChartModel("Iron", 16));
            CategoricalDatas.Add(new BarChartModel("Platinum", 23));
        }

        public ObservableCollection<BarChartModel> CategoricalDatas
        {
            get;
            set;
        }
    }
}
