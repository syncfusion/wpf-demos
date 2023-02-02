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
    public class SplineRangeAreaChartViewModel
    {
        public SplineRangeAreaChartViewModel()
        {
            this.Products = new ObservableCollection<SplineRangeAreaModel>();

            Products.Add(new SplineRangeAreaModel() { Month = "Jan", LowMetric = 20, HighMetric = 53 });
            Products.Add(new SplineRangeAreaModel() { Month = "Feb", LowMetric = 22, HighMetric = 76 });
            Products.Add(new SplineRangeAreaModel() { Month = "Mar", LowMetric = 30, HighMetric = 80 });
            Products.Add(new SplineRangeAreaModel() { Month = "Apr", LowMetric = 26, HighMetric = 50 });
            Products.Add(new SplineRangeAreaModel() { Month = "May", LowMetric = 36, HighMetric = 68 });
            Products.Add(new SplineRangeAreaModel() { Month = "Jun", LowMetric = 20, HighMetric = 90 });
            Products.Add(new SplineRangeAreaModel() { Month = "Jul", LowMetric = 40, HighMetric = 73 });
            Products.Add(new SplineRangeAreaModel() { Month = "Aug", LowMetric = 22, HighMetric = 76 });
            Products.Add(new SplineRangeAreaModel() { Month = "Sep", LowMetric = 30, HighMetric = 80 });
            Products.Add(new SplineRangeAreaModel() { Month = "Oct", LowMetric = 26, HighMetric = 50 });
            Products.Add(new SplineRangeAreaModel() { Month = "Nov", LowMetric = 36, HighMetric = 68 });
            Products.Add(new SplineRangeAreaModel() { Month = "Dec", LowMetric = 20, HighMetric = 90 });
        }

        public ObservableCollection<SplineRangeAreaModel> Products { get; set; }
    }
}
