#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace syncfusion.weatheranalysis.wpf
{
    public class ViewModel : NotificationObject
    {
        public ViewModel()
        {
            SkyCondition = condition[r.Next(condition.Count() - 1)];
            Temperature = GetTemperature(SkyCondition);
            RelativeHumidity = r.Next(80, 96).ToString();
            DewPoint = int.Parse(Temperature) > 0 ? r.Next(int.Parse(Temperature)).ToString() : "10";
            Wind = "5";
            feelsLike = r.Next(25, 60).ToString();
            PopulateData();
        }

        public void PopulateData()
        {
            Data = new ObservableCollection<WeatherData>();
            var today = DateTime.Today;

            for (int i = 0; i < 24; i++)
                Data.Add(new WeatherData()
                {
                    FeelsLike = r.Next(int.Parse(feelsLike) - 5),
                    Time = today.AddHours(i),
                    Temperature = r.Next(int.Parse(Temperature) - 5, int.Parse(Temperature) + 5),
                    Humidity = r.Next(int.Parse(RelativeHumidity) - 5, 100),
                    DewPoint = r.Next(int.Parse(DewPoint) - 5, int.Parse(DewPoint) + 5).ToString(),
                    SkyCondition = condition[r.Next(condition.Count() - 1)],
                    Wind = r.Next(int.Parse(Wind) - 5, int.Parse(Wind) + 5)
                });
        }

        private string GetTemperature(string SkyCondition)
        {
            switch (skyCondition)
            {
                case "Cloudy":
                    return "22";
                case "Rainy":
                    return "10";
                case "Rainy Storm":
                    return "4";
                case "Overcast":
                    return "17";
                case "Partly Cloudy":
                    return "20";
                case "Partly Sunny":
                    return "28";
                case "Drizzle":
                    return "14";
                case "Snow":
                    return "-4";
                case "Fog":
                    return "2";
                default:
                    return "";
            }
        }

        Random r = new Random();

        private ObservableCollection<WeatherData> data;
        public ObservableCollection<WeatherData> Data
        {
            get { return data; }
            set { data = value; RaisePropertyChanged("Data"); }
        }

        private string _feelsLike;
        public string feelsLike
        {
            get { return _feelsLike; }
            set { _feelsLike = value; RaisePropertyChanged("feelsLike"); }
        }

        private string temperature;
        public string Temperature
        {
            get { return temperature; }
            set { temperature = value; RaisePropertyChanged("Temperature"); }
        }

        private string skyCondition;
        public string SkyCondition
        {
            get { return skyCondition; }
            set { skyCondition = value; RaisePropertyChanged("SkyCondition"); }
        }

        private string dewPoint;
        public string DewPoint
        {
            get { return dewPoint; }
            set { dewPoint = value; RaisePropertyChanged("DewPoint"); }
        }

        private string relativeHumidity;
        public string RelativeHumidity
        {
            get { return relativeHumidity; }
            set { relativeHumidity = value; RaisePropertyChanged("RelativeHumidity"); }
        }

        private string wind;
        public string Wind
        {
            get { return wind; }
            set { wind = value; RaisePropertyChanged("Wind"); }
        }

        string[] condition = new string[] { "Cloudy", "Rainy", "Rainy Storm", "Partly Cloudy", "Partly Sunny", "Snow", "Fog" };
    }
}
