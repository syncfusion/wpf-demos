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

namespace ChartAutoScrollingDemo
{
    public class ProductDetails : ObservableCollection<Product>
    {
        public ProductDetails()
        {
            Random rand = new Random();
            DateTime dt = DateTime.Now;

            for (int i = 11; i < 140; i++)
            {
                this.Add(new Product { Rate = rand.Next(110, 240), Speed = dt });
                dt = dt.AddMinutes(1);
            }
        }
    }
}
