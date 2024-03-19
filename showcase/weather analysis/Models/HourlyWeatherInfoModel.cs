#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace syncfusion.weatheranalysis.wpf
{
    public class HourlyWeatherInfoModel
    {
        public string Date { get; set; }

        public DateTime DateTime { get; set; }

        public float Temperature { get; set; }

        public string Weather { get; set; }

        public float Precipitation { get; set; }

        public float Humidity { get; set; }

        public float? UVIndex { get; set; }

        public float DewPoint { get; set; }

        public float Pressure { get; set; }

        public float WindSpeed { get; set; }

        public float Feelslike { get; set; }

        public ImageSource WeatherIcon { get; set; }

        public float Visibility { get; set; }

        public List<string> WeatherCollection { get; set; }
    }
}
