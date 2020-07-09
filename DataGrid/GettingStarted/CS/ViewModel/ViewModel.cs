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

namespace GettingStarted
{
    public class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            EmployeeDetails = new EmployeeRepository().GetEmployeeDetails(50);

            Status = new List<string>();
            Status.Add("Active");
            Status.Add("Inactive");

            Trustworthiness = new List<string>();
            Trustworthiness.Add("Sufficient");
            Trustworthiness.Add("Insufficient");
            Trustworthiness.Add("Perfect");
        }

        private ObservableCollection<Employee> _EmployeeDetails;

        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public ObservableCollection<Employee> EmployeeDetails
        {
            get { return _EmployeeDetails; }
            set { _EmployeeDetails = value; }
        }

        public List<string> Status { get; set; }

        public List<string> Trustworthiness { get; set; }
    }

    public class EmployeeRepository
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        public EmployeeRepository()
        {
        }

        /// <summary>
        /// Gets the Employee details.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public ObservableCollection<Employee> GetEmployeeDetails(int count)
        {
            string[] employees = { "Michael", "Kathryn", "Tamer", "Martin", "Davolio", "Nancy", "Fuller", "Leverling", "Therasa",
        "Margaret", "Buchanan", "Janet", "Andrew", "Callahan", "Laura", "Dodsworth", "Anne",
        "Bergs", "Vinet", "Anto", "Fleet", "Zachery", "Van", "Edward", "Jack", "Rose"};
            string[] genders = { "1", "2", "1", "1", "2", "2", "1", "2", "2", "2", "1", "2", "1", "1", "2", "1", "2", "1", "1", "1", "1", "1", "1", "1", "1", "2" };

            string[] designation = { "Manager", "CFO", "Designer", "Developer", "Program Directory", "System Analyst", "Project Lead" };

            string[] mail = { "arpy.com", "sample.com", "rpy.com", "jourrapide.com" };
            string[] trust = { "Sufficient", "Perfect", "Insufficient" };
            string[] status = { "Active", "Inactive" };
            string[] location = { "UK", "USA", "Sweden", "France", "Canada", "Argentina", "Austria", "Germany", "Mexico" };

            string[] address = { "59 rue de lAbbaye", "Luisenstr. 48"," Rua do Paço 67", "2 rue du Commerce", "Boulevard Tirou 255",
        "Rua do mailPaço 67", "Hauptstr. 31", "Starenweg 5", "Rua do Mercado, 12",
        "Carrera 22 con Ave."," Carlos Soublette #8-35", "Kirchgasse 6",
        "Sierras de Granada 9993", "Mehrheimerstr. 369", "Rua da Panificadora 12", "2817 Milton Dr.", "Kirchgasse 6",
        "Åkergatan 24", "24, place Kléber", "Torikatu 38", "Berliner Platz 43", "5ª Ave. Los Palos Grandes", "1029 - 12th Ave. S.",
        "Torikatu 38", "P.O. Box 555", "2817 Milton Dr.", "Taucherstraße 10", "59 rue de lAbbaye", "Via Ludovico il Moro 22",
        "Avda. Azteca 123", "Heerstr. 22", "Berguvsvägen  8", "Magazinweg 7", "Berguvsvägen  8", "Gran Vía, 1", "Gran Vía, 1",
        "Carrera 52 con Ave. Bolívar #65-98 Llano Largo", "Magazinweg 7", "Taucherstraße 10", "Taucherstraße 10"};


            Random random = new Random();
            ObservableCollection<Employee> ordersDetails = new ObservableCollection<Employee>();

            for (int i = 10000; i < count + 10000; i++)
            {
                var name = employees[random.Next(25)];
                int index = Array.IndexOf(employees, name);
                string gender = genders[index];
                ordersDetails.Add(new Employee(i % 2 == -1, name, designation[random.Next(6)], name.ToLower() + "@" + mail[random.Next(4)], location[random.Next(8)], trust[random.Next(3)],random.Next(1,5), status[random.Next(2)], random.Next(1, 100), random.Next(100000, 400000), address[random.Next(1, 25)], gender));
            }

            return ordersDetails;
        }
    }
}
