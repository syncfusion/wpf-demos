#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncfusion.Zugferd
{
    /// <summary>
    /// Invoice product
    /// </summary>
    public class Product
    {
        public string ProductID { get; set; }

        public string productName { get; set; }

        public float Price { get; set; }

        public float Quantity { get; set; }

        public float Total { get; set; }


    }
}
