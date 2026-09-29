#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.Windows.Media;

namespace syncfusion.stockanalysisdemo.wpf
{
    public class StockData : INotifyPropertyChanged
    {
        private string selectedStock; 
        private double high;
        private double low;
        private double open;
        private double close;
        private double volume;
        private DateTime date; 

        public StockData(string selectedStock, DateTime date, double open, double high, double low, double close, double volume)
        {
            SelectedStock = selectedStock;
            Close= close;
            Open= open;
            High= high;
            Low= low;
            Volume= volume;
            Date= date;
        }  

        public string SelectedStock
        {
            get
            {
                return selectedStock;
            }
            set
            {
                selectedStock = value;
                OnPropertyChanged("SelectedStock");
            }
        }

        public double High
        {
            get
            {
                return high;
            }
            set
            {
                high = value;
                OnPropertyChanged("High");
            }
        }

        public double Low
        {
            get
            {
                return low;
            }
            set
            {
                low = value;
                OnPropertyChanged("Low");
            }
        }

        public double Open
        {
            get
            {
                return open;
            }
            set
            {
                open = value;
                OnPropertyChanged("Open");
            }
        }

        public double Close
        {
            get
            {
                return close;
            }
            set
            {
                close = value;
                OnPropertyChanged("Close");
            }
        }

        public double Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
                OnPropertyChanged("Volume");
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
