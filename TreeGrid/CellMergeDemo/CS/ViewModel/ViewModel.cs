#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merging
{
    public class EmployeeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        public EmployeeRepository()
        {
        }

        public static List<Employee> GetEmployees()
        {
            List<Employee> model = new List<Employee>();
            model.Add(new Employee() { Title = "  Management", ReportsTo = -1, Id = 2 });
            model.Add(new Employee() { Title = "  Accounts", ReportsTo = -1, Id = 3 });
            model.Add(new Employee() { Title = "  Sales", ReportsTo = -1, Id = 4 });
            model.Add(new Employee() { Title = "  Back Office", ReportsTo = -1, Id = 5 });
            model.Add(new Employee() { Title = "  Human Resource", ReportsTo = -1, Id = 6 });
            model.Add(new Employee() { Title = "  Purchasing", ReportsTo = -1, Id = 7 });
            model.Add(new Employee() { Title = "  Production", ReportsTo = -1, Id = 8 });

            //Management
            model.Add(new Employee() { FirstName = "Andrew", LastName = "Fuller", Hike = "10.00%", Department = "Management", EmpId = 1001, Id = 9, DOJ = "01-09-1937", Rating = 5, Salary = 1200000, ReportsTo = 2, Title = "Vice President" });
            model.Add(new Employee() { FirstName = "Janet", LastName = "Leverling", Hike = "8.00%", Department = "Management", EmpId = 1002, Id = 10, DOJ = "05-07-1939", Rating = 4, Salary = 1000000, ReportsTo = 2, Title = "GM" });
            model.Add(new Employee() { FirstName = "Steven", LastName = "Buchanan", Hike = "7.00%", Department = "Management", EmpId = 1003, Id = 11, DOJ = "02-05-1940", Rating = 4, Salary = 900000, ReportsTo = 2, Title = "Manager" });

            //Accounts
            model.Add(new Employee() { FirstName = "Nancy", LastName = "Davolio", Hike = "7.20%", Department = "Accounts", EmpId = 1004, Id = 12, DOJ = "02-05-1940", Rating = 5, Salary = 850000, ReportsTo = 3, Title = "Accounts Manager" });
            model.Add(new Employee() { FirstName = "Margaret", LastName = "Peacock", Hike = "6.90%", Department = "Accounts", EmpId = 1008, Id = 13, DOJ = "01-09-1945", Rating = 3, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
            model.Add(new Employee() { FirstName = "Michael", LastName = "Suyama", Hike = "6.90%", Department = "Accounts", EmpId = 1009, Id = 14, DOJ = "02-09-1945", Rating = 5, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
            model.Add(new Employee() { FirstName = "Robert", LastName = "King", Hike = "5.70%", Department = "Accounts", EmpId = 1010, Id = 15, DOJ = "02-09-1945", Rating = 3, Salary = 650000, ReportsTo = 3, Title = "Accountant" });

            //Sales
            model.Add(new Employee() { FirstName = "Laura", LastName = "Callahan", Hike = "8.20%", Department = "Sales", EmpId = 1005, Id = 16, DOJ = "07-01-1942", Rating = 5, Salary = 900000, ReportsTo = 4, Title = "Sales Manager" });
            model.Add(new Employee() { FirstName = "Anne", LastName = "Dodsworth", Hike = "8.00%", Department = "Sales", EmpId = 1011, Id = 17, DOJ = "02-10-1945", Rating = 4, Salary = 800000, ReportsTo = 4, Title = "Sales Representative" });
            model.Add(new Employee() { FirstName = "Albert", LastName = "Hellstern", Hike = "6.90%", Department = "Sales", EmpId = 1012, Id = 18, DOJ = "02-10-1945", Rating = 5, Salary = 750000, ReportsTo = 4, Title = "Sales Representative" });
            model.Add(new Employee() { FirstName = "Tim", LastName = "Smith", Hike = "5.23%", Department = "Sales", EmpId = 1013, Id = 19, DOJ = "03-11-1945", Rating = 5, Salary = 700000, ReportsTo = 4, Title = "Sales Representative" });
            model.Add(new Employee() { FirstName = "Justin", LastName = "BrId",  Hike = "6.00%", Department = "Sales", EmpId = 1014, Id = 20, DOJ = "03-11-1945", Rating = 5, Salary = 700000, ReportsTo = 4, Title = "Sales Representative" });

            //Back Office
            model.Add(new Employee() { FirstName = "Caroline", LastName = "Patterson", Hike = "6.00%", Department = "BackOffice", EmpId = 1006, Id = 21, DOJ = "07-01-1942", Rating = 5, Salary = 800000, ReportsTo = 5, Title = "Receptionist" });
            model.Add(new Employee() { FirstName = "Xavier", LastName = "Martin", Hike = "3.00%", Department = "BackOffice", EmpId = 1015, Id = 22, DOJ = "01-09-1946", Rating = 5, Salary = 700000, ReportsTo = 5, Title = "Mail Clerk" });

            //HR
            model.Add(new Employee() { FirstName = "Laurent", LastName = "Pereira", Hike = "6.60%", Department = "HumanResource", EmpId = 1007, Id = 23, DOJ = "01-09-1942", Rating = 5, Salary = 900000, ReportsTo = 6, Title = "HR Manager" });
            model.Add(new Employee() { FirstName = "Syed", LastName = "Abbas", Hike = "6.20%", Department = "HumanResource", EmpId = 1016, Id = 24, DOJ = "04-02-1947", Rating = 5, Salary = 650000, ReportsTo = 6, Title = "HR Assistant" });
            model.Add(new Employee() { FirstName = "Amy", LastName = "Alberts", Hike = "6.00%", Department = "HumanResource", EmpId = 1017, Id = 25, DOJ = "04-02-1947", Rating = 5, Salary = 650000, ReportsTo = 6, Title = "HR Assistant" });

            //Purchasing

            model.Add(new Employee() { FirstName = "Pamela", LastName = "Ansman-Wolfe", Hike = "7.60%", Department = "Purchasing", EmpId = 1018, Id = 26, DOJ = "04-02-1947", Rating = 3, Salary = 600000, ReportsTo = 7, Title = "Purchase Manager" });
            model.Add(new Employee() { FirstName = "Michael", LastName = "Blythe", Hike = "6.02%", Department = "Purchasing", EmpId = 1019, Id = 27, DOJ = "04-02-1947", Rating = 2, Salary = 550000, ReportsTo = 7, Title = "Store Keeper" });
            model.Add(new Employee() { FirstName = "DavId", LastName = "Campbell", Hike = "6.00%", Department = "Purchasing", EmpId = 1020, Id = 28, DOJ = "05-08-1949", Rating = 3, Salary = 450000, ReportsTo = 7, Title = "Store Keeper" });

            //Production
            model.Add(new Employee() { FirstName = "Jillian", LastName = "Carson", Hike = "5.00%", Department = "Production", EmpId = 1021, Id = 29, DOJ = "05-08-1949", Rating = 3, Salary = 600000, ReportsTo = 8, Title = "Production Manager" });
            model.Add(new Employee() { FirstName = "Shu", LastName = "Ito", Hike = "6.20%", Department = "Production", EmpId = 1022, Id = 30, DOJ = "06-01-1952", Rating = 2, Salary = 550000, ReportsTo = 8, Title = "Production Engineer" });
            model.Add(new Employee() { FirstName = "Stephen", LastName = "Jiang", Hike = "6.00%", Department = "Production", EmpId = 1023, Id = 31, DOJ = "06-01-1952", Rating = 3, Salary = 450000, ReportsTo = 8, Title = "Production Engineer" });


            return model;
        }
      
        #region Array Collection

        private static string[] names1 = new string[]{
            "George","John","Thomas","James","Andrew","Martin","William","Zachary",
            "Millard","Franklin","Abraham","Ulysses","Rutherford","Chester","Grover","Benjamin",
            "Theodore","Woodrow","Warren","Calvin","Herbert","Franklin","Harry","Dwight","Lyndon",
            "Richard","Gerald","Jimmy","Ronald","George","Bill", "Barack", "Warner","Peter", "Larry"
        };
        private static string[] names2 = new string[]{
             "Washington","Adams","Jefferson","Madison","Monroe","Jackson","Van Buren","Harrison","Tyler",
             "Polk","Taylor","Fillmore","Pierce","Buchanan","Lincoln","Johnson","Grant","Hayes","Garfield",
             "Arthur","Cleveland","Harrison","McKinley","Roosevelt","Taft","Wilson","Harding","Coolidge",
             "Hoover","Truman","Eisenhower","Kennedy","Johnson","Nixon","Ford","Carter","Reagan","Bush",
             "Clinton","Bush","Obama","Smith","Jones","Stogner"
        };

        private static double[] hike = new double[]{
            6,5.5,10,10.2,11, 15, 6.8,14,7.7,9.5,8.2,16
        };
        #endregion
    }
}
