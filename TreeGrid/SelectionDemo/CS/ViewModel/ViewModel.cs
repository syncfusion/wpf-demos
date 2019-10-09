#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SelectionDemo
{
    /// <summary>
    /// Interaction logic for EmployeeCollection class
    /// </summary>
    public class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.EmployeeInfo = this.GetEmployees();
        }

        private List<EmployeeInfo> _EmployeeInfo;
        /// <summary>
        /// Gets or sets the employee info.
        /// </summary>
        /// <value>The employee info.</value>
        public List<EmployeeInfo> EmployeeInfo
        {
            get
            {
                return _EmployeeInfo;
            }
            set
            {
                _EmployeeInfo = value;
            }
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns></returns>
        public List<EmployeeInfo> GetEmployees()
        {
            List<EmployeeInfo> model = new List<EmployeeInfo>();
            model.Add(new EmployeeInfo() { Title = "General Manager", ReportsTo = -1, ID = 2, FirstName = "Sean", LastName = "Jacobson", EmpID = 1001, Salary = 200000 });
            model.Add(new EmployeeInfo() { Title = "Accounts Manager", ReportsTo = -1, ID = 3, FirstName = "Phyllis", LastName = "Allen", EmpID = 1002, Salary = 175000 });
            model.Add(new EmployeeInfo() { Title = "Sales Manager", ReportsTo = -1, ID = 4, FirstName = "Oscar", LastName = "Alpuerto", EmpID = 1003, Salary = 150000 });
            model.Add(new EmployeeInfo() { Title = "Marketing Manager", ReportsTo = -1, ID = 5, FirstName = "Maxwell", LastName = "Amland", EmpID = 1004, Salary = 140000 });
            model.Add(new EmployeeInfo() { Title = "Human Resources Manager", ReportsTo = -1, ID = 6, FirstName = "Emiliya", LastName = "Alvaro", EmpID = 1005, Salary = 135000 });
            model.Add(new EmployeeInfo() { Title = "Advertising Manager", ReportsTo = -1, ID = 7, FirstName = "Carla", LastName = "Adams", EmpID = 1006, Salary = 125000 });
            model.Add(new EmployeeInfo() { Title = "Production Manager", ReportsTo = -1, ID = 8, FirstName = "John", LastName = "Ault", EmpID = 1007, Salary = 125000 });
            //Management

            model.Add(new EmployeeInfo() { FirstName = "Robert", LastName = "Fuller", EmpID = 1008, Salary = 1200000, Title = "Design Engineer", ID = 9, ReportsTo = 2 });
            model.Add(new EmployeeInfo() { FirstName = "Janet", LastName = "Leverling", EmpID = 1009, Salary = 1000000, Title = "Engineering Manager", ID = 10, ReportsTo = 2 });
            model.Add(new EmployeeInfo() { FirstName = "Steven", LastName = "Buchanan", EmpID = 1010, Salary = 900000, Title = "Business Manager", ID = 11, ReportsTo = 2 });

            //Accounts
            model.Add(new EmployeeInfo() { FirstName = "Nancy", LastName = "Davolio", EmpID = 1011, Salary = 850000, Title = "Accounts Supervisor", ID = 12, ReportsTo = 3 });
            model.Add(new EmployeeInfo() { FirstName = "Margaret", LastName = "Peacock", EmpID = 1012, Salary = 700000, Title = "Accounts Representative", ID = 13, ReportsTo = 3 });
            model.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Suyama", EmpID = 1013, Salary = 700000, Title = "Accounts Coordinator", ID = 14, ReportsTo = 3 });
            model.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = "King", EmpID = 1014, Salary = 650000, Title = "Accountant", ID = 15, ReportsTo = 3 });

            //Sales
            model.Add(new EmployeeInfo() { FirstName = "SIMOB", LastName = "Callahan", EmpID = 1015, Salary = 900000, Title = "Sales Representative", ID = 16, ReportsTo = 4 });
            model.Add(new EmployeeInfo() { FirstName = "Anne", LastName = "Dodsworth", EmpID = 1016, Salary = 800000, Title = "Sales Coordinator", ID = 17, ReportsTo = 4 });
            model.Add(new EmployeeInfo() { FirstName = "Albert", LastName = "Hellstern", EmpID = 1017, Salary = 750000, Title = "Sales Representative", ID = 18, ReportsTo = 4 });
            model.Add(new EmployeeInfo() { FirstName = "Seves", LastName = "Smith", EmpID = 1018, Salary = 700000, Title = "Inside Sales Coordinator", ID = 19, ReportsTo = 4 });
            model.Add(new EmployeeInfo() { FirstName = "Justin", LastName = "Brid", EmpID = 1019, Salary = 700000, Title = "Sales Supervisor", ID = 20, ReportsTo = 4 });

            //Back Office
            model.Add(new EmployeeInfo() { FirstName = "Caroline", LastName = "Patterson", EmpID = 1020, Salary = 800000, Title = "Marketing Director", ID = 21, ReportsTo = 5 });
            model.Add(new EmployeeInfo() { FirstName = "Hill", LastName = "Martin", EmpID = 1021, Salary = 700000, Title = "Marketing Associate", ID = 22, ReportsTo = 5 });

            //HR
            model.Add(new EmployeeInfo() { FirstName = "Albert", LastName = "Pereira", EmpID = 1022, Salary = 900000, Title = "HR Coordinator", ID = 23, ReportsTo = 6 });
            model.Add(new EmployeeInfo() { FirstName = "Hawkin", LastName = "Abbas", EmpID = 1023, Salary = 650000, Title = "HR Assistant", ID = 24, ReportsTo = 6 });
            model.Add(new EmployeeInfo() { FirstName = "Amy", LastName = "Alberts", EmpID = 1024, Salary = 650000, Title = "HR Assistant", ID = 25, ReportsTo = 6 });

            //Purchasing

            model.Add(new EmployeeInfo() { FirstName = "SIMOB", LastName = "Ansman-Wolfe", EmpID = 1025, Salary = 600000, Title = "Advertising Director", ID = 26, ReportsTo = 7 });
            model.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Blythe", EmpID = 1026, Salary = 550000, Title = "Advertising Coordinator", ID = 27, ReportsTo = 7 });
            model.Add(new EmployeeInfo() { FirstName = "Seves", LastName = "Campbell", EmpID = 1027, Salary = 450000, Title = "Advertising Specialist", ID = 28, ReportsTo = 7 });

            //Production
            model.Add(new EmployeeInfo() { FirstName = "Janet", LastName = "Carson", EmpID = 1028, Salary = 600000, Title = "Production Supervisor", ID = 29, ReportsTo = 8 });
            model.Add(new EmployeeInfo() { FirstName = "Caroline", LastName = "Ito", EmpID = 1029, Salary = 550000, Title = "Production Technician", ID = 30, ReportsTo = 8 });
            model.Add(new EmployeeInfo() { FirstName = "Steven", LastName = "Jiang", EmpID = 1030, Salary = 450000, Title = "Production Control Manager", ID = 31, ReportsTo = 8 });


            return model;
        }
    }
}
