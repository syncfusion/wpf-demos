#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using OrganizationLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AutomaticLayout_OrganizationLayout
{
    public class Employee : INotifyPropertyChanged
    {
        private string name;
        private string imageurl;
        private string heatmap = "#FFC34444";
        private string reportingPerson;

        public Employee()
        {
            Models = new ObservableCollection<Employee>();
        }
        
        private string _mDesignation;
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


        private SolidColorBrush ColorConverter(string hexaColor)
        {
            if (hexaColor != null)
            {
                byte r = Convert.ToByte(hexaColor.Substring(1, 2), 16);
                byte g = Convert.ToByte(hexaColor.Substring(3, 2), 16);
                byte b = Convert.ToByte(hexaColor.Substring(5, 2), 16);
                byte a = Convert.ToByte(hexaColor.Substring(7, 2), 16);
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(r, g, b, a));
                return myBrush;
            }
            return null;
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
       

        public string RatingColor
        {
            get
            {
                return heatmap;
            }
            set
            {
                if (heatmap != value)
                {
                    if (value != null)
                    {
                        heatmap = value;
                        OnPropertyChanged(("RatingColor"));
                    }
                }
            }
        }

        private ObservableCollection<Employee> models;


        public ObservableCollection<Employee> Models
        {
            get { return models; }
            set
            {
                models = value;
                OnPropertyChanged(("Models"));
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
