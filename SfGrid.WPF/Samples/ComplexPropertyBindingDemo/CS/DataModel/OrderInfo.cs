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

namespace ComplexPropertyBindingDemo
{
    public class OrderInfo : NotificationObject
    {
        private int _OrderID;

        private string _CustomerID;

        private CustomerInfo _Customers;                

        private ShipperDetails[] shippersInfo;

        public int OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                _OrderID = value;
                RaisePropertyChanged("OrderID");
            }
        }

        public string CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }

        public CustomerInfo Customers
        {
            get
            {
                return _Customers;
            }
            set
            {
                _Customers = value;
                RaisePropertyChanged("Customers");
            }
        }

        public ShipperDetails[] ShippersInfo
        {
            get
            {
                return shippersInfo;
            }
            set
            {
                shippersInfo = value;
                RaisePropertyChanged("ShippersInfo");
            }
        }
        
    }        
}
