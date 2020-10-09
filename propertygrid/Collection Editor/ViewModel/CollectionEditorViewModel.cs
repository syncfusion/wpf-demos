#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace syncfusion.propertygriddemos.wpf
{
    public class CollectionEditorViewModel
    {
        public EmployeeDetails Employee { get; set; }
        public CollectionEditorViewModel()
        {
            Employee = new EmployeeDetails();
            Employee.FirstName = "Carl";
            Employee.LastName = "Johnson";
            Employee.Age = 30;
            Employee.Mobile = "(205) 444-9786";
            Employee.Email = "carljohnson@gta.com";
            Employee.ID = "0005A";
            Employee.Designation = "Team Lead";
            Employee.Customers = new List<CollectionCustomerDetails>()
            {
                new CollectionCustomerDetails()
                {
                    CustomerID = "ALFKI",
                    EmployeeID = "0001A",
                    CompanyName = "Alfreds Futterkiste",
                    ContactName = "Maria Anders",
                    Country = "Germany",
                   Orders = new ObservableCollection<OrderDetails>()
                   {
                       new OrderDetails()
                       {
                          OrderID = "10835",
                          CustomerID = "ALFKI" ,
                          OrderDate = new DateTime(2020, 1, 15),
                          ShippedDate = new DateTime(2020, 1, 21),
                          RequiredDate = new DateTime(2020, 2, 12),
                       },
                       new OrderDetails()
                       {
                          OrderID = "10952",
                          CustomerID = "ALFKI" ,
                          OrderDate = new DateTime(2020, 3, 16),
                          ShippedDate = new DateTime(2020, 3, 24),
                          RequiredDate = new DateTime(2020, 4, 27),
                       }
                   }
                },
                new CollectionCustomerDetails()
                {
                    CustomerID = "AROUT",
                    EmployeeID = "0001B",
                    CompanyName = "Around the Horn",
                    ContactName = "Thomas Hardy",
                    Country = "UK",
                   Orders = new ObservableCollection<OrderDetails>()
                   {
                       new OrderDetails()
                       {
                          OrderID = "10453",
                          CustomerID = "AROUT" ,
                          OrderDate = new DateTime(2020, 2, 17),
                          ShippedDate = new DateTime(2020, 2, 17),
                          RequiredDate = new DateTime(2020, 3, 17),
                       },
                       new OrderDetails()
                       {
                          OrderID = "10558",
                          CustomerID = "AROUT" ,
                          OrderDate = new DateTime(2020, 3, 21),
                          ShippedDate = new DateTime(2020, 3, 28),
                          RequiredDate = new DateTime(2020, 4, 2),
                       },
                        new OrderDetails()
                       {
                          OrderID = "10743",
                          CustomerID = "AROUT" ,
                          OrderDate = new DateTime(2020, 4, 17),
                          ShippedDate = new DateTime(2020, 4, 21),
                          RequiredDate = new DateTime(2020, 5, 5),
                       }
                   }
                }
            };
        }
    }
}
