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
using Syncfusion.Windows.Controls.Grid;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using ColumnChooserDemo.Model;

namespace ColumnChooserDemo
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


        private bool showColumnChooser = true;

        public bool ShowColumnChooser
        {
            get 
            {
                return showColumnChooser; 
            }
            set 
            {
                showColumnChooser = value;
                RaisePropertyChanged("ShowColumnChooser");
            }
        }

        private bool useDefaultColumnChooser = true;

        public bool UseDefaultColumnChooser
        {
            get 
            {
                return useDefaultColumnChooser; 
            }
            set
            {
                useDefaultColumnChooser = value;
                RaisePropertyChanged("UseDefaultColumnChooser");
            }
        }

        private bool useCustomColumnChooser;

        public bool UseCustomColumnChooser
        {
            get 
            {
                return useCustomColumnChooser; 
            }
            set 
            {
                useCustomColumnChooser = value;
                RaisePropertyChanged("UseCustomColumnChooser");
            }
        }
        
        

        #region Delegate Command

        public DelegateCommand<object> _ColumnChooserCommand;

        /// <summary>
        /// Gets the column chooser command.
        /// </summary>
        /// <value>The column chooser command.</value>
        public DelegateCommand<object> ColumnChooserCommand
        {
            get { return _ColumnChooserCommand; }
            set
            {
                _ColumnChooserCommand = value;
                RaisePropertyChanged("ColumnChooserCommand");
            }
        }
        #endregion

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

    public class CustomColumnChooserViewModel : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomColumnChooserViewModel"/> class.
        /// </summary>
        /// <param name="totalColumns">The total columns.</param>
        public CustomColumnChooserViewModel(ObservableCollection<ColumnChooserItems> totalColumns)
        {
            ColumnCollection = totalColumns;
        }

        /// <summary>
        /// Gets or sets the column collection.
        /// </summary>
        /// <value>The column collection.</value>
        public ObservableCollection<ColumnChooserItems> ColumnCollection
        {
            get;
            set;
        }
    }
}
