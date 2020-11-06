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
using System.Linq;
using System.Text;

namespace syncfusion.datagriddemos.wpf
{
    public class EmployeeViewModel
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeViewModel"/> class.
        /// </summary>
        public EmployeeViewModel()
        {
            EmployeeDetails = GetEmployeeDetails(50);

            Status = new List<string>();
            Status.Add("Active");
            Status.Add("Inactive");

            Trustworthiness = new List<string>();
            Trustworthiness.Add("Sufficient");
            Trustworthiness.Add("Insufficient");
            Trustworthiness.Add("Perfect");

            this._employeesCollection = PopulateEmployeeDetails();
        }

        #endregion

        #region Properties

        private ObservableCollection<Employee> _EmployeeDetails;

        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        /// <value>The employee details.</value>
        public ObservableCollection<Employee> EmployeeDetails
        {
            get { return _EmployeeDetails; }
            set { _EmployeeDetails = value; }
        }

        private ObservableCollection<Employee> _employeesCollection = new ObservableCollection<Employee>();

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public ObservableCollection<Employee> EmployeesCollection
        {
            get { return _employeesCollection; }
            set { _employeesCollection = value; }
        }

        public List<string> Status { get; set; }

        public List<string> Trustworthiness { get; set; }

        #endregion

        #region Method
        public ObservableCollection<Employee> GetEmployeeDetails(int count)
        {
            Random random = new Random();
            ObservableCollection<Employee> ordersDetails = new ObservableCollection<Employee>();

            for (int i = 10000; i < count + 10000; i++)
            {
                var name = employees[random.Next(25)];
                int index = Array.IndexOf(employees, name);
                string gender = genders[index];
                ordersDetails.Add(new Employee(i % 2 == -1, name, designation[random.Next(6)], name.ToLower() + "@" + mail[random.Next(4)], location[random.Next(8)], trust[random.Next(3)], random.Next(1, 5), status[random.Next(2)], random.Next(40, 100), random.Next(100000, 400000), address[random.Next(1, 25)], gender));
            }

            return ordersDetails;
        }

