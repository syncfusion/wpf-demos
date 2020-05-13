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

namespace TitleBarCustomization
{
    /// <summary>
    /// Represents the class for title bar customization.
    /// </summary>
    public class OrderInfoRepository
    {
        /// <summary>
        /// Holds the ordered dates list.
        /// </summary>
        private List<DateTime> OrderedDates;

        /// <summary>
        /// Holds the random variable.
        /// </summary>
        private Random r = new Random();

        /// <summary>
        /// Holds the ship country array.
        /// </summary>
        private string[] ShipCountry = new string[]
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
        private Dictionary<string, string[]> ShipCity = new Dictionary<string, string[]>();

        /// <summary>
        /// Holds the details of customer ID in the array.
        /// </summary>
        private string[] CustomerID = new string[]
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
        /// Holds the postal code details in the array.
        /// </summary>
        private string[] PostalCode = new string[]
        {
            "10100",
            "H1J 1C3",
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
            "5020",
            "59000",
            "67000",
            "87110",
            "24100",
            "51100",
            "31000",
            "05023"
        };

        /// <summary>
        /// Holds the employee name details in the array.
        /// </summary>
        private string[] employeeName = new string[]
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

        /// <summary>
        /// Gets the customers <see cref="OrderInfoRepository"/> class.
        /// </summary>
        /// <value>The customers.</value>
        public List<string> Customers
        {
            get
            {
                return this.CustomerID.ToList();
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
                return this.ShipCountry.ToList();
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
            this.OrderedDates = GetDateBetween(2008, 2012, count);
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
            var shipcountry = ShipCountry[r.Next(5)];
            var shipcitycoll = ShipCity[shipcountry];
            return new OrderInfo()
            {
                OrderID = num,
                CustomerID = CustomerID[r.Next(15)],
                EmployeeID = r.Next(1, 10),
                Freight = Math.Round(r.Next(1000) + r.NextDouble(), 2),
                ShipCountry = shipcountry,
                ShippingDate = this.OrderedDates[num - 10000],
                IsClosed = num % 2 == 0 ? true : false,
                ShipCity = shipcitycoll[r.Next(shipcitycoll.Length - 1)]

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
        public string CustomerID
        {
            get
            {
                return this.customerID;
            }
            set
            {
                this.customerID = value;
                RaisePropertyChanged("CustomerID");
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
        public System.Nullable<int> EmployeeID
        {
            get
            {
                return this.employeeID;
            }
            set
            {
                this.employeeID = value;
                RaisePropertyChanged("EmployeeID");
            }
        }

        /// <summary>
        /// Gets or sets the ship city <see cref="OrderInfo"/> class.
        /// </summary>
        /// <value>The ship city.</value>
        public string ShipCity
        {
            get
            {
                return this.shipCity;
            }
            set
            {
                this.shipCity = value;
                RaisePropertyChanged("ShipCity");
            }
        }

        /// <summary>
        /// Gets or sets the ship country <see cref="OrderInfo"/> class.
        /// </summary>
        /// <value>The ship country.</value>
        public string ShipCountry
        {
            get
            {
                return this.shipCountry;
            }
            set
            {
                this.shipCountry = value;
                RaisePropertyChanged("ShipCountry");
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
