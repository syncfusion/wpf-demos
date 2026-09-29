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
