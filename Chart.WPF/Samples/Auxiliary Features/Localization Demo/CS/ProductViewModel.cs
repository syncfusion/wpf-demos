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

namespace Localization_Sample
{
    public class Product
    {
        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public double UnitPrice { get; set; }

        public double UnitsInStock { get; set; }

        public double UnitsOnOrder { get; set; }

        public double ReorderLevel { get; set; }

    }

    public class ProductCollection
    {
        public ProductCollection()
        {
            this.LocalizationModel = new ObservableCollection<Product>();
            this.LocalizationModel.Add(new Product() {ProductID="1", ProductName="Chocolate", UnitPrice=470, UnitsInStock=350, UnitsOnOrder=490, ReorderLevel=400});
            this.LocalizationModel.Add(new Product() {ProductID="2", ProductName="Olive Oil", UnitPrice=520, UnitsInStock=421, UnitsOnOrder=545, ReorderLevel=458});
            this.LocalizationModel.Add(new Product() {ProductID="3", ProductName="Cough Syrup", UnitPrice=482, UnitsInStock=375, UnitsOnOrder=530, ReorderLevel=400});
            this.LocalizationModel.Add(new Product() {ProductID="4", ProductName="Cashew Nuts", UnitPrice=495, UnitsInStock=410, UnitsOnOrder=510, ReorderLevel=400});
            this.LocalizationModel.Add(new Product() {ProductID="5", ProductName="Gumbo Mix", UnitPrice=421, UnitsInStock=180, UnitsOnOrder=440, ReorderLevel=200});
            this.LocalizationModel.Add(new Product() {ProductID="6", ProductName="Dry Fruits", UnitPrice=475, UnitsInStock=350, UnitsOnOrder=490, ReorderLevel=385});
        }

        public ObservableCollection<Product> LocalizationModel { get; set; }
    }


}
