#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace _3DManhattanChart
{
    
    public class StockMarketViewModel
    {
        public double ProdId { get; set; }

        public string Prodname { get; set; }

        public double Price { get; set; }

        public double Stock { get; set; }

        public double Stock1 { get; set; }
    }

    public class ColumnChartModel
    {
        public ColumnChartModel()
        {
            this.Products = new ObservableCollection<StockMarketViewModel>();
            Random rand = new Random(DateTime.Now.Millisecond);            
            Products.Add(new StockMarketViewModel() { ProdId = 1, Prodname = "Rice", Price = 20, Stock = 53, Stock1 = 23 });
            Products.Add(new StockMarketViewModel() { ProdId = 2, Prodname = "Wheat", Price = 22, Stock = 76, Stock1 = 55 });
            Products.Add(new StockMarketViewModel() { ProdId = 3, Prodname = "Oil", Price = 30, Stock = 80 , Stock1 = 45});
            Products.Add(new StockMarketViewModel() { ProdId = 4, Prodname = "Corn", Price = 26, Stock = 50, Stock1 = 78 });
            Products.Add(new StockMarketViewModel() { ProdId = 5, Prodname = "Gram", Price = 36, Stock = 68, Stock1 = 20 });
            Products.Add(new StockMarketViewModel() { ProdId = 6, Prodname = "Milk", Price = 20, Stock = 90, Stock1 = 56 });
            Products.Add(new StockMarketViewModel() { ProdId = 7, Prodname = "Butter", Price = 40, Stock = 73, Stock1 = 12 });
        }

        public ObservableCollection<StockMarketViewModel> Products { get; set; }

     }
   
}
