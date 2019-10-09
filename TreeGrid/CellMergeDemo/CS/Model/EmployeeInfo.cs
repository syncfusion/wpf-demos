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
using System.Collections.ObjectModel;


namespace Merging
{
    public class Employee : NotificationObject
    {
        #region Private Fields

        private string _title;
        string _department;
        int _reportsTo;
        int? _empId;
        int? _rating;
        string _doj;
        private int _id;
        private string _firstName;
        private string _lastName;
        private double? _salary;
        private string _hike;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        /// <summary>
        /// Gets or sets the Salary.
        /// </summary>
        /// <value>Salary</value>
        public double? Salary
        {
            get { return _salary; }
            set
            {
                _salary = value;
                RaisePropertyChanged("Salary");
            }
        }

        /// <summary>
        /// Gets or sets the hike
        /// </summary>
        /// <value>The hike.</value>
        public string Hike
        {
            get
            {
                return _hike;
            }
            set
            {
                _hike = value;
                RaisePropertyChanged("Hike");
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
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets the reports to.
        /// </summary>
        /// <value>The reports to.</value>
        public int ReportsTo
        {
            get
            {
                return _reportsTo;
            }
            set
            {
                _reportsTo = value;
                RaisePropertyChanged("ReportsTo");
            }
        }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>The department.</value>
        public string Department
        {
            get
            {
                return _department;
            }
            set
            {
                _department = value;
                RaisePropertyChanged("Department");
            }
        }

        /// <summary>
        /// Gets or sets the emp ID.
        /// </summary>
        /// <value>The emp ID.</value>
        public int? EmpId
        {
            get
            {
                return _empId;
            }
            set
            {
                _empId = value;
                RaisePropertyChanged("EmpID");
            }
        }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public int? Rating
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
        /// Gets or sets the DOJ.
        /// </summary>
        /// <value>The DOJ.</value>
        public string DOJ
        {
            get
            {
                return _doj;
            }
            set
            {
                _doj = value;
                RaisePropertyChanged("DOJ");
            }
        }

        #endregion
    }
}