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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace USInternetTrafficDemo
{
    public class StateWiseWebPageUsageModel:INotifyPropertyChanged
    {
       
        public StateWiseWebPageUsageModel(string name)
        {
            //this.MonthlyUsages = new ObservableCollection<MonthlyPageUsageModel>();
            //string[] months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            //for (int i = 0; i < 12; i++)
            //{
            //    this.MonthlyUsages.Add(new MonthlyPageUsageModel() { AvgTimeSpend = rand.Next(5,35), DateTime = months[i], NewVisitors = rand.Next(0,150), TotalVisits = rand.Next(230,23000) });
            //}
            this.Name = name;
        }

        private ObservableCollection<MonthlyPageUsageModel> _MonthlyUsages;
        public ObservableCollection<MonthlyPageUsageModel> MonthlyUsages
        {
            get
            {
                return this._MonthlyUsages;
            }
            set
            {
                this._MonthlyUsages = value;
                this.OnPropertyChanged("MonthlyUsages");
            }
        }


        private string _Name;
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
                this.OnPropertyChanged("Name");
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
