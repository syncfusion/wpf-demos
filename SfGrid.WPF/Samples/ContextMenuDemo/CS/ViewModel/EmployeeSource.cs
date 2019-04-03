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
using System.Linq;
using System.Text;

namespace ContextMenuDemo
{
    public class EmployeeSource : ObservableCollection<BusinessObjects>
    {
        string[] area = new string[] { "USA", "India", "UK", "UAE" };

        public EmployeeSource()
        {
            this.Clear();
            Random r = new Random();

            BusinessObjects b = new BusinessObjects() { EmployeeId = 1001, EmployeeName = "Mark", EmployeeAge = r.Next(20, 50), EmployeeArea = area[r.Next(area.Count() - 1)], EmployeeStatus = false, EmployeeDesignation = "Product Manager", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 23.15 };
            this.Add(b);


            b = new BusinessObjects() { EmployeeId = 1002, EmployeeName = "Peter", EmployeeAge = 21, EmployeeArea = "UK", EmployeeStatus = true, EmployeeDesignation = "Junior Architect", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 23.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1002, EmployeeName = "Peter", EmployeeAge = 12, EmployeeArea = "UK", EmployeeStatus = true, EmployeeDesignation = "Junior Architect", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 23.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1003, EmployeeName = "James", EmployeeAge = 20, EmployeeArea = "UAE", EmployeeStatus = false, EmployeeDesignation = "Team Lead", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 23.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1004, EmployeeName = "Oliver", EmployeeAge = 20, EmployeeArea = "USA", EmployeeStatus = true, EmployeeDesignation = "Genreral Manager", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 23.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1005, EmployeeName = "Robert", EmployeeAge = 22, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Sales Engineer", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 23.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1006, EmployeeName = "Suji", EmployeeAge = 23, EmployeeArea = "UK", EmployeeStatus = false, EmployeeDesignation = "Senior Architect", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 23.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1007, EmployeeName = "Mahesh", EmployeeAge = 22, EmployeeArea = "UK", EmployeeStatus = true, EmployeeDesignation = "Test Engineer", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 23.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1008, EmployeeName = "Ruby", EmployeeAge = 22, EmployeeArea = "UK", EmployeeStatus = true, EmployeeDesignation = "Co-Ordinator", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 23.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1009, EmployeeName = "Christain", EmployeeAge = 21, EmployeeArea = "India", EmployeeStatus = false, EmployeeDesignation = "Human Resource", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 23.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1010, EmployeeName = "Aravind", EmployeeAge = 20, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Senior Architect", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 22.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1011, EmployeeName = "Daniel", EmployeeAge = 22, EmployeeArea = "USA", EmployeeStatus = false, EmployeeDesignation = "Product Manager", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 22.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1012, EmployeeName = "Suhitha Azar", EmployeeAge = 21, EmployeeArea = "UK", EmployeeStatus = true, EmployeeDesignation = "Junior Architect", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 22.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1013, EmployeeName = "Praveen", EmployeeAge = 20, EmployeeArea = "UAE", EmployeeStatus = false, EmployeeDesignation = "Team Lead", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 22.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1014, EmployeeName = "Stephen", EmployeeAge = 20, EmployeeArea = "USA", EmployeeStatus = true, EmployeeDesignation = "Genreral Manager", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 22.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1015, EmployeeName = "Asha Joseph", EmployeeAge = 22, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Sales Engineer", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 22.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1016, EmployeeName = "Clarke", EmployeeAge = 23, EmployeeArea = "UK", EmployeeStatus = false, EmployeeDesignation = "Representative", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 22.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1017, EmployeeName = "Dhileep Venkatesh", EmployeeAge = 22, EmployeeArea = "UK", EmployeeStatus = true, EmployeeDesignation = "Test Engineer", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 22.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1018, EmployeeName = "Mary Alexender", EmployeeAge = 22, EmployeeArea = "UK", EmployeeStatus = true, EmployeeDesignation = "Co-Ordinator", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 22.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1019, EmployeeName = "Bob Gally", EmployeeAge = 21, EmployeeArea = "India", EmployeeStatus = false, EmployeeDesignation = "Human Resource", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 22.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1020, EmployeeName = "Amy Christain", EmployeeAge = 20, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Senior Architect ", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 22.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1021, EmployeeName = "Hema", EmployeeAge = 22, EmployeeArea = "USA", EmployeeStatus = false, EmployeeDesignation = "Product Manager", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 20.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1022, EmployeeName = "Julie Albert", EmployeeAge = 21, EmployeeArea = "UK", EmployeeStatus = true, EmployeeDesignation = "Junior Architect", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 20.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1023, EmployeeName = "Mahendra Gupta", EmployeeAge = 20, EmployeeArea = "UAE", EmployeeStatus = false, EmployeeDesignation = "Team Lead", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 20.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1024, EmployeeName = "Ben Thompson", EmployeeAge = 20, EmployeeArea = "USA", EmployeeStatus = true, EmployeeDesignation = "Genreral Manager", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Male", Percent = 20.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1025, EmployeeName = "Sindhya", EmployeeAge = 20, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Senior Architect ", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 20.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1026, EmployeeName = "Sindhya", EmployeeAge = 20, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Senior Architect ", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 20.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1027, EmployeeName = "Sindhya", EmployeeAge = 20, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Senior Architect ", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 20.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1028, EmployeeName = "Sindhya", EmployeeAge = 20, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Senior Architect ", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 20.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1029, EmployeeName = "Sindhya", EmployeeAge = 20, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Senior Architect ", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 20.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1030, EmployeeName = "Sindhya", EmployeeAge = 20, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Senior Architect ", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 20.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1031, EmployeeName = "Sindhya", EmployeeAge = 20, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Senior Architect ", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 16.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1032, EmployeeName = "Sindhya", EmployeeAge = 20, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Senior Architect ", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 16.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1033, EmployeeName = "Sindhya", EmployeeAge = 20, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Senior Architect ", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 16.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1034, EmployeeName = "Sindhya", EmployeeAge = 20, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Senior Architect ", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 16.15 };
            this.Add(b);
            b = new BusinessObjects() { EmployeeId = 1035, EmployeeName = "Sindhya", EmployeeAge = 20, EmployeeArea = "India", EmployeeStatus = true, EmployeeDesignation = "Senior Architect ", EmployeeSalary = 1200, ExperienceInMonth = 10, EmployeeDOB = DateTime.Now, EmployeeGender = "Female", Percent = 16.15 };
            this.Add(b);

        }
    }
}
