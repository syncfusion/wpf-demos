#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HierarchicalCollectionTreeMap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.treemap.DataContext = new CountrySalesCollection();
        }
    }
    public class CountrySalesCollection : ObservableCollection<CountrySale>
    {
        public CountrySalesCollection()
        {
            this.Add(new CountrySale() { Name = "United States", Sales = 98456, Expense = 87000 });
            this.Add(new CountrySale() { Name = "Canada", Sales = 43523, Expense = 40000 });
            this.Add(new CountrySale() { Name = "Mexico", Sales = 45634, Expense = 46000 });

            this[0].RegionalSales.Add(new RegionSale() { Country = "United States", Name = "New York", Sales = 2353, Expense = 2000 });
            this[0].RegionalSales.Add(new RegionSale() { Country = "United States", Name = "Los Angeles", Sales = 3453, Expense = 3000 });
            this[0].RegionalSales.Add(new RegionSale() { Country = "United States", Name = "San Francisco", Sales = 8456, Expense = 8000 });
            this[0].RegionalSales.Add(new RegionSale() { Country = "United States", Name = "Chicago", Sales = 6785, Expense = 7000 });
            this[0].RegionalSales.Add(new RegionSale() { Country = "United States", Name = "Miami", Sales = 7045, Expense = 6000 });


            this[1].RegionalSales.Add(new RegionSale() { Country = "Canada", Name = "Toronto", Sales = 7045, Expense = 7000 });
            this[1].RegionalSales.Add(new RegionSale() { Country = "Canada", Name = "Vancouver", Sales = 4352, Expense = 4000 });
            this[1].RegionalSales.Add(new RegionSale() { Country = "Canada", Name = "Winnipeg", Sales = 7843, Expense = 7500 });


            this[2].RegionalSales.Add(new RegionSale() { Country = "Mexico", Name = "Mexico City", Sales = 7843, Expense = 6500 });
            this[2].RegionalSales.Add(new RegionSale() { Country = "Mexico", Name = "Cancun", Sales = 6683, Expense = 6000 });
            this[2].RegionalSales.Add(new RegionSale() { Country = "Mexico", Name = "Acapulco", Sales = 2454, Expense = 2000 });
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

        public string Country { get; set; }

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
        public double Expense { get; set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, e);
        }
        #endregion
    }

}
