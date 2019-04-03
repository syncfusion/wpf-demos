#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using PrintingDemo.Model;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace PrintingDemo
{
    class EmployeeInfoViewModel : INotifyPropertyChanged
    {
        Northwind northWind;
        public EmployeeInfoViewModel()
        {
            EmployeeDetails = this.GetEmployeeInfo();
        }

        private ObservableCollection<Orders> employeeDetails;
        public ObservableCollection<Orders> EmployeeDetails
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

        public ObservableCollection<Orders> GetEmployeeInfo()
        {
            var employeesInfo = new ObservableCollection<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                northWind = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));
                var ords = northWind.Orders.Take(200);
                foreach (var em in ords)
                {
                    employeesInfo.Add(em);
                }
            }
            return employeesInfo;
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
