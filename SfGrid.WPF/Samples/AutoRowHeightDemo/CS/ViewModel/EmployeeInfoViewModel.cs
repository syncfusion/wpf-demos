#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using AutoRowHeightDemo.Model;
using Syncfusion.Windows.Shared;

namespace AutoRowHeightDemo
{
    public class EmployeeInfoViewModel : INotifyPropertyChanged
    {
        public EmployeeInfoViewModel()
        {
            CustomerDetails = new EmployeeInfoRespository().PopulateEmployees(200);
        }

        private ObservableCollection<Customers> customerDetails;
        public ObservableCollection<Customers> CustomerDetails
        {
            get
            {
                return customerDetails;
            }
            set
            {
                customerDetails = value;
                OnPropertyChanged("CustomerDetails");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
