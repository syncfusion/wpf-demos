#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
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
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for Slicer.xaml
    /// </summary>
    public partial class Slicer : DemoControl
    {      
        ExcelEngine excelEngine;        
        string fileName = "Slicer.xlsx";

        #region Constructor
        public Slicer()
        {
            InitializeComponent();
            this.DataContext = this;

            string[] columnNames = { "Requester", "Assignee", "Status"};            
            for (int i = 0; i < columnNames.Length; i++)
            {
                numColumn.Items.Add(columnNames[i]);
                numSecCol.Items.Add(columnNames[i]);
                
            }
            numColumn.SelectedIndex = 0;
            numSecCol.SelectedIndex = 2;           
            excelEngine = new ExcelEngine();
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            excelEngine.Dispose();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\XlsIO\TableSlicer.xlsx")
            {
                UseShellExecute = true
            };
            process.Start();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            CreateSlicer(fileName);
            try
            {               

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName)
                        {
                            UseShellExecute = true
                        };
                        process.Start();
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("Excel 2007 is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }
        private void CreateSlicer(string outFileName)
        {
            IWorkbook book = excelEngine.Excel.Workbooks.Open(@"Assets\XlsIO\TableSlicer.xlsx", ExcelOpenType.Automatic);
            IWorksheet sheet = book.Worksheets[0];
            IListObject table = sheet.ListObjects[0];
                        
            //Get the column id from the given column name
            int colId1 = GetColumnId(numColumn.SelectedValue.ToString(), table);
            int colId2 = GetColumnId(numSecCol.SelectedValue.ToString(), table);

            // Add slicer for the table
            sheet.Slicers.Add(table, colId1, 11, 2);
            sheet.Slicers.Add(table, colId2, 11, 4);
            sheet.Slicers[0].Width = 300;
            sheet.Slicers[0].Height = 400;
            sheet.Slicers[1].Width = 300;
            sheet.Slicers[1].Height = 400;

            book.SaveAs(outFileName);
            book.Close();
        }

        #region Helper Methods
        private int GetColumnId(string columnName, IListObject table)
        {
            int colId = 0;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (table.Columns[i].Name == columnName)
                {
                    colId = i + 1;
                    break;
                }
            }
            return colId;
        }
        #endregion


    }
}
