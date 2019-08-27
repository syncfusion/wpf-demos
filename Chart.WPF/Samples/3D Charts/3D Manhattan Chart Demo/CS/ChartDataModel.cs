#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
    
    public class StockMarketDetails
    {
        public double ProdId { get; set; }

        public double TeamName1 { get; set; }

        public double TeamName2 { get; set; }

        public double Price { get; set; }

        public double Stock { get; set; }

        public double Stock1 { get; set; }
    }

    public class ChartDataModel
    {
        public ChartDataModel()
        {
            this.Products = new ObservableCollection<StockMarketDetails>();
            Random rand = new Random(DateTime.Now.Millisecond);
            Products.Add(new StockMarketDetails() { ProdId = 1, TeamName1 = 1, TeamName2=0, Price = 67, Stock = 53, Stock1 = 23 });
            Products.Add(new StockMarketDetails() { ProdId = 2, TeamName1 = 1, TeamName2 = 0, Price = 44, Stock = 76, Stock1 = 55 });
            Products.Add(new StockMarketDetails() { ProdId = 3, TeamName1 = 1, TeamName2 = 0, Price = 55, Stock = 80, Stock1 = 45 });
            Products.Add(new StockMarketDetails() { ProdId = 4, TeamName1 = 1, TeamName2 = 0, Price = 66, Stock = 50, Stock1 = 78 });
            Products.Add(new StockMarketDetails() { ProdId = 5, TeamName1 = 1, TeamName2 = 0, Price = 67, Stock = 68, Stock1 = 20 });
            Products.Add(new StockMarketDetails() { ProdId = 6, TeamName1 = 1, TeamName2 = 0, Price = 20, Stock = 90, Stock1 = 56 });
            Products.Add(new StockMarketDetails() { ProdId = 7, TeamName1 = 1, TeamName2 = 0, Price = 77, Stock = 73, Stock1 = 12 });
            Products.Add(new StockMarketDetails() { ProdId = 8, TeamName1 = 1, TeamName2 = 0, Price = 20, Stock = 53, Stock1 = 23 });
            Products.Add(new StockMarketDetails() { ProdId = 9, TeamName1 = 1, TeamName2 = 0, Price = 55, Stock = 76, Stock1 = 55 });
            Products.Add(new StockMarketDetails() { ProdId = 10, TeamName1 = 1, TeamName2 = 0, Price = 30, Stock = 80, Stock1 = 45 });
            Products.Add(new StockMarketDetails() { ProdId = 11, TeamName1 = 1, TeamName2 = 0, Price = 66, Stock = 50, Stock1 = 78 });
            Products.Add(new StockMarketDetails() { ProdId = 12, TeamName1 = 1, TeamName2 = 0, Price = 36, Stock = 68, Stock1 = 20 });
            Products.Add(new StockMarketDetails() { ProdId = 13, TeamName1 = 1, TeamName2 = 0, Price = 20, Stock = 90, Stock1 = 56 });
            Products.Add(new StockMarketDetails() { ProdId = 14, TeamName1 = 1, TeamName2 = 0, Price = 77, Stock = 45, Stock1 = 12 });
            Products.Add(new StockMarketDetails() { ProdId = 15, TeamName1 = 1, TeamName2 = 0, Price = 30, Stock = 33, Stock1 = 12 });
            Products.Add(new StockMarketDetails() { ProdId = 16, TeamName1 = 1, TeamName2 = 0, Price = 25, Stock = 23, Stock1 = 12 });
            Products.Add(new StockMarketDetails() { ProdId = 17, TeamName1 = 1, TeamName2 = 0, Price = 67, Stock = 55, Stock1 = 12 });
            Products.Add(new StockMarketDetails() { ProdId = 18, TeamName1 = 1, TeamName2 = 0, Price = 28, Stock = 63, Stock1 = 12 });
            Products.Add(new StockMarketDetails() { ProdId = 19, TeamName1 = 1, TeamName2 = 0, Price = 76, Stock = 33, Stock1 = 12 });
            Products.Add(new StockMarketDetails() { ProdId = 20, TeamName1 = 1, TeamName2 = 0, Price = 45, Stock = 43, Stock1 = 12 });
        }

        public ObservableCollection<StockMarketDetails> Products { get; set; }

     }
   
}
