#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.treemapdemos.wpf
{
    public class HierarchicalCollectionTreeMapModel 
    {
       
    }
    public class CountrySale : NotificationObject
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
                    RaisePropertyChanged("Sales");
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
                    RaisePropertyChanged("Expense");
                }
            }
        }

        public ObservableCollection<RegionSale> RegionalSales { get; set; }

        public CountrySale()
        {
            this.RegionalSales = new ObservableCollection<RegionSale>();
        }
    }

    public class RegionSale : NotificationObject
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
                    RaisePropertyChanged("Sales");
                }
            }
        }
        public double Expense { get; set; }
    }
}
