#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Newtonsoft.Json;
using System;

namespace syncfusion.weatheranalysis.wpf
{
    public class DayDataDTO
    {
        public string Name { get; set; }

        public DateTime Datetime { get; set; }

        public float TempMax { get; set; }

        public float TempMin { get; set; }

        public float Temp { get; set; }

        public float Feelslike { get; set; }

        public float Dew { get; set; }

        public float Humidity { get; set; }

        public float Precip { get; set; }

        public float Precipprob { get; set; }

        public float Precipcover { get; set; }

        public object Preciptype { get; set; }

        public float Snow { get; set; }

        public float Snowdepth { get; set; }

        public float Windspeed { get; set; }

        public float Windspeedmax { get; set; }

        public float Windspeedmean { get; set; }

        public float Windspeedmin { get; set; }

        public float Winddir { get; set; }

        public float Sealevelpressure { get; set; }

        public float Visibility { get; set; }

        public float? UVindex { get; set; }

        public DateTime Sunrise { get; set; }

        public DateTime Sunset { get; set; }

        public MoonPhase MoonPhase { get; set; }

        public string Conditions { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public DateTime Moonrise { get; set; }

        public DateTime Moonset { get; set; }

        public HourlyDTO[] HoulyDataCollection { get; set; }

        public float DayTemp { get; set; }

        public float NightTemp { get; set; }
    }

    public class HourlyDTO
    {
        public DateTime Datetime { get; set; }

        public float Temp { get; set; }

        public float Feelslike { get; set; }

        public float Humidity { get; set; }

        public float Dew { get; set; }

        public float Precip { get; set; }

        public float Precipprob { get; set; }

        public float Snow { get; set; }

        public float Snowdepth { get; set; }

        public object Preciptype { get; set; }

        public float Windspeed { get; set; }

        public float Winddir { get; set; }

        public float Pressure { get; set; }

        public float Visibility { get; set; }

        public float? UVindex { get; set; }

        public string Conditions { get; set; }
    }

    public class HistoricalDataDTO
    {
        [JsonProperty("Month")]
        public string Month { get; set; }

        [JsonProperty("Avg Low Temp")]
        public int AvgLowTemp { get; set; }

        [JsonProperty("Avg High Temp")]
        public int AvgHighTemp { get; set; }

        [JsonProperty("Rain Fall")]
        public float RainFall { get; set; }

        [JsonProperty("Snow fall")]
        public int Snowfall { get; set; }
    }
}
