#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;

namespace MasterDetailsViewDemo
{
    public class OrderDetails:INotifyPropertyChanged
    {
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
        /// Initializes a new instance of the <see cref="OrderDetails"/> class.
        /// </summary>
        /// <param name="ord">The ord.</param>
        /// <param name="prod">The prod.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="quan">The quan.</param>
        /// <param name="disc">The disc.</param>
        public OrderDetails(int ord, int prod, decimal unit, Int16 quan, double disc,string cusid,DateTime ordDt)
        {
            this._Discount = disc;
            this._OrderID = ord;
            this._ProductID = prod;
            this._Quantity = quan;
            this._UnitPrice = unit;
            this._customerID = cusid;
            this._orderDate = ordDt;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
