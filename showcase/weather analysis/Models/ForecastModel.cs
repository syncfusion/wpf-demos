#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public class ForecastModel
    {
        public DateTime Date { get; set; }

        public ImageSource WeatherIcon { get; set; }

        public float DayTemperature { get; set; }

        public float NightTemperature { get; set; }

        public string Weather { get; set; }

        public List<string> WeatherCollection { get; set; }
    }
}
