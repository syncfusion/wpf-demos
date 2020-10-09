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

namespace RangeAreaChart
{
    public class ViewModel
    {
        public ViewModel()
        {
            this.Products = new ObservableCollection<Model>();

            Products.Add(new Model() { ProdName = "Rice", Price = 20, Stock = 53 });
            Products.Add(new Model() { ProdName = "Wheat", Price = 22, Stock = 76 });
            Products.Add(new Model() { ProdName = "Oil", Price = 30, Stock = 80 });
            Products.Add(new Model() { ProdName = "Corn", Price = 26, Stock = 50 });
            Products.Add(new Model() { ProdName = "Gram", Price = 36, Stock = 68 });
            Products.Add(new Model() { ProdName = "Milk", Price = 20, Stock = 90 });
            Products.Add(new Model() { ProdName = "Butter", Price = 40, Stock = 73 });
        }

        public ObservableCollection<Model> Products { get; set; }
    }
}
