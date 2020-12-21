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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.treeviewdemos.wpf
{
    public class EmployeeInfo
    {
        #region private variables
        int _id;
        private string _firstName;
        private string _lastName;
        private string _title;
        private double? _salary;
        #endregion

        #region public variables


        /// <summary>
        /// Denotes the employee first name
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        /// <summary>
        /// Denotes the employee last name
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        /// <summary>
        /// Denotes the employee id
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Denotes the employee title
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Denotes the employee salary
        /// </summary>
        public double? Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public ObservableCollection<EmployeeInfo> _children;

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        public ObservableCollection<EmployeeInfo> Children
        {
            get
            {
                return _children;
            }
            set
            {
                _children = value;
            }
        } 
        #endregion
    }
}
