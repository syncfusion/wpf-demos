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
using Syncfusion.Windows.Chart;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;

namespace TabControlExtDemo
{
    public class ChartViewModel :NotificationObject
    {
        ObservableCollection<ProductModel> _products;

        public ChartViewModel()
        {
            this.Products = new ObservableCollection<ProductModel>();
            Random rndm = new Random();
            Products.Add(new ProductModel() { ProdId = 1, Prodname = "Rice", Price2000 = rndm.Next(10, 80), Price2010 = rndm.Next(10, 80) });
            Products.Add(new ProductModel() { ProdId = 2, Prodname = "Wheat", Price2000 = rndm.Next(10, 80), Price2010 = rndm.Next(10, 80) });
            Products.Add(new ProductModel() { ProdId = 3, Prodname = "Oil", Price2000 = rndm.Next(10, 80), Price2010 = rndm.Next(10, 80) });
            Products.Add(new ProductModel() { ProdId = 4, Prodname = "Corn", Price2000 = rndm.Next(10, 80), Price2010 = rndm.Next(10, 80) });
            Products.Add(new ProductModel() { ProdId = 5, Prodname = "Gram", Price2000 = rndm.Next(10, 80), Price2010 = rndm.Next(10, 80) });
            Products.Add(new ProductModel() { ProdId = 6, Prodname = "Milk", Price2000 = rndm.Next(10, 80), Price2010 = rndm.Next(10, 80) });
            Products.Add(new ProductModel() { ProdId = 7, Prodname = "Butter", Price2000 = rndm.Next(10, 80), Price2010 = rndm.Next(10, 80) });

        }

        public ObservableCollection<ProductModel> Products 
        { 
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                RaisePropertyChanged("Products");
            }
        }


        public Array TypesCollection
        {
            get
            {
                return new ChartTypes[] {   
                                                        ChartTypes.Column, 
                                                        ChartTypes.StackingColumn, 
                                                        ChartTypes.RangeColumn, 
                                                        ChartTypes.StackingColumn100
                                                    };
            }
        }

    }
}
