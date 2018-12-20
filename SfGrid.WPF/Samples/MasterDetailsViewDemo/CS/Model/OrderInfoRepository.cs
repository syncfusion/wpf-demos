#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterDetailsViewDemo
{
    public class OrderInfoRepository 
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderInfoRepository"/> class.
        /// </summary>
        public OrderInfoRepository()
        {
            
        }

        /// <summary>
        /// Gets the orders details.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public  List<OrderInfo> GetOrdersDetails(int count)
        {
            List<OrderInfo> ordersDetails = new List<OrderInfo>();
            this.OrderedDates = GetDateBetween(2008, 2012, count);
            OrdersAdd(count);
            SetShipCity();
            for (int i = 10000; i < count + 10000; i++)
            {
                ordersDetails.Add(GetOrder(i));
            }
            return ordersDetails;
        }

        /// <summary>
        /// Gets the customers.
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
        /// Gets the ship countries.
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
        /// Orderses the add.
        /// </summary>
        private void OrdersAdd(int count)
        {
            ord.Add(new OrderDetails(10000, 12, 23, 5, 10, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count-1)]));
            ord.Add(new OrderDetails(10000, 14, 59, 10, 2, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10000, 18, 23, 5, 10, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10000, 34, 59, 10, 2, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10000, 14, 59, 10, 2, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10000, 18, 23, 5, 10, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10000, 34, 59, 10, 2, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10001, 23, 45, 76, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10001, 45, 67, 23, 5, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10001, 45, 42, 16, 3, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10001, 23, 95, 15, 2, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10002, 7, 70, 6, 4, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10002, 2, 30, 5, 2, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10003, 23, 73, 9, 3, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10003, 8, 11, 8, 7, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10003, 1, 150, 1, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10009, 4, 35, 4, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10009, 2, 31, 7, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10010, 7, 23, 3, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10010, 5, 65, 4, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10010, 3, 15, 5, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10010, 2, 31, 1, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10011, 6, 46, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10011, 3, 45, 4, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10011, 2, 41, 7, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10013, 19, 80, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10013, 20, 111, 2, 7, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10021, 54, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10021, 63, 46, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10021, 27, 99, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10022, 59, 80, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10022, 60, 111, 2, 7, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10022, 47, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10032, 4, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10032, 6, 46, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10034, 17, 99, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10034, 19, 80, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10034, 20, 111, 2, 7, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10042, 4, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10042, 4, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10045, 6, 46, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10045, 17, 99, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10045, 19, 80, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10045, 20, 111, 2, 7, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10056, 4, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10056, 4, 35, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10056, 6, 46, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10067, 17, 99, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10067, 19, 80, 2, 0, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
            ord.Add(new OrderDetails(10067, 20, 111, 2, 7, CustomerID[r.Next(15)], this.OrderedDates[r.Next(count - 1)]));
        }

        private List<DateTime> OrderedDates;
        Random r = new Random();
        List<OrderDetails> ord = new List<OrderDetails>();

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        private OrderInfo GetOrder(int i)
        {
            var shipcountry = ShipCountry[r.Next(5)];
            var shipcitycoll = ShipCity[shipcountry];
            return new OrderInfo()
            {
                OrderID = i,
                CustomerID = CustomerID[r.Next(15)],
                EmployeeID = r.Next(1,10),
                Freight = Math.Round(r.Next(1000) + r.NextDouble(), 2),
                ShipCountry = shipcountry,
                ShippingDate=this.OrderedDates[i - 10000],
                IsClosed= i % 2 == 0 ? true : false,
                ShipCity = shipcitycoll[r.Next(shipcitycoll.Length - 1)],
                OrderDetails =getorder(i)               
            };
        }

        /// <summary>
        /// Getors the specified i.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        public List<OrderDetails> getorder(int i)
        {
            List<OrderDetails> order = new List<OrderDetails>();
            foreach (var or in ord)
                if (or.OrderID == i)
                    order.Add(or);
            return order;
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

        Dictionary<string, string[]> ShipCity = new Dictionary<string, string[]>();

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
        /// Gets the date between.
        /// </summary>
        /// <param name="startYear">The start year.</param>
        /// <param name="EndYear">The end year.</param>
        /// <param name="Count">The count.</param>
        /// <returns></returns>
        private List<DateTime> GetDateBetween(int startYear, int EndYear, int Count)
        {
            List<DateTime> date = new List<DateTime>();
            Random d = new Random(1);
            Random m = new Random(2);
            Random y = new Random(startYear);
            for (int i = 0; i < Count; i++)
            {
                int year = y.Next(startYear, EndYear);
                int month = m.Next(3, 13);
                int day = d.Next(1, 31);

                date.Add(new DateTime(year, month, day));
            }
            return date;
        }
    }  
}
