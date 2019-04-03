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
using Syncfusion.Windows.Tools.Controls;
using System.Windows;

namespace Office2013ThemeDemo
{
    public class Model:FrameworkElement
    {
        public string City { get; set; }

        public int TemperatureNow { get; set; }

        public int TemperatureToNight { get; set; }

        public int TemperatureTomoNight { get; set; }

        public string ConditionToNight { get; set; }

        public string ConditionTomoNight { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int FeelsLike { get; set; }

        public int Humidity { get; set; }

        public string WeatherNow { get; set; }

        public string WeatherToNight { get; set; }

        public string WeatherTomoNight { get; set; }
    }
}
