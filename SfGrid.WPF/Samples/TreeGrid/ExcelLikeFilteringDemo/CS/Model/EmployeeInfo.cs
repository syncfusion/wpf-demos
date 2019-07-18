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


namespace ExcelLikeFilteringDemo
{
    public class Employee : NotificationObject
    {
        #region Private Fields

        private static int _globalId = 0;
        private int _id;
        private string _firstName;
        private string _lastName;
        private DateTime? _doj;
        private double? _salary;
        private string city;        
        private ObservableCollection<Employee> _children;  

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        public ObservableCollection<Employee> Children
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

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int EmployeeID
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
        /// Gets or sets the City.
        /// </summary>
        /// <value>City</value>      

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                RaisePropertyChanged("City");
            }
        }

        private string contactNumber;

        public string ContactNumber
        {
            get { return contactNumber; }
            set
            {
                contactNumber = value;
                RaisePropertyChanged("ContactNumber");
            }
        }     
       
        #endregion

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeInfo"/> class.
        /// </summary>
        public Employee()
            : this("Enter FirstName", "Enter LastName", new DateTime(2008, 10, 26), 78998, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeInfo"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="eyecolor">The eyecolor.</param>
        /// <param name="doj">The doj.</param>
        /// <param name="maxGenerations">The max generations.</param>
        public Employee(string firstName, string lastName, DateTime doj, double? sal, ObservableCollection<Employee> child)
        {
            FirstName = firstName;
            LastName = lastName;
            DOJ = doj;
            Salary = sal; 
            EmployeeID = _globalId++;
            Children = child;
        }

        #endregion
    }
}