#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;
using CustomPrintingDemo.Model;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Syncfusion.Windows.Shared;

namespace CustomPrintingDemo
{
    public class ViewModel : NotificationObject
    {
        private List<string> _comboBoxItemsSource = new List<string>();



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

        public List<string> ComboBoxItemsSource
        {
            get { return _comboBoxItemsSource; }
            set { _comboBoxItemsSource = value; }
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
                Random r = new Random();
                Northwind north = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));

                foreach (OrderDetails orderDet in north.OrderDetails.Take(150))
                {
                    OrderInfo orderInfo = new OrderInfo();

                    orderInfo.OrderID = orderDet.OrderID;
                    orderInfo.CustomerID = orderDet.Orders.CustomerID;
                    orderInfo.ProductName = orderDet.Products.ProductName;
                    orderInfo.UnitPrice = (double)orderDet.UnitPrice;
                    orderInfo.Quantity = orderDet.Quantity;
                    orderInfo.Discount = Math.Round(orderDet.Discount, 2);
                    orderInfo.Freight = (double)orderDet.Orders.Freight;
                    orderInfo.OrderDate = (DateTime)orderDet.Orders.OrderDate;
                    orderInfo.ShippedDate = (DateTime)orderDet.Orders.ShippedDate;
                    orderInfo.ShipPostalCode = orderDet.Orders.ShipPostalCode;
                    orderInfo.ShipAddress = orderDet.Orders.ShipAddress;
                    orderInfo.IsClosed = r.Next() % 2 == 0 ? true : false;
                    orderInfo.ContactNumber = r.Next(999111, 999119).ToString();
                    orderInfo.DeliveryDelay = orderInfo.ShippedDate - orderInfo.OrderDate;
                    orderInfo.IsProcessed = orderInfo.IsClosed;
                    if (!_comboBoxItemsSource.Contains(orderDet.Products.ProductName))
                        _comboBoxItemsSource.Add(orderDet.Products.ProductName);
                    _orderList.Add(orderInfo);
                }
            }
        }
    }
}
