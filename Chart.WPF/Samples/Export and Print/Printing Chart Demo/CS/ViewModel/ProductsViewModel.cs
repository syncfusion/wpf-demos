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
using System.Collections.ObjectModel;

namespace PrintingSample
{
    

    public class ProductCollection
    {
        public ProductCollection()
        {
            this.PrintingDemo = new ObservableCollection<Products>();
            this.PrintingDemo.Add(new Products(){Sales=20,Projected=30,Productid=1,Stock=10,Price=15});
            this.PrintingDemo.Add(new Products(){Sales=25,Projected=15,Productid=2,Stock=20,Price=20});
            this.PrintingDemo.Add(new Products(){Sales=33,Projected=29,Productid=3,Stock=15,Price=6});
            this.PrintingDemo.Add(new Products(){Sales=28,Projected=9,Productid=4,Stock=20,Price=12});
            this.PrintingDemo.Add(new Products(){Sales=42,Projected=25,Productid=5,Stock=16,Price=7});
            this.PrintingDemo.Add(new Products(){Sales=33,Projected=23,Productid=6,Stock=12,Price=19});
            this.PrintingDemo.Add(new Products(){Sales=56,Projected=45,Productid=7,Stock=10,Price=9});
        }

        public ObservableCollection<Products> PrintingDemo{ get; set;}
    }
}
