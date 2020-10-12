#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

namespace syncfusion.datagriddemos.wpf
{
    public class Employee : NotificationObject
    {
        #region Private members

        private bool _selected;
        private string _name;
        private string _designation;
        private string _mail;
        private string _trust;
        private string _status;
        private double _proficiency;
        private int _rating;
        private int _salary;
        private string _address;
        private string _gender;
        private int _employeeID;
        private int _employeeAge;
        private bool? _employeestatus;
        private double percent;
        private DateTime _edob;
        private int _experienceInMonth;

        #endregion

        public Employee()
        {

        }

        public Employee(bool selected, string name, string designation, string mail, string location, string trust, int rating, string status, double proficiency, int salary, string address, string gender)
        {
            Selected = selected;
            EmployeeName = name;
            Designation = designation;
            Mail = mail;
            Location = location;
            Trustworthiness = trust;
            Rating = rating;
            Status = status;
            SoftwareProficiency = proficiency / 100;
            Salary = salary;
            Address = address;
            Gender = gender;
        }

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
                RaisePropertyChanged("Selected");
            }
        }
        /// <summary>
        /// Gets or sets the employee name.
        /// </summary>        
        [Display(Name = "Employee Name ")]
        public string EmployeeName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("EmployeeName");
            }
        }

        public int EmployeeID
        {
            get
            {
                return _employeeID;
            }
            set
            {
                _employeeID = value;
                RaisePropertyChanged("EmployeeID");
            }
        }

        public int EmployeeAge
        {
            get
            {
                return _employeeAge;
            }
            set
            {
                _employeeAge = value;
                RaisePropertyChanged("EmployeeAge");
            }
        }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>        
        [Display(Name = "Designation ")]
        public string Designation
        {
            get
            {
                return _designation;
            }
            set
            {
                _designation = value;
                RaisePropertyChanged("Designation");
            }
        }

        /// <summary>
        /// Gets or sets the mail ID.
        /// </summary>        
        [Display(Name = "Mail")]
        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                _mail = value;
                RaisePropertyChanged("Mail");
            }
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>        
        [Display(Name = "Location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Trustworthiness.
        /// </summary>        
        [Display(Name = "Trustworthiness")]
        public string Trustworthiness
        {
            get
            {
                return _trust;
            }
            set
            {
                _trust = value;
                RaisePropertyChanged("Trustworthiness");
            }
        }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>        
        [Display(Name = "Rating")]
        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
                RaisePropertyChanged("Rating");
            }
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>        
        [Display(Name = "Status")]
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }

        public bool? EmployeeStatus
        {
            get
            {
                return _employeestatus;
            }
            set
            {
                _employeestatus = value;
                RaisePropertyChanged("EmployeeStatus");
            }
        }

        public int ExperienceInMonth
        {
            get
            {
                return _experienceInMonth;
            }
            set
            {
                _experienceInMonth = value;
                RaisePropertyChanged("ExperienceInMonth");
            }
        }

        public double Percent
        {
            get
            {
                return percent;
            }
            set
            {
                percent = value;
                RaisePropertyChanged("Percent");
            }
        }
        
        public DateTime EmployeeDOB
        {
            get
            {
                return _edob;
            }
            set
            {
                _edob = value;
                RaisePropertyChanged("EmployeeDOB");
            }
        }

        /// <summary>
        /// Gets or sets the software proficiency .
        /// </summary>        
        [Display(Name = "Software Proficiency")]
        public double SoftwareProficiency
        {
            get
            {
                return _proficiency;
            }
            set
            {
                _proficiency = value;
                RaisePropertyChanged("SoftwareProficiency");
            }
        }

        /// <summary>
        /// Gets or sets the salary.
        /// </summary>        
        [Display(Name = "Salary")]
        public int Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
                RaisePropertyChanged("Salary");
            }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>        
        [Display(Name = "Address")]
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                RaisePropertyChanged("Address");
            }
        }

        /// <summary>
        /// Gets or sets the Gender.
        /// </summary>        
        [Display(Name = "Gender")]
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                RaisePropertyChanged("Gender");
            }
        }
    }
}