#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using System.Collections.ObjectModel;

namespace FlatList
{
   public class DataViewModel
    {
       string[] countries;
       Random rand = new Random();

        public DataViewModel()
        {
             countries= new string[] 
            { 
                "Canada", 
                "Mexico", 
                "Brazil", 
                "Oregon", 
                "Utah", 
                "North Carolina", 
                "South Carolina", 
                "Florida", 
                "Louisiana", 
                "Arizona", 
                "Argentina", 
                "Texas"
            };
            salesList = new ObservableCollection<RegionalSales>();           
            salesList.Add(new RegionalSales() { Name = "US", Sales = 10000, Expense = 200 });
            for (int i = 0; i < 6; i++)
                this.salesList.Add(new RegionalSales() { Name = countries[rand.Next(countries.Length - 1)], Sales = rand.Next(1000, 7000), Expense = rand.Next(100, 500) });            
        }

        public void Add()
        {
            this.salesList.Add(new RegionalSales() { Name = countries[rand.Next(0, countries.Length - 1)], Sales = rand.Next(1000, 8000), Expense = rand.Next(100, 500) });
        }

        public ObservableCollection<RegionalSales> salesList { get; set; }
    }

   #region RegionalSales Class
    public class RegionalSales : INotifyPropertyChanged
    {
        #region Loal Variables [Private Members]
        
        private double _sales = 0;
        private double _expense = 0;

        #endregion
        
        #region Properties [Public Members]
        
        public string Name { get; set; }

        public double Sales
        {
            get { return _sales; }
            set
            {
                if (_sales != value)
                {
                    _sales = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Sales"));
                }
            }
        }

        public double Expense
        {
            get { return _expense; }
            set
            {
                if (_expense != value)
                {
                    _expense = value;
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Expense"));
                }
            }
        }

        public string Country { get; set; }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, e);
        }

        #endregion
    }

    #endregion

}
