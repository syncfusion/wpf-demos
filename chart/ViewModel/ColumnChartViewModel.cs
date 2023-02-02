#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public class ColumnChartViewModel
    {
        public ColumnChartViewModel()
        {
            this.SneakersDetail = new ObservableCollection<ColumnChartModel>();
            SneakersDetail.Add(new ColumnChartModel() { Brand = "Adidas", ItemsCount = 25 });
            SneakersDetail.Add(new ColumnChartModel() { Brand = "Nike", ItemsCount = 17 });
            SneakersDetail.Add(new ColumnChartModel() { Brand = "Reebok", ItemsCount = 30 });
            SneakersDetail.Add(new ColumnChartModel() { Brand = "Fila", ItemsCount = 18 });
            SneakersDetail.Add(new ColumnChartModel() { Brand = "Puma", ItemsCount = 10 });
            SneakersDetail.Add(new ColumnChartModel() { Brand = "TATA", ItemsCount = 21 });
        }

        public ObservableCollection<ColumnChartModel> SneakersDetail { get; set; }
    }
}
