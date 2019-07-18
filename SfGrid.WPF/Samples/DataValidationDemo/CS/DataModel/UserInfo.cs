#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DataValidationDemo
{
    public class UserInfo : INotifyPropertyChanged, IDataErrorInfo
    {

        #region Fields
        private int userId;
        private string name;
        private DateTime dateofBirth;
        private string email;
        private string contactNo;
        private string city;
        private int salary;
        Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        #endregion

        #region Properties

        public int UserId
        {
            get { return userId; }
            set { userId = value; OnPropertyChanged("UserId"); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        public DateTime DateofBirth
        {
            get { return dateofBirth; }
            set { dateofBirth = value; OnPropertyChanged("DateofBirth"); }
        }

        public string EMail
        {
            get { return email; }
            set { email = value; OnPropertyChanged("EMail"); }
        }

        [StringLength(14, ErrorMessage = "The “ContactNo” field must be a string with a maximum length of 14.")]
        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; OnPropertyChanged("ContactNo"); }
        }

        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged("City"); }
        }

        [Range(10000, 30000, ErrorMessage = "The “Salary” field can range from 10000 through 30000.")]
        public int Salary
        {
            get { return salary; }
            set { salary = value; OnPropertyChanged("Salary"); }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region IDataErrorInfo

        [Bindable(false)]
        public string Error
        {
            get
            {
                return !emailRegex.IsMatch(this.EMail) ? "Email ID is invalid!" : null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "EMail")
                {
                    return !emailRegex.IsMatch(this.EMail) ? "Email ID is invalid!" : null;
                }
                return null;
            }
        }

        #endregion
                
    }
}