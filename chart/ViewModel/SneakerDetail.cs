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

namespace syncfusion.chartdemos.wpf
{
    public class SneakerDetail
    {
        public SneakerDetail()
        {
            this.SneakerDetails = new ObservableCollection<Sneaker>();

            SneakerDetails.Add(new Sneaker() { Brand = "Adidas", ItemsCount = 25 });
            SneakerDetails.Add(new Sneaker() { Brand = "Nike", ItemsCount = 17 });
            SneakerDetails.Add(new Sneaker() { Brand = "Reebok", ItemsCount = 34 });
            SneakerDetails.Add(new Sneaker() { Brand = "Fila", ItemsCount = 18 });
            SneakerDetails.Add(new Sneaker() { Brand = "Puma", ItemsCount = 10 });
            SneakerDetails.Add(new Sneaker() { Brand = "Fastrack", ItemsCount = 27 });
            SneakerDetails.Add(new Sneaker() { Brand = "Yepme", ItemsCount = 17 });
            SneakerDetails.Add(new Sneaker() { Brand = "Zovi", ItemsCount = 10 });
            SneakerDetails.Add(new Sneaker() { Brand = "Woodland", ItemsCount = 22 });
        }

        public ObservableCollection<Sneaker> SneakerDetails { get; set; }
    }
}
