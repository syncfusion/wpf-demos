#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace TreeViewBindingDemo
{
    public class ProductMVVM
    {
        static Random rd = new Random();
        string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public ProductMVVM()
        {
            Details = new ObservableCollection<Stock>();
            for (int i = 101; i <= 111; i++)
            {
                Details.Add(new Stock() { StockID = months[i - 100], StockName = "Stock" + i.ToString(), Price = rd.Next(20, 100), Open = rd.Next(10, 50) });
            }
        }

        public ObservableCollection<Stock> Details { get; set; }

        public string Name { get; set; }

        public string ImageSource { get; set; }

        public string Description { get; set; }

        public string Des_ImageSource { get; set; }

        public ObservableCollection<ProductMVVM> SubProducts { get; set; }
    }          
}
