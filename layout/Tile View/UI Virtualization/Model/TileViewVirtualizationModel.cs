#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;

namespace syncfusion.layoutdemos.wpf
{
    public class NotificationObject : INotifyPropertyChanged
    {
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class BaseEmployee : NotificationObject
    {
        private int _EmployeeID;

        public int EmployeeID
        {
            get { return this._EmployeeID; }
            set
            {
                this._EmployeeID = value;
                this.RaisePropertyChanged("EmployeeID");
            }
        }
    }

    public class Employee : BaseEmployee
    {
        private string _Name;

        private int _ContactID;
        private string _Title;
        private string _BirthDate;
        private string _Gender;
        private double _SickLeaveHours;
        private decimal _Salary;
        private string _image;
        private string _maximage;
        private string city;
        private string emailId;

        public string Name
        {
            get { return this._Name; }
            set
            {
                this._Name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        public string Title
        {
            get { return this._Title; }
            set
            {
                this._Title = value;
                this.RaisePropertyChanged("Title");
            }
        }

        public int ContactID
        {
            get { return this._ContactID; }
            set
            {
                this._ContactID = value;
                this.RaisePropertyChanged("ContactID");
            }
        }

        public string MinimizedProfileImage
        {
            get { return _image; }
            set { _image = value; this.RaisePropertyChanged("ProfileImage"); }
        }
      
        public string MaximizedProfileImage
        {
            get { return _maximage; }
            set { _maximage = value; this.RaisePropertyChanged("ProfileImage"); }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                this.RaisePropertyChanged("City");
            }
        }

        public String BirthDate
        {
            get { return this._BirthDate; }
            set
            {
                this._BirthDate = value;
                this.RaisePropertyChanged("BirthDate");
            }
        }

        public string Gender
        {
            get { return this._Gender; }
            set
            {
                this._Gender = value;
                this.RaisePropertyChanged("Gender");
            }
        }

        public double SickLeaveHours
        {
            get { return this._SickLeaveHours; }
            set
            {
                this._SickLeaveHours = value;
                this.RaisePropertyChanged("SickLeaveHours");
            }
        }

        public string EmailID
        {
            get { return emailId; }
            set { emailId = value; this.RaisePropertyChanged("EmailID"); }
        }

        public decimal Salary
        {
            get { return this._Salary; }
            set
            {
                this._Salary = value;
                this.RaisePropertyChanged("Salary");
            }
        }
    }
}