        private ObservableCollection<Employee> PopulateEmployeeDetails()
        {
            Random r = new Random();

            this._employeesCollection.Add(new Employee() { EmployeeID = 1001, EmployeeName = "Mark", EmployeeAge = r.Next(20, 50), Location = area[r.Next(area.Count() - 1)], EmployeeStatus = false, Designation = "Product Manager", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 23.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1002, EmployeeName = "Peter", EmployeeAge = 21, Location = "UK", EmployeeStatus = true, Designation = "Junior Architect", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 23.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1002, EmployeeName = "Peter", EmployeeAge = 12, Location = "UK", EmployeeStatus = true, Designation = "Junior Architect", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 23.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1003, EmployeeName = "James", EmployeeAge = 20, Location = "UAE", EmployeeStatus = false, Designation = "Team Lead", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 23.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1004, EmployeeName = "Oliver", EmployeeAge = 20, Location = "USA", EmployeeStatus = true, Designation = "Genreral Manager", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 23.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1005, EmployeeName = "Robert", EmployeeAge = 22, Location = "India", EmployeeStatus = true, Designation = "Sales Engineer", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 23.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1006, EmployeeName = "Suji", EmployeeAge = 23, Location = "UK", EmployeeStatus = false, Designation = "Senior Architect", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 23.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1007, EmployeeName = "Mahesh", EmployeeAge = 22, Location = "UK", EmployeeStatus = true, Designation = "Test Engineer", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 23.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1008, EmployeeName = "Ruby", EmployeeAge = 22, Location = "UK", EmployeeStatus = true, Designation = "Co-Ordinator", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 23.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1009, EmployeeName = "Christain", EmployeeAge = 21, Location = "India", EmployeeStatus = false, Designation = "Human Resource", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 23.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1010, EmployeeName = "Aravind", EmployeeAge = 20, Location = "India", EmployeeStatus = true, Designation = "Senior Architect", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 22.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1011, EmployeeName = "Daniel", EmployeeAge = 22, Location = "USA", EmployeeStatus = false, Designation = "Product Manager", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 22.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1012, EmployeeName = "Suhitha Azar", EmployeeAge = 21, Location = "UK", EmployeeStatus = true, Designation = "Junior Architect", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 22.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1013, EmployeeName = "Praveen", EmployeeAge = 20, Location = "UAE", EmployeeStatus = false, Designation = "Team Lead", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 22.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1014, EmployeeName = "Stephen", EmployeeAge = 20, Location = "USA", EmployeeStatus = true, Designation = "Genreral Manager", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 22.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1015, EmployeeName = "Asha Joseph", EmployeeAge = 22, Location = "India", EmployeeStatus = true, Designation = "Sales Engineer", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 22.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1016, EmployeeName = "Clarke", EmployeeAge = 23, Location = "UK", EmployeeStatus = false, Designation = "Representative", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 22.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1017, EmployeeName = "Dhileep Venkatesh", EmployeeAge = 22, Location = "UK", EmployeeStatus = true, Designation = "Test Engineer", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 22.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1018, EmployeeName = "Mary Alexender", EmployeeAge = 22, Location = "UK", EmployeeStatus = true, Designation = "Co-Ordinator", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 22.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1019, EmployeeName = "Bob Gally", EmployeeAge = 21, Location = "India", EmployeeStatus = false, Designation = "Human Resource", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 22.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1020, EmployeeName = "Amy Christain", EmployeeAge = 20, Location = "India", EmployeeStatus = true, Designation = "Senior Architect ", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 22.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1021, EmployeeName = "Hema", EmployeeAge = 22, Location = "USA", EmployeeStatus = false, Designation = "Product Manager", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 20.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1022, EmployeeName = "Julie Albert", EmployeeAge = 21, Location = "UK", EmployeeStatus = true, Designation = "Junior Architect", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 20.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1023, EmployeeName = "Mahendra Gupta", EmployeeAge = 20, Location = "UAE", EmployeeStatus = false, Designation = "Team Lead", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 20.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1024, EmployeeName = "Ben Thompson", EmployeeAge = 20, Location = "USA", EmployeeStatus = true, Designation = "Genreral Manager", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Male", Percent = 20.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1025, EmployeeName = "Sindhya", EmployeeAge = 20, Location = "India", EmployeeStatus = true, Designation = "Senior Architect ", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 20.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1026, EmployeeName = "Sindhya", EmployeeAge = 20, Location = "India", EmployeeStatus = true, Designation = "Senior Architect ", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 20.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1027, EmployeeName = "Sindhya", EmployeeAge = 20, Location = "India", EmployeeStatus = true, Designation = "Senior Architect ", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 20.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1028, EmployeeName = "Sindhya", EmployeeAge = 20, Location = "India", EmployeeStatus = true, Designation = "Senior Architect ", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 20.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1029, EmployeeName = "Sindhya", EmployeeAge = 20, Location = "India", EmployeeStatus = true, Designation = "Senior Architect ", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 20.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1030, EmployeeName = "Sindhya", EmployeeAge = 20, Location = "India", EmployeeStatus = true, Designation = "Senior Architect ", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 20.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1031, EmployeeName = "Sindhya", EmployeeAge = 20, Location = "India", EmployeeStatus = true, Designation = "Senior Architect ", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 16.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1032, EmployeeName = "Sindhya", EmployeeAge = 20, Location = "India", EmployeeStatus = true, Designation = "Senior Architect ", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 16.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1033, EmployeeName = "Sindhya", EmployeeAge = 20, Location = "India", EmployeeStatus = true, Designation = "Senior Architect ", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 16.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1034, EmployeeName = "Sindhya", EmployeeAge = 20, Location = "India", EmployeeStatus = true, Designation = "Senior Architect ", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 16.15 });
            this._employeesCollection.Add(new Employee() { EmployeeID = 1035, EmployeeName = "Sindhya", EmployeeAge = 20, Location = "India", EmployeeStatus = true, Designation = "Senior Architect ", Salary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, Gender = "Female", Percent = 16.15 });

            return _employeesCollection;
        }



        #endregion

        #region Collections

        string[] area = new string[] { "USA", "India", "UK", "UAE" };

        string[] employees = { "Michael", "Kathryn", "Tamer", "Martin", "Davolio", "Nancy", "Fuller", "Leverling", "Therasa",
        "Margaret", "Buchanan", "Janet", "Andrew", "Callahan", "Laura", "Dodsworth", "Anne",
        "Bergs", "Vinet", "Anto", "Fleet", "Zachery", "Van", "Edward", "Jack", "Rose"};

        string[] genders = { "1", "2", "1", "1", "2", "2", "1", "2", "2", "2", "1", "2", "1", "1", "2", "1", "2", "1", "1", "1", "1", "1", "1", "1", "1", "2" };

        string[] designation = { "Manager", "CFO", "Designer", "Developer", "Program Directory", "System Analyst", "Project Lead" };

        string[] mail = { "arpy.com", "sample.com", "rpy.com", "jourrapide.com" };
        string[] trust = { "Sufficient", "Perfect", "Insufficient" };
        string[] status = { "Active", "Inactive" };
        string[] location = { "UK", "USA", "Sweden", "France", "Canada", "Argentina", "Austria", "Germany", "Mexico" };

        string[] address = {"59 rue de lAbbaye", "Luisenstr. 48"," Rua do Paço 67", "2 rue du Commerce", "Boulevard Tirou 255",
        "Rua do mailPaço 67", "Hauptstr. 31", "Starenweg 5", "Rua do Mercado, 12",
        "Carrera 22 con Ave."," Carlos Soublette #8-35", "Kirchgasse 6",
        "Sierras de Granada 9993", "Mehrheimerstr. 369", "Rua da Panificadora 12", "2817 Milton Dr.", "Kirchgasse 6",
        "Åkergatan 24", "24, place Kléber", "Torikatu 38", "Berliner Platz 43", "5ª Ave. Los Palos Grandes", "1029 - 12th Ave. S.",
        "Torikatu 38", "P.O. Box 555", "2817 Milton Dr.", "Taucherstraße 10", "59 rue de lAbbaye", "Via Ludovico il Moro 22",
        "Avda. Azteca 123", "Heerstr. 22", "Berguvsvägen  8", "Magazinweg 7", "Berguvsvägen  8", "Gran Vía, 1", "Gran Vía, 1",
        "Carrera 52 con Ave. Bolívar #65-98 Llano Largo", "Magazinweg 7", "Taucherstraße 10", "Taucherstraße 10"};

        #endregion
    }
}
