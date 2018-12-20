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

namespace IndexedChart
{
    

    public class Products : ObservableCollection<Product>
    {
        public Products()
        {
            this.Add(new Product { carat = 18, Price = 43.01});
            this.Add(new Product { carat = 12, Price = 30.36 });
            this.Add(new Product { carat = 24, Price = 53.34 });
            this.Add(new Product { carat = 14, Price = 34.2 });
            this.Add(new Product { carat = 22, Price = 49.89 });
            this.Add(new Product { carat = 10, Price = 25.9 });
            this.Add(new Product { carat = 21, Price = 48.18 });
        }
    }

}
