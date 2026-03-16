#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace syncfusion.weatheranalysis.wpf
{
    public class TodayWeatherTileViewModel : NotificationObject
    {
        public TodayWeatherTileViewModel()
        {
            EventManager.Instance.Subscribe<TempFormatChangedEvent, TempFormatChangedEventArgs>(FormatChanged);
            RefreshData();
            EventManager.Instance.Subscribe<DataChangedEvent, EventArgs>(RefreshData);
        }

        private void FormatChanged(TempFormatChangedEventArgs args)
        {
            IsCelsius = args.Payload.Contains("C");
        }

        private void RefreshData(EventArgs obj = null)
        {
            var datamodel = DataStore.GetSelectedTileWeather(DateTime.Now);
            City = datamodel.City;
            Today = DateTime.Now;
            Weather = datamodel.Weather;
            Temperature = datamodel.Temperature;
            TemperatureDay = datamodel.TemperatureDay;
            TemperatureNight = datamodel.TemperatureNight;
            WindSpeed = datamodel.WindSpeed;
            Feelslike = datamodel.Feelslike;
            Humidity = datamodel.Humidity;
            UVIndex = datamodel.UVIndex;
            MaxTemperature = datamodel.MaxTemperature;
            MinTemperature = datamodel.MinTemperature;
            Dew = datamodel.Dew;
            Precipitation = datamodel.Precipitation;
            MaxWind = datamodel.MaxWind;
            WeatherCollection = datamodel.WeatherCollection;
        }

        public void Dispose()
        {
            EventManager.Instance.Unsubscribe<TempFormatChangedEvent, TempFormatChangedEventArgs>(FormatChanged);
            EventManager.Instance.Unsubscribe<DataChangedEvent, EventArgs>(RefreshData);
            if (WeatherCollection != null)
            {
                WeatherCollection.Clear();
                WeatherCollection = null;
            }
        }

        private bool isCelsius = false;

        public bool IsCelsius
        {
            get { return isCelsius; }
            set { isCelsius = value; RaisePropertyChanged(nameof(IsCelsius)); }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; RaisePropertyChanged(nameof(City)); }
        }

        private float temperature;

        public float Temperature
        {
            get { return temperature; }
            set { temperature = value; RaisePropertyChanged(nameof(Temperature)); }
        }

        private float temperatureDay;

        public float TemperatureDay
        {
            get { return temperatureDay; }
            set { temperatureDay = value; RaisePropertyChanged(nameof(TemperatureDay)); }
        }

        private float temperatureNight;

        public float TemperatureNight
        {
            get { return temperatureNight; }
            set { temperatureNight = value; RaisePropertyChanged(nameof(TemperatureNight)); }
        }

        private float windSpeed;

        public float WindSpeed
        {
            get { return windSpeed; }
            set { windSpeed = value; RaisePropertyChanged(nameof(WindSpeed)); }
        }

        private float feelslike;

        public float Feelslike
        {
            get { return feelslike; }
            set { feelslike = value; RaisePropertyChanged(nameof(Feelslike)); }
        }

        private float humidity;

        public float Humidity
        {
            get { return humidity; }
            set { humidity = value; RaisePropertyChanged(nameof(Humidity)); }
        }

        private ImageSource weatherIcon;

        public ImageSource WeatherIcon
        {
            get { return weatherIcon; }
            set { weatherIcon = value; RaisePropertyChanged(nameof(WeatherIcon)); }
        }

        private float uvIndex;

        public float UVIndex
        {
            get { return uvIndex; }
            set { uvIndex = value; RaisePropertyChanged(nameof(UVIndex)); }
        }

        private float maxTemperature;
        private float minTemperature;

        public float MaxTemperature
        {
            get { return maxTemperature; }
            set { maxTemperature = value; RaisePropertyChanged(nameof(MaxTemperature)); }
        }

        public float MinTemperature
        {
            get { return minTemperature; }
            set { minTemperature = value; RaisePropertyChanged(nameof(MinTemperature)); }
        }

        private float dewPoint;

        public float Dew
        {
            get { return dewPoint; }
            set { dewPoint = value; RaisePropertyChanged(nameof(Dew)); }
        }


        private float precipitation;

        public float Precipitation
        {
            get { return precipitation; }
            set { precipitation = value; RaisePropertyChanged(nameof(Precipitation)); }
        }

        private float maxWind;

        public float MaxWind
        {
            get { return maxWind; }
            set { maxWind = value; RaisePropertyChanged(nameof(MaxWind)); }
        }

        private string weather;

        public string Weather
        {
            get { return weather; }
            set { weather = value; RaisePropertyChanged(nameof(Weather)); }
        }

        private DateTime dateTime;

        public DateTime Today
        {
            get { return dateTime; }
            set { dateTime = value; RaisePropertyChanged(nameof(Today)); }
        }

        private List<string> weatherCollection;

        public List<string> WeatherCollection
        {
            get { return weatherCollection; }
            set { weatherCollection = value; RaisePropertyChanged(nameof(WeatherCollection)); }
        }
    }
}
