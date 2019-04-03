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
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using ComplexPropertyBindingDemo.DataModel;

namespace ComplexPropertyBindingDemo
{
    class ViewModel : NotificationObject
    {
        #region Constructor
        Northwind northWind;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            OrdersDetails = this.GetOrdersDetails();
        }
        #endregion

        #region Properties

        private ObservableCollection<OrderInfo> _ordersDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public ObservableCollection<OrderInfo> OrdersDetails
        {
            get { return _ordersDetails; }
            set { _ordersDetails = value; RaisePropertyChanged("OrdersDetails"); }
        }

        #endregion

        /// <summary>
        /// Gets the orders details.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<OrderInfo> GetOrdersDetails()
        {
            ObservableCollection<OrderInfo> orderinfo = new ObservableCollection<OrderInfo>();            
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = LayoutControl.FindFile("Northwind.sdf");
                northWind = new Northwind(connectionString);
                var order = northWind.Orders.Take(50);

                foreach (var o in order)
                {
                    OrderInfo or = new OrderInfo();
                    or.CustomerID = o.CustomerID;
                    or.OrderID = o.OrderID;
                    or.Customers = new CustomerInfo();
                    or.Customers.Address = o.Customers.Address;
                    or.Customers.City = o.Customers.City;
                    or.Customers.CompanyName = o.Customers.CompanyName;
                    or.ShippersInfo = new ShipperDetails[1];
                    or.ShippersInfo[0] = new ShipperDetails();
                    or.ShippersInfo[0].CompanyName = o.Shippers.CompanyName;
                    or.ShippersInfo[0].ShipperID = o.Shippers.ShipperID;

                    orderinfo.Add(or);
                }
            }
            return orderinfo;
        }
    }
}
