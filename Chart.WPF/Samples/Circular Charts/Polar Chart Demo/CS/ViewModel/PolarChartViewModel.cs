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

namespace Polar_Chart
{
    public class PolarChartViewModel
    {
        public PolarChartViewModel()
        {
            this.PlantDetails = new ObservableCollection<PlantData>();
            this.PlantDetails.Add(new PlantData() { DirectionID = 0, Direction = "North", Weed = 63, Flower = 42, Tree = 80 });
            this.PlantDetails.Add(new PlantData() { DirectionID = 1, Direction = "NorthEast", Weed = 70, Flower = 40, Tree = 85 });
            this.PlantDetails.Add(new PlantData() { DirectionID = 2, Direction = "East", Weed = 45, Flower = 25, Tree = 78 });
            this.PlantDetails.Add(new PlantData() { DirectionID = 3, Direction = "SouthEast", Weed = 70, Flower = 40, Tree = 90 });
            this.PlantDetails.Add(new PlantData() { DirectionID = 4, Direction = "South", Weed = 47, Flower = 20, Tree = 78 });
            this.PlantDetails.Add(new PlantData() { DirectionID = 5, Direction = "SouthWest", Weed = 65, Flower = 45, Tree = 83 });
            this.PlantDetails.Add(new PlantData() { DirectionID = 6, Direction = "West", Weed = 58, Flower = 40, Tree = 79 });
            this.PlantDetails.Add(new PlantData() { DirectionID = 7, Direction = "NorthWest", Weed = 73, Flower = 28, Tree = 88 });
        }

        public ObservableCollection<PlantData> PlantDetails { get; set; }
    }
}
