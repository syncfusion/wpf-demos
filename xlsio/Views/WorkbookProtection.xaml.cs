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
    /// Interaction logic for WorkbookProtection.xaml
    /// </summary>
    public partial class WorkbookProtection : DemoControl
    {
        # region Constructor
        /// <summary>
        /// WorkbookProtection constructor
        /// </summary>
        public WorkbookProtection()
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
        /// Protects Workbook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProtect_Click(object sender, RoutedEventArgs e)
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

            sheet.Range["C5"].Text = "Workbook is protected with password 'syncfusion'";
            sheet.Range["C6"].Text = "You can't make changes to structure and window of the workbook.";
            sheet.Range["C5"].CellStyle.Font.Bold = true;
            sheet.Range["C5"].CellStyle.Font.Size = 12;

            sheet.Range["C6"].CellStyle.Font.Bold = true;
            sheet.Range["C6"].CellStyle.Font.Size = 12;

            sheet.Range["C8"].Text = "For Excel 2003: Click 'Tools->Protection' to Unprotect the workbook.";
			sheet.Range["C8"].CellStyle.Font.Bold = true;
			sheet.Range["C8"].CellStyle.Font.Size = 12;

			sheet.Range["C10"].Text = "For Excel 2007 and above: Click 'Review Tab->Protect Workbook' to Unprotect the workbook.";
			sheet.Range["C10"].CellStyle.Font.Bold = true;
			sheet.Range["C10"].CellStyle.Font.Size = 12;

            workbook.Protect(true, true, "syncfusion");

            try
            {
                //Saving the workbook to disk.
                string fileName = "ProtectedWorkbook";
                if(rdbtnXLS.IsChecked.Value)
                    fileName = fileName + ".xls";
                else
                    fileName = fileName + ".xlsx";

                workbook.SaveAs(fileName);

                //Close the workbook.
                workbook.Close();
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
        /// Unprotects workbook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnprotect_Click(object sender, RoutedEventArgs e)
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
                IWorkbook workbook = application.Workbooks.Open(@"Assets\XlsIO\ProtectedWorkbook.xls");

                //Unprotecting( unlocking) Workbook using the Password
                workbook.Unprotect("syncfusion");

                //The first worksheet object in the worksheets collection is accessed.
                IWorksheet sheet = workbook.Worksheets[0];

                sheet.Range["C5"].Text = "Workbook is Unprotected with password 'syncfusion' and changes are done";
                sheet.Range["C6"].Text = "You can now edit the structure and window of this workbook.";

                sheet.Range["C5"].CellStyle.Font.Bold = true;
                sheet.Range["C5"].CellStyle.Font.Size = 12;

                sheet.Range["C8"].Text = "Click 'Tools->Protection' to view the Protection settings.";
                sheet.Range["C8"].CellStyle.Font.Bold = true;
                sheet.Range["C8"].CellStyle.Font.Size = 12;


                //Saving the workbook to disk.
                string fileName = "UnprotectedWorkbook";
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