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
using PdfExportingDemo.Model;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;

namespace PdfExportingDemo
{
    public class ViewModel
    {
        Northwind northWind;
        public ViewModel()
        {
            OrderInfo = this.GetOrderInfo();
        }

        private List<Orders> _OrderInfo;

        /// <summary>
        /// Gets or sets the product info.
        /// </summary>
        /// <value>The product info.</value>
        public List<Orders> OrderInfo
        {
            get
            {
                return _OrderInfo;
            }
            set
            {
                _OrderInfo = value;
               
            }
        }

        /// <summary>
        /// Gets the product info.
        /// </summary>
        /// <returns></returns>
        public List<Orders> GetOrderInfo()
        {
            List<Orders> OrderInfo = new List<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                northWind = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));
                var ords = northWind.Orders.Take(200);
                foreach (var em in ords)
                {
                    OrderInfo.Add(em);
                }
            }
            return OrderInfo;
        }      
    }  
}
