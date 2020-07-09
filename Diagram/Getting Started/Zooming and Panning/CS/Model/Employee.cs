#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GettingStarted_ZoomingandPanning.Model
{
    public class Employee : INotifyPropertyChanged
    {
        private string name;
        private string imageurl;
        private string reportingPerson;
        private string _mDesignation;

        public Employee()
        {
        }

        public string Designation
        {
            get { return _mDesignation; }
            set
            {
                if (_mDesignation != value)
                {
                    _mDesignation = value;
                    OnPropertyChanged("Designation");
                }
            }
        }


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(("Name"));
                }
            }
        }

        public string ReportingPerson
        {
            get
            {
                return reportingPerson;
            }
            set
            {
                if (reportingPerson != value)
                {
                    reportingPerson = value;
                    OnPropertyChanged(("ReportingPerson"));
                }
            }
        }

        public string ImageUrl
        {
            get
            {
                return imageurl;
            }
            set
            {
                if (imageurl != value)
                {
                    if (value != null)
                    {
                        imageurl = value;
                        OnPropertyChanged(("ImageUrl"));
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }


    public class Employees : ObservableCollection<Employee>
    {

    }
}
