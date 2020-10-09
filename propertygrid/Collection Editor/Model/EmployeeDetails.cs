#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PropertyGrid;
using System.Collections.Generic;
using System.ComponentModel;

namespace syncfusion.propertygriddemos.wpf
{
    [Editor("Email", typeof(CustomMaskEditor))]
    [MaskAttribute(MaskAttribute.MobileNumber, "Mobile")]
    public class EmployeeDetails
    {
        #region Feilds
        private List<CollectionCustomerDetails> m_customers;
        #endregion

        #region Properties
        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("First Name")]
        [DescriptionAttribute("First Name of the employee.")]
        public string FirstName
        {
            get;

            set;
        }

        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("Last Name")]
        [DescriptionAttribute("Last Name of the employee.")]
        public string LastName
        {
            get;

            set;
        }

        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("Age")]
        [DescriptionAttribute("Age of the employee.")]
        public int Age
        {
            get;

            set;
        }

        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("Gender")]
        [DescriptionAttribute("Gender information of the actual employee.")]
        public Gender Gender
        {
            get;

            set;
        }

        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("ID")]
        [DescriptionAttribute("ID of the employee.")]
        public string ID
        {
            get;

            set;
        }

        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("Designation")]
        [DescriptionAttribute("Position of the employee in the organisation.")]
        [ReadOnly(true)]
        public string Designation
        {
            get;

            set;
        }

        [CategoryAttribute("Customer Details")]
        [DisplayNameAttribute("Customers")]
        [DescriptionAttribute("List of Customers that was handled by employee.")]
        public List<CollectionCustomerDetails> Customers
        {
            get
            {
                if (m_customers == null)
                    m_customers = new List<CollectionCustomerDetails>();
                return m_customers;
            }
            set
            {
                m_customers = value;
            }
        }

        [CategoryAttribute("Contact Details")]
        [DisplayNameAttribute("Mobile Number")]
        [DescriptionAttribute("Contact Number of the employee.")]
        public string Mobile
        {
            get;

            set;
        }

        [CategoryAttribute("Contact Details")]
        [DisplayNameAttribute("Email ID")]
        [DescriptionAttribute("Email address of the employee.")]
        public string Email
        {
            get;

            set;
        }
        #endregion

        #region constructor
        public EmployeeDetails()
        {
            m_customers = new List<CollectionCustomerDetails>();
        }
        #endregion
    }
}
