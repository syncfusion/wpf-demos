#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;

namespace PrintingDemo
{
    public class Employees : INotifyPropertyChanged
    {
        private int _EmployeeID;
        private string _Name;
        private long _NationalIDNumber;
        private int _ContactID;
        private string _LoginID;
        private int _ManagerID;
        private string _Title;
        private DateTime _BirthDate;
        private string _MaritalStatus;
        private string _Gender;
        private DateTime _HireDate;
        private int _SickLeaveHours;
        private double _Salary;



        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        /// <value>The employee ID.</value>
        public int EmployeeID
        {
            get
            {
                return this._EmployeeID;
            }
            set
            {
                this._EmployeeID = value;
                this.OnPropertyChanged("EmployeeID");
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
                this.OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public long NationalIDNumber
        {
            get
            {
                return this._NationalIDNumber;
            }
            set
            {
                this._NationalIDNumber = value;
                this.OnPropertyChanged("NationalIDNumber");
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
                this.OnPropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public int ContactID
        {
            get
            {
                return this._ContactID;
            }
            set
            {
                this._ContactID = value;
                this.OnPropertyChanged("ContactID");
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return this._BirthDate;
            }
            set
            {
                this._BirthDate = value;
                this.OnPropertyChanged("BirthDate");
            }
        }


        public string MaritalStatus
        {
            get
            {
                return this._MaritalStatus;
            }
            set
            {
                this._MaritalStatus = value;
                this.OnPropertyChanged("MaritalStatus");
            }
        }

        public string Gender
        {
            get
            {
                return this._Gender;
            }
            set
            {
                this._Gender = value;
                this.OnPropertyChanged("Gender");
            }
        }

        public DateTime HireDate
        {
            get
            {
                return this._HireDate;
            }
            set
            {
                this._HireDate = value;
                this.OnPropertyChanged("HireDate");
            }
        }

        public int SickLeaveHours
        {
            get
            {
                return this._SickLeaveHours;
            }
            set
            {
                this._SickLeaveHours = value;
                this.OnPropertyChanged("SickLeaveHours");
            }
        }

        public double Salary
        {
            get
            {
                return this._Salary;
            }
            set
            {
                this._Salary = value;
                this.OnPropertyChanged("Salary");
            }
        }

        public string LoginID
        {
            get
            {
                return _LoginID;
            }
            set
            {
                _LoginID = value;
                this.OnPropertyChanged("LoginID");
            }
        }

        public int ManagerID
        {
            get
            {
                return _ManagerID;
            }
            set
            {
                _ManagerID = value;
                this.OnPropertyChanged("ManagerID");
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
