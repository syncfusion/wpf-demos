#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomValidationDemo
{
    public partial class OrderInfo : NotificationObject
    {

        private int _OrderID;

        private int _Discount;

        private string _ShipCountry;

        private double _Freight;

        private double _Expense;

        private string _ShipCity;

        private string _ShipPostalCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfo"/> class.
        /// </summary>
        public OrderInfo()
        {

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
                this.RaisePropertyChanged("OrderID");
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
                this.RaisePropertyChanged("ShipCountry");
            }
        }

        /// <summary>
        /// Gets or sets the Freight.
        /// </summary>
        /// <value>The Freight.</value>
        public double Freight
        {
            get
            {
                return this._Freight;
            }
            set
            {
                this._Freight = value;
                this.RaisePropertyChanged("Freight");
            }
        }

        /// <summary>
        /// Gets or sets the ShipPostalCode.
        /// </summary>
        /// <value>The ShipPostalCode.</value>
        public string ShipPostalCode
        {
            get
            {
                return this._ShipPostalCode;
            }
            set
            {
                this._ShipPostalCode = value;
                this.RaisePropertyChanged("ShipPostalCode");
            }
        }

        /// <summary>
        /// Gets or sets the ShipCity.
        /// </summary>
        /// <value>The ShipCity.</value>
        public string ShipCity
        {
            get
            {
                return this._ShipCity;
            }
            set
            {
                this._ShipCity = value;
                this.RaisePropertyChanged("ShipCity");
            }
        }

        /// <summary>
        /// Gets or sets the Discount.
        /// </summary>
        /// <value>The Discount.</value>
        public int Discount
        {
            get
            {
                return this._Discount;
            }
            set
            {
                this._Discount = value;
                this.RaisePropertyChanged("Discount");
            }
        }

        /// <summary>
        /// Gets or sets the TotalExpense.
        /// </summary>
        /// <value>The TotalExpense.</value>
        public double Expense
        {
            get
            {
                return this._Expense;
            }
            set
            {
                this._Expense = value;
                this.RaisePropertyChanged("Expense");
            }
        }
    }
}
