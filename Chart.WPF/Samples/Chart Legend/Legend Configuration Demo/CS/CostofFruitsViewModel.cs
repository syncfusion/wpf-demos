#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
    public class CostofFruitsViewModel
    {
        public double FruitID{get; set;}
        
        public string FruitName{get; set;}
        
        public double Price{get; set;}

        public int Year { get; set; }

        public int NumberOfFruits { get; set; }
    }

    public class LegendModel
    {
        public LegendModel()
        {
            this.fruitList = new List<CostofFruitsViewModel>();
            fruitList.Add(new CostofFruitsViewModel() { FruitID = 135, Price = 200, Year = 2005, FruitName = "Apple", NumberOfFruits = 134 });
            fruitList.Add(new CostofFruitsViewModel() { FruitID = 45, Price = 214, Year = 2005, FruitName = "Banana", NumberOfFruits = 256 });
            fruitList.Add(new CostofFruitsViewModel() { FruitID = 156, Price = 323, Year = 2007, FruitName = "Pineapple", NumberOfFruits = 123 });
            fruitList.Add(new CostofFruitsViewModel() { FruitID = 150, Price = 216, Year = 2007, FruitName = "Grapes", NumberOfFruits = 389 });
            fruitList.Add(new CostofFruitsViewModel() { FruitID = 100, Price = 312, Year = 2009, FruitName = "Orange", NumberOfFruits = 167 });
            fruitList.Add(new CostofFruitsViewModel() { FruitID = 110, Price = 132, Year = 2009, FruitName = "Nuts", NumberOfFruits = 290 });

        }
        public List<CostofFruitsViewModel> fruitList { get; set; }

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
