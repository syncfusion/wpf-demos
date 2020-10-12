#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;

namespace syncfusion.propertygriddemos.wpf
{
    public class OrderDetails
    {
        #region Feilds
        private string m_orderID;
        private string m_customerID;
        private DateTime m_orderDate;
        private DateTime m_requiredDate;
        private DateTime m_shippedDate;
        #endregion

        #region Properties


        [DisplayNameAttribute("Order ID")]
        public string OrderID
        {
            get { return m_orderID; }
            set { m_orderID = value; }
        }

        [DisplayNameAttribute("Customer ID")]
        public string CustomerID
        {
            get { return m_customerID; }
            set { m_customerID = value; }
        }

        [DisplayNameAttribute("Order Date")]
        public DateTime OrderDate
        {
            get { return m_orderDate; }
            set { m_orderDate = value; }
        }

        [DisplayNameAttribute("Required Date")]
        public DateTime RequiredDate
        {
            get { return m_requiredDate; }
            set { m_requiredDate = value; }
        }

        [DisplayNameAttribute("Shipped Date")]
        public DateTime ShippedDate
        {
            get { return m_shippedDate; }
            set { m_shippedDate = value; }
        }
        #endregion

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
