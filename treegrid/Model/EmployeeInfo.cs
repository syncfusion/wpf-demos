#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using System.Collections.ObjectModel;

namespace syncfusion.treegriddemos.wpf
{
    public class EmployeeInfo : NotificationObject, IComparable<EmployeeInfo>
    {
        public static int _globalId = 0;

        private int _id;
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
                RaisePropertyChanged("ID");
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
                RaisePropertyChanged("FirstName");
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
                RaisePropertyChanged("LastName");
            }
        }
        string _department;

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
                RaisePropertyChanged("Title");
            }
        }

        private string date;

        /// <summary>
        /// Gets or sets the Date.
        /// </summary>
        /// <value>The Date.</value>
        public string Date
        {
            get { return date; }
            set { date = value; }
        }


        private double? _salary;
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
                RaisePropertyChanged("Salary");
            }
        }

        private string _city;

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
            }
        }

        private int _reportsTo;
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

        private int? _empId;

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
                RaisePropertyChanged("EmpId");
            }
        }

        private int? _rating;

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

        private ObservableCollection<EmployeeInfo> _children;

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

        internal double _hike = 5;
        /// <summary>
        /// Gets or sets the hike
        /// </summary>
        /// <value>The hike.</value>
        public double Hike
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

        private string customerCity;

        public string CustomerCity
        {
            get
            {
                return customerCity;
            }
            set
            {
                customerCity = value;
                RaisePropertyChanged("CustomerCity");
            }
        }

        private string _customerArea;

        public string CustomerArea
        {
            get
            {
                return _customerArea;
            }
            set
            {
                _customerArea = value;
                RaisePropertyChanged("CustomerArea");
            }
        }
        private System.Nullable<int> _OrderID;

        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        /// <value>The order ID.</value>
        public System.Nullable<int> OrderID
        {
            get
            {
                return this._OrderID;
            }
            set
            {
                this._OrderID = value;
                RaisePropertyChanged("OrderID");
            }
        } 

        private double _UnitPrice;

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public double UnitPrice
        {
            get
            {
                return this._UnitPrice;
            }
            set
            {
                this._UnitPrice = value;
                RaisePropertyChanged("UnitPrice");
            }
        }
        
        private double _Discount;

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public double Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                this._Discount = value;
                RaisePropertyChanged("Discount");
            }
        }

        private string _customerID;

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        /// <value>The customer ID.</value>
        public string CustomerID
        {
            get
            {
                return _customerID;
            }
            set
            {
                _customerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }

        private DateTime _orderDate;      

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        /// <value>The order date.</value>
        public DateTime OrderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
                RaisePropertyChanged("OrderDate");
            }
        }

        private string _eyecolor;

        /// <summary>
        /// Gets or sets the color of my eye.
        /// </summary>
        /// <value>The color of my eye.</value>
        public string MyEyeColor
        {
            get
            {
                return _eyecolor;
            }
            set
            {
                _eyecolor = value;
                RaisePropertyChanged("MyEyeColor");
            }
        }

        private DateTime _dob;
        private bool _availability;

        /// <summary>
        /// Gets or sets the DOB.
        /// </summary>
        /// <value>The DOB.</value>
        public DateTime DOB
        {
            get
            {
                return _dob;
            }
            set
            {
                _dob = value;
                RaisePropertyChanged("DOB");
            }
        }

        private DateTime? _doj;

        /// <summary>
        /// Gets or sets the DOJ.
        /// </summary>
        /// <value>The DOJ.</value>
        public DateTime? DOJ
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

        private long contactNumber;

        public long ContactNumber
        {
            get { return contactNumber; }
            set
            {
                contactNumber = value;
                RaisePropertyChanged("ContactNumber");
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [likes cake].
        /// </summary>
        /// <value><c>true</c> if [likes cake]; otherwise, <c>false</c>.</value>
        public bool Availability
        {
            get
            {
                return _availability;
            }
            set
            {
                _availability = value;
                RaisePropertyChanged("Availability");
            }
        }

        #region IComparable<EmployeeInfo> Members

        public int CompareTo(EmployeeInfo other)
        {
            // return this.reportsTo - other.reportsTo;
            if (other == null)
                return -1;

            return this.ReportsTo.CompareTo(other.ReportsTo);
        }

        #endregion
    }
}