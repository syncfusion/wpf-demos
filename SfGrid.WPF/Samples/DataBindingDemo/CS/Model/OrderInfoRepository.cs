#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBindingDemo.Model;
using System.ComponentModel;


namespace DataBindingDemo
{
    public class OrderInfoRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfoRepository"/> class.
        /// </summary>
        public OrderInfoRepository()
        {
        }

        internal BindingList<Orders> PopulateOrders(int count)
        {
            Northwind northWind;
            BindingList<Orders> orderCollection = new BindingList<Orders>();
            if (!Syncfusion.Windows.Controls.Grid.LayoutControl.IsInDesignMode)
            {
                string connectionString = string.Format(@"Data Source = {0}", Syncfusion.Windows.Controls.Grid.LayoutControl.FindFile("Northwind.sdf"));
                northWind = new Northwind(connectionString);
                var orders = northWind.Orders.Skip(0).Take(count).ToList();
                foreach (var o in orders)
                {
                    orderCollection.Add(o);
                }
            }
            return orderCollection;
        }
    }
}
