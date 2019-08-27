#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace ChartExport
{
    public class Products
    {
        public Products()
        {
            this.Stocks = new ObservableCollection<Product>();
            this.Stocks.Add(new Product { X = 0, Y1 = 9, Y2 = 5 });
            this.Stocks.Add(new Product { X = 1, Y1 = 5, Y2 = 2 });
            this.Stocks.Add(new Product { X = 2, Y1 = 3, Y2 = 4 });
            this.Stocks.Add(new Product { X = 3, Y1 = 7, Y2 = 8 });
            this.Stocks.Add(new Product { X = 4, Y1 = 2, Y2 = 5 });
            this.Stocks.Add(new Product { X = 5, Y1 = 5, Y2 = 5 });
            this.Stocks.Add(new Product { X = 6, Y1 = 6, Y2 = 4 });
        }

        public ObservableCollection<Product> Stocks { get; set; }
    }
}
