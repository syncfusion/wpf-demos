#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using DetailsViewColumnTypes.Model;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DetailsViewColumnTypes
{
    public class OrderDetails : NotificationObject
    {
        static int count = 0;
        
        private string customerCity;

        /// <summary>
        /// Gets or sets the CustomerCity
        /// </summary>
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

        private int _ProductID;

        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        /// <value>The product ID.</value>
        public int ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this._ProductID = value;
                RaisePropertyChanged("ProductID");
            }
        }

        private decimal _UnitPrice;

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public decimal UnitPrice
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
        private Int16 _Quantity;

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public Int16 Quantity
        {
            get
            {
                return this._Quantity;
            }
            set
            {
                this._Quantity = value;
                RaisePropertyChanged("Quantity");
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

        /// <summary>
        /// Gets or sets the Delivery delay.
        /// </summary>

        private TimeSpan _deliveryDelay;

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
        /// Gets or sets the HyperLinkAddress.
        /// </summary>
        private string hyperLinkShipAddress;

        public string HyperLinkShipAddress
        {
            get
            {
                return hyperLinkShipAddress;
            }
            set
            {
                hyperLinkShipAddress = value;
                RaisePropertyChanged("HyperLinkShipAddress");
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
        /// Initializes a new instance of the <see cref="OrderDetails"/> class.
        /// </summary>
        /// <param name="ord">The ord.</param>
        /// <param name="prod">The prod.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="quan">The quan.</param>
        /// <param name="disc">The disc.</param>
        public OrderDetails(int ord, int prod, decimal unit, Int16 quan, double disc, string cusid, DateTime ordDt, string city)
        {
            this._Discount = disc;
            this._OrderID = ord;
            this._ProductID = prod;
            this._Quantity = quan;
            this._UnitPrice = unit;
            this._customerID = cusid;
            this._orderDate = ordDt;
            this.customerCity = city;
            this._deliveryDelay = ordDt.AddDays(quan - 1) - ordDt;
            this.hyperLinkShipAddress = city;
            if (count % 3 == 0)
                this.imageLink = "US.jpg";
            else if (count % 2 == 0)
                this.imageLink = "UK.jpg";
            else
                this.imageLink = "Japan.jpg";
            this.supplierID = count % 3 == 0 ? 1 : count % 3;
            count++;

        }
    }
}
