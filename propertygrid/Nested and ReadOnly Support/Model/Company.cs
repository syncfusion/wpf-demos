#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PropertyGrid;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.RightsManagement;

namespace syncfusion.propertygriddemos.wpf
{
    public class Company
    {
        [ReadOnly(true)]
        [Display(Description = "Name of the Company")]
        public string CompanyName { get; set; }

        [Editable(false)]
        [Display(Description = "ID of the Company")]
        public int CompanyID { get; set; }

        [ReadOnly(true)]
        [Display(Description = "Company's product name")]
        public string ProductName { get; set; }

        [Display(Description = "Bank in which Company has account")]
        public Bank Bank { get; set; }
        
        private List<Employee> employees;

        //Readonly collection type property
        [Description("Employee list of the Company (cannot be editable)")]
        public ReadOnlyCollection<Employee> Employees {
            get
            {
                return employees.AsReadOnly();
            }
        }

        [Display(Description = "Company's customer list")]
        public List<CollectionCustomerDetails> Customers { get; set; }

        [Display(Description = "Address where the company located")]
        public Address Address { get; set; }

        public Company()
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
