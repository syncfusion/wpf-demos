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
using System.Threading.Tasks;
using Syncfusion.Windows.Shared;

namespace CheckBoxSelectorColumnDemo
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

    }
}
