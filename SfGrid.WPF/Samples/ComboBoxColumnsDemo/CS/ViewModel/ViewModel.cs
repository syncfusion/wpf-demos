#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ComboBoxColumnsDemo
{
    public class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.PopulateData();
            _shipCities = CountryDetailsRepository.GetShipCities();
            CountryList = new List<string>(ShipCities.Keys);
        }
        
        private ObservableCollection<OrderDetails> _orderDatails;
        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public ObservableCollection<OrderDetails> OrderDetails
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
            _orderDatails = new ObservableCollection<OrderDetails>();
            _orderDatails.Add(new OrderDetails(1000, CustomerID[r.Next(15)], ProductName[r.Next(6)], 10, "Argentina", 101));
            _orderDatails.Add(new OrderDetails(1001, CustomerID[r.Next(15)], ProductName[r.Next(6)], 15, "Austria", 106));
            _orderDatails.Add(new OrderDetails(1002, CustomerID[r.Next(15)], ProductName[r.Next(6)], 20, "Belgium", 111));
            _orderDatails.Add(new OrderDetails(1003, CustomerID[r.Next(15)], ProductName[r.Next(6)], 25, "Brazil", 115));
            _orderDatails.Add(new OrderDetails(1004, CustomerID[r.Next(15)], ProductName[r.Next(6)], 20, "Canada", 120));
            _orderDatails.Add(new OrderDetails(1005, CustomerID[r.Next(15)], ProductName[r.Next(6)], 17, "Denmark", 125));
            _orderDatails.Add(new OrderDetails(1006, CustomerID[r.Next(15)], ProductName[r.Next(6)], 14, "Finland", 130));
            _orderDatails.Add(new OrderDetails(1007, CustomerID[r.Next(15)], ProductName[r.Next(6)], 11, "Italy", 134));
            _orderDatails.Add(new OrderDetails(1008, CustomerID[r.Next(15)], ProductName[r.Next(6)], 7, "US", 138));
            _orderDatails.Add(new OrderDetails(1009, CustomerID[r.Next(15)], ProductName[r.Next(6)], 5, "Belgium", 112));
            _orderDatails.Add(new OrderDetails(1010, CustomerID[r.Next(15)], ProductName[r.Next(6)], 3, "Brazil", 116));
            _orderDatails.Add(new OrderDetails(1011, CustomerID[r.Next(15)], ProductName[r.Next(6)], 7, "Denmark", 126));
            _orderDatails.Add(new OrderDetails(1012, CustomerID[r.Next(15)], ProductName[r.Next(6)], 13, "Argentina", 102));
            _orderDatails.Add(new OrderDetails(1013, CustomerID[r.Next(15)], ProductName[r.Next(6)], 12, "Canada", 121));
            _orderDatails.Add(new OrderDetails(1014, CustomerID[r.Next(15)], ProductName[r.Next(6)], 5, "Finland", 131));
            _orderDatails.Add(new OrderDetails(1015, CustomerID[r.Next(15)], ProductName[r.Next(6)], 1, "US", 139));
            _orderDatails.Add(new OrderDetails(1016, CustomerID[r.Next(15)], ProductName[r.Next(6)], 6, "Austria", 107));
            _orderDatails.Add(new OrderDetails(1017, CustomerID[r.Next(15)], ProductName[r.Next(6)], 9, "Italy", 135));
            _orderDatails.Add(new OrderDetails(1018, CustomerID[r.Next(15)], ProductName[r.Next(6)], 4, "Denmark", 127));
            _orderDatails.Add(new OrderDetails(1019, CustomerID[r.Next(15)], ProductName[r.Next(6)], 2, "Finland", 132));
            _orderDatails.Add(new OrderDetails(1020, CustomerID[r.Next(15)], ProductName[r.Next(6)], 3, "Argentina", 103));
            _orderDatails.Add(new OrderDetails(1021, CustomerID[r.Next(15)], ProductName[r.Next(6)], 8, "Austria", 108));
            _orderDatails.Add(new OrderDetails(1022, CustomerID[r.Next(15)], ProductName[r.Next(6)], 18, "Belgium", 113));
            _orderDatails.Add(new OrderDetails(1023, CustomerID[r.Next(15)], ProductName[r.Next(6)], 4, "Brazil", 117));
            _orderDatails.Add(new OrderDetails(1024, CustomerID[r.Next(15)], ProductName[r.Next(6)], 9, "Canada", 122));
            _orderDatails.Add(new OrderDetails(1025, CustomerID[r.Next(15)], ProductName[r.Next(6)], 10, "Denmark", 128));
            _orderDatails.Add(new OrderDetails(1026, CustomerID[r.Next(15)], ProductName[r.Next(6)], 17, "Finland", 133));
            _orderDatails.Add(new OrderDetails(1027, CustomerID[r.Next(15)], ProductName[r.Next(6)], 15, "Italy", 136));
            _orderDatails.Add(new OrderDetails(1028, CustomerID[r.Next(15)], ProductName[r.Next(6)], 13, "US", 140));
            _orderDatails.Add(new OrderDetails(1029, CustomerID[r.Next(15)], ProductName[r.Next(6)], 5, "Belgium", 114));
            _orderDatails.Add(new OrderDetails(1030, CustomerID[r.Next(15)], ProductName[r.Next(6)], 3, "Brazil", 118));
            _orderDatails.Add(new OrderDetails(1031, CustomerID[r.Next(15)], ProductName[r.Next(6)], 17, "Denmark", 129));
            _orderDatails.Add(new OrderDetails(1032, CustomerID[r.Next(15)], ProductName[r.Next(6)], 19, "Argentina", 104));
            _orderDatails.Add(new OrderDetails(1033, CustomerID[r.Next(15)], ProductName[r.Next(6)], 4, "Canada", 123));
            _orderDatails.Add(new OrderDetails(1034, CustomerID[r.Next(15)], ProductName[r.Next(6)], 12, "Finland", 133));
            _orderDatails.Add(new OrderDetails(1035, CustomerID[r.Next(15)], ProductName[r.Next(6)], 11, "US", 141));
            _orderDatails.Add(new OrderDetails(1036, CustomerID[r.Next(15)], ProductName[r.Next(6)], 7, "Austria", 109));
            _orderDatails.Add(new OrderDetails(1037, CustomerID[r.Next(15)], ProductName[r.Next(6)], 10, "Italy", 137));
            _orderDatails.Add(new OrderDetails(1038, CustomerID[r.Next(15)], ProductName[r.Next(6)], 1, "Denmark", 126));
            _orderDatails.Add(new OrderDetails(1039, CustomerID[r.Next(15)], ProductName[r.Next(6)], 13, "Finland", 132));
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
