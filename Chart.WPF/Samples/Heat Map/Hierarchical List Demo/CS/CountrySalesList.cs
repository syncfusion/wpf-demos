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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HierarchicalList
{
    #region Hierarchical Data

    public class CountrySalesList : ObservableCollection<CountrySale>
    {
        public CountrySalesList()
        {
            this.Add(new CountrySale() { Name = "US", Sales = 100000, Expense = 100000 });
            this.Add(new CountrySale() { Name = "Canada", Sales = 43523, Expense = 43523 });
            this.Add(new CountrySale() { Name = "Mexico", Sales = 45634, Expense = 45634 });

            this[0].RegionalSales.Add(new RegionSale() { Name = "New York", Revenue = 2353, Expenditure = 2353 });
            this[0].RegionalSales.Add(new RegionSale() { Name = "Los Angeles", Revenue = 3453, Expenditure = 3453 });
            this[0].RegionalSales.Add(new RegionSale() { Name = "San Francisco", Revenue = 8456, Expenditure = 8456 });
            this[0].RegionalSales.Add(new RegionSale() { Name = "Chicago", Revenue = 6785, Expenditure = 6785 });
            this[0].RegionalSales.Add(new RegionSale() { Name = "Miami", Revenue = 7045, Expenditure = 7045 });


            this[1].RegionalSales.Add(new RegionSale() { Name = "Toronto", Revenue = 7045, Expenditure = 7045 });
            this[1].RegionalSales.Add(new RegionSale() { Name = "Vancouver", Revenue = 4352, Expenditure = 4352 });
            this[1].RegionalSales.Add(new RegionSale() { Name = "Winnipeg", Revenue = 7843, Expenditure = 7843 });


            this[2].RegionalSales.Add(new RegionSale() { Name = "Mexico City", Revenue = 7843, Expenditure = 7843 });
            this[2].RegionalSales.Add(new RegionSale() { Name = "Cancun", Revenue = 7683, Expenditure = 7683 });
            this[2].RegionalSales.Add(new RegionSale() { Name = "Acapulco", Revenue = 2454, Expenditure = 2454 });
        }
    }
    public class CountrySale : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private double _sales = 0;
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

        private double _expense = 0;
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

        public ObservableCollection<RegionSale> RegionalSales { get; set; }

        public CountrySale()
        {
            this.RegionalSales = new ObservableCollection<RegionSale>();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, e);
        }
        #endregion
    }

    public class RegionSale : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private double _sales = 0;
        public double Revenue
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
        public double Expenditure { get; set; }

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
