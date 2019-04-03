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

namespace ToolBarDemo
{
    public class ToolBarViewModel
    {
        public ToolBarViewModel()
        {
            this.ProductDetails = new ObservableCollection<product>();
            this.ProductDetails.Add(new product() { ProdId = 1, Price = 10, Stock = 15, Projection = 50 });
            this.ProductDetails.Add(new product() { ProdId = 2, Price = 20, Stock = 10, Projection = 45 });
            this.ProductDetails.Add(new product() { ProdId = 3, Price = 50, Stock = 5, Projection = 30 });
            this.ProductDetails.Add(new product() { ProdId = 4, Price = 15, Stock = 10, Projection = 25 });
            this.ProductDetails.Add(new product() { ProdId = 5, Price = 35, Stock = 20, Projection = 10 });
            this.ProductDetails.Add(new product() { ProdId = 6, Price = 25, Stock = 20, Projection = 30 });
            this.ProductDetails.Add(new product() { ProdId = 7, Price = 45, Stock = 5, Projection = 35 });
        }

        public ObservableCollection<product> ProductDetails { get; set; }
    }

}
