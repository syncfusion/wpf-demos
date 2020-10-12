#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using Syncfusion.UI.Xaml.Grid;

namespace syncfusion.datagriddemos.wpf
{
    public class OrderInfoViewModel : NotificationObject
    {
        static int countrycount = 0;
        static int discountcount = 2;
        Random r = new Random();
        
        public Dictionary<string, string[]> ShipCity = new Dictionary<string, string[]>();        

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfoViewModel"/> class.
        /// </summary>
        public OrderInfoViewModel()
        {
            SetShipCity();
            ComboboxSelectedItem.Add(GridCopyOption.CopyData);
            ComboboxSelectedItem.Add(GridCopyOption.CutData);
            this.PopulateData();
            PrepareCoveredData();
            SearchComboBoxItems = this.GetSearchComboBoxItems(); 
            this._ordersDetails = GetOrdersDetails(50);
            this.suppliers = PopulateDataForShip(40);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfoViewModel"/> class.
        /// </summary>
        /// <param name="totalColumns">The total columns.</param>
        public OrderInfoViewModel(ObservableCollection<OrderInfo> totalColumns)
        {
            ColumnCollection = totalColumns;
        }
        #endregion

        #region Properties   
      
        /// <summary>
        /// Gets or sets the column collection.
        /// </summary>
        /// <value>The column collection.</value>
        public ObservableCollection<OrderInfo> ColumnCollection
        {
            get;
            set;
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

        private ObservableCollection<OrderInfo> _ordersDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public ObservableCollection<OrderInfo> OrdersDetails
        {
            get { return _ordersDetails; }
            set { _ordersDetails = value;
                RaisePropertyChanged("OrdersDetails"); }
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
            }
        }

        private List<string> _comboBoxItemsSource = new List<string>();

        public List<string> ComboBoxItemsSource
        {
            get { return _comboBoxItemsSource; }
            set { _comboBoxItemsSource = value; }
        }

        private ObservableCollection<object> _comboBoxselecteditem = new ObservableCollection<object>();

        public ObservableCollection<object> ComboboxSelectedItem
        {
            get { return _comboBoxselecteditem; }
            set { _comboBoxselecteditem = value; }
        }

        private List<string> _searchComboBoxItems;
        public List<string> SearchComboBoxItems
        {
            get { return _searchComboBoxItems; }
            set { _searchComboBoxItems = value; }
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
        #endregion

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

        #region Method

        private ObservableCollection<SupplierDetails> PopulateDataForShip(int count)
        {
            ObservableCollection<SupplierDetails> SupplierInfo = new ObservableCollection<SupplierDetails>();
            for(int i = 0;i < count; i++)
            {
                var shipcountry = ShipCountry[r.Next(0, 5)];
                var shipcitycoll = ShipCity[shipcountry];

                SupplierDetails s = new SupplierDetails();               
                s.SupplierID = r.Next(1, 50);
                s.SupplierName = SupplierName[r.Next(1)];
                s.SupplierCity = shipcitycoll[r.Next(shipcitycoll.Length - 1)];
                SupplierInfo.Add(s);
            }

            return SupplierInfo;
        }

            public ObservableCollection<OrderInfo> GetOrdersDetails(int count)
        {
            ObservableCollection<OrderInfo> orderInfoCollection = new ObservableCollection<OrderInfo>();
            
            for (int i = 0; i < count; i++)
            {
                var shipcountry = ShipCountry[r.Next(0, 5)];
                var shipcitycoll = ShipCity[shipcountry];

                OrderInfo orderInfo = new OrderInfo();
                orderInfo.CustomerID = CustomerID[r.Next(0, 9)];
                orderInfo.OrderID = 10000 + i;
                orderInfo.Customers = new CustomerInfo();
                orderInfo.Customers.CustomerName = EmployeeName[r.Next(0, 15)];
                orderInfo.Customers.City = shipcitycoll[r.Next(shipcitycoll.Length - 1)];
                orderInfo.Customers.Country = shipcountry;
                orderInfo.ShippersInfo = new ShipperDetails[1];
                orderInfo.ShippersInfo[0] = new ShipperDetails();
                orderInfo.ShippersInfo[0].CompanyName = CompanyName[r.Next(0, 2)];
                orderInfo.ShippersInfo[0].ShipperID = r.Next(1, 5); 

                orderInfoCollection.Add(orderInfo);
            }
            return orderInfoCollection;
        }

        /// <summary>
        /// Populates the data.
        /// </summary>
        private void PopulateData()
        {
            for (int i = 0; i < 100; i++)
            {
                var shipcountry = ShipCountry[r.Next(0, 5)];
                var shipcitycoll = ShipCity[shipcountry];

                OrderInfo orderInfo = new OrderInfo();
                orderInfo.OrderID = 10000 + i;
                orderInfo.ProductID = 1000 + i;
                orderInfo.CustomerID =  CustomerID[i< CustomerID.Length ? i : r.Next(0, 14)];               
                orderInfo.ProductName = ProductName[r.Next(0, 47)];
                orderInfo.UnitPrice = r.Next(10, 500);
                orderInfo.Quantity = r.Next(10, 50);
                orderInfo.Discount = (double)r.Next(40);
                orderInfo.Freight = Math.Round(Freight[r.Next(0, 11)], 2);
                orderInfo.OrderDate = new DateTime(r.Next(2004, 2005), r.Next(1, 06), r.Next(1, 15));
                orderInfo.ShippedDate = new DateTime(r.Next(2004, 2005), r.Next(06, 12), r.Next(16, 28));
                orderInfo.ShipPostalCode = PostalCode[r.Next(0,9)];
                orderInfo.ShipAddress = shipcountry;
                orderInfo.Expense = r.Next(2000, 4000);
                orderInfo.ShipName = ShipName[r.Next(0, 97)];
                orderInfo.CompanyName = CompanyName[r.Next(0, 2)];
                orderInfo.UnitsInStock = (short)r.Next(1, 40);
                orderInfo.ShipCity = shipcitycoll[r.Next(shipcitycoll.Length - 1)];
                orderInfo.DeliveryDelay = orderInfo.ShippedDate - orderInfo.OrderDate;
                orderInfo.ShipCityID = r.Next(100, 200);
                orderInfo.ContactNumber = 9991121234 + i;
                
                orderInfo.NoOfOrders = discountcount + 6 / 100;
                if (discountcount > 16)
                    discountcount = 7;
                orderInfo.SupplierID = countrycount % 3 == 0 ? 1 : countrycount % 3;
                if (countrycount % 3 == 0 || countrycount % 9 == 0)
                    orderInfo.ImageLink = "US.jpg";
                else if (countrycount % 5 == 0 || countrycount % 17 == 0)
                    orderInfo.ImageLink = "Japan.jpg";
                else
                    orderInfo.ImageLink = "UK.jpg";

                countrycount++;
                discountcount += 3;
                orderInfo.IsShipped = r.Next() % 2 == 0 ? true : false;

                if (!_comboBoxItemsSource.Contains(orderInfo.ProductName))
                    _comboBoxItemsSource.Add(orderInfo.ProductName);
                _orderList.Add(orderInfo);
            }
        }
        private List<string> GetSearchComboBoxItems()
        {
            List<string> comboItem = new List<string>();
            comboItem.Add("Search main Grid");
            comboItem.Add("Search first level Grid's");
            comboItem.Add("Search second level Grid's");
            return comboItem;
        }

        private void PrepareCoveredData()
        {
            int range = 0;
            for (int i = 0; i < OrderList.Count; i++)
            {
                var orderInfo = OrderList[range];
                if (i == 0 || i % 5 != 0)
                {
                    var modifyOrderinfo = OrderList[i];
                    modifyOrderinfo.CustomerID = orderInfo.CustomerID;
                }
                else
                {
                    if (range % 5 == 0)
                        range = i;
                }
            }
        } 

        #endregion

        #region Collections


        /// <summary>
        /// Sets the ship city.
        /// </summary>
        private void SetShipCity()
        {
            string[] argentina = new string[] { "Buenos Aires" };

            string[] austria = new string[] { "Graz", "Salzburg" };

            string[] belgium = new string[] { "Bruxelles", "Charleroi" };

            string[] brazil = new string[] { "Campinas", "Resende", "Rio de Janeiro", "São Paulo" };

            string[] canada = new string[] { "Montréal", "Tsawassen", "Vancouver" };

            string[] denmark = new string[] { "Århus", "København" };

            string[] finland = new string[] { "Helsinki", "Oulu" };

            string[] france = new string[] { "Lille", "Lyon", "Marseille", "Nantes", "Paris", "Reims", "Strasbourg", "Toulouse", "Versailles" };

            string[] germany = new string[] { "Aachen", "Berlin", "Brandenburg", "Cunewalde", "Frankfurt a.M.", "Köln", "Leipzig", "Mannheim", "München", "Münster", "Stuttgart" };

            string[] ireland = new string[] { "Cork" };

            string[] italy = new string[] { "Bergamo", "Reggio Emilia", "Torino" };

            string[] mexico = new string[] { "México D.F." };

            string[] norway = new string[] { "Stavern" };

            string[] poland = new string[] { "Warszawa" };

            string[] portugal = new string[] { "Lisboa" };

            string[] spain = new string[] { "Barcelona", "Madrid", "Sevilla" };

            string[] sweden = new string[] { "Bräcke", "Luleå" };

            string[] switzerland = new string[] { "Bern", "Genève" };

            string[] uk = new string[] { "Colchester", "Hedge End", "London" };

            string[] usa = new string[] { "Albuquerque", "Anchorage", "Boise", "Butte", "Elgin", "Eugene", "Kirkland", "Lander", "Portland", "San Francisco", "Seattle", "Walla Walla" };

            string[] venezuela = new string[] { "Barquisimeto", "Caracas", "I. de Margarita", "San Cristóbal" };

            ShipCity.Add("Argentina", argentina);
            ShipCity.Add("Austria", austria);
            ShipCity.Add("Belgium", belgium);
            ShipCity.Add("Brazil", brazil);
            ShipCity.Add("Canada", canada);
            ShipCity.Add("Denmark", denmark);
            ShipCity.Add("Finland", finland);
            ShipCity.Add("France", france);
            ShipCity.Add("Germany", germany);
            ShipCity.Add("Ireland", ireland);
            ShipCity.Add("Italy", italy);
            ShipCity.Add("Mexico", mexico);
            ShipCity.Add("Norway", norway);
            ShipCity.Add("Poland", poland);
            ShipCity.Add("Portugal", portugal);
            ShipCity.Add("Spain", spain);
            ShipCity.Add("Sweden", sweden);
            ShipCity.Add("Switzerland", switzerland);
            ShipCity.Add("UK", uk);
            ShipCity.Add("USA", usa);
            ShipCity.Add("Venezuela", venezuela);

        } 

        string[] CustomerID = new string[]
      {            
            "FRANS",
            "MEREP",
            "FOLKO",
            "SIMOB",
            "WARTH",
            "VAFFE",
             "BLONP",
            "FURIB",
            "SEVES",
            "LINOD",
            "RISCU",           
            "PICCO",
            "FOLIG",
            "WELLI",            
            "ALFKI",

      };

        double[] Freight = new double[]
        {
            4.45, 10.98, 17.67, 50.87, 20.12, 36.19, 49.21, 79.45, 18.59, 3.01, 4.13, 74,22
        }; 
        

        string[] ProductName = new string[]
       {
            "Alice Mutton",
            "NuNuCa Nub-Nougat-Creme",
            "Boston Crab Meat",
            "Raclette Courdavault",
            "Wimmers gute Semmelknodel",
            "Konbu",
            "Wimmers gute Semmelknödel",
            "Gorgonzola Telino",
            "Chartreuse verte",
            "Fløtemysost",
            "Carnarvon Tigers",
            "Thüringer Rostbratwurst",
            "Vegie-spread",
            "Tarte au sucre",
            "Valkoinen suklaa",
            "Queso Manchego La Pastora",
            "Perth Pasties",
            "Vegie-spread",
            "Tofu",
            "Sir Rodney's Scones",
            "Manjimup Dried Apples",
            "Tunnbröd",
            "Manjimup Dried Apples",
            "Ipoh Coffee",
            "Fløtemysost",
            "Carnarvon Tigers",
            "Teatime Chocolate Biscuits",
            "Inlagd Sill",
            "Teatime Chocolate Biscuits",
            "Steeleye Stout",
            "Boston Crab Meat",
            "Jack's New England Clam Chowder",
            "Ipoh Coffee",
            "Carnarvon Tigers",
            "Queso Cabrales",
            "Guaraná Fantástica",
            "Röd Kaviar",
            "Longlife Tofu",
            "Sirop d'érable",
            "Tarte au sucre",
            "Scottish Longbreads",
            "Spegesild",
            "Wimmers gute Semmelknödel",
            "Rhönbräu Klosterbier",
            "Queso Cabrales",
            "Valkoinen suklaa",
            "Rhönbräu Klosterbier",
            "Northwoods Cranberry Sauce",
            "Pavlova"
       };

        string[] ShipName = new string[]
        {
            "Franchi S.p.A.",
            "Mère Paillarde",
            "Folk och fä HB",
            "Simons bistro",
            "Vaffeljernet",
            "Wartian Herkku",
            "Franchi S.p.A",
            "Morgenstern Gesundkost",
            "Furia Bacalhau e Frutos do Mar",
            "Seven Seas Imports",
            "Simons bistro",
            "Wellington Importadora",
            "LINO-Delicateses",
            "Richter Supermarkt",
            "GROSELLA-Restaurante",
            "Piccolo und mehr",
            "Folies gourmandes",
            "Blondel père et fils",
            "Rattlesnake Canyon Grocery",
            "Magazzini Alimentari Riuniti",
            "Vins et alcools Chevalier",
            "Ernst Handel",
            "La maison d'Asie",
            "Toms Spezialitäten",
            "Rattlesnake Canyon Grocery",
            "Morgenstern Gesundkost",
            "Ernst Handel",
            "Antonio Moreno Taquería ",
            "Santé Gourmet",
            "LILA-Supermercado",
            "Suprêmes délices",
            "Bólido Comidas preparadas",
            "Ottilies Käseladen	",
            "Eastern Connection",
            "HILARIÓN-Abastos",
            "Centro comercial Moctezuma ",
            "Vaffeljernet",
            "Old World Delicatessen",
            "Mère Paillarde",
            "White Clover Markets",
            "HILARIÓN-Abastos",
            "Folk och fä HB",
            "LINO-Delicateses",
            "Antonio Moreno Taquería",
            "Berglunds snabbköp",
            "Santé Gourmet",
            "Morgenstern Gesundkost",
            "HILARIÓN-Abastos",
            "Toms Spezialitäten",
            "Bólido Comidas preparadas",
            "Folk och fä HB",
            "Save-a-lot Markets",
            "Wartian Herkku",
            "Ricardo Adocicados",
            "Blondel père et fils",
            "LILA-Supermercado",
            "The Cracker Box",
            "Hungry Owl All-Night Grocers",
            "LILA-Supermercado ",
            "Seven Seas Imports",
            "Eastern Connection",
            "Alfred's Futterkiste",
            "Hungry Owl All-Night Grocers",
            "Vaffeljernet",
            "Save-a-lot Markets",
            "Wartian Herkku",
            "France restauration",
            "Piccolo und mehr",
            "La maison d'Asie",
            "Hungry Owl All-Night Grocers",
            "Folk och fä HB",
            "Hungry Owl All-Night Grocers",
            "Chop-suey Chinese",
            "Spécialités du monde",
            "La maison d'Asie",
            "Richter Supermarkt	",
            "Suprêmes délices",
            "Bottom-Dollar Markets	",
            "Chop-suey Chinese",
            "Godos Cocina Típica ",
            "Suprêmes délices",
            "La maison d'Asie",
            "Santé Gourmet",
            "Franchi S.p.A",
            "Mère Paillarde",
            "LINO-Delicateses",
            "Galería del gastronómo",
            "B's Beverages ",
            "Ricardo Adocicados ",
            "Ernst Handel	",
            "QUICK-Stop ",
            "Rattlesnake Canyon Grocery",
            "Lazy K Kountry Store",
            "Richter Supermarkt",
            "Eastern Connection",
            "Save-a-lot Markets ",
            "Magazzini Alimentari Riuniti"
        };

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

        string[] CompanyName = new string[]
        {
            "Federal Shipping",
            "Speedy Express",
            "United Package"
        }; 

        internal string[] EmployeeName = new string[]
            {
                "Sean Jacobson",
                "Phyllis Allen",
                "Marvin Allen",
                "Michael Allen",
                "Cecil Allison",
                "Oscar Alpuerto",
                "Sandra Altamirano",
                "Selena Alvarad",
                "Emilio Alvaro",
                "Maxwell Amland",
                "Mae Anderson",
                "Ramona Antrim",
                "Sabria Appelbaum",
                "Hannah Arakawa",
                "Kyley Arbelaez",
                "Tom Johnston",
                "Thomas Armstrong",
                "John Arthur",
                "Chris Ashton",
                "Teresa Atkinson",
                "John Ault",
                "Robert Avalos",
                "Stephen Ayers",
                "Phillip Bacalzo",
                "Gustavo Achong",
                "Catherine Abel",
                "Kim Abercrombie",
                "Humberto Acevedo",
                "Pilar Ackerman",
                "Frances Adams",
                "Margar Smith",
                "Carla Adams",
                "Jay Adams",
                "Ronald Adina",
                "Samuel Agcaoili",
                "James Aguilar",
                "Robert Ahlering",
                "Francois Ferrier",
                "Kim Akers",
                "Lili Alameda",
                "Amy Alberts",
                "Anna Albright",
                "Milton Albury",
                "Paul Alcorn",
                "Gregory Alderson",
                "J. Phillip Alexander",
                "Michelle Alexander",
                "Daniel Blanco",
                "Cory Booth",
                "James Bailey"
            };
        
        string[] PostalCode = new string[]
        {
            "10100",
            "H1J 1c3",
            "S-844 67",
            "1734",
            "8200",
            "90110",
            "04179",
            "1675",
            "OX15 4NB",
            "08737-363",
            "4980",
            "1204",
            "1081",
            "5020"
        };

        string[] SupplierName = new string[]
        {
            "New Orleans Cajun Delights",
            "Extic Liquids",
        };
        
        #endregion
    }
}
