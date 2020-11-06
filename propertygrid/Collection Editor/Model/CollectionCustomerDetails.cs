#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace syncfusion.propertygriddemos.wpf
{
    public class CollectionCustomerDetails
    {
        #region Feilds
        private string m_customerID;
        private string m_employeeID;
        private string m_companyName;
        private string m_contactName;
        private string m_country;
        private ObservableCollection<OrderDetails> m_orders;
        #endregion

        #region Properties
        public ObservableCollection<OrderDetails> Orders
        {
            get
            {
                if (m_orders == null)
                    m_orders = new ObservableCollection<OrderDetails>();
                return m_orders;
            }
            set
            {
                m_orders = value;
            }
        }

        [DisplayNameAttribute("Customer ID")]
        public string CustomerID
        {
            get { return m_customerID; }
            set { m_customerID = value; }
        }

        [DisplayNameAttribute("Employee ID")]
        public string EmployeeID
        {
            get { return m_employeeID; }
            set { m_employeeID = value; }
        }

        [DisplayNameAttribute("Company Name")]
        public string CompanyName
        {
            get { return m_companyName; }
            set { m_companyName = value; }
        }

        [DisplayNameAttribute("Contact Name")]
        public string ContactName
        {
            get { return m_contactName; }
            set { m_contactName = value; }
        }
        public string Country
        {
            get { return m_country; }
            set { m_country = value; }
        }
        #endregion

        #region Constructor
        public CollectionCustomerDetails()
        {
            m_orders = new ObservableCollection<OrderDetails>();
        }
        #endregion

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
