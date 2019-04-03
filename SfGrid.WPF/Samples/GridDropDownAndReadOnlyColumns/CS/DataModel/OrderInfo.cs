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

namespace GridDropDownAndReadOnlyColumns
{
    public class OrderInfo : NotificationObject
    {
        #region Private members

        private string _productName;
        private double _NoOfOrders;
        private DateTime _orderDate = DateTime.Now;
        private int total;

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>The name of the product.</value>
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                RaisePropertyChanged("ProductName");
            }
        }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public double NoOfOrders
        {
            get
            {
                return _NoOfOrders;
            }
            set
            {
                _NoOfOrders = value;
                RaisePropertyChanged("NoOfOrders");
            }
        }

        /// <summary>
        /// Gets or sets the ImageLink.
        /// </summary>
        private string imageLink;

        public string ImageLink
        {
            get
            {
                return imageLink;
            }
            set
            {
                imageLink = value;
                RaisePropertyChanged("ImageLink");
            }
        }

        private string countryDescription;

        public string CountryDescription
        {
            get
            {
                return countryDescription;
            }
            set
            {
                countryDescription = value;
                RaisePropertyChanged("CountryDescription");
            }
        }

        /// <summary>
        /// Gets or sets the Supplier ID.
        /// </summary>

        private int supplierID;

        public int SupplierID
        {
            get
            {
                return supplierID;
            }
            set
            {
                supplierID = value;
                RaisePropertyChanged("SupplierID");
            }
        }

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
        public int Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value; 
                RaisePropertyChanged("Total");
            }
        }


        #endregion
    }
}