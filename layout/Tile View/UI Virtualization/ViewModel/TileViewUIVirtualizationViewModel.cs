#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace syncfusion.layoutdemos.wpf
{
    public class TileViewVirtualizationViewModel : NotificationObject
    {
        private ObservableCollection<Employee> _employeeDetails = null;
        Random r = new Random();
        Dictionary<string, string> loginID = new Dictionary<string, string>();
        Dictionary<string, string> gender = new Dictionary<string, string>();
        List<string> Cities = new List<string>();

        #region TileView Properties
        private int columnCount = 4;
        /// <summary>
        /// Gets or sets the ColumCount of the TileViewControl.
        /// </summary>
        public int ColumnCount
        {
            get
            {
                return columnCount;
            }

            set
            {
                if (ColumnCount != value)
                {
                    columnCount = value;
                    this.RaisePropertyChanged("ColumnCount");
                }
            }
        }

        private int rowCount = 4;
        /// <summary>
        /// Gets or sets the RowCount of the TileViewControl.
        /// </summary>
        public int RowCount
        {
            get
            {
                return rowCount;
            }

            set
            {
                if (rowCount != value)
                {
                    rowCount = value;
                    this.RaisePropertyChanged("RowCount");
                }
            }
        }

        private ICommand loadTileViewItems;
        public ICommand LoadTileViewItems
        {
            get
            {
                return loadTileViewItems;
            }
            set
            {
                loadTileViewItems = value;
                this.RaisePropertyChanged("LoadTileViewItems");
            }
        }

        #endregion

        #region Implementation

        public TileViewVirtualizationViewModel()
        {
            if (System.Windows.SystemParameters.PrimaryScreenWidth <= 1366)
                columnCount = 3;
            if (System.Windows.SystemParameters.PrimaryScreenHeight <= 768)
                rowCount = 3;
            PopulateData();
            LoadCities();
            LoadTileViewItems = new DelegateCommand(LoadItems, CanLoad);
        }

        private bool CanLoad(object arg)
        {
            return true;
        }

        private void LoadItems(object obj)
        {
            (obj as Button).Visibility = Visibility.Collapsed;
            EmployeeDetails = GetEmployeesDetails(100000);
        }

        private void LoadCities()
        {
            Cities.Add("New York");
            Cities.Add("Los Angeles");
            Cities.Add("Chicago");
            Cities.Add("San Diego");
            Cities.Add("San Francisco");
            Cities.Add("Washington");
            Cities.Add("Boston");
            Cities.Add("Portland");
            Cities.Add("California");
            Cities.Add("New Mexico");
            Cities.Add("North Carolina");
            Cities.Add("Florida");
            Cities.Add("Texas");
            Cities.Add("Las Vegas");
            Cities.Add("Alaska");
        }

        public ObservableCollection<Employee> EmployeeDetails
        {
            get
            {
                return _employeeDetails;
            }
            set
            {
                _employeeDetails = value;
                RaisePropertyChanged("EmployeeDetails");
            }
        }

        int _ccount = 0;
        public ObservableCollection<Employee> GetEmployeesDetails(int count)
        {
            var employees = new ObservableCollection<Employee>();
            for (var i = 1; i <= count; i++)
            {
                employees.Add(GetEmployee(i));

                if (_ccount == Cities.Count)
                    _ccount = 0;
                if (employees[i - 1].Gender == "Male")
                {
                    employees[i - 1].MinimizedProfileImage = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/male.png";
                    employees[i - 1].MaximizedProfileImage = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/malemax.png";
                    employees[i - 1].City = Cities[_ccount];
                    employees[i - 1].EmailID = employees[i - 1].Name.Replace(" ", string.Empty).ToLower() + "@empsoft.com";
                }
                else
                {
                    employees[i - 1].MinimizedProfileImage = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/female.png";
                    employees[i - 1].MaximizedProfileImage = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/femalemax.png";
                    employees[i - 1].City = Cities[_ccount];
                    employees[i - 1].EmailID = employees[i - 1].Name.Replace(" ", string.Empty) + "@empsoft.com";
                }
                _ccount++;
            }
            return employees;
        }

        public Employee GetEmployee(int i)
        {
            var name = employeeName[r.Next(employeeName.Count() - 1)];
            DateTime date = new DateTime(r.Next(1975, 1985), r.Next(1, 12), r.Next(1, 28));
            return new Employee()
            {
                EmployeeID = 1000 + i,
                Name = name,
                ContactID = r.Next(1001, 2000),
                Gender = gender[name],
                Title = title[r.Next(title.Count() - 1)],
                BirthDate = date.Day.ToString() + "/" + date.Month.ToString() + "/" + date.Year.ToString(),
                SickLeaveHours = r.Next(15, 70),
                Salary = new decimal(Math.Round(r.NextDouble() * 6000.5, 2))
            };

        }

        private void PopulateData()
        {
            gender.Add("Sean Jacobson", "Male");
            gender.Add("Phyllis Allen", "Male");
            gender.Add("Marvin Allen", "Male");
            gender.Add("Michael Allen", "Male");
            gender.Add("Cecil Allison", "Male");
            gender.Add("Oscar Alpuerto", "Male");
            gender.Add("Sandra Altamirano", "Female");
            gender.Add("Selena Alvarad", "Female");
            gender.Add("Emilio Alvaro", "Female");
            gender.Add("Maxwell Amland", "Male");
            gender.Add("Mae Anderson", "Male");
            gender.Add("Ramona Antrim", "Female");
            gender.Add("Sabria Appelbaum", "Male");
            gender.Add("Hannah Arakawa", "Male");
            gender.Add("Kyley Arbelaez", "Male");
            gender.Add("Tom Johnston", "Female");
            gender.Add("Thomas Armstrong", "Female");
            gender.Add("John Arthur", "Male");
            gender.Add("Chris Ashton", "Female");
            gender.Add("Teresa Atkinson", "Male");
            gender.Add("John Ault", "Male");
            gender.Add("Robert Avalos", "Male");
            gender.Add("Stephen Ayers", "Male");
            gender.Add("Phillip Bacalzo", "Male");
            gender.Add("Gustavo Achong", "Male");
            gender.Add("Catherine Abel", "Male");
            gender.Add("Kim Abercrombie", "Male");
            gender.Add("Humberto Acevedo", "Male");
            gender.Add("Pilar Ackerman", "Male");
            gender.Add("Frances Adams", "Female");
            gender.Add("Margar Smith", "Male");
            gender.Add("Carla Adams", "Male");
            gender.Add("Jay Adams", "Male");
            gender.Add("Ronald Adina", "Female");
            gender.Add("Samuel Agcaoili", "Male");
            gender.Add("James Aguilar", "Female");
            gender.Add("Robert Ahlering", "Male");
            gender.Add("Francois Ferrier", "Male");
            gender.Add("Kim Akers", "Male");
            gender.Add("Lili Alameda", "Female");
            gender.Add("Amy Alberts", "Male");
            gender.Add("Anna Albright", "Female");
            gender.Add("Milton Albury", "Male");
            gender.Add("Paul Alcorn", "Male");
            gender.Add("Gregory Alderson", "Male");
            gender.Add("J. Phillip Alexander", "Male");
            gender.Add("Michelle Alexander", "Male");
            gender.Add("Daniel Blanco", "Male");
            gender.Add("Cory Booth", "Male");
            gender.Add("James Bailey", "Female");

            loginID.Add("Sean Jacobson", "sean2");
            loginID.Add("Phyllis Allen", "phyllis0");
            loginID.Add("Marvin Allen", "marvin0");
            loginID.Add("Michael Allen", "michael10");
            loginID.Add("Cecil Allison", "cecil0");
            loginID.Add("Oscar Alpuerto", "oscar0");
            loginID.Add("Sandra Altamirano", "sandra1");
            loginID.Add("Selena Alvarad", "selena0");
            loginID.Add("Emilio Alvaro", "emilio0");
            loginID.Add("Maxwell Amland", "maxwell0");
            loginID.Add("Mae Anderson", "mae0");
            loginID.Add("Ramona Antrim", "ramona0");
            loginID.Add("Sabria Appelbaum", "sabria0");
            loginID.Add("Hannah Arakawa", "hannah0");
            loginID.Add("Kyley Arbelaez", "kyley0");
            loginID.Add("Tom Johnston", "tom1");
            loginID.Add("Thomas Armstrong", "thomas1");
            loginID.Add("John Arthur", "john6");
            loginID.Add("Chris Ashton", "chris3");
            loginID.Add("Teresa Atkinson", "teresa0");
            loginID.Add("John Ault", "john7");
            loginID.Add("Robert Avalos", "robert2");
            loginID.Add("Stephen Ayers", "stephen1");
            loginID.Add("Phillip Bacalzo", "phillip0");
            loginID.Add("Gustavo Achong", "gustavo0");
            loginID.Add("Catherine Abel", "catherine0");
            loginID.Add("Kim Abercrombie", "kim2");
            loginID.Add("Humberto Acevedo", "humberto0");
            loginID.Add("Pilar Ackerman", "pilar1");
            loginID.Add("Frances Adams", "frances0");
            loginID.Add("Margar Smith", "margaret0");
            loginID.Add("Carla Adams", "carla0");
            loginID.Add("Jay Adams", "jay1");
            loginID.Add("Ronald Adina", "ronald0");
            loginID.Add("Samuel Agcaoili", "samuel0");
            loginID.Add("James Aguilar", "james2");
            loginID.Add("Robert Ahlering", "robert1");
            loginID.Add("Francois Ferrier", "françois1");
            loginID.Add("Kim Akers", "kim3");
            loginID.Add("Lili Alameda", "lili0");
            loginID.Add("Amy Alberts", "amy1");
            loginID.Add("Anna Albright", "anna0");
            loginID.Add("Milton Albury", "milton0");
            loginID.Add("Paul Alcorn", "paul2");
            loginID.Add("Gregory Alderson", "gregory0");
            loginID.Add("J. Phillip Alexander", "jphillip0");
            loginID.Add("Michelle Alexander", "michelle0");
            loginID.Add("Daniel Blanco", "daniel0");
            loginID.Add("Cory Booth", "cory0");
            loginID.Add("James Bailey", "james3");
        }

        private string[] title = new string[]
            {
                "Marketing Assistant",
                "Engineering Manager",
                "Senior Tool Designer",
                "Tool Designer",
                "Marketing Manager",
                "Production Supervisor - WC60",
                "Production Technician - WC10",
                "Design Engineer",
                "Production Technician - WC10",
                "Design Engineer",
                "Vice President of Engineering",
                "Production Technician - WC10",
                "Production Supervisor - WC50",
                "Production Technician - WC10",
                "Production Supervisor - WC60",
                "Production Technician - WC10",
                "Production Supervisor - WC60",
                "Production Technician - WC10",
                "Production Technician - WC30",
                "Production Control Manager",
                "Production Technician - WC45",
                "Production Technician - WC45",
                "Production Technician - WC30",
                "Production Supervisor - WC10",
                "Production Technician - WC20",
                "Production Technician - WC40",
                "Network Administrator",
                "Production Technician - WC50",
                "Human Resources Manager",
                "Production Technician - WC40",
                "Production Technician - WC30",
                "Production Technician - WC30",
                "Stocker",
                "Shipping and Receiving Clerk",
                "Production Technician - WC50",
                "Production Technician - WC60",
                "Production Supervisor - WC50",
                "Production Technician - WC20",
                "Production Technician - WC45",
                "Quality Assurance Supervisor",
                "Information Services Manager",
                "Production Technician - WC50",
                "Master Scheduler",
                "Production Technician - WC40",
                "Marketing Specialist",
                "Recruiter",
                "Production Technician - WC50",
                "Maintenance Supervisor",
                "Production Technician - WC30",
            };

        private string[] employeeName = new string[]
            {
                "Sean Jacobson",
                "Phyllis Allen",
                "Marvin Allen",
                "Michael Allen",
                "Cecil Allison",
                "Oscar Alpuerto",
                "Sandra Altamirano",
                "Selena Alvarad",
                "Emilio Alvaro",
                "Maxwell Amland",
                "Mae Anderson",
                "Ramona Antrim",
                "Sabria Appelbaum",
                "Hannah Arakawa",
                "Kyley Arbelaez",
                "Tom Johnston",
                "Thomas Armstrong",
                "John Arthur",
                "Chris Ashton",
                "Teresa Atkinson",
                "John Ault",
                "Robert Avalos",
                "Stephen Ayers",
                "Phillip Bacalzo",
                "Gustavo Achong",
                "Catherine Abel",
                "Kim Abercrombie",
                "Humberto Acevedo",
                "Pilar Ackerman",
                "Frances Adams",
                "Margar Smith",
                "Carla Adams",
                "Jay Adams",
                "Ronald Adina",
                "Samuel Agcaoili",
                "James Aguilar",
                "Robert Ahlering",
                "Francois Ferrier",
                "Kim Akers",
                "Lili Alameda",
                "Amy Alberts",
                "Anna Albright",
                "Milton Albury",
                "Paul Alcorn",
                "Gregory Alderson",
                "J. Phillip Alexander",
                "Michelle Alexander",
                "Daniel Blanco",
                "Cory Booth",
                "James Bailey"
            };

        #endregion
    }
}
