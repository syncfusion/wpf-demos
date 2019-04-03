#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace CollectionViewSource
{
    #region Data
    public class RegionalSales : INotifyPropertyChanged
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
        public string Country { get; set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, e);
        }

    }

    public class SalesList : List<RegionalSales>
    {
        public SalesList()
        {
            this.Add(new RegionalSales() { Name = "New York", Sales = 90000, Expense = 100000, Country = "US" });
            this.Add(new RegionalSales() { Name = "Los Angeles", Sales = 30523, Expense = 55500, Country = "US" });
            this.Add(new RegionalSales() { Name = "San Francisco", Sales = 55600, Expense = 55600, Country = "US" });
            this.Add(new RegionalSales() { Name = "Chicago", Sales = 72746, Expense = 86750, Country = "US" });
            this.Add(new RegionalSales() { Name = "Vancouver", Sales = 65774, Expense = 75000, Country = "Canada" });
            this.Add(new RegionalSales() { Name = "Toronto", Sales = 94500, Expense = 96450, Country = "Canada" });
            this.Add(new RegionalSales() { Name = "Halifax", Sales = 37935, Expense = 42433, Country = "Canada" });
            this.Add(new RegionalSales() { Name = "Montreal", Sales = 55650, Expense = 60000, Country = "Canada" });
        }
    }
    #endregion
}
