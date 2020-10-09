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

namespace syncfusion.heatmapdemos.wpf
{
    public class ProductInfo
    {
        public string ProductName { get; set; }
        public int Year { get; set; }
        public double Value { get; set; }

        public ProductInfo(string productname, int year, double value)
        {
            this.ProductName = productname;
            this.Year = year;
            this.Value = value;
        }
    }

}

