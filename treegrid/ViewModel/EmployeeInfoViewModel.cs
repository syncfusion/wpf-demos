#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.UI.Xaml.TreeGrid.Converter;
using Syncfusion.Windows.PdfViewer;
using System.IO;
using Syncfusion.Pdf.Parsing;

namespace syncfusion.treegriddemos.wpf
{
    public class EmployeeInfoViewModel : NotificationObject
    {
        static int baseCount = -1;
        private List<EmployeeInfo> _employeeList;
        internal static Random random = new Random(123123);
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeInfoViewModel"/> class.
        /// </summary>

        #region Constructor

        public EmployeeInfoViewModel()
        {
            this.ExpandCommand = new DelegateCommand<object>(ExpandExecute);
            this.CollapseCommand = new DelegateCommand<object>(CollapseExecute);
            this.PrintCommand = new DelegateCommand<object>(PrintExecute);
            this.PopulateWithSampleData(560);
            this.PersonDetails = this.CreateGenericPersonData(5, 8);
            this.EmployeesListInfo = this.GetEmployeesInfo();
        }

        #endregion


        #region Properties

        private ObservableCollection<EmployeeInfo> _PersonDetails = new ObservableCollection<EmployeeInfo>();

        /// <summary>
        /// Gets or sets the person details.
        /// </summary>
        /// <value>The person details.</value>
        public ObservableCollection<EmployeeInfo> PersonDetails
        {
            get { return _PersonDetails; }
            set { _PersonDetails = value; }
        }

        private List<EmployeeInfo> _EmployeeInfo;
        /// <summary>
        /// Gets or sets the employee info.
        /// </summary>
        /// <value>The employee info.</value>
        public List<EmployeeInfo> EmployeesListInfo
        {
            get
            {
                return _EmployeeInfo;
            }
            set
            {
                _EmployeeInfo = value;
            }
        }

        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        /// <value>The employee details.</value>
        public List<EmployeeInfo> EmployeeList
        {
            get { return _employeeList; }
            set { _employeeList = value; }
        }

        private ObservableCollection<string> cityCollection;

        public ObservableCollection<string> CityCollection
        {
            get { return cityCollection; }
            set { cityCollection = value; }
        }

        internal List<string> _comboBoxItemsSource = new List<string>();

        public List<string> ComboBoxItemsSource
        {
            get { return _comboBoxItemsSource; }
            set { _comboBoxItemsSource = value; }
        }
        #endregion

        #region Commnad

        private ICommand expandCommand;

        public ICommand ExpandCommand
        {
            get { return expandCommand; }
            set { expandCommand = value; }
        }

        private ICommand collapseCommand;

        public ICommand CollapseCommand
        {
            get { return collapseCommand; }
            set { collapseCommand = value; }
        }

        private ICommand printCommand;

        public ICommand PrintCommand
        {
            get { return printCommand; }
            set { printCommand = value; }
        }
        #endregion

        #region Methods 

        private void ExpandExecute(object obj)
        {
            var treeGrid = obj as SfTreeGrid;
            treeGrid.ExpandAllNodes();
        }

        private void CollapseExecute(object obj)
        {
            var treeGrid = obj as SfTreeGrid;
            treeGrid.CollapseAllNodes();
        }

        private void PrintExecute(object obj)
        {
            var treeGrid = obj as SfTreeGrid;
            if (treeGrid == null) return;
            try
            {
                var options = new TreeGridPdfExportingOptions();
                options.AllowIndentColumn = true;
                options.FitAllColumnsInOnePage = true;

                var document = treeGrid.ExportToPdf(options);

                PdfViewerControl pdfViewer = new PdfViewerControl();
                MemoryStream stream = new MemoryStream();
                document.Save(stream);
                PdfLoadedDocument ldoc = new PdfLoadedDocument(stream);
                pdfViewer.Load(ldoc);
                pdfViewer.Print(true);
            }
            catch (Exception)
            {

            }
            treeGrid.ExpandAllNodes();
        }


        #endregion

        #region Methods

        /// <summary>
        /// Populates the with sample data.
        /// </summary>
        /// <param name="count">The count.</param>
        public void PopulateWithSampleData(int count)
        {
            PopulateWithSampleData(count, true);
        }

