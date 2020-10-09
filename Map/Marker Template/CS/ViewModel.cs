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

namespace MarkerTemplate
{
    public class ViewModel
    {
        public ObservableCollection<Model> DataMarkers { get; set; }

        public ViewModel()
        {
            this.DataMarkers = new ObservableCollection<Model>();

            this.DataMarkers.Add(new Model()
            {
                Name = "Perth ",
                Latitude = "-31.950527",
                Longitude = "115.860457",
                Temperature = "31.6",
                ImageSource = "weather-clear.png"
            });
            this.DataMarkers.Add(new Model()
            {
                Name = "Adelaide ",
                Latitude = "-34.928499",
                Longitude = "138.600746",
                Temperature = "28.5",
                ImageSource = "weather-clouds.png"
            });

            this.DataMarkers.Add(new Model()
            {
                Name = "Townsville ",
                Latitude = "-19.2589635",
                Longitude = "146.8169483",
                Temperature = "31.3",
                ImageSource = "weather-clear.png"
            });
            this.DataMarkers.Add(new Model()
            {
                Name = "Sydney ",
                Latitude = "-33.868820",
                Longitude = "151.209296",
                Temperature = "26.4",
                ImageSource = "weather-rain.png"
            });

            this.DataMarkers.Add(new Model()
            {
                Name = "Alice Springs ",
                Latitude = "-23.698042",
                Longitude = "133.880747",
                Temperature = "36.4",
                ImageSource = "weather-clear.png"
            });
            this.DataMarkers.Add(new Model()
            {
                Name = "Brisbane ",
                Latitude = "-27.469771",
                Longitude = "153.025124",
                Temperature = "29.1",
                ImageSource = "weather-clouds.png"
            });
        }
    }
}
