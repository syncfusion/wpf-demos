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
using FilterRow.Model;
using Syncfusion.Windows.Controls.Grid;

namespace FilterRow
{
    public class ViewModel : NotificationObject
    {

        private ObservableCollection<OrderInfo> _orderList = new ObservableCollection<OrderInfo>();
        private List<string> _comboBoxItemsSource = new List<string>();

        /// <summary>
        /// Gets or sets the order list.
        /// </summary>
        /// <value>The list of OrderInfo.</value>
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
        /// Gets or sets the product name list.
        /// </summary>
        /// <value>List of ProductNames.</value>
        public List<string> ComboBoxItemsSource
        {
            get
            {
                return _comboBoxItemsSource;
            }
            set
            {
                _comboBoxItemsSource = value;
                RaisePropertyChanged("ComboBoxItemsSource");
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
                Random r = new Random();
                Northwind north = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));

                foreach (OrderDetails orderDet in north.OrderDetails.Take(200))
                {
                    OrderInfo orderInfo = new OrderInfo();

                    orderInfo.OrderID = orderDet.OrderID;
                    orderInfo.CustomerID = orderDet.Orders.CustomerID;
                    orderInfo.ProductName = orderDet.Products.ProductName;
                    orderInfo.UnitPrice = (double)orderDet.UnitPrice;
                    orderInfo.OrderDate = (DateTime)orderDet.Orders.OrderDate;
                    orderInfo.Quantity = orderDet.Quantity;
                    orderInfo.ContactNumber = r.Next(999111234, 999111239).ToString();
                    orderInfo.ShipAddress = orderDet.Orders.ShipAddress;
                    orderInfo.IsAvailable = orderInfo.UnitPrice%2 == 0;
                    _orderList.Add(orderInfo);
                    if (!_comboBoxItemsSource.Contains(orderDet.Products.ProductName))
                        _comboBoxItemsSource.Add(orderDet.Products.ProductName);
                }
            }
        }
    }
}
