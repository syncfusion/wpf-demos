#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Syncfusion.Windows.Chart;
using System.Windows;

namespace ChartLegends
{
    

    public class LegendViewModel
    {
        public LegendViewModel()
        {
            this.fruitList = new List<CarMileageModel>();
            fruitList.Add(new CarMileageModel() {  HighwayMileage = 41, CarName = "Prius 1st Gen", CityMileage = 42 });
            fruitList.Add(new CarMileageModel() { HighwayMileage = 45, CarName = "Prius 2nd Gen", CityMileage = 48});
            fruitList.Add(new CarMileageModel() {  HighwayMileage = 48, CarName = "Prius 3rd Gen", CityMileage = 51 });
            fruitList.Add(new CarMileageModel() { HighwayMileage = 40, CarName = "Prius V", CityMileage = 54 });
            fruitList.Add(new CarMileageModel() {  HighwayMileage = 46, CarName = "Prius C", CityMileage = 53 });
            fruitList.Add(new CarMileageModel() {HighwayMileage = 50, CarName = "Prius Hybrid", CityMileage = 95 });

        }
        public List<CarMileageModel> fruitList { get; set; }

        public Array ChartDockCollection
        {
            get { return Enum.GetValues(typeof(ChartDock)); }
        }

        public Array VisibilityCollection
        {
            get { return Enum.GetValues(typeof(Visibility)); }
        }
    }
}
