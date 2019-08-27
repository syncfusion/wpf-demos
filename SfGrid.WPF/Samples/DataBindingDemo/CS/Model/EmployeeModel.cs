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
using System.Threading.Tasks;

namespace DataBindingDemo
{
    public class EmployeeDetail : NotificationObject
    {
        private int _CustomerID;

        /// <summary>
        /// Gets or sets the CustomerID.
        /// </summary>
        /// <value>The CustomerID.</value>
        public int CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }

        private string _ComapnyName;

        /// <summary>
        /// Gets or sets the CompanyName.
        /// </summary>
        /// <value>The CompanyName.</value>
        public string CompanyName
        {
            get
            {
                return _ComapnyName;
            }
            set
            {
                _ComapnyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }


        private string _ContactName;

        /// <summary>
        /// Gets or sets the ContactName.
        /// </summary>
        /// <value>The ContactName.</value>
        public string ContactName
        {
            get
            { return _ContactName; }
            set
            {
                _ContactName = value;
                RaisePropertyChanged("ContactName");
            }
        }

        private string _Country;

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        /// <value>The Country.</value>
        public string Country
        {
            get
            { return _Country; }
            set
            {
                _Country = value;
                RaisePropertyChanged("Country");
            }
        }

        private string _City;

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City
        {
            get
            { return _City; }
            set
            {
                _City = value;
                RaisePropertyChanged("City");
            }
        }

        private int _postalCode;

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>The city.</value>
        public int PostalCode
        {
            get
            { return _postalCode; }
            set
            {
                _postalCode = value;
                RaisePropertyChanged("PostalCode");
            }
        }
    }
}
