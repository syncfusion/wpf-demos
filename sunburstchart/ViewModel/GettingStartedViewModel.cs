#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.SunburstChart;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.sunburstchartdemos.wpf
{
    /// <summary>
    /// Represents the GettingStartedViewModel.
    /// </summary>
    public class GettingStartedViewModel :NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public GettingStartedViewModel()
        {
            Data = new List<GettingStartedModel>();

            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "USA", JobDescription = "Sales", JobGroup = "Executive", EmployeesCount = 50 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "USA", JobDescription = "Sales", JobGroup = "Analyst", EmployeesCount = 40 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "USA", JobDescription = "Marketing", EmployeesCount = 40 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "USA", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 35 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "USA", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 175 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "USA", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 70 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "USA", JobDescription = "Management", EmployeesCount = 40 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "USA", JobDescription = "Accounts", EmployeesCount = 60 });

            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "India", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 33 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "India", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 125 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "India", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 60 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "India", JobDescription = "HR Executives", EmployeesCount = 70 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "India", JobDescription = "Accounts", EmployeesCount = 45 });

            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "Germany", JobDescription = "Sales", JobGroup = "Executive", EmployeesCount = 30 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "Germany", JobDescription = "Sales", JobGroup = "Analyst", EmployeesCount = 40 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "Germany", JobDescription = "Marketing", EmployeesCount = 50 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "Germany", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 40 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "Germany", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 65 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "Germany", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 27 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "Germany", JobDescription = "Management", EmployeesCount = 33 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "Germany", JobDescription = "Accounts", EmployeesCount = 55 });

            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "UK", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 25 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "UK", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 96 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "UK", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 55 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "UK", JobDescription = "HR Executives", EmployeesCount = 60 });
            Data.Add(new GettingStartedModel() { Category = "Employees", Country = "UK", JobDescription = "Accounts", EmployeesCount = 30 });

            LabelOverflowMode = LabelOverflowMode.Trim;
            LabelRotationMode = LabelRotationMode.Angle;
        }

        /// <summary>
        /// Gets or sets the collection of data models for the GettingStarted view.
        /// </summary>
        public List<GettingStartedModel> Data { get; set; }

        private LabelOverflowMode labelOverflowMode;

        /// <summary>
        /// Gets or sets the label overflow mode for chart labels.
        /// </summary>
        public LabelOverflowMode LabelOverflowMode
        {
            get 
            {
                return labelOverflowMode; 
            }
            set 
            {
                labelOverflowMode = value;
                RaisePropertyChanged("LabelOverflowMode");
            }
        }

        private LabelRotationMode labelRotationMode;

        /// <summary>
        /// Gets or sets the label rotation mode for chart labels.
        /// </summary>
        public LabelRotationMode LabelRotationMode
        {
            get 
            { 
                return labelRotationMode; 
            }
            set 
            {
                labelRotationMode = value;
                RaisePropertyChanged("LabelRotationMode");
            }
        }


    }
}