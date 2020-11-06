#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.datagriddemos.wpf
{
    public class EmployeeInfo : NotificationObject
    {
        private string _Name;        
        private int _ContactID;
        private string _Title;
        private DateTime _BirthDate;       
        private string _Gender;        
        private double _SickLeaveHours;
        private decimal _Salary;
        private int _EmployeeID;
        private int _rating;

        [Display(Name = "Employee ID")]
        public int EmployeeID
        {
            get { return this._EmployeeID; }
            set
            {
                this._EmployeeID = value;
                this.RaisePropertyChanged("EmployeeID");
            }
        }

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

        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                this.RaisePropertyChanged("Rating");
            }
        }

        [Display(Name ="Contact ID")]
        public int ContactID
        {
            get { return this._ContactID; }
            set
            {
                this._ContactID = value;
                this.RaisePropertyChanged("ContactID");
            }
        }

        [Display(Name = "Birth Date")]
        public DateTime BirthDate
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

        [Display(Name="Sick Leave Hours")]
        public double SickLeaveHours
        {
            get { return this._SickLeaveHours; }
            set
            {
                this._SickLeaveHours = value;
                this.RaisePropertyChanged("SickLeaveHours");
            }
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