        /// <summary>
        /// Populates the with flat data.
        /// </summary>
        /// <param name="count">The count.</param>
        public void PopulateWithFlatData(int count)
        {
            baseCount++;
            Random r = new Random(12313);
            EmployeeInfo emp;

            //just generate to random data in some manner - not really related to the TreeGrid itself...
            for (int i = 0; i < count; ++i)
            {
                emp = new EmployeeInfo();
                emp.ID = i;
                emp.FirstName = names1[r.Next(names1.GetLength(0))];
                emp.LastName = names2[r.Next(names2.GetLength(0))];
                emp.Salary = 30000d + r.Next(9) * 10000;
                emp.Title = title[r.Next(title.GetLength(0))];
                emp.City = city[r.Next(city.GetLength(0))];
                emp.Department = dept[r.Next(dept.GetLength(0))];
                this.EmployeeList.Add(emp);
            }
        }

        /// <summary>
        /// Populates with sample data.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="multipleRootNodes">if set to <c>true</c> [multiple root nodes].</param>
        public void PopulateWithSampleData(int count, bool multipleRootNodes)
        {
            this.EmployeeList = new List<EmployeeInfo>();
            Random r = new Random(12313);

            //just generate to random data in some manner - not really related to the TreeGrid itself...
            PopulateWithFlatData(count);

            //now need to set up the reportsto property...
            // first create a list of all the employees
            List<int> all = new List<int>();
            for (int i = 0; i < count; ++i)
            {
                all.Add(i);
            }

            //choose 2 big bosses - with half the employees reporting to each...

            //first big boss
            int randonLocation = r.Next(all.Count);
            int parentID = all[randonLocation];
            EmployeeInfo bigBoss = this.EmployeeList[parentID];
            bigBoss.FirstName = "Madison";
            bigBoss.Department = "General manager";
            bigBoss.Title = "Vice President";
            bigBoss.Salary = 200000d;
            bigBoss.ReportsTo = -1; //big boss reports to no one

            //remove boss for pool
            all.Remove(parentID);
            ObservableCollection<EmployeeInfo> employeesToProcess = new ObservableCollection<EmployeeInfo>();
            employeesToProcess = new ObservableCollection<EmployeeInfo>();
            employeesToProcess.Add(bigBoss);

            //now loop through and set direct reports to this parent
            int half = multipleRootNodes ? all.Count / 2 : 0;
            while (all.Count > half)
            {
                ObservableCollection<EmployeeInfo> nextSetToProcess = new ObservableCollection<EmployeeInfo>();
                nextSetToProcess = new ObservableCollection<EmployeeInfo>();

                foreach (EmployeeInfo e in employeesToProcess)
                {
                    int numberOfReports = r.Next(6) + 1;
                    while (numberOfReports > 0 && all.Count > half)
                    {
                        randonLocation = r.Next(all.Count);
                        int childID = all[randonLocation];
                        EmployeeInfo child = this.EmployeeList[childID];
                        nextSetToProcess.Add(child);
                        child.ReportsTo = e.ID;
                        numberOfReports--;
                        all.Remove(childID);
                    }
                    if (all.Count <= half)
                        break;
                }
                employeesToProcess = nextSetToProcess;
            }

            if (multipleRootNodes)
            {
                //second big boss
                randonLocation = r.Next(all.Count);
                parentID = all[randonLocation];
                bigBoss = this.EmployeeList[parentID];
                bigBoss.FirstName = "Hawkin";
                bigBoss.Department = "Business Manager";
                bigBoss.Title = "Sales Representative";
                bigBoss.Salary = 200000d;
                bigBoss.ReportsTo = -1; //big boss reports to no one

                //remove boss for pool
                all.Remove(parentID);
                employeesToProcess = new ObservableCollection<EmployeeInfo>();
                employeesToProcess.Add(bigBoss);

                int halfCount = all.Count / 2;
                //now loop through and set direct reports to this parent
                while (all.Count > halfCount)
                {
                    ObservableCollection<EmployeeInfo> nextSetToProcess = new ObservableCollection<EmployeeInfo>();
                    foreach (EmployeeInfo e in employeesToProcess)
                    {
                        int numberOfReports = r.Next(6) + 1;
                        while (numberOfReports > 0 && all.Count > halfCount)
                        {
                            randonLocation = r.Next(all.Count);
                            int childID = all[randonLocation];
                            EmployeeInfo child = this.EmployeeList[childID];
                            nextSetToProcess.Add(child);
                            child.ReportsTo = e.ID;
                            numberOfReports--;
                            all.Remove(childID);
                        }
                        if (all.Count == 0)
                            break;
                    }
                    employeesToProcess = nextSetToProcess;
                }


                //third big boss
                randonLocation = r.Next(all.Count);
                parentID = all[randonLocation];
                bigBoss = this.EmployeeList[parentID];
                bigBoss.FirstName = "Richard";
                bigBoss.Department = "Human resources";
                bigBoss.Title = "HR Coordinator";
                bigBoss.Salary = 200000d;
                bigBoss.ReportsTo = -1; //big boss reports to no one

                //remove boss for pool
                all.Remove(parentID);
                employeesToProcess = new ObservableCollection<EmployeeInfo>();
                employeesToProcess.Add(bigBoss);

                //now loop through and set direct reports to this parent
                while (all.Count > 0)
                {
                    ObservableCollection<EmployeeInfo> nextSetToProcess = new ObservableCollection<EmployeeInfo>();
                    foreach (EmployeeInfo e in employeesToProcess)
                    {
                        int numberOfReports = r.Next(6) + 1;
                        while (numberOfReports > 0 && all.Count > 0)
                        {
                            randonLocation = r.Next(all.Count);
                            int childID = all[randonLocation];
                            EmployeeInfo child = this.EmployeeList[childID];
                            nextSetToProcess.Add(child);
                            child.ReportsTo = e.ID;
                            numberOfReports--;
                            all.Remove(childID);
                        }
                        if (all.Count == 0)
                            break;
                    }
                    employeesToProcess = nextSetToProcess;
                }
            }
            this.EmployeeList.Sort();
        }

