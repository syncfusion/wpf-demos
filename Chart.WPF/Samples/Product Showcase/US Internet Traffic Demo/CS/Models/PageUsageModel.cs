#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace USInternetTrafficDemo
{
    public class MonthlyPageUsageModel : INotifyPropertyChanged
    {
        public MonthlyPageUsageModel()
        {

        }

        private string _DateTime;
        public string DateTime
        {
            get
            {
                return _DateTime;
            }
            set
            {
                _DateTime = value;
                this.OnPropertyChanged("DateTime");
            }
        }


        private double _TotalVisits;
        public double TotalVisits
        {
            get
            {
                return _TotalVisits;
            }
            set
            {
                _TotalVisits = value;
                this.OnPropertyChanged(TotalVisits);
            }
        }

        private double _AvgTimeSpend;
        public double AvgTimeSpend
        {
            get
            {
                return _AvgTimeSpend;
            }
            set
            {
                this._AvgTimeSpend = value;
                this.OnPropertyChanged("AvgTimeSpend");
            }
        }

        private double _NewVisitors;
        public double NewVisitors
        {
            get
            {
                return _NewVisitors;
            }
            set
            {
                _NewVisitors = value;
                this.OnPropertyChanged("NewVisitors");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(object Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Property"));
            }
        }
    }
}
