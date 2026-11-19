#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
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

namespace syncfusion.treegriddemos.wpf
{
    /// <summary>
    /// Represents an employee detail for the AutoRowHeight TreeGrid demo using self-relational binding
    /// </summary>
    public class EmployeeDetailInfo : NotificationObject
    {
        private int _id;
        /// <summary>
        /// Gets or sets the unique employee ID.
        /// </summary>
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("ID");
            }
        }

        private string _name;
        /// <summary>
        /// Gets or sets the employee first name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        private string _lastName;
        /// <summary>
        /// Gets or sets the employee last name.
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        private string _about;
        /// <summary>
        /// Gets or sets the about information (description).
        /// </summary>
        public string About
        {
            get { return _about; }
            set
            {
                _about = value;
                RaisePropertyChanged("About");
            }
        }

        private int _reportsTo;
        /// <summary>
        /// Gets or sets the ID of the employee this person reports to. Use -1 for root level (no manager).
        /// </summary>
        public int ReportsTo
        {
            get { return _reportsTo; }
            set
            {
                _reportsTo = value;
                RaisePropertyChanged("ReportsTo");
            }
        }
    }
}