        /// <summary>
        /// Finds the ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public int FindID(int id)
        {
            int loc = -1;

            int top = 0;
            int bot = this.EmployeeList.Count - 1;

            int mid;
            do
            {
                mid = (top + bot) / 2;
                if (this.EmployeeList[mid].ReportsTo > id)
                {
                    bot = mid - 1;
                }
                else if (this.EmployeeList[mid].ReportsTo < id)
                {
                    top = mid + 1;
                }
            }
            while (bot > -1 && top < this.EmployeeList.Count && this.EmployeeList[mid].ReportsTo != id && bot >= top);
            if (this.EmployeeList[mid].ReportsTo == id)
            {
                while (mid > 0 && this.EmployeeList[mid - 1].ReportsTo == id)
                    mid--;
                loc = mid;
            }
            return loc;
        }

        /// <summary>
        /// Gets the reportees.
        /// </summary>
        /// <param name="bossID">The boss ID.</param>
        /// <returns></returns>
        public IEnumerable<EmployeeInfo> GetReportees(int bossID)
        {
            List<EmployeeInfo> list = new List<EmployeeInfo>();
            int loc = FindID(bossID);
            if (loc > -1)
            {
                while (loc < this.EmployeeList.Count && this.EmployeeList[loc].ReportsTo == bossID)
                    list.Add(this.EmployeeList[loc++]);
            }
            return list;
        }

        /// <summary>
        /// Creates the child list.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        public ObservableCollection<EmployeeInfo> CreateChildList(int count, int maxGenerations, string lastName)
        {
            ObservableCollection<EmployeeInfo> _children = new ObservableCollection<EmployeeInfo>();
            if (count > 0 && maxGenerations > 0)
            {
                _children = CreateGenericPersonData(count, maxGenerations - 1);
                foreach (EmployeeInfo p in _children)
                    p.LastName = lastName;
            }
             CityCollection = new ObservableCollection<string>();
            foreach (var item in city)
            {
                CityCollection.Add(item);
            }
            return _children;
        }

