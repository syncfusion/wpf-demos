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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomValidationDemo
{
    public class OrderInfoViewModel : NotificationObject, IDisposable
    {
        public OrderInfoViewModel()
        {
            OrdersListDetails = new OrderInfoRepository().GetListOrdersDetails(500);
        }

        private List<OrderInfo> _ordersListDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public List<OrderInfo> OrdersListDetails
        {
            get { return _ordersListDetails; }
            set { _ordersListDetails = value; }
        }

        public void Dispose()
        {
            if (this.OrdersListDetails != null)
            {
                this.OrdersListDetails.Clear();
                this.OrdersListDetails = null;
            }
        }
    }
}
