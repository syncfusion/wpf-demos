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

namespace HiLoAreaChart
{
    public class HiLoAreaChartViewModel
    {
        public HiLoAreaChartViewModel()
        {
            DateTime dt = new DateTime(2000, 1, 5);
            productList = new List<product>();
            productList.Add(new product(dt, 4, 6));
            productList.Add(new product(dt.AddYears(1), 4, 2));
            productList.Add(new product(dt.AddYears(2), 4, 3));
            productList.Add(new product(dt.AddYears(3), 3, 5));
            productList.Add(new product(dt.AddYears(4), 5, 3));
            productList.Add(new product(dt.AddYears(5), 3, 4));
            productList.Add(new product(dt.AddYears(6), 3, 5));
            productList.Add(new product(dt.AddYears(7), 5, 3));
            productList.Add(new product(dt.AddYears(8), 3, 4));
        }

        public List<product> productList
        {
            get;
            set;
        }
    }
}
