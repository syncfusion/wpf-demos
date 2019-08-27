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
using StackedHeaderRowsDemo.Model;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;

namespace StackedHeaderRowsDemo
{
    public class ViewModel
    {
        private List<Orders> _orders = new List<Orders>();

        /// <summary>
        /// Gets or sets the product list.
        /// </summary>
        /// <value>The product list.</value>
        public List<Orders> OrderList
        {
            get { return _orders; }
            set { _orders = value; }
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
                var order = north.Orders.Take(100);
                foreach (var o in order)
                {
                    OrderList.Add(o);
                }
            }
        }     
    }  
}
