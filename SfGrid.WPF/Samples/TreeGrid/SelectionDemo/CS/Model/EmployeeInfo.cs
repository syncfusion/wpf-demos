#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionDemo
{
    public class EmployeeInfo : NotificationObject
    {
        int _id;
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>The ID.</value>
        public int ID
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

        int? _empId;
        /// <summary>
        /// Gets or sets the emp ID.
        /// </summary>
        /// <value>The emp ID.</value>
        public int? EmpID
        {
            get
            {
                return _empId;
            }
            set
            {
                _empId = value;
            }
        }

        string _firstName;
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

        string _lastName;
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

        private string _title;
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
            }
        }

        double? _salary;
        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        /// <value>The salary.</value>
        public double? Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
            }
        }

        int _reportsTo;
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
            }
        }
    }
}
