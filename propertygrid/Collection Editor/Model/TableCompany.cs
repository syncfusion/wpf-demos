#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace syncfusion.propertygriddemos.wpf
{
    public class TableCompany
    {
        [Display(Description ="Name of the Company")]
        public string CompanyName { get; set; }

        [Display(Description = "ID of the Company")]
        public int CompanyID { get; set; }

        [Browsable(false)]
        public DateTime CompanyStartedDate { get; set; }

        [Display(Description = "Company's product name")]
        public string ProductName { get; set; }

        [Bindable(false)]
        public string OwnerName { get; set; }

        [Display(Description = "Company's customer list")]
        public List<CollectionCustomerDetails> Customers { get; set; }

        public string EmailID { get; set; }

        [Browsable(false)]
        public long NetIncome { get; set; }

        [Display(Description = "Company's goods delivery agent list")]
        public ObservableCollection<DeliveryAgent> DeliveryAgents { get; set; }

        public long EmployeeCount { get; set; }

        [Bindable(false)]
        public Bank Bank { get; set; }     

        
        private List<Employee> employees;

        [Description ("Employee list of the Company (cannot be editable)")]
        [Display( Name ="Employees(ReadOnly)")]
        //Readonly collection type property
        public ReadOnlyCollection<Employee> Employees {
            get
            {
                return employees.AsReadOnly();
            }
        }             

        public Address Address { get; set; }

        public TableCompany()
        {
            employees = new List<Employee>()
            {
                new Employee()
                { 
                    ID = 0, 
                    Name = "John", 
                    Phone = "2065349857",
                    Address= new Address(){
                        DoorNo=10, 
                        State="New Yark", 
                        StreetName="Michael Street"}},
                new Employee() 
                { 
                    ID = 1, 
                    Name = "Peter", 
                    Phone = "2065981189" ,
                    Address= new Address(){
                        DoorNo=23, 
                        State="New Yark", 
                        StreetName="Michael Street"}},
            };            
        }
    }
}
