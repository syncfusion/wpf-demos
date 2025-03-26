#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
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
using System.Diagnostics;
using Syncfusion.XlsIO;
using Syncfusion.Windows.Shared;
using System.Data;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for Performance.xaml
    /// </summary>
    public partial class Performance : DemoControl
    {
        # region Private Members
        //Measurement variables.
        DateTime startTime;
        TimeSpan endTime;
        int rowCount;
        int colCount;
        private string fileName;
        TextBox textLog = new TextBox();
        # endregion

        # region Constructor
        /// <summary>
        /// Performance Constructor
        /// </summary>
        public Performance()
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
        /// Creates spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!(int.TryParse(txtboxRows.Text, out rowCount) && int.TryParse(txtboxColumns.Text, out colCount)))
            {
                MessageBox.Show("Enter Numerical Value");
                return;
            }

            if (rowCount <= 0 )
            {   
                MessageBox.Show("Invalid row count");
                return;
            }

            if (colCount <= 0)
            {
                MessageBox.Show("Invalid column count");
                return;
            }
            if (rdbtnXls.IsChecked.Value)
            {
                if (colCount > 256)
                {
                    MessageBox.Show("Column count must be less than or equal to 256 for Excel 2003 format.");
                    return;
                }
                if (rowCount > 65536)
                {
                    MessageBox.Show("Row count must be less than or equal to 65,536 for Excel 2003 format.");
                    return;
                }
            }
            if (rdbtnXlsx.IsChecked.Value)
            {
                if (rowCount > 100001)
                {
                    MessageBox.Show("Row count must be less than or equal to 100,000.");
                    return;
                }
                if (colCount > 151)
                {
                    MessageBox.Show("Column count must be less than or equal to 151.");
                    return;
                }
            }
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            if (this.rdbtnXls.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel97to2003;
                fileName = "Performance.xls";
            }
            else if (this.rdbtnXlsx.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Xlsx;
                fileName = "Performance.xlsx";
            }
            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 3 worksheets
            IWorkbook workbook = application.Workbooks.Create(3);

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            //Start Time
            startTime = DateTime.Now;

            workbook.DetectDateTimeInValue = false;

            if (chkboxColumnStyle.IsChecked.Value)
            {
                //Body Style
                IStyle bodyStyle = workbook.Styles.Add("BodyStyle");
                bodyStyle.BeginUpdate();

                //Add custom colors to the palette.
                workbook.SetPaletteColor(9, System.Drawing.Color.FromArgb(239, 243, 247));
                bodyStyle.Color = System.Drawing.Color.FromArgb(239, 243, 247);
                bodyStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
                bodyStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
                bodyStyle.EndUpdate();

                sheet.SetDefaultColumnStyle(1, colCount, bodyStyle);
            }
            if (chkboxImportOnSave.IsChecked.Value && !rdbtnXls.IsChecked.Value)
            {
                DataTable dataTable = new DataTable();
                for(int column = 1; column <= colCount; column++)
                {
                    dataTable.Columns.Add("Column: "+ column.ToString(), typeof(int));
                }
                //Adding data into data table
                for (int row = 1; row < rowCount; row++)
                {
                    dataTable.Rows.Add();                       
                    for (int column = 1; column <= colCount; column++)
                    {
                        dataTable.Rows[row - 1][column - 1] = row * column;
                    }
                }

                //Start Time
                startTime = DateTime.Now;

                sheet.ImportDataTable(dataTable, 1, 1, true, true);
            }
            else
            {
                IMigrantRange migrantRange = sheet.MigrantRange;

                //Header Style
                IStyle headerStyle = workbook.Styles.Add("HeaderStyle");

                headerStyle.BeginUpdate();
                //Add custom colors to the palette.
                workbook.SetPaletteColor(8, System.Drawing.Color.FromArgb(255, 174, 33));
                headerStyle.Color = System.Drawing.Color.FromArgb(255, 174, 33);
                headerStyle.Font.Bold = true;
                headerStyle.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
                headerStyle.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
                headerStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
                headerStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
                headerStyle.EndUpdate();

                for (int column = 1; column <= colCount; column++)
                {
                    migrantRange.ResetRowColumn(1, column);
                    migrantRange.Text = "Column: " + column.ToString();
                    migrantRange.CellStyle = headerStyle;
                }

                //Writing Data using normal interface
                for (int row = 2; row <= rowCount; row++)
                {
                    //double columnSum = 0.0; 
                    for (int column = 1; column <= colCount; column++)
                    {
                        //Writing number
                        migrantRange.ResetRowColumn(row, column);
                        migrantRange.Number = row * column;
                    }
                }
            }
            try
            {
                workbook.SaveAs(fileName);
                workbook.Close();
                excelEngine.Dispose();

                //End Time
                endTime = DateTime.Now - startTime;
                LogDetails(endTime);

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName)
                    {
                        UseShellExecute = true
                    };
                    process.Start();
                }
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }
        # endregion

        # region Helper Methods
        void LogDetails(TimeSpan endtime)
        {
            // Force garbage collection and get used memory size
            GC.Collect();
            System.Threading.Thread.Sleep(10);
            GC.Collect();
            System.Threading.Thread.Sleep(100);
            GC.Collect();
            //Log.Text ="Optimizations for {0}: ";

            Process myProcess = Process.GetCurrentProcess();

            double workingSetSizeinKiloBytes = myProcess.WorkingSet64 / 1000;

            string s = "Number of rows : " + txtboxRows.Text + "\r\n" + "Number of columns: " + txtboxColumns.Text + "\r\n" + "Process' physical memory usage: " + workingSetSizeinKiloBytes.ToString() + " kb \r\n";
            textLog.Text = s + "\r\n" + "Time taken : " + endTime.Minutes + "Mins : " + endTime.Seconds + "secs : " + endTime.Milliseconds + "msec";
        }

        private void CheckBoxColumn_Checked(object sender, RoutedEventArgs e)
        {
            if(chkboxImportOnSave != null)
              chkboxImportOnSave.IsChecked = false;
        }

        private void ImportOnSave_Checked(object sender, RoutedEventArgs e)
        {
            chkboxColumnStyle.IsChecked = false;
            if (rdbtnXls.IsChecked.Value)
            {
                rdbtnXls.IsChecked = false;
                rdbtnXlsx.IsChecked = true;
            }
        }
        private void TextLog_Loaded(object sender, RoutedEventArgs e)
        {
            string s = "Number of rows : " + "\r\n" + "Number of columns: " + "\r\n" + "Process' physical memory usage: " + "\r\n";
            textLog.Text = s + "\r\n" + "Time taken :";
        }

        private void RdButtonxls_Click(object sender, RoutedEventArgs e)
        {
           chkboxImportOnSave.IsChecked = false;
           chkboxImportOnSave.IsEnabled = false;          
        }
        private void RdButtonxls_Unchecked(object sender, RoutedEventArgs e)
        {
            if (chkboxImportOnSave != null)
                chkboxImportOnSave.IsEnabled = true;
        }
        #endregion


    }
}