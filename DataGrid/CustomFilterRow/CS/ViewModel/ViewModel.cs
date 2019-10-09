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
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using CustomFilterRow.Model;
using Syncfusion.Windows.Controls.Grid;

namespace CustomFilterRow
{
    public class ViewModel : NotificationObject
    {
        Random r = new Random();
        private ObservableCollection<OrderInfo> _orderList = new ObservableCollection<OrderInfo>();

        /// <summary>
        /// Gets or sets the order list.
        /// </summary>
        /// <value>The order list.</value>
        public ObservableCollection<OrderInfo> OrderList
        {
            get
            {
                return _orderList;
            }
            set
            {
                _orderList = value;
                RaisePropertyChanged("OrderList");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.PopulateData();
        }

        /// <summary>
        /// Populates the data.
        /// </summary>
        private void PopulateData()
        {
            if (!LayoutControl.IsInDesignMode)
            {
                Northwind north = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));

                foreach (OrderDetails orderDet in north.OrderDetails.Take(600))
                {
                    OrderInfo orderInfo = new OrderInfo();
                    orderInfo.OrderID = orderDet.OrderID;
                    orderInfo.CustomerID = orderDet.Orders.CustomerID;
                    orderInfo.ProductName = orderDet.Products.ProductName;
                    orderInfo.OrderDate = DateTime.Today.AddDays(r.Next(-100,1));
                    if (orderInfo.OrderID % 2 == 0)
                        orderInfo.IsShipped = true;
                    else
                        orderInfo.IsShipped = false;
                    orderInfo.ShipName = orderDet.Orders.ShipName;
                    orderInfo.ShipAddress = orderDet.Orders.ShipAddress;
                    _orderList.Add(orderInfo);
                }
            }
        }
    }
}
