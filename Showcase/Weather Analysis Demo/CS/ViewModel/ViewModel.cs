#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WeatherAnalysis
{
    class ViewModel:INotifyPropertyChanged
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
                    FeelsLike=r.Next(int.Parse(feelsLike)-5),
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
            set { data = value; OnPropertyChanged("Data"); }
        }

        public string CurrentTime
        {
            get { return DateTime.Now.ToString(@"hh':'mm tt"); }
        }

        public string CurrentDay
        {
            get { return DateTime.Now.ToString(@"dddd"); }
        }

        private string _feelsLike;
        public string feelsLike
        {
            get { return _feelsLike; }
            set { _feelsLike = value; OnPropertyChanged("feelsLike"); }
        }

        private string temperature;
        public string Temperature
        {
            get { return temperature; }
            set { temperature = value; OnPropertyChanged("Temperature"); }
        }

        private string skyCondition;
        public string SkyCondition
        {
            get { return skyCondition; }
            set { skyCondition = value; OnPropertyChanged("SkyCondition"); }
        }

        private string dewPoint;
        public string DewPoint
        {
            get { return dewPoint; }
            set { dewPoint = value; OnPropertyChanged("DewPoint"); }
        }

        private string relativeHumidity;
        public string RelativeHumidity
        {
            get { return relativeHumidity; }
            set { relativeHumidity = value; OnPropertyChanged("RelativeHumidity"); }
        }

        private string wind;
        public string Wind
        {
            get { return wind; }
            set { wind = value; OnPropertyChanged("Wind"); }
        }

        string[] condition = new string[] { "Cloudy", "Rainy", "Rainy Storm", "Partly Cloudy", "Partly Sunny", "Snow", "Fog" };

        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
