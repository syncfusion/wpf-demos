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
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Shared;

namespace UnBoundColumnsDemo
{
    public class ProductSalesDetails : NotificationObject
    {
        private string _product;

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public string Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                RaisePropertyChanged("Product");
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
