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
    public class BubbleChartViewModel
    {
        public BubbleChartViewModel()
        {
            BubbleData = new ObservableCollection<BubbleChartModel>
            {
                new BubbleChartModel(92.2, 7.8, 1.347, "China"),
                new BubbleChartModel(74, 6.5, 1.241, "India"),
                new BubbleChartModel(90.4, 6.0, 0.238, "Indonesia"),
                new BubbleChartModel(99.4, 2.2, 0.312, "US"),
                new BubbleChartModel(88.6, 1.3, 0.197, "Brazil"),
                new BubbleChartModel(99, 4.7, 0.0818, "Germany"),
                new BubbleChartModel(72, 2.0, 0.0826, "Egypt"),
                new BubbleChartModel(99.6, 3.4, 0.143, "Russia"),
                new BubbleChartModel(99, 0.2, 0.128, "Japan"),
                new BubbleChartModel(86.1, 4.0, 0.115, "Mexico"),
                new BubbleChartModel(92.6, 4.6, 0.096, "Philippines"),
                new BubbleChartModel(61.3, 1.45, 0.162, "Nigeria"),
                new BubbleChartModel(82.2, 4.97, 0.7, "Hong Kong"),
                new BubbleChartModel(79.2, 3.9,0.162, "Netherland"),
                new BubbleChartModel(72.5, 4.5,0.7, "Jordan"),
                new BubbleChartModel(81, 3.5, 0.21, "Australia"),
                new BubbleChartModel(66.8, 3.9, 0.028, "Mongolia"),
                new BubbleChartModel(79.2, 2.9, 0.231, "Taiwan"),
            };
        }
        public ObservableCollection<BubbleChartModel> BubbleData { get; set; }

    }
}
