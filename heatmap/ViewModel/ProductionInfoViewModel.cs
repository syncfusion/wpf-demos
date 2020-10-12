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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.heatmapdemos.wpf
{
    class ProductionInfoViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ProductInfoModel> _productlist;
        public ProductionInfoViewModel()
        {
            ProductList = new ObservableCollection<ProductInfoModel>();
            PopulateData();
        }

        public ObservableCollection<ProductInfoModel> ProductList
        {
            get
            {
                return _productlist;
            }
            set
            {
                if (value != _productlist)
                {
                    _productlist = value;
                    onpropertychanged("ProductList");
                }
            }
        }

        private void onpropertychanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void PopulateData()
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                ProductInfoModel productInfo = new ProductInfoModel();
                productInfo.ProductName = productName[i];
                productInfo.Y2007 = r.Next(0, 51);
                productInfo.Y2008 = r.Next(0, 51);
                productInfo.Y2009 = r.Next(0, 51);
                productInfo.Y2010 = r.Next(0, 51);
                productInfo.Y2011 = r.Next(0, 51);
                productInfo.Y2012 = r.Next(0, 51);
                productInfo.Y2013 = r.Next(0, 51);
                productInfo.Y2014 = r.Next(0, 51);
                productInfo.Y2015 = r.Next(0, 51);
                productInfo.Y2016 = r.Next(0, 51);
                ProductList.Add(productInfo);
            }
        }

        string[] productName = new string[]
        {
            "Alice",
            "Boston",
            "Raclette",
            "Telino",
            "Verte",
            "Fløtemy",
            "Tigers",
            "Vegie",
            "Tarte",
            "Konbu",
            "Suklaa",
            "Perth",
            "Spread",
            "Tofu",
        };

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
