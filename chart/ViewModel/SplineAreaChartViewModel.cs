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
    public class SplineAreaChartViewModel
    {
        public SplineAreaChartViewModel()
        {
            this.Products = new ObservableCollection<SplineAreaChartModel>();
            Products.Add(new SplineAreaChartModel() { ProdName = "Toyota", Price = 13, Stock = 10 });
            Products.Add(new SplineAreaChartModel() { ProdName = "Volkswagen", Price = 10, Stock = 7 });
            Products.Add(new SplineAreaChartModel() { ProdName = "Audi", Price = 4, Stock = 1 });
            Products.Add(new SplineAreaChartModel() { ProdName = "Ford", Price = 10, Stock = 7 });
            Products.Add(new SplineAreaChartModel() { ProdName = "Mercedes", Price = 4, Stock = 1 });
            Products.Add(new SplineAreaChartModel() { ProdName = "Hyundai", Price = 7, Stock = 5 });
        }

        public ObservableCollection<SplineAreaChartModel> Products { get; set; }
    }
}
