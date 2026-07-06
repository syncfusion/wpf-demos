#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
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
using Syncfusion.Windows.Shared;

namespace syncfusion.treegriddemos.wpf
{
    /// <summary>
    /// ViewModel for the AutoRowHeight TreeGrid demo using self-relational binding
    /// </summary>
    public class AutoRowHeightViewModel : NotificationObject, IDisposable
    {
        private ObservableCollection<EmployeeDetailInfo> _employeeDetails;

        /// <summary>
        /// Initializes a new instance of the AutoRowHeightViewModel class.
        /// </summary>
        public AutoRowHeightViewModel()
        {
            this.EmployeeDetails = new ObservableCollection<EmployeeDetailInfo>();
            this.PopulateEmployeeData();
        }

        /// <summary>
        /// Gets or sets the flat list of all employee details.
        /// </summary>
        public ObservableCollection<EmployeeDetailInfo> EmployeeDetails
        {
            get { return _employeeDetails; }
            set
            {
                _employeeDetails = value;
                RaisePropertyChanged("EmployeeDetails");
            }
        }

        /// <summary>
        /// Populates sample employee  using self-relational binding.
        /// Root managers have ReportsTo = -1, subordinates have ReportsTo = parent manager's ID.
        /// </summary>
        private void PopulateEmployeeData()
        {
            int employeeId = 1001;

            var managers = new List<EmployeeDetailInfo>
            {
                new EmployeeDetailInfo { ID = employeeId++, Name = "Nancy", LastName = "Davolio", About = "BA in Psychology from Colorado State University; expert in leadership and strategic planning.", ReportsTo = -1 },
                new EmployeeDetailInfo { ID = employeeId++, Name = "Andrea", LastName = "Peacock", About = "Ph.D. in International Marketing from Harvard Business School, with specialized expertise in global market expansion, brand development, and driving sustainable growth strategies across diverse international markets.", ReportsTo = -1 },
                new EmployeeDetailInfo { ID = employeeId++, Name = "Garry", LastName = "Fuller", About = "BS in Chemistry from Boston College, leading R&D with innovative product solutions", ReportsTo = -1 },
                new EmployeeDetailInfo { ID = employeeId++, Name = "Margaret", LastName = "Hammersley", About = "BA in English Literature from Concordia College.", ReportsTo = -1 },
                new EmployeeDetailInfo { ID = employeeId++, Name = "Steven", LastName = "Buchanan", About = "BSc in Business Administration from the University of Manchester. Senior Manager overseeing operational excellence, driving process improvements and ensuring efficient business performance. Also plays a key role in aligning team strategies with organizational goals to achieve sustained growth and productivity", ReportsTo = -1 },
                new EmployeeDetailInfo { ID = employeeId++, Name = "Michael", LastName = "Suyama", About = "MA in Economics from Sussex University; financial analyst specializing in cost optimization with a proven track record.", ReportsTo = -1 },
                new EmployeeDetailInfo { ID = employeeId++, Name = "Robert", LastName = "King", About = "MBA from Stanford Graduate School of Business. Strategic account manager overseeing key relationships with Fortune 500 clients. Skilled in driving revenue growth through tailored business solutions and high-impact negotiations. Adept at building long-term partnerships and aligning client objectives with organizational strategy", ReportsTo = -1 },
                new EmployeeDetailInfo { ID = employeeId++, Name = "Laura", LastName = "Callahan", About = "BS in Computer Science from MIT; Software Architect specializing in cloud scalability", ReportsTo = -1 },
                new EmployeeDetailInfo { ID = employeeId++, Name = "Anne", LastName = "Dodsworth", About = "BBA in Marketing from USC; Brand Manager leading product positioning and customer engagement strategies effective.", ReportsTo = -1 },
                new EmployeeDetailInfo { ID = employeeId++, Name = "James", LastName = "Wilson", About = "BS in Mechanical Engineering from UC Berkeley. Manufacturing Director ensuring quality production standards and efficiency, with a strong focus on optimizing processes and driving continuous improvement across operations", ReportsTo = -1 },
                new EmployeeDetailInfo { ID = employeeId++, Name = "Caroline", LastName = "Patterson", About = "Masters Human Resources Northwestern; leads talent development and culture strategy", ReportsTo = -1 },
                new EmployeeDetailInfo { ID = employeeId++, Name = "Justin", LastName = "Brid", About = "BA in Business Administration from Yale University. Sales Director with track record of exceeding quarterly targets by 30%.", ReportsTo = -1 },
                new EmployeeDetailInfo { ID = employeeId++, Name = "Shu", LastName = "Ito", About = "PhD Materials Science Tokyo Tech; Chief Innovation Officer driving research.", ReportsTo = -1 },
                new EmployeeDetailInfo { ID = employeeId++, Name = "Jillian", LastName = "Carson", About = "Duke Healthcare BS; Operations Manager coordinating", ReportsTo = -1 },
                new EmployeeDetailInfo { ID = employeeId++, Name = "Stephen", LastName = "Jiang", About = "MS in Information Technology from Carnegie Mellon University. Infrastructure Manager responsible for IT security and system reliability, ensuring robust system performance and implementing best practices for secure and scalable infrastructure operations.", ReportsTo = -1 }
            };

            // Add all managers to collection first
            foreach (var manager in managers)
            {
                this.EmployeeDetails.Add(manager);
            }

            // Add 3 subordinates for each manager
            string[] childFirstNames = { "Thomas", "Rebecca", "Christopher" };
            string[] childLastNames = { "Anderson", "Mitchell", "Lee" };

            for (int i = 0; i < managers.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        this.EmployeeDetails.Add(new EmployeeDetailInfo
                        {
                            ID = employeeId++,
                            Name = childFirstNames[j],
                            LastName = childLastNames[j],
                            About = "Experienced professional specializing in client relationship management and project delivery with focus on customer satisfaction metrics.",
                            ReportsTo = managers[i].ID
                        });
                    }
                    else if(j == 1)
                    {
                        this.EmployeeDetails.Add(new EmployeeDetailInfo
                        {
                            ID = employeeId++,
                            Name = childFirstNames[j],
                            LastName = childLastNames[j],
                            About = "Professional specializing in software development and application design with a focus on scalable and efficient solutions. Skilled in building robust systems, optimizing performance, and ensuring high-quality, maintainable code across projects.\r\nExperienced in collaborating with cross-functional teams to deliver end-to-end solutions aligned with business requirements. Adept at adopting modern technologies and best practices to drive innovation and continuous improvement.",
                            ReportsTo = managers[i].ID
                        });
                    }
                    else
                    {
                        this.EmployeeDetails.Add(new EmployeeDetailInfo
                        {
                            ID = employeeId++,
                            Name = childFirstNames[j],
                            LastName = childLastNames[j],
                            About = "Specializing in DevOps and automation with a focus on continuous integration and efficient delivery pipelines.",
                            ReportsTo = managers[i].ID
                        });
                    }
                }
            }
        }

        /// <summary>
        /// Disposes resources.
        /// </summary>
        public void Dispose()
        {
            if (this.EmployeeDetails != null)
            {
                this.EmployeeDetails.Clear();
                this.EmployeeDetails = null;
            }
        }
    }
}
