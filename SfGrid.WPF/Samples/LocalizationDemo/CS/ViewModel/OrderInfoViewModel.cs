#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using LocalizationDemo.Model;
using Syncfusion.Windows.Controls.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LocalizationDemo
{
    public class OrderInfoViewModel : INotifyPropertyChanged
    {
        Northwind northWind;
        public OrderInfoViewModel()
        {
            OrdersDetails = this.GetOrderInfo();
        }


        private ObservableCollection<Orders> _ordersDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public ObservableCollection<Orders> OrdersDetails
        {
            get { return _ordersDetails; }
            set { _ordersDetails = value; }
        }

        /// <summary>
        /// Gets the product info.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Orders> GetOrderInfo()
        {
            ObservableCollection<Orders> orderInfo = new ObservableCollection<Orders>();
            if (!LayoutControl.IsInDesignMode)
            {
                northWind = new Northwind(string.Format(@"Data Source= {0}", LayoutControl.FindFile("Northwind.sdf")));
                var ords = northWind.Orders.Take(50);
                foreach (var em in ords)
                {
                    orderInfo.Add(em);
                }
            }
            return orderInfo;
        }     

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
		
    }
}
