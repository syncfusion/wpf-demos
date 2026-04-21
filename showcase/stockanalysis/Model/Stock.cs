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
        private string stockLogo;
        private string stockName;
        private string company;
        private string graph;
        private string previousHigh;
        private double previousClose;
        private double currentClose;
        private string previousChange;
        private string currentChange; 
        private string currentHigh; 
        private string icon;
        private string stockVolume;
        private string rating;

        public Stock()
        {

        }

        public string StockLogo
        {
            get
            {
                return stockLogo;
            }
            set
            {
                stockLogo = value;
                OnPropertyChanged("StockLogo");
            }
        }

        public string StockName 
        {
            get
            {
                return stockName;
            }
            set
            {
                stockName = value;
                OnPropertyChanged("StockName");
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
                OnPropertyChanged("Company");
            }
        }

        public string Graph
        {
            get
            {
                return graph;
            }
            set
            {
                graph = value;
                OnPropertyChanged("Graph");
            }
        } 

        public string CurrentHigh
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

        public string PreviousHigh
        {
            get
            {
                return previousHigh;
            }
            set
            {
                previousHigh = value;
                OnPropertyChanged("PreviousHigh");
            }
        } 


        public string Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
                OnPropertyChanged("Icon");
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

        public double CurrentClose
        {
            get
            {
                return currentClose;
            }
            set
            {
                currentClose = value;
                OnPropertyChanged("CurrentClose");
            }
        }
        public string PreviousChange
        {
            get
            {
                return previousChange;
            }
            set
            {
                previousChange = value;
                OnPropertyChanged("PreviousChange");
            }
        }

        public string CurrentChange
        {
            get
            {
                return currentChange;
            }
            set
            {
                currentChange = value;
                OnPropertyChanged("CurrentChange");
            }
        }

        public string StockVolume
        {
            get
            {
                return stockVolume;
            }
            set
            {
                stockVolume = value;
                OnPropertyChanged("StockVolume");
            }
        }

        public string Rating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
                OnPropertyChanged("Rating");
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
