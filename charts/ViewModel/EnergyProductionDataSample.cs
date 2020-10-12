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
    public class EnergyProductionDataSample
    {
        public string[] StrokeDashArray
        {
            get
            {
                return new string[] { "2,2", "2,4", "4.2", "1,0" };
            }
        }

        public EnergyProductionDataSample()
        {
            EnergyProductions = new ObservableCollection<EnergyProduction>();
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 1,
                Region = "America",
                Country = "Canada",
                Coal = 400,
                Oil = 100,
                Gas = 175,
                Nuclear = 225,
                VerticalErrorValue = 20,
                HorizontalErrorValue = 5
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 2,
                Region = "Asia",
                Country = "China",
                Coal = 925,
                Oil = 200,
                Gas = 350,
                Nuclear = 400,
                VerticalErrorValue = 30,
                HorizontalErrorValue = 3
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 3,
                Region = "Europe",
                Country = "Russia",
                Coal = 550,
                Oil = 200,
                Gas = 250,
                Nuclear = 475,
                VerticalErrorValue = 28,
                HorizontalErrorValue = 2
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 4,
                Region = "Asia",
                Country = "Australia",
                Coal = 450,
                Oil = 100,
                Gas = 150,
                Nuclear = 175,
                VerticalErrorValue = 20,
                HorizontalErrorValue = 1
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 5,
                Region = "America",
                Country = "United States",
                Coal = 800,
                Oil = 250,
                Gas = 475,
                Nuclear = 575,
                VerticalErrorValue = 40,
                HorizontalErrorValue = 2.5
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 6,
                Region = "Europe",
                Country = "France",
                Coal = 375,
                Oil = 150,
                Gas = 350,
                Nuclear = 275,
                VerticalErrorValue = 55,
                HorizontalErrorValue = 0.5
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 7,
                Region = "Europe",
                Country = "Itly",
                Coal = 289,
                Oil = 150,
                Gas = 350,
                Nuclear = 275,
                VerticalErrorValue = 15,
                HorizontalErrorValue = 0.11
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 8,
                Region = "Asia",
                Country = "India",
                Coal = 654,
                Oil = 150,
                Gas = 350,
                Nuclear = 275,
                VerticalErrorValue = 20,
                HorizontalErrorValue = 0.4
            });
            EnergyProductions.Add(new EnergyProduction
            {
                ID = 9,
                Region = "Asia",
                Country = "China",
                Coal = 765,
                Oil = 180,
                Gas = 450,
                Nuclear = 375,
                VerticalErrorValue = 65,
                HorizontalErrorValue = 0.2
            });
        }

        public ObservableCollection<EnergyProduction> EnergyProductions { get; set; }
    }
}
