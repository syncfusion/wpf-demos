#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using IntervalGroupingDemo.Model;

namespace IntervalGroupingDemo
{
    public class ViewModel : NotificationObject
    {
        Northwind northWind;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            OrdersDetail = this.GetOrdersDetail();
        }        
      

        private ObservableCollection<Orders> _ordersDetail;
        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public ObservableCollection<Orders> OrdersDetail
        {
            get
            {
                return _ordersDetail;
            }
            set
            {
                _ordersDetail = value;
            }
        }

        /// <summary>
        /// Gets the orders details.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Orders> GetOrdersDetail()
        {
            ObservableCollection<Orders> ordersDetail = new ObservableCollection<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var customer = northWind.Orders.Skip(0).Take(100).ToList();
                foreach (var o in customer)
                {
                    ordersDetail.Add(o);
                }
            }
            return ordersDetail;
        }
    }    
}
