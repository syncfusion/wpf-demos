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
using System.Threading.Tasks;
using Syncfusion.Windows.Shared;

namespace syncfusion.datagriddemos.wpf
{
    public class ProductInfo : NotificationObject
    {
        private int _ProductID;

        private string _ProductModel;

        private int _UserRating;

        private string _Product;

        private bool _Availability;

        private double _Price;

        private int _shippingDays;

        private string _ProductType;



        public int ProductID
        {
            get
            {
                return this._ProductID;
            }
            set
            {
                this._ProductID = value;
                this.RaisePropertyChanged("ProductID");
            }
        }

        public string ProductModel
        {
            get
            {
                return this._ProductModel;
            }
            set
            {
                this._ProductModel = value;
                this.RaisePropertyChanged("ProductModel");
            }
        }

        public int UserRating
        {
            get
            {
                return this._UserRating;
            }
            set
            {
                this._UserRating = value;
                this.RaisePropertyChanged("UserRating");
            }
        }

        public bool Availability
        {
            get
            {
                return this._Availability;
            }
            set
            {
                this._Availability = value;
                this.RaisePropertyChanged("Availability");
            }
        }

        public double Price
        {
            get
            {
                return this._Price;
            }
            set
            {
                this._Price = value;
                this.RaisePropertyChanged("Price");
            }
        }

        public int ShippingDays
        {
            get
            {
                return this._shippingDays;
            }
            set
            {
                this._shippingDays = value;
                this.RaisePropertyChanged("ShippingDays");
            }
        }

        public string ProductType
        {
            get
            {
                return this._ProductType;
            }
            set
            {
                this._ProductType = value;
                this.RaisePropertyChanged("ProductType");
            }
        }

        public string Product
        {
            get
            {
                return this._Product;
            }
            set
            {
                this._Product = value;
                this.RaisePropertyChanged("Product");
            }
        }         

        private string _country;

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                RaisePropertyChanged("Country");
            }
        }

        private string _state;

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                RaisePropertyChanged("State");
            }
        }

        private int _quantity;

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                RaisePropertyChanged("Quantity");
            }
        }

        private double _discount;

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

        private double _amount;

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                RaisePropertyChanged("Amount");
            }
        }
    }
}
