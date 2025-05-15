#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for WorksheetProtection.xaml
    /// </summary>
    public partial class WorksheetProtection : DemoControl
    {
        # region Constructor
        /// <summary>
        /// WorksheetProtection constructor
        /// </summary>
        public WorksheetProtection()
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
        /// Lock worksheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLock_Click(object sender, RoutedEventArgs e)
        {
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            // Opening the Existing Worksheet from a Workbook
            IWorkbook workbook = application.Workbooks.Create(1);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            sheet.Range["C5"].Text = "Worksheet protected with password 'syncfusion'";
            sheet.Range["C6"].Text = "You can't edit any cells other than A1 and A2";
            sheet.Range["C5"].CellStyle.Font.Bold = true;
            sheet.Range["C5"].CellStyle.Font.Size = 12;

            sheet.Range["C6"].CellStyle.Font.Bold = true;
            sheet.Range["C6"].CellStyle.Font.Size = 12;

            sheet.Range["C8"].Text = "For Excel 2003: Click 'Tools->Protection' to Unprotect the sheet.";
			sheet.Range["C8"].CellStyle.Font.Bold = true;
			sheet.Range["C8"].CellStyle.Font.Size = 12;

			sheet.Range["C10"].Text = "For Excel 2007 and above: Click 'Review Tab->Unprotect Sheet' to Unprotect the sheet.";
			sheet.Range["C10"].CellStyle.Font.Bold = true;
			sheet.Range["C10"].CellStyle.Font.Size = 12;

            sheet.Range["A1:A2"].Text = "You can edit this cell";
            sheet.Range["A1:A2"].CellStyle.Font.Bold = true;

            //Protecting Worksheet using Password
            sheet.Protect("syncfusion");

            //Unlocking the cells which are needed to be edited
            sheet.Range["A1"].CellStyle.Locked = false;
            sheet.Range["A2"].CellStyle.Locked = false;

            try
            {
                //Saving the workbook to disk.
                string fileName = "LockedWorksheet";
                if (rdbtnXLS.IsChecked.Value)
                    fileName = fileName + ".xls";
                else
                    fileName = fileName + ".xlsx";

                workbook.SaveAs(fileName);

                //Close the workbook.
                workbook.Close();

                //No exception will be thrown if there are unsaved workbooks.
                excelEngine.ThrowNotSavedOnDestroy = false;
                excelEngine.Dispose();

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

        /// <summary>
        /// Unlock worksheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnlock_Click(object sender, RoutedEventArgs e)
        {
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            try
            {
                // Opening a Existing(Protected) Worksheet from a Workbook
                IWorkbook workbook = application.Workbooks.Open(@"Assets\XlsIO\LockedWorksheet.xls");
                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet sheet = workbook.Worksheets[0];

                //Unprotecting( unlocking) Worksheet using the Password
                sheet.Unprotect("syncfusion");

                sheet.Range["C5"].Text = "For Excel 2003: Click 'Tools->Protection' to view the Protection settings.";
                sheet.Range["C6"].Text = "You can edit any cell";
                sheet.Range["A1:A2"].Text = " ";

                sheet.Range["C5"].CellStyle.Font.Bold = true;
                sheet.Range["C5"].CellStyle.Font.Size = 12;

                sheet.Range["C8"].Text = "For Excel 2007 and above: Click 'Review Tab->Protect Sheet' to view the Protection settings.";
                sheet.Range["C8"].CellStyle.Font.Bold = true;
                sheet.Range["C8"].CellStyle.Font.Size = 12;

                //Saving the workbook to disk.
                string fileName = "UnlockedWorksheet";
                if (rdbtnXLS.IsChecked.Value)
                    fileName = fileName + ".xls";
                else
                    fileName = fileName + ".xlsx";

                workbook.SaveAs(fileName);

                //Close the workbook.
                workbook.Close();

                //No exception will be thrown if there are unsaved workbooks.
                excelEngine.ThrowNotSavedOnDestroy = false;
                excelEngine.Dispose();

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
    }
}