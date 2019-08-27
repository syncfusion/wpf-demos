#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using Syncfusion.Windows.Chart;

namespace ChartVisualStyles
{

    public class ProductCollection
    {
        public ProductCollection()
        {
            DateTime dt = new DateTime(2000, 1, 1);
            Product = new ObservableCollection<ProductModel>();
            Product.Add(new ProductModel() { Years = dt, SalesinNA = 5.8, SalesinUS = 5.6 });
            Product.Add(new ProductModel() { Years = dt.AddYears(1), SalesinNA = 16, SalesinUS = 15.6 });
            Product.Add(new ProductModel() { Years = dt.AddYears(2), SalesinNA = 20.3, SalesinUS = 20.1 });
            Product.Add(new ProductModel() { Years = dt.AddYears(3), SalesinNA = 24.9, SalesinUS = 24.6 });
            Product.Add(new ProductModel() { Years = dt.AddYears(4), SalesinNA = 55.9, SalesinUS = 54 });
            Product.Add(new ProductModel() { Years = dt.AddYears(5), SalesinNA = 109.9, SalesinUS = 107.9 });
            Product.Add(new ProductModel() { Years = dt.AddYears(6), SalesinNA = 109, SalesinUS = 107 });
            Product.Add(new ProductModel() { Years = dt.AddYears(7), SalesinNA = 183.8, SalesinUS = 181.2 });
            Product.Add(new ProductModel() { Years = dt.AddYears(8), SalesinNA = 163.3, SalesinUS = 158.6 });
            Product.Add(new ProductModel() { Years = dt.AddYears(9), SalesinNA = 144.3, SalesinUS = 139.7 });
            
        }

        public ObservableCollection<ProductModel> Product { get; set; }

        public Array StyleCollection
        {
            get { return Enum.GetValues(typeof(ChartStyles)); }
        }

        public Array PaletteCollection
        {
            get { return Enum.GetValues(typeof(ChartColorPalette)); }
        }
    }
}
