#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace syncfusion.datagriddemos.wpf
{
    public class ComboBoxColumnsViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxColumnsViewModel"/> class.
        /// </summary>
        public ComboBoxColumnsViewModel()
        {
            this.PopulateData();
            _shipCities = GetShipCities();
            CountryList = new List<string>(ShipCities.Keys);
        }
        
        private ObservableCollection<OrderInfo> _orderDatails;
        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public ObservableCollection<OrderInfo> OrderDetails
        {
            get
            {
                return _orderDatails;
            }
            set
            {
                _orderDatails = value;
            }
        }

        Dictionary<string, ObservableCollection<ShipCityDetails>> _shipCities;
        /// <summary>
        /// Gets or sets the ship cities.
        /// </summary>
        /// <value>The ship cities.</value>
        public Dictionary<string, ObservableCollection<ShipCityDetails>> ShipCities
        {
            get
            {
                return _shipCities;
            }
            set
            {
                _shipCities = value;
            }
        }

        public List<string> CountryList { get; set; }

        Random r = new Random();
        public void PopulateData()
        {
            _orderDatails = new ObservableCollection<OrderInfo>();
            _orderDatails.Add(new OrderInfo(1000, CustomerID[r.Next(15)], ProductName[r.Next(6)], 10, "Argentina", 101));
            _orderDatails.Add(new OrderInfo(1001, CustomerID[r.Next(15)], ProductName[r.Next(6)], 15, "Austria", 106));
            _orderDatails.Add(new OrderInfo(1002, CustomerID[r.Next(15)], ProductName[r.Next(6)], 20, "Belgium", 111));
            _orderDatails.Add(new OrderInfo(1003, CustomerID[r.Next(15)], ProductName[r.Next(6)], 25, "Brazil", 115));
            _orderDatails.Add(new OrderInfo(1004, CustomerID[r.Next(15)], ProductName[r.Next(6)], 20, "Canada", 120));
            _orderDatails.Add(new OrderInfo(1005, CustomerID[r.Next(15)], ProductName[r.Next(6)], 17, "Denmark", 125));
            _orderDatails.Add(new OrderInfo(1006, CustomerID[r.Next(15)], ProductName[r.Next(6)], 14, "Finland", 130));
            _orderDatails.Add(new OrderInfo(1007, CustomerID[r.Next(15)], ProductName[r.Next(6)], 11, "Italy", 134));
            _orderDatails.Add(new OrderInfo(1008, CustomerID[r.Next(15)], ProductName[r.Next(6)], 7, "US", 138));
            _orderDatails.Add(new OrderInfo(1009, CustomerID[r.Next(15)], ProductName[r.Next(6)], 5, "Belgium", 112));
            _orderDatails.Add(new OrderInfo(1010, CustomerID[r.Next(15)], ProductName[r.Next(6)], 3, "Brazil", 116));
            _orderDatails.Add(new OrderInfo(1011, CustomerID[r.Next(15)], ProductName[r.Next(6)], 7, "Denmark", 126));
            _orderDatails.Add(new OrderInfo(1012, CustomerID[r.Next(15)], ProductName[r.Next(6)], 13, "Argentina", 102));
            _orderDatails.Add(new OrderInfo(1013, CustomerID[r.Next(15)], ProductName[r.Next(6)], 12, "Canada", 121));
            _orderDatails.Add(new OrderInfo(1014, CustomerID[r.Next(15)], ProductName[r.Next(6)], 5, "Finland", 131));
            _orderDatails.Add(new OrderInfo(1015, CustomerID[r.Next(15)], ProductName[r.Next(6)], 1, "US", 139));
            _orderDatails.Add(new OrderInfo(1016, CustomerID[r.Next(15)], ProductName[r.Next(6)], 6, "Austria", 107));
            _orderDatails.Add(new OrderInfo(1017, CustomerID[r.Next(15)], ProductName[r.Next(6)], 9, "Italy", 135));
            _orderDatails.Add(new OrderInfo(1018, CustomerID[r.Next(15)], ProductName[r.Next(6)], 4, "Denmark", 127));
            _orderDatails.Add(new OrderInfo(1019, CustomerID[r.Next(15)], ProductName[r.Next(6)], 2, "Finland", 132));
            _orderDatails.Add(new OrderInfo(1020, CustomerID[r.Next(15)], ProductName[r.Next(6)], 3, "Argentina", 103));
            _orderDatails.Add(new OrderInfo(1021, CustomerID[r.Next(15)], ProductName[r.Next(6)], 8, "Austria", 108));
            _orderDatails.Add(new OrderInfo(1022, CustomerID[r.Next(15)], ProductName[r.Next(6)], 18, "Belgium", 113));
            _orderDatails.Add(new OrderInfo(1023, CustomerID[r.Next(15)], ProductName[r.Next(6)], 4, "Brazil", 117));
            _orderDatails.Add(new OrderInfo(1024, CustomerID[r.Next(15)], ProductName[r.Next(6)], 9, "Canada", 122));
            _orderDatails.Add(new OrderInfo(1025, CustomerID[r.Next(15)], ProductName[r.Next(6)], 10, "Denmark", 128));
            _orderDatails.Add(new OrderInfo(1026, CustomerID[r.Next(15)], ProductName[r.Next(6)], 17, "Finland", 133));
            _orderDatails.Add(new OrderInfo(1027, CustomerID[r.Next(15)], ProductName[r.Next(6)], 15, "Italy", 136));
            _orderDatails.Add(new OrderInfo(1028, CustomerID[r.Next(15)], ProductName[r.Next(6)], 13, "US", 140));
            _orderDatails.Add(new OrderInfo(1029, CustomerID[r.Next(15)], ProductName[r.Next(6)], 5, "Belgium", 114));
            _orderDatails.Add(new OrderInfo(1030, CustomerID[r.Next(15)], ProductName[r.Next(6)], 3, "Brazil", 118));
            _orderDatails.Add(new OrderInfo(1031, CustomerID[r.Next(15)], ProductName[r.Next(6)], 17, "Denmark", 129));
            _orderDatails.Add(new OrderInfo(1032, CustomerID[r.Next(15)], ProductName[r.Next(6)], 19, "Argentina", 104));
            _orderDatails.Add(new OrderInfo(1033, CustomerID[r.Next(15)], ProductName[r.Next(6)], 4, "Canada", 123));
            _orderDatails.Add(new OrderInfo(1034, CustomerID[r.Next(15)], ProductName[r.Next(6)], 12, "Finland", 133));
            _orderDatails.Add(new OrderInfo(1035, CustomerID[r.Next(15)], ProductName[r.Next(6)], 11, "US", 141));
            _orderDatails.Add(new OrderInfo(1036, CustomerID[r.Next(15)], ProductName[r.Next(6)], 7, "Austria", 109));
            _orderDatails.Add(new OrderInfo(1037, CustomerID[r.Next(15)], ProductName[r.Next(6)], 10, "Italy", 137));
            _orderDatails.Add(new OrderInfo(1038, CustomerID[r.Next(15)], ProductName[r.Next(6)], 1, "Denmark", 126));
            _orderDatails.Add(new OrderInfo(1039, CustomerID[r.Next(15)], ProductName[r.Next(6)], 13, "Finland", 132));
        }

        public static Dictionary<string, ObservableCollection<ShipCityDetails>> GetShipCities()
        {
            ObservableCollection<ShipCityDetails> argentina = new ObservableCollection<ShipCityDetails>();
            argentina.Add(new ShipCityDetails() { ShipCityName = "Bergamo", ShipCityID = 101 });
            argentina.Add(new ShipCityDetails() { ShipCityName = "Graz", ShipCityID = 102 });
            argentina.Add(new ShipCityDetails() { ShipCityName = "Campinas", ShipCityID = 103 });
            argentina.Add(new ShipCityDetails() { ShipCityName = "Montr�al", ShipCityID = 104 });
            argentina.Add(new ShipCityDetails() { ShipCityName = "Buenos Aires", ShipCityID = 105 });

            ObservableCollection<ShipCityDetails> austria = new ObservableCollection<ShipCityDetails>();
            austria.Add(new ShipCityDetails() { ShipCityName = "austriaAachen", ShipCityID = 106 });
            austria.Add(new ShipCityDetails() { ShipCityName = "Cork", ShipCityID = 107 });
            austria.Add(new ShipCityDetails() { ShipCityName = "�rhus", ShipCityID = 108 });
            austria.Add(new ShipCityDetails() { ShipCityName = "Montr�al", ShipCityID = 109 });
            austria.Add(new ShipCityDetails() { ShipCityName = "Graz", ShipCityID = 110 });

            ObservableCollection<ShipCityDetails> belgium = new ObservableCollection<ShipCityDetails>();
            belgium.Add(new ShipCityDetails() { ShipCityName = "Bruxelles", ShipCityID = 111 });
            belgium.Add(new ShipCityDetails() { ShipCityName = "Campinas", ShipCityID = 112 });
            belgium.Add(new ShipCityDetails() { ShipCityName = "Lille", ShipCityID = 113 });
            belgium.Add(new ShipCityDetails() { ShipCityName = "Bergamo", ShipCityID = 114 });

            ObservableCollection<ShipCityDetails> brazil = new ObservableCollection<ShipCityDetails>();
            brazil.Add(new ShipCityDetails() { ShipCityName = "Montr�al", ShipCityID = 115 });
            brazil.Add(new ShipCityDetails() { ShipCityName = "Aachen", ShipCityID = 116 });
            brazil.Add(new ShipCityDetails() { ShipCityName = "Graz", ShipCityID = 117 });
            brazil.Add(new ShipCityDetails() { ShipCityName = "Bergamo", ShipCityID = 118 });
            brazil.Add(new ShipCityDetails() { ShipCityName = "Campinas", ShipCityID = 119 });

            ObservableCollection<ShipCityDetails> canada = new ObservableCollection<ShipCityDetails>();
            canada.Add(new ShipCityDetails() { ShipCityName = "Montr�al", ShipCityID = 120 });
            canada.Add(new ShipCityDetails() { ShipCityName = "�rhus", ShipCityID = 121 });
            canada.Add(new ShipCityDetails() { ShipCityName = "Bergamo", ShipCityID = 122 });
            canada.Add(new ShipCityDetails() { ShipCityName = "Lille", ShipCityID = 123 });
            canada.Add(new ShipCityDetails() { ShipCityName = "Montr�al", ShipCityID = 124 });

            ObservableCollection<ShipCityDetails> denmark = new ObservableCollection<ShipCityDetails>();
            denmark.Add(new ShipCityDetails() { ShipCityName = "Campinas", ShipCityID = 125 });
            denmark.Add(new ShipCityDetails() { ShipCityName = "Bruxelles", ShipCityID = 126 });
            denmark.Add(new ShipCityDetails() { ShipCityName = "Bergamo", ShipCityID = 127 });
            denmark.Add(new ShipCityDetails() { ShipCityName = "Graz", ShipCityID = 128 });
            denmark.Add(new ShipCityDetails() { ShipCityName = "�rhus", ShipCityID = 129 });

            ObservableCollection<ShipCityDetails> finland = new ObservableCollection<ShipCityDetails>();
            finland.Add(new ShipCityDetails() { ShipCityName = "Bruxelles", ShipCityID = 130 });
            finland.Add(new ShipCityDetails() { ShipCityName = "Montr�al", ShipCityID = 131 });
            finland.Add(new ShipCityDetails() { ShipCityName = "Cork", ShipCityID = 132 });
            finland.Add(new ShipCityDetails() { ShipCityName = "Helsinki", ShipCityID = 133 });

            ObservableCollection<ShipCityDetails> italy = new ObservableCollection<ShipCityDetails>();
            italy.Add(new ShipCityDetails() { ShipCityName = "Bruxelles", ShipCityID = 134 });
            italy.Add(new ShipCityDetails() { ShipCityName = "Montr�al", ShipCityID = 135 });
            italy.Add(new ShipCityDetails() { ShipCityName = "Cork", ShipCityID = 136 });
            italy.Add(new ShipCityDetails() { ShipCityName = "Helsinki", ShipCityID = 137 });

            ObservableCollection<ShipCityDetails> us = new ObservableCollection<ShipCityDetails>();
            us.Add(new ShipCityDetails() { ShipCityName = "Campinas", ShipCityID = 138 });
            us.Add(new ShipCityDetails() { ShipCityName = "Bruxelles", ShipCityID = 139 });
            us.Add(new ShipCityDetails() { ShipCityName = "Bergamo", ShipCityID = 140 });
            us.Add(new ShipCityDetails() { ShipCityName = "Graz", ShipCityID = 141 });
            us.Add(new ShipCityDetails() { ShipCityName = "�rhus", ShipCityID = 142 });

            ObservableCollection<ShipCityDetails> uk = new ObservableCollection<ShipCityDetails>();
            uk.Add(new ShipCityDetails() { ShipCityName = "Bruxelles", ShipCityID = 143 });
            uk.Add(new ShipCityDetails() { ShipCityName = "Montr�al", ShipCityID = 145 });
            uk.Add(new ShipCityDetails() { ShipCityName = "Cork", ShipCityID = 146 });
            uk.Add(new ShipCityDetails() { ShipCityName = "Helsinki", ShipCityID = 147 });


            Dictionary<string, ObservableCollection<ShipCityDetails>> shipDictionary =
                new Dictionary<string, ObservableCollection<ShipCityDetails>>();
            shipDictionary.Add("Argentina", argentina);
            shipDictionary.Add("Austria", austria);
            shipDictionary.Add("Belgium", belgium);
            shipDictionary.Add("Brazil", brazil);
            shipDictionary.Add("Canada", canada);
            shipDictionary.Add("Denmark", denmark);
            shipDictionary.Add("Finland", finland);
            shipDictionary.Add("Italy", italy);
            shipDictionary.Add("US", us);
            shipDictionary.Add("UK", uk);
            return shipDictionary;
        }

        string[] ProductName = new string[]
       {
            "Alice Mutton",
            "NuNuCa Nub-Nougat-Creme",
            "Boston Crab Meat",
            "Raclette Courdavault",
            "Wimmers gute Semmelknodel",
            "Konbu"
       };
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
    }
}
