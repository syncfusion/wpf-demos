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
using System.ComponentModel.DataAnnotations;

namespace CustomFilterRow
{
    public class OrderInfo : NotificationObject
    {
        #region Private members

        private int _orderId;
        private string _customerId;
        private string _productName;
        private DateTime _orderedDate;
        private bool _isShipped;
        private string _ShipName;
        private string _shipAddress;
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
        /// Gets or sets the OrderDate.
        /// </summary>
        /// <value>The OrderDate.</value>
        public DateTime OrderDate
        {
            get
            {
                return _orderedDate;
            }
            set
            {
                _orderedDate = value;
                RaisePropertyChanged("OrderDate");
            }
        }

        /// <summary>
        /// Gets or sets the is shipped.
        /// </summary>
        /// <value>The IsShipped.</value>
        public bool IsShipped
        {
            get
            {
                return _isShipped;
            }
            set
            {
                _isShipped = value;
                RaisePropertyChanged("IsShipped");
            }
        }

        /// <summary>
        /// Gets or sets the is ShipName.
        /// </summary>
        /// <value>The ShipName.</value>
        public string ShipName
        {
            get
            {
                return _ShipName;
            }
            set
            {
                _ShipName = value;
                RaisePropertyChanged("ShipName");
            }
        }

        /// <summary>
        /// Gets or sets the is ShipAddress.
        /// </summary>
        /// <value>The ShipAddress.</value>
        public string ShipAddress
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
