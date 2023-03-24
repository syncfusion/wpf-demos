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
    public class HistogramChartViewModel
    {
        public HistogramChartViewModel()
        {
            this.Product = new ObservableCollection<HistogramChartModel>();

            Product.Add(new HistogramChartModel() { Price = 3 });
            Product.Add(new HistogramChartModel() { Price = 4 });
            Product.Add(new HistogramChartModel() { Price = 6 });
            Product.Add(new HistogramChartModel() { Price = 7 });
            Product.Add(new HistogramChartModel() { Price = 8 });
            Product.Add(new HistogramChartModel() { Price = 11 });
            Product.Add(new HistogramChartModel() { Price = 13 });
            Product.Add(new HistogramChartModel() { Price = 12 });
            Product.Add(new HistogramChartModel() { Price = 14 });
            Product.Add(new HistogramChartModel() { Price = 17 });
            Product.Add(new HistogramChartModel() { Price = 18 });
            Product.Add(new HistogramChartModel() { Price = 19 });
            Product.Add(new HistogramChartModel() { Price = 16 });
            Product.Add(new HistogramChartModel() { Price = 20 });
            Product.Add(new HistogramChartModel() { Price = 21 });
            Product.Add(new HistogramChartModel() { Price = 22 });
            Product.Add(new HistogramChartModel() { Price = 23 });
            Product.Add(new HistogramChartModel() { Price = 23 });
            Product.Add(new HistogramChartModel() { Price = 22 });
            Product.Add(new HistogramChartModel() { Price = 23 });
            Product.Add(new HistogramChartModel() { Price = 26 });
            Product.Add(new HistogramChartModel() { Price = 28 });
            Product.Add(new HistogramChartModel() { Price = 26 });
            Product.Add(new HistogramChartModel() { Price = 26 });
            Product.Add(new HistogramChartModel() { Price = 27 });
            Product.Add(new HistogramChartModel() { Price = 31 });
            Product.Add(new HistogramChartModel() { Price = 33 });
            Product.Add(new HistogramChartModel() { Price = 31 });
            Product.Add(new HistogramChartModel() { Price = 33 });
            Product.Add(new HistogramChartModel() { Price = 38 });
            Product.Add(new HistogramChartModel() { Price = 37 });
            Product.Add(new HistogramChartModel() { Price = 39 });
            Product.Add(new HistogramChartModel() { Price = 42 });
            Product.Add(new HistogramChartModel() { Price = 44 });
        }

        public ObservableCollection<HistogramChartModel> Product { get; set; }
    }
}
