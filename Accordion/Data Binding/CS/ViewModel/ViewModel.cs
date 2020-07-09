#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace DataBinding
{
    /// <summary>
    /// Represents the behaviour or business logic for MainWindow.xaml
    /// </summary>
    public class ViewModel :NotificationObject
    {
        /// <summary>
        ///  Maintains the collection of employee details.
        /// </summary>
        private ObservableCollection<Model> employeeDetails;

        /// <summary>
        /// Maintains the collection of themes.
        /// </summary>
        private ObservableCollection<VisualStyles> visualStyles;


        /// <summary>
        ///  Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>
        public ViewModel()
        {
            Employees = new ObservableCollection<Model>();
            Employees.Add(new Model() { Name = "Eric Joplin", Image = new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_02.png")), Position = "Chairman", OrganizationUnit = "Management", DateOfBirth = "27/09/1973", Location = "Boston", Phone = "+800 9899 9929", Email = "ericjoplin@syncfusion.com", TileColor = "#FFA400", HeaderColor = "#E78E00"});
            Employees.Add(new Model() { Name = "Paul Vent", Image = new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_04.png")), Position = "Chief Executive Officer", OrganizationUnit = "Management", DateOfBirth = "27/09/1975", Location = "New York", Phone = "+800 9899 9930", Email = "paulvent@syncfusion.com", TileColor = "#6DA4A3", HeaderColor = "#4E7F7D" });
            Employees.Add(new Model() { Name = "Clara Venus", Image = new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_06.png")), Position = "Chief Executive Assistant", OrganizationUnit = "Management", DateOfBirth = "27/09/1978", Location = "California", Phone = "+800 9899 9931", Email = "claravenus@syncfusion.com", TileColor = "#A45378", HeaderColor = "#883F64" });
            Employees.Add(new Model() { Name = "Maria Even", Image = new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_11.png")), Position = "Executive Manager", OrganizationUnit = "Operational Unit", DateOfBirth = "27/09/1970", Location = "New York", Phone = "+800 9899 9932", Email = "mariaeven@syncfusion.com", TileColor = "#DA9545", HeaderColor = "#BB7731" });
            Employees.Add(new Model() { Name = "Mark Zuen", Image = new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_13.png")), Position = "Senior Executive", OrganizationUnit = "Operational Unit", DateOfBirth = "27/09/1983", Location = "Boston", Phone = "+800 9899 9933", Email = "markzuen@syncfusion.com", TileColor = "#AC3832", HeaderColor = "#8B2826" });

            Themes = new ObservableCollection<VisualStyles>();
            PopulateThemes();
        }

        /// <summary>
        /// Gets or sets the employee details <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> Employees
        {
            get
            {
                return employeeDetails;
            }
            set
            {
                employeeDetails = value;
                RaisePropertyChanged("Employees");
            }
        }

        /// <summary>
        /// Dispose the employee details.
        /// </summary>
        public void Dispose()
        {
            if (Employees != null)
            {
                Employees.Clear();
            }
        }

        /// <summary>
        /// Gets or set the collection of themes <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<VisualStyles> Themes
        {
            get
            {
                return visualStyles;
            }
            set
            {
                if (visualStyles != value)
                    visualStyles = value;
            }
        }

        /// <summary>
        /// Adding details to the collection of themes.
        /// </summary> 
        private void PopulateThemes()
        {
            Themes.Add(VisualStyles.MaterialLight);
            Themes.Add(VisualStyles.MaterialLightBlue);
            Themes.Add(VisualStyles.MaterialDark);
            Themes.Add(VisualStyles.MaterialDarkBlue);
        }
    }
}
   
