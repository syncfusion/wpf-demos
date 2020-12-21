#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace syncfusion.gridcontroldemos.wpf
{
    public class Order
    {
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public string EmployeeID { get; set; }
        public string OrderDate { get; set; }
        public string RequiredDate { get; set; }
        public string ShippedDate { get; set; }
        public string ShipVia { get; set; }
        public string Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public Order()
        {
        }

        public static string GetPropertyName(int index)
        {
            switch (index)
            {
                case 1:
                    return "OrderID";
                case 2:
                    return "CustomerID";
                case 3:
                    return "EmployeeID";
                case 4:
                    return "OrderDate";
                case 5:
                    return "RequiredDate";
                case 6:
                    return "ShippedDate";
                case 7:
                    return "ShipVia";
                case 8:
                    return "Freight";
                case 9:
                    return "ShipName";
                case 10:
                    return "ShipAddress";
                case 11:
                    return "ShipCity";
                case 12:
                    return "ShipRegion";
                case 13:
                    return "ShipPostalCode";
                case 14:
                    return "ShipCountry";
                default:
                    return string.Empty;
            }
        }

        public string this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1:
                        return OrderID;
                    case 2:
                        return CustomerID;
                    case 3:
                        return EmployeeID;
                    case 4:
                        return OrderDate;
                    case 5:
                        return RequiredDate;
                    case 6:
                        return ShippedDate;
                    case 7:
                        return ShipVia;
                    case 8:
                        return Freight;
                    case 9:
                        return ShipName;
                    case 10:
                        return ShipAddress;
                    case 11:
                        return ShipCity;
                    case 12:
                        return ShipRegion;
                    case 13:
                        return ShipPostalCode;
                    case 14:
                        return ShipCountry;
                    default:
                        return string.Empty;
                }
            }
            set
            {
                switch (index)
                {
                    case 1:
                        OrderID = value;
                        break;
                    case 2:
                        CustomerID = value;
                        break;
                    case 3:
                        EmployeeID = value;
                        break;
                    case 4:
                        OrderDate = value;
                        break;
                    case 5:
                        RequiredDate = value;
                        break;
                    case 6:
                        ShippedDate = value;
                        break;
                    case 7:
                        ShipVia = value;
                        break;
                    case 8:
                        Freight = value;
                        break;
                    case 9:
                        ShipName = value;
                        break;
                    case 10:
                        ShipAddress = value;
                        break;
                    case 11:
                        ShipCity = value;
                        break;
                    case 12:
                        ShipRegion = value;
                        break;
                    case 13:
                        ShipPostalCode = value;
                        break;
                    case 14:
                        ShipCountry = value;
                        break;
                }
            }
        }
    }

    public class Orders1
    {
        public static List<Order> LoadOrders()
        {
            List<Order> orders = new List<Order>();
            XDocument xdoc = XDocument.Load(@"Data\GridControl\Orders.xml");
            foreach (XElement currentElement in xdoc.Root.Elements("Orders"))
            {
                Order o = new Order();
                if (currentElement.Element("OrderID") != null)
                    o.OrderID = currentElement.Element("OrderID").Value;
                if (currentElement.Element("CustomerID") != null)
                    o.CustomerID = currentElement.Element("CustomerID").Value;
                if (currentElement.Element("EmployeeID") != null)
                    o.EmployeeID = currentElement.Element("EmployeeID").Value;
                if (currentElement.Element("OrderDate") != null)
                    o.OrderDate = currentElement.Element("OrderDate").Value;
                if (currentElement.Element("RequiredDate") != null)
                    o.RequiredDate = currentElement.Element("RequiredDate").Value;
                if (currentElement.Element("ShippedDate") != null)
                    o.ShippedDate = currentElement.Element("ShippedDate").Value;
                if (currentElement.Element("ShipVia") != null)
                    o.ShipVia = currentElement.Element("ShipVia").Value;
                if (currentElement.Element("Freight") != null)
                    o.Freight = currentElement.Element("Freight").Value;
                if (currentElement.Element("ShipName") != null)
                    o.ShipName = currentElement.Element("ShipName").Value;
                if (currentElement.Element("ShipAddress") != null)
                    o.ShipAddress = currentElement.Element("ShipAddress").Value;
                if (currentElement.Element("ShipCity") != null)
                    o.ShipCity = currentElement.Element("ShipCity").Value;
                if (currentElement.Element("ShipRegion") != null)
                    o.ShipRegion = currentElement.Element("ShipRegion").Value;
                if (currentElement.Element("ShipPostalCode") != null)
                    o.ShipPostalCode = currentElement.Element("ShipPostalCode").Value;
                if (currentElement.Element("ShipCountry") != null)
                    o.ShipCountry = currentElement.Element("ShipCountry").Value;
                orders.Add(o);
            }
            return orders;
        }
    }

}
