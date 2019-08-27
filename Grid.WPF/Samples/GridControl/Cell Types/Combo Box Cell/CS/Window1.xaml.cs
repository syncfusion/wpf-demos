#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Grid;
using System.Collections.Specialized;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.Cells;
using System.IO;
using Syncfusion.Windows.GridCommon;


namespace GridComboBox_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        Northwind northWind;
        public Window1()
        {
            InitializeComponent();

            string connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
            northWind = new Northwind(connectionString);

            this.grid.Model.RowCount = 35;
            this.grid.Model.ColumnCount = 25;
            this.grid.Model.ColumnWidths[1] = 100d;
            this.grid.Model.ColumnWidths[2] = 200d;

            grid.Model[1, 1].Foreground = Brushes.Black;
            grid.Model[1, 1].Background = Brushes.LightBlue;
            grid.Model[1, 1].Font.FontSize = 13;
            grid.Model[1, 1].HorizontalAlignment = HorizontalAlignment.Left;
            grid.Model[1, 1].Font.FontWeight = FontWeights.Bold;

            grid.Model[6, 1].Foreground = Brushes.Black;
            grid.Model[6, 1].Background = Brushes.LightBlue;
            grid.Model[6, 1].Font.FontSize = 13;
            grid.Model[6, 1].HorizontalAlignment = HorizontalAlignment.Left;
            grid.Model[6, 1].Font.FontWeight = FontWeights.Bold;

            grid.Model[6, 1].Foreground = Brushes.Black;
            grid.Model[6, 1].Background = Brushes.LightBlue;
            grid.Model[6, 1].Font.FontSize = 13;
            grid.Model[6, 1].HorizontalAlignment = HorizontalAlignment.Left;
            grid.Model[6, 1].Font.FontWeight = FontWeights.Bold;

            grid.Model[12, 1].Foreground = Brushes.Black;
            grid.Model[12, 1].Background = Brushes.LightBlue;
            grid.Model[12, 1].Font.FontSize = 13;
            grid.Model[12, 1].HorizontalAlignment = HorizontalAlignment.Left;
            grid.Model[12, 1].Font.FontWeight = FontWeights.Bold;

            grid.Model[17, 1].Foreground = Brushes.Black;
            grid.Model[17, 1].Background = Brushes.LightBlue;
            grid.Model[17, 1].Font.FontSize = 13;
            grid.Model[17, 1].HorizontalAlignment = HorizontalAlignment.Left;
            grid.Model[17, 1].Font.FontWeight = FontWeights.Bold;

            this.AddComboBoxes();
            this.AddDropDownLists();
            this.AddComboBoxesChoiceList();
            this.AddDropDownWithoutValueMember();            
         }

        private static string FindFile(string fileName)
        {
            // Check both in parent folder and Parent\Data folders.
            string dataFileName = @"Common\Data\" + fileName;
            for (int n = 0; n < 12; n++)
            {
                if (System.IO.File.Exists(fileName))
                {
                    return new FileInfo(fileName).FullName;
                }
                if (System.IO.File.Exists(dataFileName))
                {
                    return new FileInfo(dataFileName).FullName;
                }
                fileName = @"..\" + fileName;
                dataFileName = @"..\" + dataFileName;
            }

            return fileName;
        }


        private void AddDropDownWithoutValueMember()
        {
            
            this.grid.Model[17, 1].CellValue = "Drop-down List Control types without Value Member";
            this.grid.Model[17, 1].CellType = "Static";
            this.grid.Model[18, 1].CellValue = "Editable ";
            this.grid.Model[19, 1].CellValue = "AutoComplete";
            this.grid.Model[20, 1].CellValue = "Exclusive";

            var dropdown1 = this.grid.Model[18, 2];
            dropdown1.CellType = "DropDownList";
            dropdown1.ItemsSource = northWind.Employees.Select(emp =>
                    new
                    {
                        EmployeeID = emp.EmployeeID,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        Phone = emp.HomePhone
                    }).ToList();
            dropdown1.DisplayMember = "FirstName";
            dropdown1.DropDownStyle = GridDropDownStyle.Editable;

            var dropdown2 = this.grid.Model[19, 2];
            dropdown2.CellType = "DropDownList";
            dropdown2.ItemsSource = northWind.Employees.Select(emp =>
                    new
                    {
                        EmployeeID = emp.EmployeeID,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        Phone = emp.HomePhone
                    }).ToList();
            dropdown2.DisplayMember = "FirstName";
            dropdown2.DropDownStyle = GridDropDownStyle.AutoComplete;

            var dropdown3 = this.grid.Model[20, 2];
            dropdown3.CellType = "DropDownList";
            dropdown3.ItemsSource = northWind.Employees.Select(emp =>
                    new
                    {
                        EmployeeID = emp.EmployeeID,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        Phone = emp.HomePhone
                    }).ToList();
            dropdown3.DisplayMember = "FirstName";
            dropdown3.DropDownStyle = GridDropDownStyle.Exclusive;

        }

        private void AddComboBoxesChoiceList()
        {
            StringCollection list = new StringCollection();

            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list.Add("Four");
            list.Add("Five");

            this.grid.Model[12, 1].CellValue = "Combo Box using choice List";
            this.grid.Model[12, 1].CellType = "Static";
            this.grid.Model[13, 1].CellValue = "Editable";
            this.grid.Model[14, 1].CellValue = "AutoComplete";
            this.grid.Model[15, 1].CellValue = "Exclusive";

            var combo1 = this.grid.Model[13, 2];
            combo1.CellType = "ComboBox";
            combo1.ChoiceList = list;
            combo1.DropDownStyle = GridDropDownStyle.Editable;

            var combo2 = this.grid.Model[14, 2];
            combo2.CellType = "ComboBox";
            combo2.ChoiceList = list;
            combo2.DropDownStyle = GridDropDownStyle.AutoComplete;

            var combo3 = this.grid.Model[15, 2];
            combo3.CellType = "ComboBox";
            combo3.ChoiceList = list;
            combo3.DropDownStyle = GridDropDownStyle.Exclusive;




        }

        private void AddComboBoxes()
        {
            this.grid.Model[1, 1].CellValue = "Combo Box types";
            this.grid.Model[1, 1].CellType = "Static";
            this.grid.Model[2, 1].CellValue = "Editable";
            this.grid.Model[3, 1].CellValue = "AutoComplete";
            this.grid.Model[4, 1].CellValue = "Exclusive";
            var combo1 = this.grid.Model[2, 2];

            this.grid.Model.QueryCoveredRange += new GridQueryCoveredRangeEventHandler(Model_QueryCoveredRange);

            combo1.CellType = "ComboBox";
            combo1.ItemsSource = northWind.Employees.Select(emp => emp.FirstName).ToList();
            combo1.DropDownStyle = GridDropDownStyle.Editable;

            var combo2 = this.grid.Model[3, 2];
            combo2.CellType = "ComboBox";
            combo2.ItemsSource = northWind.Employees.Select(emp => emp.FirstName).ToList();
            combo2.DropDownStyle = GridDropDownStyle.AutoComplete;

            var combo3 = this.grid.Model[4, 2];
            combo3.CellType = "ComboBox";
            combo3.ItemsSource = northWind.Employees.Select(emp => emp.FirstName).ToList();
            combo3.DropDownStyle = GridDropDownStyle.Exclusive;


            this.grid.Model[6, 1].CellValue = "Combo Box For Customers Table";
            this.grid.Model[7, 1].CellValue = "Editable";
            this.grid.Model[8, 1].CellValue = "AutoComplete";
            this.grid.Model[9, 1].CellValue = "Exclusive";

            var combo5 = this.grid.Model[7, 2];
            combo5.CellType = "ComboBox";
            combo5.ItemsSource = northWind.Customers.Select(cust => cust.ContactName).ToList();
            combo5.DropDownStyle = GridDropDownStyle.Editable;

            var combo6 = this.grid.Model[8, 2];
            combo6.CellType = "ComboBox";
            combo6.ItemsSource = northWind.Customers.Select(cust => cust.ContactName).ToList();
            combo6.DropDownStyle = GridDropDownStyle.AutoComplete;

            var combo7 = this.grid.Model[9, 2];
            combo7.CellType = "ComboBox";
            combo7.ItemsSource = northWind.Customers.Select(cust => cust.ContactName).ToList();
            combo7.DropDownStyle = GridDropDownStyle.Exclusive;
        }

        private void AddDropDownLists()
        {
            this.grid.Model[6, 1].CellValue = "Drop-down List Control types";
            this.grid.Model[6, 1].CellType = "Static";
            this.grid.Model[7, 1].CellValue = "Editable";
            this.grid.Model[8, 1].CellValue = "AutoComplete";
            this.grid.Model[9, 1].CellValue = "Exclusive";

            var dropdown1 = this.grid.Model[7, 2];
            dropdown1.CellType = "DropDownList";
            dropdown1.ItemsSource = northWind.Employees.Select(emp =>
                    new
                    {
                        EmployeeID = emp.EmployeeID,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        Phone = emp.HomePhone
                    }).ToList();
            dropdown1.DisplayMember = "FirstName";
            dropdown1.ValueMember = "EmployeeID";
            dropdown1.DropDownStyle = GridDropDownStyle.Editable;

            var dropdown2 = this.grid.Model[8, 2];
            dropdown2.CellType = "DropDownList";
            dropdown2.ItemsSource = northWind.Employees.Select(emp =>
                    new
                    {
                        EmployeeID = emp.EmployeeID,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        Phone = emp.HomePhone
                    }).ToList();
            dropdown2.DisplayMember = "FirstName";
            dropdown2.ValueMember = "EmployeeID";
            dropdown2.DropDownStyle = GridDropDownStyle.AutoComplete;

            var dropdown3 = this.grid.Model[9, 2];
            dropdown3.CellType = "DropDownList";
            dropdown3.ItemsSource = northWind.Employees.Select(emp =>
                    new
                    {
                        EmployeeID = emp.EmployeeID,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        Phone = emp.HomePhone
                    }).ToList();
            dropdown3.DisplayMember = "FirstName";
            dropdown3.ValueMember = "EmployeeID";
            dropdown3.DropDownStyle = GridDropDownStyle.Exclusive;
        }

        void Model_QueryCoveredRange(object sender, GridQueryCoveredRangeEventArgs e)
        {
            if (e.CellRowColumnIndex.RowIndex == 1 && e.CellRowColumnIndex.ColumnIndex == 1)
            {
                e.Range = new Syncfusion.Windows.Controls.Cells.CoveredCellInfo(1, 1, 1, this.grid.Model.ColumnCount);
                e.Handled = true;
            }
            else if (e.CellRowColumnIndex.RowIndex == 6 && e.CellRowColumnIndex.ColumnIndex == 1)
            {
                e.Range = new Syncfusion.Windows.Controls.Cells.CoveredCellInfo(6, 1, 6, this.grid.Model.ColumnCount);
                e.Handled = true;
            }

            else if (e.CellRowColumnIndex.RowIndex == 12 && e.CellRowColumnIndex.ColumnIndex == 1)
            {
                e.Range = new Syncfusion.Windows.Controls.Cells.CoveredCellInfo(12, 1, 12, this.grid.Model.ColumnCount);
                e.Handled = true;
            }

            else if (e.CellRowColumnIndex.RowIndex == 17 && e.CellRowColumnIndex.ColumnIndex == 1)
            {
                e.Range = new Syncfusion.Windows.Controls.Cells.CoveredCellInfo(17, 1, 17, this.grid.Model.ColumnCount);
                e.Handled = true;
            }
        }

    }
}

