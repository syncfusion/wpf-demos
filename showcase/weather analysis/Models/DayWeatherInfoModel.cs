#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace syncfusion.weatheranalysis.wpf
{
    public class DayWeatherInfoModel
    {
        public string City { get; set; }

        public double TimeOffset { get; set; }

        public float Temperature { get; set; }

        public float TemperatureDay { get; set; }

        public float TemperatureNight { get; set; }

        public int AirQuality { get; set; }

        public float WindSpeed { get; set; }

        public float Feelslike { get; set; }

        public float Humidity { get; set; }

        public DateTime SunRiseTime { get; set; }

        public DateTime SunSetTime { get; set; }

        public DateTime MoonRiseTime { get; set; }

        public DateTime MoonSetTime { get; set; }

        public float UVIndex { get; set; }

        public float MaxTemperature { get; set; }

        public float MinTemperature { get; set; }

        public string MoonPhase { get; set; }

        public float Dew { get; set; }

        public float Precipitation { get; set; }

        public float MaxWind { get; set; }

        public string Weather { get; set; }

        public ObservableCollection<HourlyWeatherInfoModel> HourlyWeatherData { get; set; }

        public List<string> WeatherCollection { get; set; }
    }
}
