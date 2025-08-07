#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Diagnostics;
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
using Syncfusion.XlsIO;
using System.Data;
using Syncfusion.Calculate;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for ComputeSpecificFormula.xaml
    /// </summary>
    public partial class ComputeSpecificFormula : DemoControl
    {
        # region Private Members        
        ExcelEngine eng;
        IWorkbook workBook;
        CalcEngine calcEngine;
        # endregion

        # region Constructor
        /// <summary>
        /// ComputeSpecificFormula constructor
        /// </summary>
        public ComputeSpecificFormula()
        {
            InitializeComponent();
        }
        # endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        # region Events
        /// <summary>
        /// View the sample spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\XlsIO\Input.xls")
            {
                UseShellExecute = true
            };
            process.Start();
        }

        /// <summary>
        /// Imports to table using Essential XlsIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            eng = new ExcelEngine();
            workBook = eng.Excel.Workbooks.Open(@"Assets\XlsIO\Input.xls");
            IWorksheet sheet = workBook.Worksheets[0];
            IWorksheet sheet2 = workBook.Worksheets[1];
            
            //Enable to calculate formulas in the sheet
            sheet.EnableSheetCalculations();

			//Assign the sheet calculation engine.
            calcEngine = sheet.CalcEngine;

            //Load the datagrids with the data from Xls file.
            DataTable dt = new DataTable("Input Data");
            dt = sheet.ExportDataTable(1, 1, 15, 5, ExcelExportDataTableOptions.None);

            //Updates the listview
            UpdateTable(dt, 0);

            DataTable dt2 = new DataTable("Sheet2 Data");
            dt2 = sheet2.ExportDataTable(1, 1, 15, 8, ExcelExportDataTableOptions.None);

            UpdateTable(dt2, 1);

            this.btnImport.IsEnabled = false;
            this.tabControl.IsEnabled = true;
        }

        /// <summary>
        /// Computes the formula based on selection in listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Clear the textbox
            txtCompute.Clear();
            if (tabControl.SelectedIndex == 0)
            {
                DataRowView rowView = e.AddedItems[0] as DataRowView;

                //Update the computed value
                txtCompute.Text = rowView.Row.ItemArray[3].ToString().TrimStart('=') + " = " + calcEngine.ParseAndComputeFormula(rowView.Row.ItemArray[3].ToString()) + "\n" + rowView.Row.ItemArray[4].ToString().TrimStart('=') + " = " + calcEngine.ParseAndComputeFormula(rowView.Row.ItemArray[4].ToString());
            }
            else
                txtCompute.Text = "Selected Row does not contain any formula";
            e.Handled = true;
        }

        /// <summary>
        /// Explicitly closes the workbook and engine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (eng != null)
            {
                workBook.Close();
                eng.Dispose();
            }
        }
        # endregion

        # region Helper Methods
        /// <summary>
        /// Updates the table with the Datatable
        /// </summary>
        /// <param name="customersTable"></param>
        private void UpdateTable(DataTable customersTable, int tabItemNum)
        {
            char name = 'A';

            //Create a grid view
            GridView gridView1 = new GridView();
            gridView1.AllowsColumnReorder = true;

            //Update the grid view columns
            foreach (DataColumn column in customersTable.Columns)
            {
                GridViewColumn column1 = new GridViewColumn();
                column1.DisplayMemberBinding = new Binding(column.ColumnName);
                column1.Header = name.ToString();
                if (tabItemNum == 1)
                    column1.Width = tabControl.Width / customersTable.Columns.Count;
                gridView1.Columns.Add(column1);
                name++;
            }

            //Bind the listview
            Binding bind = new Binding();
            TabItem tabItem = tabControl.Items[tabItemNum] as TabItem;
            ListView listView = new ListView();
            tabItem.Content = listView;
            listView.DataContext = customersTable;
            listView.SetBinding(ListView.ItemsSourceProperty, bind);

            //Use gridview as listview item
            listView.View = gridView1;
            listView.SelectionChanged += new SelectionChangedEventHandler(listView_SelectionChanged);
        }
        # endregion
    }
}