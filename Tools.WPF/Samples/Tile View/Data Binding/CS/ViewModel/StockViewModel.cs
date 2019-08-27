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

namespace DataBindingDemo
{
    public class StockViewModel
    {
        public StockViewModel()
        {
            this.Coffee = new ProductSalesCollection();
            this.Tea = new ProductSalesCollection();

            this.Coffee.Add(new ProductSales() { Year = 1996, Sales = 50 });
            this.Coffee.Add(new ProductSales() { Year = 1997, Sales = 54 });
            this.Coffee.Add(new ProductSales() { Year = 1999, Sales = 58 });
            this.Coffee.Add(new ProductSales() { Year = 2000, Sales = 62 });
            this.Coffee.Add(new ProductSales() { Year = 2001, Sales = 66 });
            this.Coffee.Add(new ProductSales() { Year = 2003, Sales = 70 });
            this.Coffee.Add(new ProductSales() { Year = 2005, Sales = 74 });
            this.Coffee.Add(new ProductSales() { Year = 2007, Sales = 78 });
            this.Coffee.Add(new ProductSales() { Year = 2008, Sales = 82 });
            this.Coffee.Add(new ProductSales() { Year = 2009, Sales = 86 });

            this.Tea.Add(new ProductSales() { Year = 1996, Sales = 55 });
            this.Tea.Add(new ProductSales() { Year = 1997, Sales = 60 });
            this.Tea.Add(new ProductSales() { Year = 1999, Sales = 65 });
            this.Tea.Add(new ProductSales() { Year = 2000, Sales = 70 });
            this.Tea.Add(new ProductSales() { Year = 2001, Sales = 75 });
            this.Tea.Add(new ProductSales() { Year = 2003, Sales = 80 });
            this.Tea.Add(new ProductSales() { Year = 2005, Sales = 85 });
            this.Tea.Add(new ProductSales() { Year = 2007, Sales = 90 });
            this.Tea.Add(new ProductSales() { Year = 2008, Sales = 95 });
            this.Tea.Add(new ProductSales() { Year = 2009, Sales = 100 });
        }

        public ProductSalesCollection Tea { get; set; }
        public ProductSalesCollection Coffee { get; set; }

       
    }

    public class ProductSales
    {
        public double Year { get; set; }

        public double Sales { get; set; }
    }
    /// <summary>
    /// Data Collection added with Year and Sale
    /// </summary>
    public class ProductSalesCollection : ObservableCollection<ProductSales>
    {
        public ProductSalesCollection()
        {
        }
    }

}
