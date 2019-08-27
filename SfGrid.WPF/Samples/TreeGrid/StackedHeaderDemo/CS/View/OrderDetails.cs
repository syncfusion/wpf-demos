#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackedHeaderDemo
{
    public class OrderDetails : INotifyPropertyChanged
    {
        private string customerCity;

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

        private string _customerArea;

        public string CustomerArea
        {
            get
            {
                return _customerArea;
            }
            set
            {
                _customerArea = value;
                RaisePropertyChanged("CustomerArea");
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

        private double _UnitPrice;

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public double UnitPrice
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

        private ObservableCollection<OrderDetails> _children;

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        public ObservableCollection<OrderDetails> Children
        {
            get
            {
                return _children;
            }
            set
            {
                _children = value;
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
