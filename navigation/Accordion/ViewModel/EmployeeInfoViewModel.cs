#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
using System.Collections.ObjectModel;

namespace syncfusion.navigationdemos.wpf
{
    public class EmployeeInfoViewModel : NotificationObject
    {
        /// <summary>
        ///  Maintains the collection of employee details.
        /// </summary>
        private ObservableCollection<EmployeeModel> employeeDetails;

        /// <summary>
        ///  Initializes a new instance of the <see cref="EmployeeInfoViewModel" /> class.
        /// </summary>
        public EmployeeInfoViewModel()
        {
            Employees = new ObservableCollection<EmployeeModel>();
            Employees.Add(new EmployeeModel() { Name = "Eric Joplin", Image = @"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle14.png", Position = "Chairman", OrganizationUnit = "Management", DateOfBirth = "27/09/1973", Location = "Boston", Phone = "+800 9899 9929", Email = "ericjoplin@syncfusion.com", TileColor = "#FFA400", HeaderColor = "#E78E00" });
            Employees.Add(new EmployeeModel() { Name = "Paul Vent", Image = @"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle5.png", Position = "Chief Executive Officer", OrganizationUnit = "Management", DateOfBirth = "27/09/1975", Location = "New York", Phone = "+800 9899 9930", Email = "paulvent@syncfusion.com", TileColor = "#6DA4A3", HeaderColor = "#4E7F7D" });
            Employees.Add(new EmployeeModel() { Name = "Clara Venus", Image = @"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle13.png", Position = "Chief Executive Assistant", OrganizationUnit = "Management", DateOfBirth = "27/09/1978", Location = "California", Phone = "+800 9899 9931", Email = "claravenus@syncfusion.com", TileColor = "#A45378", HeaderColor = "#883F64" });
            Employees.Add(new EmployeeModel() { Name = "Maria Even", Image = @"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle0.png", Position = "Executive Manager", OrganizationUnit = "Operational Unit", DateOfBirth = "27/09/1970", Location = "New York", Phone = "+800 9899 9932", Email = "mariaeven@syncfusion.com", TileColor = "#DA9545", HeaderColor = "#BB7731" });
            Employees.Add(new EmployeeModel() { Name = "Mark Zuen", Image = @"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle23.png", Position = "Senior Executive", OrganizationUnit = "Operational Unit", DateOfBirth = "27/09/1983", Location = "Boston", Phone = "+800 9899 9933", Email = "markzuen@syncfusion.com", TileColor = "#AC3832", HeaderColor = "#8B2826" });
        }

        /// <summary>
        /// Gets or sets the employee details <see cref="EmployeeInfoViewModel"/> class.
        /// </summary>
        public ObservableCollection<EmployeeModel> Employees
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
    }
}
