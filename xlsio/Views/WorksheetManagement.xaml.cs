#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for WorksheetManagement.xaml
    /// </summary>
    public partial class WorksheetManagement : DemoControl
    {
        #region
        /// <summary>
        /// File Name
        /// </summary>
        private string filename;
        #endregion

        # region Constructor
        /// <summary>
        /// WorksheetManagement Constructor
        /// </summary>
        public WorksheetManagement()
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
        /// Create spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //New instance of Excel is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel object.
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;
            //Open the Source WorkBook	
            
            IWorkbook sourceWorkbook = application.Workbooks.Open(@"Assets\XlsIO\SourceWorkbookTemplate.xlsx");
            
            //Add a WorkBook	
            IWorkbook destinationWorkbook = application.Workbooks.Add();

            //Copy the first worksheet from Source workbook to destination workbook.
            destinationWorkbook.Worksheets.AddCopy(sourceWorkbook.Worksheets[0], ExcelWorksheetCopyFlags.CopyAll);

            //Copy the first worksheet from Source workbook to destination workbook. This will copy only shapes[images and comments]in the source worksheet
            destinationWorkbook.Worksheets.AddCopy(sourceWorkbook.Worksheets[0], ExcelWorksheetCopyFlags.CopyShapes | ExcelWorksheetCopyFlags.CopyConditionlFormats | ExcelWorksheetCopyFlags.CopyColumnHeight | ExcelWorksheetCopyFlags.CopyDataValidations);

            //Rename the copied worksheet.
            destinationWorkbook.Worksheets[3].Name = "Copied_Worksheet";
            destinationWorkbook.Worksheets[4].Name = "Copied_Shapes_ConditionalFormats_Datavalidation";
            destinationWorkbook.Worksheets[4].Range["B3"].Text = "This worksheet contains shapes[comments and images],Conditional formats and data validations[No Number format/styles will be copied]";
            destinationWorkbook.Worksheets[4].Range["B3"].CellStyle.Font.Bold = true;

            //Move the copied worksheet to specified index.
            destinationWorkbook.Worksheets[3].Move(0);
            destinationWorkbook.Worksheets[4].Move(0);

            //Remove unwanted worksheets
            destinationWorkbook.Worksheets[3].Remove();
            destinationWorkbook.Worksheets[3].Remove();
            destinationWorkbook.Worksheets[2].Remove();

            //Activate the moved worksheet in the destination workbook.
            destinationWorkbook.ActiveSheetIndex = 1;

            if (this.rdbtnXLS.IsChecked.Value)
            {
                destinationWorkbook.Version = ExcelVersion.Excel97to2003;
                filename = "SheetManagement.xls";
            }
            else if (this.rdbtnXLSX.IsChecked.Value)
            {
                destinationWorkbook.Version = ExcelVersion.Xlsx;
                filename = "SheetManagement.xlsx";
            }            

            try
            {
                //Saving the workbook to disk.

                destinationWorkbook.SaveAs(filename);

                //Close the workbook.
                destinationWorkbook.Close();

                //No exception will be thrown if there are unsaved workbooks.
                excelEngine.ThrowNotSavedOnDestroy = false;
                excelEngine.Dispose();

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(filename) { UseShellExecute = true };
                    process.Start();
                }                
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Opens input template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            //Launching the Input Template using the default Application.[MS Excel Or Free ExcelViewer]
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\XlsIO\SourceWorkbookTemplate.xls") { UseShellExecute = true };
            process.Start();
        }
        # endregion
    }
}