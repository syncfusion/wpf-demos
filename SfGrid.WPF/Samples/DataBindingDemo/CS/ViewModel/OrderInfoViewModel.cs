#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using DataBindingDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataBindingDemo
{
    public class OrderInfoViewModel : NotificationObject
    {
        public OrderInfoViewModel()
        {            
            OrdersListDetails = new OrderInfoRepository().PopulateOrders(200);
        }

        private BindingList<Orders> _ordersListDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public BindingList<Orders> OrdersListDetails
        {
            get { return _ordersListDetails; }
            set { _ordersListDetails = value; }
        }

        ObservableCollection<dynamic> _dynamicOrders;

        /// <summary>
        /// Gets or sets the dynamic orders.
        /// </summary>
        /// <value>The dynamic orders.</value>
        public ObservableCollection<dynamic> DynamicOrders
        {
            get
            {
                if (_dynamicOrders == null)
                {
                    _dynamicOrders = new DynamicObjectRepository().PopulateData(200);
                }
                return _dynamicOrders;
            }
            set
            {
                _dynamicOrders = value;
                RaisePropertyChanged("DynamicOrders");
            }
        }
    }
}
