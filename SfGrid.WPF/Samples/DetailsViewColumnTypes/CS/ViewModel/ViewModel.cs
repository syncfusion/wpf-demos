#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using DetailsViewColumnTypes;
using DetailsViewColumnTypes.Model;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DetailsViewColumnTypes
{
    public class ViewModel : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            OrderInfoRepository order = new OrderInfoRepository();
            OrdersDetails = order.GetOrdersDetails(100);
            Suppliers = PopulateDataForShip(30);
        }

        public ObservableCollection<OrderInfo> _ordersDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public ObservableCollection<OrderInfo> OrdersDetails
        {
            get{ return _ordersDetails; }
            set { _ordersDetails = value; RaisePropertyChanged("OrdersDetails"); }
        }

        private ObservableCollection<SupplierDetails> suppliers;

        public ObservableCollection<SupplierDetails> Suppliers
        {
            get
            {
                return suppliers;
            }
            set
            {
                suppliers = value;
                RaisePropertyChanged("Suppliers");
            }
        }

        private ObservableCollection<SupplierDetails> PopulateDataForShip(int i)
        {
            ObservableCollection<SupplierDetails> SupplierInfo = new ObservableCollection<SupplierDetails>();
            if (!LayoutControl.IsInDesignMode)
            {
                string connectionString = LayoutControl.FindFile("Northwind.sdf");
                Northwind northWind = new Northwind(connectionString);
                var suppliers = northWind.Suppliers.Take(40);

                foreach (var supplier in suppliers)
                {
                    SupplierDetails s = new SupplierDetails();
                    s.SupplierCity = supplier.City;
                    s.SupplierID = supplier.SupplierID;
                    s.SupplierName = supplier.CompanyName;
                    SupplierInfo.Add(s);
                }
            }
            return SupplierInfo;
        }
    }
}
