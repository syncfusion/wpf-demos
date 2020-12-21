#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Reflection;

namespace syncfusion.datagriddemos.wpf
{
    public class DataTableViewModel : NotificationObject
    {
        public Dictionary<string, string[]> ShipCity = new Dictionary<string, string[]>();
        /// <summary>
        /// Initializes a new instance of the <see cref="DataTableViewModel"/> class.
        /// </summary>
        public DataTableViewModel()
        {
            DataCollection = GetDataTable();
        }

        private DataTable _dataCollection;

        /// <summary>
        /// Gets or sets the data collection.
        /// </summary>
        /// <value>The data collection.</value>
        public DataTable DataCollection
        {
            get { return _dataCollection; }
            set { _dataCollection = value; }
        }
     
        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            SetShipCity();
            Random ran1 = new Random();
            DataSet dataSet = new DataSet("Supplier_Product");
            DataTable SupplierDetails = new DataTable("SupplierDetail");

            // Define all the columns once.
            DataColumn[] Suppliercols ={
                                  new DataColumn("SupplierID", typeof(int)),
                                  new DataColumn("ContactName",typeof(string)),
                                  new DataColumn("ContactTitle",typeof(string)),
                                  new DataColumn("City",typeof(string)),
                                  new DataColumn("Country",typeof(string)),
                                  new DataColumn("PostalCode",typeof(string)),
                                   new DataColumn("Phone",typeof(string)),
                              };

            SupplierDetails.Columns.AddRange(Suppliercols);

            for (int i = 0; i < 20; i++)
            {
                var shipcountry = ShipCountry[ran1.Next(0, 5)];
                var shipcitycoll = ShipCity[shipcountry];

                DataRow row1 = SupplierDetails.NewRow();
                row1["SupplierID"] = i + 1;
                row1["ContactName"] = Name[ran1.Next(0, 9)];
                row1["ContactTitle"] = title[ran1.Next(0, 9)];
                row1["City"] = shipcitycoll[ran1.Next(shipcitycoll.Length - 1)];
                row1["PostalCode"] = PostalCode[ran1.Next(1, 10)];
                row1["Country"] = shipcountry;
                row1["Phone"] = ran1.Next(999111, 999119).ToString();

                SupplierDetails.Rows.Add(row1);
            }

            Random rand2 = new Random();
            DataTable OrderDetails = new DataTable("OrderDetail");
            DataColumn[] Ordercols ={
                                  new DataColumn("Product ID",typeof(string)),
                                  new DataColumn("Supplier ID",typeof(int)),
                                  new DataColumn("Product Name",typeof(string)),
                                  new DataColumn("Quantity Per Unit",typeof(int)),
                                  new DataColumn("Unit Price",typeof(double)),
                                   new DataColumn("Units In Stock",typeof(int)),
                                   new DataColumn("No Of Orders",typeof(int)),
                                   new DataColumn("Discontinued",typeof(bool)),
                              };

            OrderDetails.Columns.AddRange(Ordercols);
            int genUniqueID = 0;
            for (int i = 0; i < 20; i++)
            {
                 
                DataRow row1 = OrderDetails.NewRow();

                row1["Product ID"] = 1000 + i;
                row1["Supplier ID"] = genUniqueID + 1;
                row1["Product Name"] = ProductName[rand2.Next(1, 15)];
                row1["Quantity Per Unit"] = rand2.Next(1, 15);
                row1["Unit Price"] = (double)rand2.Next(75, 500);
                row1["Units In Stock"] = rand2.Next(1, 50);
                row1["No Of Orders"] = rand2.Next(1, 10);
                row1["Discontinued"] = rand2.Next() % 2 == 0 ? true : false;

                OrderDetails.Rows.Add(row1);
                if (i % 5 == 0)
                    genUniqueID = 0;
                else
                    genUniqueID++;
            }

            dataSet.Tables.Add(SupplierDetails);
            dataSet.Tables.Add(OrderDetails);
 
            dataSet.Relations.Add("SupplierProduct",  dataSet.Tables["SupplierDetail"].Columns["SupplierID"],  dataSet.Tables["OrderDetail"].Columns["Supplier ID"], false);

            if (dataSet.Tables.Count > 0)
                return dataSet.Tables[0];
            else
                return null;

        }

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

        internal string[] title = new string[]
           {
                "Marketing Assistant",
                "Engineering Manager",
                "Senior Tool Designer",
                "Tool Designer",
                "Marketing Manager",
                "Production Supervisor - WC60",
                "Production Technician - WC10",
                "Design Engineer",
                "Production Technician - WC10",
                "Design Engineer",
                "Vice President of Engineering",
                "Production Technician - WC10",
                "Production Supervisor - WC50",
                "Production Technician - WC10",
                "Production Supervisor - WC60",
                "Production Technician - WC10",
                "Production Supervisor - WC60",
                "Production Technician - WC10",
                "Production Technician - WC30",
                "Production Control Manager",
                "Production Technician - WC45",
                "Production Technician - WC45",
                "Production Technician - WC30",
                "Production Supervisor - WC10",
                "Production Technician - WC20",
                "Production Technician - WC40",
                "Network Administrator",
                "Production Technician - WC50",
                "Human Resources Manager",
                "Production Technician - WC40",
                "Production Technician - WC30",
                "Production Technician - WC30",
                "Stocker",
                "Shipping and Receiving Clerk",
                "Production Technician - WC50",
                "Production Technician - WC60",
                "Production Supervisor - WC50",
                "Production Technician - WC20",
                "Production Technician - WC45",
                "Quality Assurance Supervisor",
                "Information Services Manager",
                "Production Technician - WC50",
                "Master Scheduler",
                "Production Technician - WC40",
                "Marketing Specialist",
                "Recruiter",
                "Production Technician - WC50",
                "Maintenance Supervisor",
                "Production Technician - WC30",
           };

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

        internal string[] Name = new string[]
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
    }
}
