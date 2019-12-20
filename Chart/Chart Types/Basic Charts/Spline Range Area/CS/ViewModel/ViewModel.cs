#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace SplineRangeAreaChart
{
    public class ViewModel
    {
        public ViewModel()
        {
            this.Products = new ObservableCollection<Model>();

            Products.Add(new Model() { Month = "Jan", LowMetric = 20, HighMetric = 53 });
            Products.Add(new Model() { Month = "Feb", LowMetric = 22, HighMetric = 76 });
            Products.Add(new Model() { Month = "Mar", LowMetric = 30, HighMetric = 80 });
            Products.Add(new Model() { Month = "Apr", LowMetric = 26, HighMetric = 50 });
            Products.Add(new Model() { Month = "May", LowMetric = 36, HighMetric = 68 });
            Products.Add(new Model() { Month = "Jun", LowMetric = 20, HighMetric = 90 });
            Products.Add(new Model() { Month = "Jul", LowMetric = 40, HighMetric = 73 });
            Products.Add(new Model() { Month = "Aug", LowMetric = 22, HighMetric = 76 });
            Products.Add(new Model() { Month = "Sep", LowMetric = 30, HighMetric = 80 });
            Products.Add(new Model() { Month = "Oct", LowMetric = 26, HighMetric = 50 });
            Products.Add(new Model() { Month = "Nov", LowMetric = 36, HighMetric = 68 });
            Products.Add(new Model() { Month = "Dec", LowMetric = 20, HighMetric = 90 });
        }

        public ObservableCollection<Model> Products { get; set; }
    }
}
