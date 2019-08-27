#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Media;
using Syncfusion.Windows.Shared;

namespace DockingManagerTouchDemo_2010
{
   public class Model :NotificationObject
    {
        public Model()
        {
            
        }

        #region TabItemExt Properties
        /// <summary>
        /// Gets or sets a value indicating header of the TabItemExt.        
        /// </summary>
        private string header;
        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
                this.RaisePropertyChanged("Header");
            }
        }

        private ImageSource content = null;
        public ImageSource Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
                this.RaisePropertyChanged("Content");
            }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        private Climate climate;

        public Climate Climate
        {
            get { return climate; }
            set { climate = value; }
        }

        private string sunrise;

        public string SunRise
        {
            get { return sunrise; }
            set { sunrise = value; }
        }

        private string sunset;

        public string SunSet
        {
            get { return sunset; }
            set { sunset = value; }
        }

        private string feelsLike;

        public string FeelsLike
        {
            get { return feelsLike; }
            set { feelsLike = value; }
        }

        private string latitude;

        public string Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        private string longitude;

        public string Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        private string humidity;

        public string Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }

        private string degree;

        public string Degree
        {
            get { return degree; }
            set { degree = value; }
        }

        private string degreetmw;

        public string DegreeTmw
        {
            get { return degreetmw; }
            set { degreetmw = value; }
        }

        private Climate climatetmw;

        public Climate ClimateTmw
        {
            get { return climatetmw; }
            set { climatetmw = value; }
        }

        #endregion
    }

    public enum Climate
    {
        Sunny,

        Cloudy,

        Rainy
    }

    public class WeatherConverter : IValueConverter
    {

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((Climate)value == Climate.Sunny)
            {
                return "/Images/sunny.png";
            }
            else if ((Climate)value == Climate.Rainy)
            {
                return "/Images/rainy.png";
            }
            else
            {
                return "/Images/cloudy.png";
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}


