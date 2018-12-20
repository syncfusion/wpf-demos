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

namespace LINQBound
{
    #region CountryWiseSalesGroup

    /// <summary>
    /// Data CountryWiseSalesGroup collection with CountryName, RegionalSales, Sales and Expense
    /// </summary>
    /// <returns></returns>
    public class CountryWiseSalesGroup
    {
        public string CountryName { get; set; }
        public List<RegionalSales> RegionalSales { get; set; }
        public double Sales { get; set; }
        public double Expense { get; set; }
    }

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
            this.Add(new RegionalSales() { Name = "New York", Sales = 100000, Expense = 100000, Country = "US" });
            this.Add(new RegionalSales() { Name = "Los Angeles", Sales = 43523, Expense = 43523, Country = "US" });
            this.Add(new RegionalSales() { Name = "San Francisco", Sales = 45634, Expense = 45634, Country = "US" });
            //this.Add(new RegionalSales() { Name = "Chicago", Sales = 58746, Expense = 58746, Country = "US" });
            this.Add(new RegionalSales() { Name = "Vancouver", Sales = 35774, Expense = 35774, Country = "Canada" });
            this.Add(new RegionalSales() { Name = "Toronto", Sales = 79345, Expense = 46345, Country = "Canada" });
            this.Add(new RegionalSales() { Name = "Halifax", Sales = 79835, Expense = 42433, Country = "Canada" });
            //this.Add(new RegionalSales() { Name = "Montreal", Sales = 24565, Expense = 10000, Country = "Canada" });
        }
    }
    #endregion
}
