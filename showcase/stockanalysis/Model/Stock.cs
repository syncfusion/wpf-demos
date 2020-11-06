#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.ComponentModel;

namespace syncfusion.stockanalysisdemo.wpf
{
    public class Stock : INotifyPropertyChanged
    {
        List<StockData> datas;
        Stock selectedStock;
        private double currentLow;
        private double currentClose;
        private double currentHigh;
        private double previousClose;

        public Stock()
        {

        }

        public string StockName 
        { 
            get; 
            set; 
        }

        public List<StockData> OrgDatas
        {
            get;
            set;
        }

        public List<StockData> Datas
        {
            get
            {
                return datas;
            }
            set
            {
                datas = value;
                selectedStock = this;
                OnPropertyChanged("Datas");
            }
        }
      
        public Stock SelectedStock
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

        public double CurrentLow
        {
            get
            {
                return currentLow;
            }
            set
            {
                currentLow = value;
                OnPropertyChanged("CurrentLow");
            }
        }

        public double CurrentHigh
        {
            get
            {
                return currentHigh;
            }
            set
            {
                currentHigh = value;
                OnPropertyChanged("CurrentHigh");
            }
        }

        public double CurrentClose
        {
            get
            {
                return currentClose;
            }
            set
            {
                currentClose = value;
                OnPropertyChanged("TodayClose");
            }
        }

        public double PreviousClose
        {
            get
            {
                return previousClose;
            }
            set
            {
                previousClose = value;
                OnPropertyChanged("PreviousClose");
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