        /// <summary>
        /// Creates the generic person data.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        /// <returns></returns>
        public ObservableCollection<EmployeeInfo> CreateGenericPersonData(int count, int maxGenerations)
        {
            var personList = new ObservableCollection<EmployeeInfo>();
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var lastname = names2[random.Next(names2.GetLength(0))];
                    personList.Add(new EmployeeInfo()
                    {
                        FirstName = names1[random.Next(names1.GetLength(0))],
                        LastName = lastname,
                        ID = 1000 + i,
                        CustomerID = lastname,
                        Availability = random.Next() % 2 == 0 ? true : false,
                        Title = title[random.Next(0, 15)],
                        Children = this.CreateChildList(count, (int)Math.Max(0, maxGenerations - 1), lastname),
                        MyEyeColor = color[random.Next(color.GetLength(0))],
                        Salary = 30000d + random.Next(9) * 10000,
                        City = city[random.Next(city.GetLength(0))],
                        Discount = hike[random.Next(hike.GetLength(0))],
                        UnitPrice = 30000d + random.Next(9) * 1000,
                        Hike = random.Next(5, 10),
                        ContactNumber = 9991121234+i,
                        DOJ = new DateTime(random.Next(2008, 2012), random.Next(1, 12), random.Next(1, 28)),
                        DOB = GenerateRandomDate(),
                        ReportsTo = random.Next(0, 20),
                        OrderDate =  GenerateRandomDate().Date,
                    });
                    if (!_comboBoxItemsSource.Contains(personList.FirstOrDefault().LastName))
                        _comboBoxItemsSource.Add(personList.FirstOrDefault().LastName);
                }
            }
            return personList;
        }

        public static List<EmployeeInfo> GetEmployees()
        {
            List<EmployeeInfo> model = new List<EmployeeInfo>();
            model.Add(new EmployeeInfo() { Title = "  Management", ReportsTo = -1, ID = 2 });
            model.Add(new EmployeeInfo() { Title = "  Accounts", ReportsTo = -1, ID = 3 });
            model.Add(new EmployeeInfo() { Title = "  Sales", ReportsTo = -1, ID = 4 });
            model.Add(new EmployeeInfo() { Title = "  Back Office", ReportsTo = -1, ID = 5 });
            model.Add(new EmployeeInfo() { Title = "  Human Resource", ReportsTo = -1, ID = 6 });
            model.Add(new EmployeeInfo() { Title = "  Purchasing", ReportsTo = -1, ID = 7 });
            model.Add(new EmployeeInfo() { Title = "  Production", ReportsTo = -1, ID = 8 });

            //Management
            model.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = "Fuller", Hike = 10.00, Department = "Management", EmpId = 1001, ID = 9, Date = "01-09-1937", Rating = 5, Salary = 1200000, ReportsTo = 2, Title = "Vice President" });
            model.Add(new EmployeeInfo() { FirstName = "Janet", LastName = "Leverling", Hike = 8.00, Department = "Management", EmpId = 1002, ID = 10, Date = "05-07-1939", Rating = 4, Salary = 1000000, ReportsTo = 2, Title = "GM" });
            model.Add(new EmployeeInfo() { FirstName = "Steven", LastName = "Buchanan", Hike = 7.00, Department = "Management", EmpId = 1003, ID = 11, Date = "02-05-1940", Rating = 4, Salary = 900000, ReportsTo = 2, Title = "Manager" });

            //Accounts
            model.Add(new EmployeeInfo() { FirstName = "Nancy", LastName = "Davolio", Hike = 7.20, Department = "Accounts", EmpId = 1004, ID = 12, Date = "02-05-1940", Rating = 5, Salary = 850000, ReportsTo = 3, Title = "Accounts Manager" });
            model.Add(new EmployeeInfo() { FirstName = "Margaret", LastName = "Peacock", Hike = 6.90, Department = "Accounts", EmpId = 1008, ID = 13, Date = "01-09-1945", Rating = 3, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
            model.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Suyama", Hike = 6.90, Department = "Accounts", EmpId = 1009, ID = 14, Date = "02-09-1945", Rating = 5, Salary = 700000, ReportsTo = 3, Title = "Accountant" });
            model.Add(new EmployeeInfo() { FirstName = "Robert", LastName = "King", Hike = 5.70, Department = "Accounts", EmpId = 1010, ID = 15, Date = "02-09-1945", Rating = 3, Salary = 650000, ReportsTo = 3, Title = "Accountant" });

            //Sales
            model.Add(new EmployeeInfo() { FirstName = "Laura", LastName = "Callahan", Hike = 8.20, Department = "Sales", EmpId = 1005, ID = 16, Date = "07-01-1942", Rating = 5, Salary = 900000, ReportsTo = 4, Title = "Sales Manager" });
            model.Add(new EmployeeInfo() { FirstName = "Anne", LastName = "Dodsworth", Hike = 8.00, Department = "Sales", EmpId = 1011, ID = 17, Date = "02-10-1945", Rating = 4, Salary = 800000, ReportsTo = 4, Title = "Sales Representative" });
            model.Add(new EmployeeInfo() { FirstName = "Albert", LastName = "Hellstern", Hike = 6.90, Department = "Sales", EmpId = 1012, ID = 18, Date = "02-10-1945", Rating = 5, Salary = 750000, ReportsTo = 4, Title = "Sales Representative" });
            model.Add(new EmployeeInfo() { FirstName = "Tim", LastName = "Smith", Hike = 5.23, Department = "Sales", EmpId = 1013, ID = 19, Date = "03-11-1945", Rating = 5, Salary = 700000, ReportsTo = 4, Title = "Sales Representative" });
            model.Add(new EmployeeInfo() { FirstName = "Justin", LastName = "BrId", Hike = 6.00, Department = "Sales", EmpId = 1014, ID = 20, Date = "03-11-1945", Rating = 5, Salary = 700000, ReportsTo = 4, Title = "Sales Representative" });

            //Back Office
            model.Add(new EmployeeInfo() { FirstName = "Caroline", LastName = "Patterson", Hike = 6.00, Department = "BackOffice", EmpId = 1006, ID = 21, Date = "07-01-1942", Rating = 5, Salary = 800000, ReportsTo = 5, Title = "Receptionist" });
            model.Add(new EmployeeInfo() { FirstName = "Xavier", LastName = "Martin", Hike = 3.00, Department = "BackOffice", EmpId = 1015, ID = 22, Date = "01-09-1946", Rating = 5, Salary = 700000, ReportsTo = 5, Title = "Mail Clerk" });

            //HR
            model.Add(new EmployeeInfo() { FirstName = "Laurent", LastName = "Pereira", Hike = 6.60, Department = "HumanResource", EmpId = 1007, ID = 23, Date = "01-09-1942", Rating = 5, Salary = 900000, ReportsTo = 6, Title = "HR Manager" });
            model.Add(new EmployeeInfo() { FirstName = "Syed", LastName = "Abbas", Hike = 6.20, Department = "HumanResource", EmpId = 1016, ID = 24, Date = "04-02-1947", Rating = 5, Salary = 650000, ReportsTo = 6, Title = "HR Assistant" });
            model.Add(new EmployeeInfo() { FirstName = "Amy", LastName = "Alberts", Hike = 6.00, Department = "HumanResource", EmpId = 1017, ID = 25, Date = "04-02-1947", Rating = 5, Salary = 650000, ReportsTo = 6, Title = "HR Assistant" });

            //Purchasing

            model.Add(new EmployeeInfo() { FirstName = "Pamela", LastName = "Ansman-Wolfe", Hike = 7.60, Department = "Purchasing", EmpId = 1018, ID = 26, Date = "04-02-1947", Rating = 3, Salary = 600000, ReportsTo = 7, Title = "Purchase Manager" });
            model.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Blythe", Hike = 6.02, Department = "Purchasing", EmpId = 1019, ID = 27, Date = "04-02-1947", Rating = 2, Salary = 550000, ReportsTo = 7, Title = "Store Keeper" });
            model.Add(new EmployeeInfo() { FirstName = "DavId", LastName = "Campbell", Hike = 6.00, Department = "Purchasing", EmpId = 1020, ID = 28, Date = "05-08-1949", Rating = 3, Salary = 450000, ReportsTo = 7, Title = "Store Keeper" });

            //Production
            model.Add(new EmployeeInfo() { FirstName = "Jillian", LastName = "Carson", Hike = 5.00, Department = "Production", EmpId = 1021, ID = 29, Date = "05-08-1949", Rating = 3, Salary = 600000, ReportsTo = 8, Title = "Production Manager" });
            model.Add(new EmployeeInfo() { FirstName = "Shu", LastName = "Ito", Hike = 6.20, Department = "Production", EmpId = 1022, ID = 30, Date = "06-01-1952", Rating = 2, Salary = 550000, ReportsTo = 8, Title = "Production Engineer" });
            model.Add(new EmployeeInfo() { FirstName = "Stephen", LastName = "Jiang", Hike = 6.00, Department = "Production", EmpId = 1023, ID = 31, Date = "06-01-1952", Rating = 3, Salary = 450000, ReportsTo = 8, Title = "Production Engineer" });


            return model;
        } 

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns></returns>
        public List<EmployeeInfo> GetEmployeesInfo()
        {
            List<EmployeeInfo> model = new List<EmployeeInfo>();
            model.Add(new EmployeeInfo() { Title = "General Manager", ReportsTo = -1, ID = 2, FirstName = "Sean", LastName = "Jacobson", EmpId = 1001, Salary = 200000 });
            model.Add(new EmployeeInfo() { Title = "Accounts Manager", ReportsTo = -1, ID = 3, FirstName = "Phyllis", LastName = "Allen", EmpId = 1002, Salary = 175000 });
            model.Add(new EmployeeInfo() { Title = "Sales Manager", ReportsTo = -1, ID = 4, FirstName = "Oscar", LastName = "Alpuerto", EmpId = 1003, Salary = 150000 });
            model.Add(new EmployeeInfo() { Title = "Marketing Manager", ReportsTo = -1, ID = 5, FirstName = "Maxwell", LastName = "Amland", EmpId = 1004, Salary = 140000 });
            model.Add(new EmployeeInfo() { Title = "Human Resources Manager", ReportsTo = -1, ID = 6, FirstName = "Emiliya", LastName = "Alvaro", EmpId = 1005, Salary = 135000 });
            model.Add(new EmployeeInfo() { Title = "Advertising Manager", ReportsTo = -1, ID = 7, FirstName = "Carla", LastName = "Adams", EmpId = 1006, Salary = 125000 });
            model.Add(new EmployeeInfo() { Title = "Production Manager", ReportsTo = -1, ID = 8, FirstName = "John", LastName = "Ault", EmpId = 1007, Salary = 125000 });
            //Management

            model.Add(new EmployeeInfo() { FirstName = "Robert", LastName = "Fuller", EmpId = 1008, Salary = 1200000, Title = "Design Engineer", ID = 9, ReportsTo = 2 });
            model.Add(new EmployeeInfo() { FirstName = "Janet", LastName = "Leverling", EmpId = 1009, Salary = 1000000, Title = "Engineering Manager", ID = 10, ReportsTo = 2 });
            model.Add(new EmployeeInfo() { FirstName = "Steven", LastName = "Buchanan", EmpId = 1010, Salary = 900000, Title = "Business Manager", ID = 11, ReportsTo = 2 });

            //Accounts
            model.Add(new EmployeeInfo() { FirstName = "Nancy", LastName = "Davolio", EmpId = 1011, Salary = 850000, Title = "Accounts Supervisor", ID = 12, ReportsTo = 3 });
            model.Add(new EmployeeInfo() { FirstName = "Margaret", LastName = "Peacock", EmpId = 1012, Salary = 700000, Title = "Accounts Representative", ID = 13, ReportsTo = 3 });
            model.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Suyama", EmpId = 1013, Salary = 700000, Title = "Accounts Coordinator", ID = 14, ReportsTo = 3 });
            model.Add(new EmployeeInfo() { FirstName = "Andrew", LastName = "King", EmpId = 1014, Salary = 650000, Title = "Accountant", ID = 15, ReportsTo = 3 });

            //Sales
            model.Add(new EmployeeInfo() { FirstName = "SIMOB", LastName = "Callahan", EmpId = 1015, Salary = 900000, Title = "Sales Representative", ID = 16, ReportsTo = 4 });
            model.Add(new EmployeeInfo() { FirstName = "Anne", LastName = "Dodsworth", EmpId = 1016, Salary = 800000, Title = "Sales Coordinator", ID = 17, ReportsTo = 4 });
            model.Add(new EmployeeInfo() { FirstName = "Albert", LastName = "Hellstern", EmpId = 1017, Salary = 750000, Title = "Sales Representative", ID = 18, ReportsTo = 4 });
            model.Add(new EmployeeInfo() { FirstName = "Seves", LastName = "Smith", EmpId = 1018, Salary = 700000, Title = "Inside Sales Coordinator", ID = 19, ReportsTo = 4 });
            model.Add(new EmployeeInfo() { FirstName = "Justin", LastName = "Brid", EmpId = 1019, Salary = 700000, Title = "Sales Supervisor", ID = 20, ReportsTo = 4 });

            //Back Office
            model.Add(new EmployeeInfo() { FirstName = "Caroline", LastName = "Patterson", EmpId = 1020, Salary = 800000, Title = "Marketing Director", ID = 21, ReportsTo = 5 });
            model.Add(new EmployeeInfo() { FirstName = "Hill", LastName = "Martin", EmpId = 1021, Salary = 700000, Title = "Marketing Associate", ID = 22, ReportsTo = 5 });

            //HR
            model.Add(new EmployeeInfo() { FirstName = "Albert", LastName = "Pereira", EmpId = 1022, Salary = 900000, Title = "HR Coordinator", ID = 23, ReportsTo = 6 });
            model.Add(new EmployeeInfo() { FirstName = "Hawkin", LastName = "Abbas", EmpId = 1023, Salary = 650000, Title = "HR Assistant", ID = 24, ReportsTo = 6 });
            model.Add(new EmployeeInfo() { FirstName = "Amy", LastName = "Alberts", EmpId = 1024, Salary = 650000, Title = "HR Assistant", ID = 25, ReportsTo = 6 });

            //Purchasing

            model.Add(new EmployeeInfo() { FirstName = "SIMOB", LastName = "Ansman-Wolfe", EmpId = 1025, Salary = 600000, Title = "Advertising Director", ID = 26, ReportsTo = 7 });
            model.Add(new EmployeeInfo() { FirstName = "Michael", LastName = "Blythe", EmpId = 1026, Salary = 550000, Title = "Advertising Coordinator", ID = 27, ReportsTo = 7 });
            model.Add(new EmployeeInfo() { FirstName = "Seves", LastName = "Campbell", EmpId = 1027, Salary = 450000, Title = "Advertising Specialist", ID = 28, ReportsTo = 7 });

            //Production
            model.Add(new EmployeeInfo() { FirstName = "Janet", LastName = "Carson", EmpId = 1028, Salary = 600000, Title = "Production Supervisor", ID = 29, ReportsTo = 8 });
            model.Add(new EmployeeInfo() { FirstName = "Caroline", LastName = "Ito", EmpId = 1029, Salary = 550000, Title = "Production Technician", ID = 30, ReportsTo = 8 });
            model.Add(new EmployeeInfo() { FirstName = "Steven", LastName = "Jiang", EmpId = 1030, Salary = 450000, Title = "Production Control Manager", ID = 31, ReportsTo = 8 });

            return model;
        }

        /// <summary>
        /// Generates the random date.
        /// </summary>
        /// <returns></returns>
        internal DateTime GenerateRandomDate()
        {
            int randInt = random.Next(4000);
            return DateTime.Now.AddDays(-8000 + randInt);
        }

        #endregion
        #region Filtering
        internal FilterChanged filterChanged;

        private bool MakeStringFilter(EmployeeInfo o, string option, string condition)
        {
            var value = o.GetType().GetProperty(option);
            var exactValue = value.GetValue(o, null);
            exactValue = exactValue.ToString().ToLower();
            string text = FilterText.ToLower();
            var methods = typeof(string).GetMethods();
            if (methods.Count() != 0)
            {
                var methodInfo = methods.FirstOrDefault(method => method.Name == condition);
                bool result1 = (bool)methodInfo.Invoke(exactValue, new object[] { text });
                return result1;
            }
            else
                return false;
        }

        private bool MakeNumericFilter(EmployeeInfo o, string option, string condition)
        {
            var value = o.GetType().GetProperty(option);
            var exactValue = value.GetValue(o, null);
            double res;
            bool checkNumeric = double.TryParse(exactValue.ToString(), out res);
            if (checkNumeric)
            {
                switch (condition)
                {
                    case "Equals":
                        if (Convert.ToDouble(exactValue) == (Convert.ToDouble(FilterText)))
                            return true;
                        break;
                    case "GreaterThan":
                        if (Convert.ToDouble(exactValue) > Convert.ToDouble(FilterText))
                            return true;
                        break;
                    case "LessThan":
                        if (Convert.ToDouble(exactValue) < Convert.ToDouble(FilterText))
                            return true;
                        break;
                    case "NotEquals":
                        if (Convert.ToDouble(FilterText) != Convert.ToDouble(exactValue))
                            return true;
                        break;
                }
            }
            return false;
        }

        public bool FilerRecords(object o)
        {
            double res;
            bool checkNumeric = double.TryParse(FilterText, out res);
            var item = o as EmployeeInfo;
            if (item != null && FilterText.Equals(""))
            {
                return true;
            }
            else
            {
                if (item != null)
                {
                    if (checkNumeric && FilterOption.Equals("ContactNumber"))
                    {
                        bool result = MakeStringFilter(item, FilterOption, FilterCondition);
                        return result;
                    }
                    else if (checkNumeric && !FilterOption.Equals("AllColumns"))
                    {
                        if (FilterCondition == null || FilterCondition.Equals("Contains") || FilterCondition.Equals("StartsWith") || FilterCondition.Equals("EndsWith"))
                            FilterCondition = "Equals";
                        bool result = MakeNumericFilter(item, FilterOption, FilterCondition);
                        return result;
                    }
                    else if (FilterOption.Equals("AllColumns"))
                    {
                        if (item.FirstName.ToLower().Contains(FilterText.ToLower()) ||
                            // item.LastName.ToLower().Contains(FilterText.ToLower()) || item.ContactNumber.ToLower().Contains(FilterText.ToLower()) || item.DOB.ToString().ToLower().Contains(FilterText.ToLower()) || 
                            item.LastName.ToLower().Contains(FilterText.ToLower()) || item.ContactNumber.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.Salary.ToString().ToLower().Contains(FilterText.ToLower()) || item.ID.ToString().ToLower().Contains(FilterText.ToLower()) ||
                            item.City.ToLower().Contains(FilterText.ToLower()))
                            return true;
                        return false;
                    }
                    else
                    {
                        if (FilterCondition == null || FilterCondition.Equals("Equals") || FilterCondition.Equals("LessThan") || FilterCondition.Equals("GreaterThan") || FilterCondition.Equals("NotEquals"))
                            FilterCondition = "Contains";
                        bool result = MakeStringFilter(item, FilterOption, FilterCondition);
                        return result;
                    }
                }
            }
            return false;
        }

        private string filterOption = "AllColumns";

        public string FilterOption
        {
            get { return filterOption; }
            set
            {
                filterOption = value.Replace(" ", "");
                if (filterChanged != null)
                    filterChanged();
                RaisePropertyChanged("FilterOption");
            }
        }

        private string filterText = string.Empty;

        public string FilterText
        {
            get { return filterText; }
            set
            {
                filterText = value;
                if (filterChanged != null)
                    filterChanged();
                RaisePropertyChanged("FilterText");
            }
        }

        private string filterCondition;

        public string FilterCondition
        {
            get { return filterCondition; }
            set
            {
                filterCondition = value.Replace(" ", "");
                if (filterChanged != null)
                    filterChanged();
                RaisePropertyChanged("FilterCondition");
            }
        }
        #endregion

        #region Array Collection

        internal string[] city = new string[]
      {
            "NewYork",
            "San Francisco",
            "Delhi",
            "Brisbane",
            "Tokyo",
            "Rome",
            "Durban",
            "Canberra",
            "Sydney",
            "London",
            "Manchester",
            "Birmingham",
            "Liverpool",
            "Cardiff",
            "Adelaide",
            "Perth",
            "Zurich",
            "Madrid",
            "Barcelona"
      };

        internal static string[] names1 = new string[]{
            "George","John","Thomas","James","Andrew","Martin","William","Zachary",
            "Millard","Franklin","Abraham","Ulysses","Rutherford","Chester","Grover","Benjamin",
            "Theodore","Woodrow","Warren","Calvin","Herbert","Franklin","Harry","Dwight","Lyndon",
            "Gerald","Jimmy","Ronald","George","Bill", "Barack", "Warner","Peter", "Larry"
        };

        internal static string[] names2 = new string[]{
             "Washington","Adams","Jefferson","Madison","Monroe","Jackson","Van Buren","Harrison","Tyler",
             "Polk","Taylor","Fillmore","Pierce","Buchanan","Lincoln","Johnson","Grant","Hayes","Garfield",
             "Arthur","Cleveland","Harrison","McKinley","Roosevelt","Taft","Wilson","Harding","Coolidge",
             "Hoover","Truman","Eisenhower","Kennedy","Johnson","Nixon","Ford","Carter","Reagan","Bush",
             "Clinton","Bush","Obama","Smith","Jones","Stogner"
        };

        internal static string[] dept = new string[]{
              "Accounts","Sales","BackOffice","HumanResource","Purchasing","Production"
        };

        internal static string[] title = new string[]
        {
            "Engineering Manager","Production Control Manager","Design Engineer","Network Administrator",
            "Stocker","Shipping and Receiving Clerk","Production Technician","Master Scheduler",
            "Marketing Specialist","Recruiter","Maintenance Supervisor","Marketing Assistant","Tool Designer",
             "Senior Tool Designer","Quality Assurance Supervisor","Information Services Manager"
        };

        internal string[] mail = new string[]
       {
            "gmail", "yahoo", "msn", "hotmail","ymail", "live"
       };

        internal string[] contactNos = new string[] {
        "(833) 215-6503",
        "(855) 727-4387",
        "(844) 479-2783",
        "(855) 055-5922",
        "(899) 378-8810",
        "(833) 389-76618",
        "(855) 313-1072",
        "(899) 287-1193",
        "(844) 613-4240",
        "(833) 293-9651",
        "(899) 751-7249",
        "(833) 266-3598",
        "(855) 117-36707",
        "(811) 638-39931",
        "(833) 444-7832",
        "(899) 995-59379",
        "(899) 544-1240",
        "(811) 892-78532",
        "(844) 080-8130",
        "(899) 256-2942"
        };

        internal static double[] hike = new double[]{
            6,5.5,10,10.2,11, 15, 6.8,14,7.7,9.5,8.2,16
        };

        internal static string[] color = new string[]{
            "Red", "Blue", "Brown", "Unknown"
        };
        #endregion
    }

    internal delegate void FilterChanged();
}