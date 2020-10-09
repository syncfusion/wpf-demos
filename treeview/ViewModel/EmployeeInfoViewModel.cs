#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace syncfusion.treeviewdemos.wpf
{
    public class EmployeeInfoViewModel
    {
        #region Private Variables
        private ObservableCollection<EmployeeInfo> _treeViewCollection;
        private ObservableCollection<EmployeeInfo> _dataGridCollection;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeInfoViewModel"/> class.
        /// </summary>
        public EmployeeInfoViewModel()
        {
            this.DataGridCollection = PopulateDataGridCollection();
            this.TreeViewCollection = PopulateTreeViewCollection();
        }

        #endregion

        #region Populate data 
        private ObservableCollection<EmployeeInfo> PopulateDataGridCollection()
        {
            var accountant1 = new ObservableCollection<EmployeeInfo>();

            accountant1.Add(new EmployeeInfo() { FirstName = "George", LastName = "Washington", ID = 600, Title = "Accountant", Salary = 40000 });
            accountant1.Add(new EmployeeInfo() { FirstName = "John", LastName = "Adams", ID = 600, Title = "Accountant", Salary = 40000 });
            accountant1.Add(new EmployeeInfo() { FirstName = "Thomas", LastName = "Jefferson", ID = 600, Title = "Accountant", Salary = 40000 });
            accountant1.Add(new EmployeeInfo() { FirstName = "James", LastName = "Madison", ID = 600, Title = "Accountant", Salary = 40000 });

            var employeeInfo = new ObservableCollection<EmployeeInfo>();

            employeeInfo.Add(new EmployeeInfo() { FirstName = "Dwayne", LastName = "Douglas", ID = 200, Title = "Vice President", Salary = 150000 });
            employeeInfo.Add(new EmployeeInfo() { FirstName = "Sam", LastName = "Harrison", ID = 400, Title = "GeneralManager", Salary = 90000 });
            employeeInfo.Add(new EmployeeInfo() { FirstName = "Jones", LastName = "Lincoln", ID = 450, Title = "Accounts Manager", Salary = 80000, Children = accountant1 });
            employeeInfo.Add(new EmployeeInfo() { FirstName = "Hunter", LastName = "Washington", ID = 600, Title = "Accountant", Salary = 40000 });
            employeeInfo.Add(new EmployeeInfo() { FirstName = "Colin", LastName = "Adams", ID = 600, Title = "Accountant", Salary = 40000 });
            employeeInfo.Add(new EmployeeInfo() { FirstName = "Harold", LastName = "Jefferson", ID = 600, Title = "Accountant", Salary = 40000 });
            employeeInfo.Add(new EmployeeInfo() { FirstName = "Truman", LastName = "Monroe", ID = 600, Title = "Accountant", Salary = 40000 });
            employeeInfo.Add(new EmployeeInfo() { FirstName = "Elton", LastName = "Jackson", ID = 600, Title = "Accountant", Salary = 40000 });
            employeeInfo.Add(new EmployeeInfo() { FirstName = "Kennedy", LastName = "Gates", ID = 600, Title = "Accountant", Salary = 40000 });
            employeeInfo.Add(new EmployeeInfo() { FirstName = "Nixon", LastName = "Buren", ID = 600, Title = "Accountant", Salary = 40000 });
            employeeInfo.Add(new EmployeeInfo() { FirstName = "Frank", LastName = "Tyler", ID = 600, Title = "Accountant", Salary = 40000 });
            employeeInfo.Add(new EmployeeInfo() { FirstName = "Clint", LastName = "Polk", ID = 500, Title = "Manager", Salary = 50000 });
            employeeInfo.Add(new EmployeeInfo() { FirstName = "Richard", LastName = "Taylor", ID = 500, Title = "Manager", Salary = 50000 });

            return employeeInfo;
        }

        private ObservableCollection<EmployeeInfo> PopulateTreeViewCollection()
        {
            var accountant1 = new ObservableCollection<EmployeeInfo>();

            accountant1.Add(new EmployeeInfo() { FirstName = "George", LastName = "Harrison", ID = 600, Title = "Accountant", Salary = 40000 });
            accountant1.Add(new EmployeeInfo() { FirstName = "John", LastName = "Washington", ID = 600, Title = "Accountant", Salary = 40000 });
            accountant1.Add(new EmployeeInfo() { FirstName = "Thomas", LastName = "Adams", ID = 600, Title = "Accountant", Salary = 40000 });
            accountant1.Add(new EmployeeInfo() { FirstName = "James", LastName = "Jefferson", ID = 600, Title = "Accountant", Salary = 40000 });

            var accountant2 = new ObservableCollection<EmployeeInfo>();

            accountant2.Add(new EmployeeInfo() { FirstName = "Larry", LastName = "Madison", ID = 600, Title = "Accountant", Salary = 40000 });
            accountant2.Add(new EmployeeInfo() { FirstName = "Peter", LastName = "Monroe", ID = 600, Title = "Accountant", Salary = 40000 });
            accountant2.Add(new EmployeeInfo() { FirstName = "David", LastName = "Jackson", ID = 600, Title = "Accountant", Salary = 40000 });
            accountant2.Add(new EmployeeInfo() { FirstName = "Barry", LastName = "Warner", ID = 600, Title = "Accountant", Salary = 40000 });

            var accountant3 = new ObservableCollection<EmployeeInfo>();

            accountant3.Add(new EmployeeInfo() { FirstName = "Bill", LastName = "Van", ID = 600, Title = "Accountant", Salary = 40000 });
            accountant3.Add(new EmployeeInfo() { FirstName = "Jimmy", LastName = "Gates", ID = 600, Title = "Accountant", Salary = 40000 });
            accountant3.Add(new EmployeeInfo() { FirstName = "Gerald", LastName = "Buren", ID = 600, Title = "Accountant", Salary = 40000 });
            accountant3.Add(new EmployeeInfo() { FirstName = "Paul", LastName = "Tyler", ID = 600, Title = "Accountant", Salary = 40000 });

            var manager1 = new ObservableCollection<EmployeeInfo>();

            manager1.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = "Richard", ID = 500, Title = "Manager", Salary = 50000 });
            manager1.Add(new EmployeeInfo() { FirstName = "Martin", LastName = "Polk", ID = 500, Title = "Manager", Salary = 50000 });
            manager1.Add(new EmployeeInfo() { FirstName = "Zachary", LastName = "Taylor", ID = 500, Title = "Manager", Salary = 50000 });
            manager1.Add(new EmployeeInfo() { FirstName = "Milton", LastName = "Fillmore", ID = 500, Title = "Manager", Salary = 50000 });

            var manager2 = new ObservableCollection<EmployeeInfo>();

            manager2.Add(new EmployeeInfo() { FirstName = "Lyndon", LastName = "Buchanan", ID = 500, Title = "Manager", Salary = 50000 });
            manager2.Add(new EmployeeInfo() { FirstName = "Dwight", LastName = "Johnson", ID = 500, Title = "Manager", Salary = 50000 });
            manager2.Add(new EmployeeInfo() { FirstName = "Harry", LastName = "Potter", ID = 500, Title = "Manager", Salary = 50000 });
            manager2.Add(new EmployeeInfo() { FirstName = "Herbert", LastName = "Grant", ID = 500, Title = "Manager", Salary = 50000 });

            var manager3 = new ObservableCollection<EmployeeInfo>();

            manager3.Add(new EmployeeInfo() { FirstName = "Calvin", LastName = "Hayes", ID = 500, Title = "Manager", Salary = 50000 });
            manager3.Add(new EmployeeInfo() { FirstName = "Warren", LastName = "Garfield", ID = 500, Title = "Manager", Salary = 50000 });
            manager3.Add(new EmployeeInfo() { FirstName = "Woodrow", LastName = "Arthur", ID = 500, Title = "Manager", Salary = 50000 });
            manager3.Add(new EmployeeInfo() { FirstName = "Theodore", LastName = "Cleveland", ID = 500, Title = "Manager", Salary = 50000 });

            var vp_childnodes1 = new ObservableCollection<EmployeeInfo>();

            vp_childnodes1.Add(new EmployeeInfo() { FirstName = "Franklin", LastName = "Harrison", ID = 400, Title = "GeneralManager", Salary = 90000, Children = manager1 });
            vp_childnodes1.Add(new EmployeeInfo() { FirstName = "Abraham", LastName = "Lincoln", ID = 450, Title = "Accounts Manager", Salary = 80000, Children = accountant1 });

            var vp_childnodes2 = new ObservableCollection<EmployeeInfo>();

            vp_childnodes2.Add(new EmployeeInfo() { FirstName = "Benjamin", LastName = "Franklin", ID = 400, Title = "GeneralManager", Salary = 90000, Children = manager2 });
            vp_childnodes2.Add(new EmployeeInfo() { FirstName = "Grover", LastName = "Roosevelt", ID = 450, Title = "Accounts Manager", Salary = 80000, Children = accountant2 });

            var vp_childnodes3 = new ObservableCollection<EmployeeInfo>();

            vp_childnodes3.Add(new EmployeeInfo() { FirstName = "Ricky", LastName = "Pointer", ID = 400, Title = "GeneralManager", Salary = 90000, Children = manager3 });
            vp_childnodes3.Add(new EmployeeInfo() { FirstName = "Johny", LastName = "Dermot", ID = 450, Title = "Accounts Manager", Salary = 80000, Children = accountant3 });

            var vice_president = new ObservableCollection<EmployeeInfo>();
            vice_president.Add(new EmployeeInfo() { FirstName = "Ulysses", LastName = "Taft", Title = "Vice President", ID = 200, Salary = 150000, Children = vp_childnodes1 });
            vice_president.Add(new EmployeeInfo() { FirstName = "Rutherford", LastName = "Wilson", Title = "Vice President", ID = 200, Salary = 150000, Children = vp_childnodes2 });
            vice_president.Add(new EmployeeInfo() { FirstName = "Chester", LastName = "Harding", Title = "Vice President", ID = 200, Salary = 150000, Children = vp_childnodes3 });

            return vice_president;
        }

        #endregion

        #region Public properties
        /// <summary>
        /// contains the details of employees for treegrid
        /// </summary>
        public ObservableCollection<EmployeeInfo> TreeViewCollection
        {
            get { return _treeViewCollection; }
            set
            {
                _treeViewCollection = value;
            }
        }

        /// <summary>
        /// contains the details of employees for datagrid
        /// </summary>
        public ObservableCollection<EmployeeInfo> DataGridCollection
        {
            get { return _dataGridCollection; }
            set
            {
                _dataGridCollection = value;
            }
        }

        #endregion
    }
}
