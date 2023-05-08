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
    class StepAreaChartViewModel
    {

        public StepAreaChartViewModel()
        {
            this.SneakersDetail = new ObservableCollection<StepAreaChartModel>();

            SneakersDetail.Add(new StepAreaChartModel() { Brand = "Adidas", ItemsCount = 416, ItemsCount1 = 180 });
            SneakersDetail.Add(new StepAreaChartModel() { Brand = "Nike", ItemsCount = 490, ItemsCount1 = 240 });
            SneakersDetail.Add(new StepAreaChartModel() { Brand = "Reebok", ItemsCount = 470, ItemsCount1 = 370 });
            SneakersDetail.Add(new StepAreaChartModel() { Brand = "Fila", ItemsCount = 500, ItemsCount1 = 200 });
            SneakersDetail.Add(new StepAreaChartModel() { Brand = "Puma", ItemsCount = 449, ItemsCount1 = 229 });
            SneakersDetail.Add(new StepAreaChartModel() { Brand = "New Balance", ItemsCount = 470, ItemsCount1 = 210 });
            SneakersDetail.Add(new StepAreaChartModel() { Brand = "Asics", ItemsCount = 437, ItemsCount1 = 337 });
            SneakersDetail.Add(new StepAreaChartModel() { Brand = "Skechers", ItemsCount = 458, ItemsCount1 = 258 });
            SneakersDetail.Add(new StepAreaChartModel() { Brand = "Bata", ItemsCount = 500, ItemsCount1 = 300 });
            SneakersDetail.Add(new StepAreaChartModel() { Brand = "Burberry", ItemsCount = 473, ItemsCount1 = 173 });
            //SneakersDetail.Add(new StepAreaChartModel() { Brand = "VF Corporation", ItemsCount = 520, ItemsCount1 = 220 });
        }

        public ObservableCollection<StepAreaChartModel> SneakersDetail { get; set; }
    }

}
