#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingDemo
{
    class GridViewModel : NotificationObject
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="GridViewModel"/> class.
        /// </summary>
        public GridViewModel()
        {
            this.EmployeeDetails = this.GetEmployeeDetails();
        }
        #endregion

       
        /// <summary>
        /// Determines whether this instance [can add employee] the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>
        /// 	<c>true</c> if this instance [can add employee] the specified employee; otherwise, <c>false</c>.
        /// </returns>
        bool CanAddEmployee(EmployeeDetail employee)
        {
            return true;
        }

        /// <summary>
        /// Adds the employee handler.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void AddEmployeeHandler(EmployeeDetail employee)
        {
            if (employee == null)
            {
                return;
            }
            var row = this.EmployeeDetails.NewRow();
            row["Customer ID"] = employee.ContactName;
            row["Comapny Name"] = employee.CompanyName;
            row["Contact Name"] = employee.ContactName;
            row["City"] = employee.City;
            row["PostalCode"] = employee.PostalCode;
            row["Country"] = employee.Country;
            this.EmployeeDetails.Rows.Add(row);
        }

        #region Properties

        private DataTable _employeeDetails;

        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        /// <value>The employee details.</value>
        public DataTable EmployeeDetails
        {
            get { return _employeeDetails; }
            set { _employeeDetails = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the customer details.
        /// </summary>
        /// <returns></returns>
        public DataTable GetEmployeeDetails()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                using (SqlCeConnection con = new SqlCeConnection(string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"))))
                {
                    con.Open();
                    SqlCeDataAdapter sda = new SqlCeDataAdapter("SELECT * FROM Customers", con);
                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    return ds;
                }
            }

            return new DataTable();
        }
        #endregion
    }   
}
