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
    public class WatermarkViewModel
    {
        public WatermarkViewModel()
        {
            this.ItemsDetails = new ObservableCollection<WatermarkModel>();

            ItemsDetails.Add(new WatermarkModel() { Brand = "Adidas", ItemsCount = 25 });
            ItemsDetails.Add(new WatermarkModel() { Brand = "Nike", ItemsCount = 17 });
            ItemsDetails.Add(new WatermarkModel() { Brand = "Reebok", ItemsCount = 34 });
            ItemsDetails.Add(new WatermarkModel() { Brand = "Fila", ItemsCount = 18 });
            ItemsDetails.Add(new WatermarkModel() { Brand = "Puma", ItemsCount = 10 });
            ItemsDetails.Add(new WatermarkModel() { Brand = "Fastrack", ItemsCount = 27 });
            ItemsDetails.Add(new WatermarkModel() { Brand = "Yepme", ItemsCount = 17 });
            ItemsDetails.Add(new WatermarkModel() { Brand = "Zovi", ItemsCount = 10 });
            ItemsDetails.Add(new WatermarkModel() { Brand = "Woodland", ItemsCount = 22 });
        }

        public ObservableCollection<WatermarkModel> ItemsDetails { get; set; }
    }
}
