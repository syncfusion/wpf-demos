#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class PieChart3DViewModel: NotificationObject , IDisposable
    {
        private double startAngle;
        private double endAngle;

        public double StartAngle
        {
            get
            {
                return startAngle;
            }

            set
            {
                startAngle = value;
                RaisePropertyChanged(nameof(this.StartAngle));
            }
        }
        public double EndAngle
        {
            get
            {
                return endAngle;
            }

            set
            {
                endAngle = value;
                RaisePropertyChanged(nameof(this.EndAngle));
            }
        }
        public ObservableCollection<PieChart3DModel> FoodData { get; set; }
        public ObservableCollection<PieChart3DModel> CropData { get; set; }
        public ObservableCollection<PieChart3DModel> UraniumData { get; set; }
        public ObservableCollection<PieChart3DModel> HobbiesData { get; set; }
        public ObservableCollection<PieChart3DModel> RiceData { get; set; }
        public ObservableCollection<PieChart3DModel> EarthData { get; set; }

        public PieChart3DViewModel()
        {
            StartAngle = 180;
            EndAngle = 360;

            //Default Pie
            this.FoodData = new ObservableCollection<PieChart3DModel>();
            FoodData.Add(new PieChart3DModel() { Category = "Rice", Percentage=30 });
            FoodData.Add(new PieChart3DModel() { Category = "Cereals", Percentage = 20 });
            FoodData.Add(new PieChart3DModel() { Category = "Vegetables", Percentage = 33 });
            FoodData.Add(new PieChart3DModel() { Category = "Milk", Percentage = 10 });
            FoodData.Add(new PieChart3DModel() { Category = "Water", Percentage = 7 });

            //Semi Pie
            this.CropData = new ObservableCollection<PieChart3DModel>();
            CropData.Add(new PieChart3DModel() { Category = "Cannabis", Percentage = 5 });
            CropData.Add(new PieChart3DModel() { Category = "Corn", Percentage = 82.6 });
            CropData.Add(new PieChart3DModel() { Category = "Cotton", Percentage = 7.5 });
            CropData.Add(new PieChart3DModel() { Category = "Soybeans", Percentage = 57.5 });
            CropData.Add(new PieChart3DModel() { Category = "Hay", Percentage = 19.3 });
            CropData.Add(new PieChart3DModel() { Category = "Wheat", Percentage = 11.9 });

            //Exploded pie
            this.UraniumData = new ObservableCollection<PieChart3DModel>();
            UraniumData.Add(new PieChart3DModel() { Category = "Kazakhstan", Percentage = 26.82 });
            UraniumData.Add(new PieChart3DModel() { Category = "Niger", Percentage = 25.38 });
            UraniumData.Add(new PieChart3DModel() { Category = "Canada", Percentage = 21.99 });
            UraniumData.Add(new PieChart3DModel() { Category = "Russia", Percentage = 16.89 });
            UraniumData.Add(new PieChart3DModel() { Category = "Uzbekistan", Percentage = 3.76 });
            UraniumData.Add(new PieChart3DModel() { Category = "Others", Percentage = 5.17 });

            // Default Doughnut 
            this.HobbiesData = new ObservableCollection<PieChart3DModel>();
            HobbiesData.Add(new PieChart3DModel() { Category = "Work", Percentage = 45.8 });
            HobbiesData.Add(new PieChart3DModel() { Category = "Eat", Percentage = 8.3 });
            HobbiesData.Add(new PieChart3DModel() { Category = "Travel", Percentage = 8.3 });
            HobbiesData.Add(new PieChart3DModel() { Category = "Watch TV", Percentage = 8.3 });
            HobbiesData.Add(new PieChart3DModel() { Category = "Sleep", Percentage = 29.3 });

            // Semi Doughnut 
            this.RiceData = new ObservableCollection<PieChart3DModel>();
            RiceData.Add(new PieChart3DModel() { Category = "India", Percentage = 22500 });
            RiceData.Add(new PieChart3DModel() { Category = "Thailand", Percentage = 8500 });
            RiceData.Add(new PieChart3DModel() { Category = "Vietnam", Percentage = 7500 });
            RiceData.Add(new PieChart3DModel() { Category = "Pakistan", Percentage = 3600 });
            RiceData.Add(new PieChart3DModel() { Category = "US", Percentage = 2125 });
            RiceData.Add(new PieChart3DModel() { Category = "Others", Percentage = 11423 });

            //Exploded Doughnut 
            this.EarthData = new ObservableCollection<PieChart3DModel>();
            EarthData.Add(new PieChart3DModel() { Continent = "Asia", Percentage = 29.6 });
            EarthData.Add(new PieChart3DModel() { Continent = "Africa", Percentage = 20.2 });
            EarthData.Add(new PieChart3DModel() { Continent = "North America", Percentage = 16.4 });
            EarthData.Add(new PieChart3DModel() { Continent = "South America", Percentage = 11.9 });
            EarthData.Add(new PieChart3DModel() { Continent = "Antarctica", Percentage = 9.4 });
            EarthData.Add(new PieChart3DModel() { Continent = "Europe", Percentage = 6.8 });
            EarthData.Add(new PieChart3DModel() { Continent = "Australia", Percentage = 5.7 });
        }

        public void Dispose()
        {
            if(FoodData != null)
                FoodData.Clear();

            if (CropData != null)
                CropData.Clear(); 

            if (UraniumData != null)
                UraniumData.Clear();

            if (HobbiesData != null)
                HobbiesData.Clear();

            if (RiceData != null)
                RiceData.Clear();

            if (EarthData != null)
                EarthData.Clear();

        }
    }
}
