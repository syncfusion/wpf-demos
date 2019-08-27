#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZoomableSunburst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class Model
    {
        public string Country { get; set; }

        public string JobDescription { get; set; }

        public string JobGroup { get; set; }

        public string JobRole { get; set; }

        public double EmployeesCount { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            Data = new ObservableCollection<Model>();

            Data.Add(new Model { Country = "USA", JobDescription = "Sales", JobGroup = "Executive", EmployeesCount = 50 });
            Data.Add(new Model { Country = "USA", JobDescription = "Sales", JobGroup = "Analyst", EmployeesCount = 40 });
            Data.Add(new Model { Country = "USA", JobDescription = "Marketing", EmployeesCount = 40 });
            Data.Add(new Model { Country = "USA", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 35 });
            Data.Add(new Model { Country = "USA", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 175 });
            Data.Add(new Model { Country = "USA", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 70 });
            Data.Add(new Model { Country = "USA", JobDescription = "Management", EmployeesCount = 40 });
            Data.Add(new Model { Country = "USA", JobDescription = "Accounts", EmployeesCount = 60 });

            Data.Add(new Model { Country = "India", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 33 });
            Data.Add(new Model { Country = "India", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 125 });
            Data.Add(new Model { Country = "India", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 60 });
            Data.Add(new Model { Country = "India", JobDescription = "HR Executives", EmployeesCount = 70 });
            Data.Add(new Model { Country = "India", JobDescription = "Accounts", EmployeesCount = 45 });

            Data.Add(new Model { Country = "Germany", JobDescription = "Sales", JobGroup = "Executive", EmployeesCount = 30 });
            Data.Add(new Model { Country = "Germany", JobDescription = "Sales", JobGroup = "Analyst", EmployeesCount = 40 });
            Data.Add(new Model { Country = "Germany", JobDescription = "Marketing", EmployeesCount = 50 });
            Data.Add(new Model { Country = "Germany", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 40 });
            Data.Add(new Model { Country = "Germany", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 65 });
            Data.Add(new Model { Country = "Germany", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 27 });
            Data.Add(new Model { Country = "Germany", JobDescription = "Management", EmployeesCount = 33 });
            Data.Add(new Model { Country = "Germany", JobDescription = "Accounts", EmployeesCount = 55 });

            Data.Add(new Model { Country = "UK", JobDescription = "Technical", JobGroup = "Testers", EmployeesCount = 25 });
            Data.Add(new Model { Country = "UK", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Windows", EmployeesCount = 96 });
            Data.Add(new Model { Country = "UK", JobDescription = "Technical", JobGroup = "Developers", JobRole = "Web", EmployeesCount = 55 });
            Data.Add(new Model { Country = "UK", JobDescription = "HR Executives", EmployeesCount = 60 });
            Data.Add(new Model { Country = "UK", JobDescription = "Accounts", EmployeesCount = 30 });
        }

        public ObservableCollection<Model> Data { get; set; }
    }
}
