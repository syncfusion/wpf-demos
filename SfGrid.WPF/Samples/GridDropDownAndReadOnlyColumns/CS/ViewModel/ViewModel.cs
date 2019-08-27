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
using System.Data.SqlServerCe;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using GridDropDownAndReadOnlyColumns.DataModel;

namespace GridDropDownAndReadOnlyColumns
{
    public class ViewModel : NotificationObject
    {
        static int countrycount = 0;
        static int discountcount = 2;

        private List<string> _comboBoxItemsSource = new List<string>();

        public List<string> ComboBoxItemsSource
        {
            get { return _comboBoxItemsSource; }
            set { _comboBoxItemsSource = value; }
        }

        private ObservableCollection<OrderInfo> _orderList = new ObservableCollection<OrderInfo>();

        /// <summary>
        /// Gets or sets the order list.
        /// </summary>
        /// <value>The order list.</value>
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
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.PopulateData();
            suppliers = PopulateDataForShip(30);
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

                foreach (OrderDetails orderDet in north.OrderDetails.Take(50))
                {
                    OrderInfo orderInfo = new OrderInfo();

                    orderInfo.ProductName = orderDet.Products.ProductName;
                    orderInfo.NoOfOrders = discountcount + 6 / 100;
                    if (discountcount > 16)
                        discountcount = 7;
                    orderInfo.OrderDate = (DateTime)orderDet.Orders.OrderDate;
                    if (countrycount >= 21)
                        countrycount = 0;
                    orderInfo.Total = 10;
                    orderInfo.SupplierID = countrycount % 3 == 0 ? 1 : countrycount % 3;
                    orderInfo.CountryDescription = this.ShipCountry[countrycount];
                    if (countrycount % 3 == 0 || countrycount % 9 == 0)
                        orderInfo.ImageLink = "US.jpg";
                    else if (countrycount % 5 == 0 || countrycount % 17 == 0)
                        orderInfo.ImageLink = "Japan.jpg";                            
                    else
                        orderInfo.ImageLink = "UK.jpg";

                    countrycount++;
                    discountcount += 3;

                    if (!_comboBoxItemsSource.Contains(orderDet.Products.ProductName))
                        _comboBoxItemsSource.Add(orderDet.Products.ProductName);
                    _orderList.Add(orderInfo);
                }
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

        string[] ShipCountry = new string[]
        {
            
            "Argentina",
            "Austria",
            "Belgium",
            "Brazil",            
            "Canada",
            "Denmark",
            "Finland",
            "France",
            "Germany",
            "Ireland",
            "Italy",
            "Mexico",
            "Norway",
            "Poland",
            "Portugal",
            "Spain",
            "Sweden",
            "Switzerland",
            "UK",
            "USA",
            "Venezuela"
        };
    }


}
