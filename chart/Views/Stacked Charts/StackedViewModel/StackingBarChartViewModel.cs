#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
    public class StackingBarChartViewModel
    {
        public StackingBarChartViewModel()
        {
            SalesRate = new ObservableCollection<StackingBarChartModel>()
             {
                 new StackingBarChartModel("2010",9.05,14.1,4.19),
                 new StackingBarChartModel("2011",6.62,17.07,11.12),
                 new StackingBarChartModel("2012",5.34,26.91,14.04),
                 new StackingBarChartModel("2013",3.5,33.8,14.08),
                 new StackingBarChartModel("2014",2.64,39.27,12.32)
             };
        }

        public ObservableCollection<StackingBarChartModel> SalesRate { get; set; }
    }
}






