using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WeatherAnalysis
{
    class WeatherData:INotifyPropertyChanged
    {

        private double _FeelsLike;
        public double FeelsLike
        {
            get { return _FeelsLike; }
            set { _FeelsLike = value; OnPropertyChanged("FeelsLike"); }
        }

        private DateTime _Time;
        public DateTime Time
        {
            get { return _Time; }
            set { _Time = value; OnPropertyChanged("Time"); }
        }

        private string _Condition;
        public string SkyCondition
        {
            get { return _Condition; }
            set { _Condition = value; OnPropertyChanged("SkyCondition"); }
        }

        private Double _Temperature;
        public Double Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; OnPropertyChanged("Temperature"); }
        }

        private Double _Humidity;
        public Double Humidity
        {
            get { return _Humidity; }
            set { _Humidity = value; OnPropertyChanged("Humidity"); }
        }

        private string _DewPoint;
        public string DewPoint
        {
            get { return _DewPoint; }
            set { _DewPoint = value; OnPropertyChanged("DewPoint"); }
        }

        private Double _Wind;
        public Double Wind
        {
            get { return _Wind; }
            set { _Wind = value; OnPropertyChanged("Wind"); }
        }
       
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
