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

namespace ScatterChart
{
    public class ScatterChartViewModel
    {
        public ScatterChartViewModel()
        {
            this.ExpensiveCarDetails = new ObservableCollection<ExpensiveCar>();

            this.ExpensiveCarDetails.Add(new ExpensiveCar() { Position = 1, CarName = "Bugatti Veyron", Price = 2.401});
            this.ExpensiveCarDetails.Add(new ExpensiveCar() { Position = 2, CarName = "One-77", Price = 1.852 });
            //this.ExpensiveCarDetails.Add(new ExpensiveCar() { Position = 2, CarName = "Pagani Zonda Clinque Roadster", Price = 1.85 });
            this.ExpensiveCarDetails.Add(new ExpensiveCar() { Position = 3, CarName = "Lamborghini", Price = 1.602 });
            //this.ExpensiveCarDetails.Add(new ExpensiveCar() { Position = 3, CarName = "Koenigsegg Agera R", Price = 1.6 });
            this.ExpensiveCarDetails.Add(new ExpensiveCar() { Position = 4, CarName = "Landaulet", Price = 1.379 });
            this.ExpensiveCarDetails.Add(new ExpensiveCar() { Position = 5, CarName = "Zenvo ST1 ", Price = 1.225 });
            this.ExpensiveCarDetails.Add(new ExpensiveCar() { Position = 6, CarName = "McLaren F1", Price = 0.971 });
            this.ExpensiveCarDetails.Add(new ExpensiveCar() { Position = 7, CarName = "Ferrari Enzo", Price = 0.669 });
            this.ExpensiveCarDetails.Add(new ExpensiveCar() { Position = 8, CarName = "Pagani Zonda", Price = 0.667 });
            this.ExpensiveCarDetails.Add(new ExpensiveCar() { Position = 9, CarName = "Ultimate Aero", Price = 0.654 });
            this.ExpensiveCarDetails.Add(new ExpensiveCar() { Position = 10, CarName = "Ascari A10", Price = 0.649 });
        }

        public ObservableCollection<ExpensiveCar> ExpensiveCarDetails { get; set; }
    }
}
