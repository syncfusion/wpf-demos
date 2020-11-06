#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace syncfusion.layoutdemos.wpf
{
    /// <summary>
    /// Represents the class for title bar customization.
    /// </summary>
    public class OrderInfoRepository
    {
        /// <summary>
        /// Holds the ordered dates list.
        /// </summary>
        private List<DateTime> orderedDatesCollection;

        /// <summary>
        /// Holds the random variable.
        /// </summary>
        private Random r = new Random();

        /// <summary>
        /// Holds the ship country array.
        /// </summary>
        private string[] countriesCollection = new string[]
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

        /// <summary>
        /// Holds the ship city details in the dictionary.
        /// </summary>
        private Dictionary<string, string[]> citiesCollection = new Dictionary<string, string[]>();

        /// <summary>
        /// Holds the details of customer ID in the array.
        /// </summary>
        private string[] customersIDCollection = new string[]
        {
            "ALFKI",
            "FRANS",
            "MEREP",
            "FOLKO",
            "SIMOB",
            "WARTH",
            "VAFFE",
            "FURIB",
            "SEVES",
            "LINOD",
            "RISCU",
            "PICCO",
            "BLONP",
            "WELLI",
            "FOLIG"
        };

        /// <summary>
        /// Gets the customers <see cref="OrderInfoRepository"/> class.
        /// </summary>
        /// <value>The customers.</value>
        public List<string> Customers
        {
            get
            {
                return this.customersIDCollection.ToList();
            }
        }

        /// <summary>
        /// Gets the ship countries <see cref="OrderInfoRepository"/> class.
        /// </summary>
        /// <value>The ship countries.</value>
        public List<string> ShipCountries
        {
            get
            {
                return this.countriesCollection.ToList();
            }
        }

        /// <summary>
        /// Gets the orders details.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>Returns the order list.</returns>
        public List<OrderInfo> GetOrdersDetails(int count)
        {
            List<OrderInfo> ordersDetails = new List<OrderInfo>();
            this.orderedDatesCollection = GetDateBetween(2008, 2012, count);
            SetShipCity();
            for (int i = 10000; i < count + 10000; i++)
            {
                ordersDetails.Add(GetOrder(i));
            }
            return ordersDetails;
        }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="num">The order.</param>
        /// <returns>Returns the order.</returns>
        private OrderInfo GetOrder(int num)
        {
            var shipcountry = countriesCollection[r.Next(5)];
            var shipcitycoll = citiesCollection[shipcountry];
            return new OrderInfo()
            {
                OrderID = num,
                CustomersID = customersIDCollection[r.Next(15)],
                SupplierID = r.Next(1, 10),
                Freight = Math.Round(r.Next(1000) + r.NextDouble(), 2),
                Countries = shipcountry,
                ShippingDate = this.orderedDatesCollection[num - 10000],
                IsClosed = num % 2 == 0 ? true : false,
                Cities = shipcitycoll[r.Next(shipcitycoll.Length - 1)]

            };
        }

        /// <summary>
        /// Sets the ship city.
        /// </summary>
        private void SetShipCity()
        {
            string[] argentina = new string[] { "Buenos Aires" };
            string[] austria = new string[] { "Graz", "Salzburg" };
            string[] belgium = new string[] { "Bruxelles", "Charleroi" };
            string[] brazil = new string[] { "Campinas", "Resende", "Rio de Janeiro", "S�o Paulo" };
            string[] canada = new string[] { "Montr�al", "Tsawassen", "Vancouver" };
            string[] denmark = new string[] { "�rhus", "K�benhavn" };
            string[] finland = new string[] { "Helsinki", "Oulu" };
            string[] france = new string[] { "Lille", "Lyon", "Marseille", "Nantes", "Paris", "Reims", "Strasbourg", "Toulouse", "Versailles" };
            string[] germany = new string[] { "Aachen", "Berlin", "Brandenburg", "Cunewalde", "Frankfurt a.M.", "K�ln", "Leipzig", "Mannheim", "M�nchen", "M�nster", "Stuttgart" };
            string[] ireland = new string[] { "Cork" };
            string[] italy = new string[] { "Bergamo", "Reggio Emilia", "Torino" };
            string[] mexico = new string[] { "M�xico D.F." };
            string[] norway = new string[] { "Stavern" };
            string[] poland = new string[] { "Warszawa" };
            string[] portugal = new string[] { "Lisboa" };
            string[] spain = new string[] { "Barcelona", "Madrid", "Sevilla" };
            string[] sweden = new string[] { "Br�cke", "Lule�" };
            string[] switzerland = new string[] { "Bern", "Gen�ve" };
            string[] uk = new string[] { "Colchester", "Hedge End", "London" };
            string[] usa = new string[] { "Albuquerque", "Anchorage", "Boise", "Butte", "Elgin", "Eugene", "Kirkland", "Lander", "Portland", "San Francisco", "Seattle", "Walla Walla" };
            string[] venezuela = new string[] { "Barquisimeto", "Caracas", "I. de Margarita", "San Crist�bal" };

            citiesCollection.Add("Argentina", argentina);
            citiesCollection.Add("Austria", austria);
            citiesCollection.Add("Belgium", belgium);
            citiesCollection.Add("Brazil", brazil);
            citiesCollection.Add("Canada", canada);
            citiesCollection.Add("Denmark", denmark);
            citiesCollection.Add("Finland", finland);
            citiesCollection.Add("France", france);
            citiesCollection.Add("Germany", germany);
            citiesCollection.Add("Ireland", ireland);
            citiesCollection.Add("Italy", italy);
            citiesCollection.Add("Mexico", mexico);
            citiesCollection.Add("Norway", norway);
            citiesCollection.Add("Poland", poland);
            citiesCollection.Add("Portugal", portugal);
            citiesCollection.Add("Spain", spain);
            citiesCollection.Add("Sweden", sweden);
            citiesCollection.Add("Switzerland", switzerland);
            citiesCollection.Add("UK", uk);
            citiesCollection.Add("USA", usa);
            citiesCollection.Add("Venezuela", venezuela);

        }

        /// <summary>
        /// Gets the date between the start year and end year.
        /// </summary>
        /// <param name="startYear">Specifies the start year.</param>
        /// <param name="EndYear">Specifies the end year.</param>
        /// <param name="Count">Specifies the count.</param>
        /// <returns>Returns the date.</returns>
        private List<DateTime> GetDateBetween(int startYear, int EndYear, int Count)
        {
            List<DateTime> date = new List<DateTime>();
            Random random_day = new Random(1);
            Random random_month = new Random(2);
            Random random_year = new Random(startYear);
            for (int i = 0; i < Count; i++)
            {
                int year = random_year.Next(startYear, EndYear);
                int month = random_month.Next(3, 13);
                int day = random_day.Next(1, 31);

                date.Add(new DateTime(year, month, day));
            }
            return date;
        }
    }

    /// <summary>
    /// Order info class
    /// </summary>
    public class OrderInfo : NotificationObject
    {
        /// <summary>
        /// Holfd the order ID.
        /// </summary>
        private int orderID;

        /// <summary>
        /// Holds the customer ID.
        /// </summary>
        private string customerID;

        /// <summary>
        /// Holds the value of employee ID.
        /// </summary>
        private System.Nullable<int> employeeID;

        /// <summary>
        /// Holds the value of ship city.
        /// </summary>
        private string shipCity;

        /// <summary>
        /// Holds the value of ship country.
        /// </summary>
        private string shipCountry;

        /// <summary>
        /// Holds the value of freight.
        /// </summary>
        private double freight;

        /// <summary>
        /// Holds the value of Closing
        /// </summary>
        private bool isClosed;

        /// <summary>
        /// Holds the value of shipping date.
        /// </summary>
        private DateTime shippingDate;

        /// <summary>
        /// Gets or sets the order ID <see cref="OrderInfo"/> class.
        /// </summary>
        /// <value>The order ID.</value>
        public int OrderID
        {
            get
            {
                return this.orderID;
            }
            set
            {
                this.orderID = value;
                RaisePropertyChanged("OrderID");
            }
        }

        /// <summary>
        /// Gets or sets the customer ID <see cref="OrderInfo"/> class.
        /// </summary>
        /// <value>The customer ID.</value>
        public string CustomersID
        {
            get
            {
                return this.customerID;
            }
            set
            {
                this.customerID = value;
                RaisePropertyChanged("CustomersID");
            }
        }

        /// <summary>
        /// Gets or sets the shipping date <see cref="OrderInfo"/> class.
        /// </summary>
        /// <value>The shipping date.</value>
        public DateTime ShippingDate
        {
            get
            {
                return shippingDate;
            }
            set
            {
                shippingDate = value;
                RaisePropertyChanged("ShippingDate");
            }
        }

        /// <summary>
        /// Gets or sets the employee ID <see cref="OrderInfo"/> class.
        /// </summary>
        /// <value>The employee ID.</value>
        public System.Nullable<int> SupplierID
        {
            get
            {
                return this.employeeID;
            }
            set
            {
                this.employeeID = value;
                RaisePropertyChanged("SupplierID");
            }
        }

        /// <summary>
        /// Gets or sets the ship city <see cref="OrderInfo"/> class.
        /// </summary>
        /// <value>The ship city.</value>
        public string Cities
        {
            get
            {
                return this.shipCity;
            }
            set
            {
                this.shipCity = value;
                RaisePropertyChanged("Cities");
            }
        }

        /// <summary>
        /// Gets or sets the ship country <see cref="OrderInfo"/> class.
        /// </summary>
        /// <value>The ship country.</value>
        public string Countries
        {
            get
            {
                return this.shipCountry;
            }
            set
            {
                this.shipCountry = value;
                RaisePropertyChanged("Countries");
            }
        }

        /// <summary>
        /// Gets or sets the freight <see cref="OrderInfo"/> class.
        /// </summary>
        /// <value>The freight.</value>
        public double Freight
        {
            get
            {
                return this.freight;
            }
            set
            {
                this.freight = value;
                RaisePropertyChanged("Freight");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is closed <see cref="OrderInfo"/> class.
        /// </summary>
        /// <value><c>true</c> if this instance is closed; otherwise, <c>false</c>.</value>
        public bool IsClosed
        {
            get
            {
                return this.isClosed;
            }

            set
            {
                this.isClosed = value;
                this.RaisePropertyChanged("IsClosed");
            }
        }
    }
}
