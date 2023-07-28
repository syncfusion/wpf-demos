#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class PolarChartViewModel
    {
        public PolarChartViewModel()
        {
            this.PlantDetails = new ObservableCollection<PolarChartModel>();
            this.PlantDetails.Add(new PolarChartModel() { Direction = "North", Weed = 63, Flower = 42, Tree = 80 });
            this.PlantDetails.Add(new PolarChartModel() { Direction = "NorthEast", Weed = 70, Flower = 40, Tree = 85 });
            this.PlantDetails.Add(new PolarChartModel() { Direction = "East", Weed = 45, Flower = 25, Tree = 78 });
            this.PlantDetails.Add(new PolarChartModel() { Direction = "SouthEast", Weed = 70, Flower = 40, Tree = 90 });
            this.PlantDetails.Add(new PolarChartModel() { Direction = "South", Weed = 47, Flower = 20, Tree = 78 });
            this.PlantDetails.Add(new PolarChartModel() { Direction = "SouthWest", Weed = 65, Flower = 45, Tree = 83 });
            this.PlantDetails.Add(new PolarChartModel() { Direction = "West", Weed = 58, Flower = 40, Tree = 79 });
            this.PlantDetails.Add(new PolarChartModel() { Direction = "NorthWest", Weed = 73, Flower = 28, Tree = 88 });
        }

        public ObservableCollection<PolarChartModel> PlantDetails { get; set; }
    }    
}
