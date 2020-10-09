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
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace syncfusion.weatheranalysis.wpf
{
    public class WeatherData : NotificationObject
    {
        private double _FeelsLike;
        public double FeelsLike
        {
            get { return _FeelsLike; }
            set { _FeelsLike = value; this.RaisePropertyChanged("FeelsLike"); }
        }

        private DateTime _Time;
        public DateTime Time
        {
            get { return _Time; }
            set { _Time = value; this.RaisePropertyChanged("Time"); }
        }

        private string _Condition;
        public string SkyCondition
        {
            get { return _Condition; }
            set { _Condition = value; this.RaisePropertyChanged("SkyCondition"); }
        }

        private Double _Temperature;
        public Double Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; this.RaisePropertyChanged("Temperature"); }
        }

        private Double _Humidity;
        public Double Humidity
        {
            get { return _Humidity; }
            set { _Humidity = value; this.RaisePropertyChanged("Humidity"); }
        }

        private string _DewPoint;
        public string DewPoint
        {
            get { return _DewPoint; }
            set { _DewPoint = value; this.RaisePropertyChanged("DewPoint"); }
        }

        private Double _Wind;
        public Double Wind
        {
            get { return _Wind; }
            set { _Wind = value; this.RaisePropertyChanged("Wind"); }
        }
    }
}
