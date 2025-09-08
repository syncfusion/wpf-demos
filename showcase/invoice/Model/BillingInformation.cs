#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace syncfusion.invoice.wpf
{
    public class BillingInformation
    {
        #region Fields
        private string m_Name;
        private string m_Address;
        private DateTime m_DueDate;
        private string m_InvoiveNumber;
        private DateTime m_date;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or Sets the Name
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        /// <summary>
        /// Gets or Sets the Address
        /// </summary>
        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }
        /// <summary>
        /// Gets or Sets the Date
        /// </summary>
        public DateTime Date
        {
            get { return m_date; }
            set { m_date = value; }
        }
        /// <summary>
        /// Gets or Sets the Invoice
        /// </summary>
        public string InvoiceNumber
        {
            get { return m_InvoiveNumber; }
            set { m_InvoiveNumber = value; }
        }
        /// <summary>
        /// Gets or Sets the Due Date
        /// </summary>
        public DateTime DueDate
        {
            get { return m_DueDate; }
            set { m_DueDate = value; }

        }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public BillingInformation()
        {
        }
        #endregion
    }
}
