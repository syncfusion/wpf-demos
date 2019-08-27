#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverterDemo
{
    public class ViewModel : INotifyPropertyChanged
    {
        private double area = 10.0;
        private double data = 1;
        private double length = 10.0;
        private double temperature = 10;
        private double time = 1;
        private double weight = 10000;
        private double volume = 10000.0;
        private double currency = 10;

        public double Area
        {
            get { return area; }
            set { area = value; RaisePropertyChanged("Area"); }
        }

        public double Data
        {
            get { return data; }
            set { data = value; RaisePropertyChanged("Data"); }
        }

        public double Length
        {
            get { return length; }
            set { length = value; RaisePropertyChanged("Length"); }
        }

        public double Temperature
        {
            get { return temperature; }
            set { temperature = value; RaisePropertyChanged("Temperature"); }
        }

        public double Time
        {
            get { return time; }
            set { time = value; RaisePropertyChanged("Time"); }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; RaisePropertyChanged("Weight"); }
        }

        public double Volume
        {
            get { return volume; }
            set { volume = value; RaisePropertyChanged("Volume"); }
        }

        public double Currency
        {
            get { return currency; }
            set { currency = value; RaisePropertyChanged("Currency"); }
        }

        private CultureModel culture;

        public CultureModel Culture
        {
            get
            {
                return culture;
            }
        }

        public ViewModel()
        {
            culture = new CultureModel();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
