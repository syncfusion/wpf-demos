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

namespace ColumnSizerDemo
{
    public class OrderInfo : NotificationObject
    {
        #region Private members

        private int _orderId;
        private string _customerId;
        private string _productName;
        private double _unitPrice;
        private int _quantiy;
        private double _discount;
        private double _freight;
        private DateTime _orderDate;
        private string _shipPostalCode;
        private string _shipAddress;
        private DateTime _shippedDate;
        private bool isClosed;
        private string _contactNumber;
        private TimeSpan _deliveryDelay;
        

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        /// <value>The order ID.</value>
        public int OrderID
        {
            get
            {
                return _orderId;
            }
            set
            {
                _orderId = value;
                RaisePropertyChanged("OrderID");
            }
        }

        public bool IsClosed
        {
            get 
            {
                return isClosed; 
            }
            set 
            {
                isClosed = value;
                RaisePropertyChanged("IsClosed");
            }
        }

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        /// <value>The customer ID.</value>
        public string CustomerID
        {
            get
            {
                return _customerId;
            }
            set
            {
                _customerId = value;
                RaisePropertyChanged("CustomerID");
            }
        }

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
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public double UnitPrice
        {
            get
            {
                return _unitPrice;   
            }
            set
            {
                _unitPrice = value;
            }
        }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity
        {
            get
            {
                return _quantiy;
            }
            set
            {
                _quantiy = value;
                RaisePropertyChanged("Quantity");
            }
        }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public double Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                _discount = value;
                RaisePropertyChanged("Discount");
            }
        }

        public TimeSpan DeliveryDelay
        {
            get
            {
                return _deliveryDelay;
            }
            set
            {
                _deliveryDelay = value;
                RaisePropertyChanged("DeliveryDelay");
            }
        }

        /// <summary>
        /// Gets or sets the freight.
        /// </summary>
        /// <value>The freight.</value>
        public double Freight
        {
            get
            {
                return _freight;
            }
            set
            {
                _freight = value;
                RaisePropertyChanged("Freight");
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

        /// <summary>
        /// Gets or sets the shipped date.
        /// </summary>
        /// <value>The shipped date.</value>
        public DateTime ShippedDate
        {
            get
            {
                return _shippedDate;
            }
            set
            {
                _shippedDate = value;
                RaisePropertyChanged("ShippedDate");
            }
        }

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        /// <value>
        /// The contact number.
        /// </value>
        public string ContactNumber
        {
            get
            {
                return _contactNumber;
            }
            set
            {
                _contactNumber = value;
                RaisePropertyChanged("ContactNumber");
            }
        }

        /// <summary>
        /// Gets or sets the ship postal code.
        /// </summary>
        /// <value>The ship postal code.</value>
        public string ShipPostalCode
        {
            get
            {
                return _shipPostalCode;
            }
            set
            {
                _shipPostalCode = value;
                RaisePropertyChanged("ShipPostalCode");
            }
        }

        /// <summary>
        /// Gets or sets the ship address.
        /// </summary>
        /// <value>The ship address.</value>
        public string  ShipAddress
        {
            get
            {
                return _shipAddress;
            }
            set
            {
                _shipAddress = value;
                RaisePropertyChanged("ShipAddress");
            }
        }

        #endregion
    }
}