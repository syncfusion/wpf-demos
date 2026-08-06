#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using System.Windows.Input;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class DockingTouchViewModel
    {
        private void PopulateCollection()
        {
            DockingTouchModel model1 = new DockingTouchModel()
            {
                Header = "Newyork",
                Country = "United States",
                Climate = Climate.Cloudy,
                FeelsLike = "-2",
                Degree = "4",
                SunRise = "7.11",
                SunSet = "5.45",
                Latitude = "45.21",
                Longitude = "21.12",
                Humidity = "50",
                ClimateTmw=Climate.Cloudy,
                DegreeTmw="30"
            };

            DockingTouchModel model2 = new DockingTouchModel()
            {
                Header = "London",
                Country = "England",
                Climate = Climate.Rainy,
                FeelsLike = "3",
                Degree = "7",
                SunRise = "6.11",
                SunSet = "6.45",
                Latitude = "49.21",
                Longitude = "41.12",
                Humidity = "10",
                ClimateTmw=Climate.Cloudy,
                DegreeTmw="11"
            };

            DockingTouchModel model3 = new DockingTouchModel()
            {
                Header = "Beijing",
                Country = "China",
                Climate = Climate.Cloudy,
                FeelsLike = "1",
                Degree = "6",
                SunRise = "5.11",
                SunSet = "7.45",
                Latitude = "25.21",
                Longitude = "11.12",
                Humidity = "10",
                ClimateTmw=Climate.Rainy,
                DegreeTmw="40"
            };

            DockingTouchModel model4 = new DockingTouchModel()
            {
                Header = "Brussels",
                Country = "Belgium",
                Climate = Climate.Cloudy,
                FeelsLike = "5",
                Degree = "8",
                SunRise = "6.05",
                SunSet = "6.45",
                Latitude = "15.21",
                Longitude = "51.12",
                Humidity = "78",
                 ClimateTmw=Climate.Rainy,
                DegreeTmw="4"
            };

            DockingTouchModel model5 = new DockingTouchModel()
            {
                Header = "Nairobi",
                Country = "Kenya",
                Climate = Climate.Sunny,
                FeelsLike = "34",
                Degree = "40",
                SunRise = "5.16",
                SunSet = "6.45",
                Latitude = "62.21",
                Longitude = "18.12",
                Humidity = "2",
                ClimateTmw = Climate.Cloudy,
                DegreeTmw="30"
            };

            DockingTouchModel model6 = new DockingTouchModel()
            {
                Header = "Madagascar",
                Country = "Antananarivo",
                Climate = Climate.Sunny,
                FeelsLike = "30",
                Degree = "32",
                SunRise = "7.00",
                SunSet = "6.45",
                Latitude = "15.21",
                Longitude = "71.12",
                Humidity = "10",
                ClimateTmw=Climate.Cloudy,
                DegreeTmw="20"
            };

            DockingTouchModel model7 = new DockingTouchModel()
            {
                Header = "New Delhi",
                Country = "India",
                Climate = Climate.Sunny,
                FeelsLike = "36",
                Degree = "38",
                SunRise = "6.00",
                SunSet = "6.45",
                Latitude = "85.21",
                Longitude = "31.12",
                Humidity = "7",
                ClimateTmw=Climate.Rainy,
                DegreeTmw="30"
            };

            ModelItems.Add(model3);
            ModelItems.Add(model6);
            ModelItems.Add(model1);
            ModelItems.Add(model2);
            ModelItems.Add(model4);
            ModelItems.Add(model5);
            ModelItems.Add(model7);
        }

        private ObservableCollection<DockingTouchModel> modelItems;
        public ObservableCollection<DockingTouchModel> ModelItems
        {
            get
            {
                return modelItems;
            }

            set
            {
                modelItems = value;
            }
        }
        public DockingTouchViewModel()
        {
            ModelItems = new ObservableCollection<DockingTouchModel>();
            PopulateCollection();
        }

    }
}
