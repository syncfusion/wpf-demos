#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MasterDetailsViewDemo
{
    public class OrderInfo:INotifyPropertyChanged
    {

        private int _OrderID;

        private string _CustomerID;

        private System.Nullable<int> _EmployeeID;

        private string _ShipCity;

        private string _ShipCountry;

        private double _Freight;

        private List<OrderDetails> orderDetails;
        private bool _isClosed;

        private DateTime _shippingDate;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfo"/> class.
        /// </summary>
        public OrderInfo()
        {

        }

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public List<OrderDetails> OrderDetails
        {
            get
            {
                return this.orderDetails; 
            }
            set
            {
                this.orderDetails = value;
                RaisePropertyChanged("OrderDetails");
            }
        }

        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        /// <value>The order ID.</value>
        public int OrderID
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

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        /// <value>The customer ID.</value>
        public string CustomerID
        {
            get
            {
                return this._CustomerID;
            }
            set
            {
                this._CustomerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }

        /// <summary>
        /// Gets or sets the shipping date.
        /// </summary>
        /// <value>The shipping date.</value>
        public DateTime ShippingDate
        {
            get
            {
                return _shippingDate;
            }
            set
            {
                _shippingDate = value;
                RaisePropertyChanged("ShippingDate");
            }
        }

        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        /// <value>The employee ID.</value>
        public System.Nullable<int> EmployeeID
        {
            get
            {
                return this._EmployeeID;
            }
            set
            {
                this._EmployeeID = value;
                RaisePropertyChanged("EmployeeID");
            }
        }

        /// <summary>
        /// Gets or sets the ship city.
        /// </summary>
        /// <value>The ship city.</value>
        public string ShipCity
        {
            get
            {
                return this._ShipCity;
            }
            set
            {
                this._ShipCity = value;
                RaisePropertyChanged("ShipCity");
            }
        }

        /// <summary>
        /// Gets or sets the ship country.
        /// </summary>
        /// <value>The ship country.</value>
        public string ShipCountry
        {
            get
            {
                return this._ShipCountry;
            }
            set
            {
                this._ShipCountry = value;
                RaisePropertyChanged("ShipCountry");
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
                return this._Freight;
            }
            set
            {
                this._Freight = value;
                RaisePropertyChanged("Freight");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is closed.
        /// </summary>
        /// <value><c>true</c> if this instance is closed; otherwise, <c>false</c>.</value>
        public bool IsClosed
        {
            get
            {
                return this._isClosed;
            }

            set
            {
                this._isClosed = value;
                this.RaisePropertyChanged("IsClosed");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
