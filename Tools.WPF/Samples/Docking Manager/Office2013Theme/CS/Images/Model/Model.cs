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
