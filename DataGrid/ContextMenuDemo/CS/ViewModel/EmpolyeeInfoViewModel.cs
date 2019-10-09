#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace ContextMenuDemo
{

    public class EmployeeInfoViewModel : INotifyPropertyChanged
    {
        public EmployeeInfoViewModel()
        {
            EmployeeDetails = new EmployeeSource();
        }

        private ObservableCollection<BusinessObjects> employeeDetails;
        public ObservableCollection<BusinessObjects> EmployeeDetails
        {
            get
            {
                return employeeDetails;
            }
            set
            {
                employeeDetails = value;
                OnPropertyChanged("EmployeeDetails");
            }

        }
      
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

}
