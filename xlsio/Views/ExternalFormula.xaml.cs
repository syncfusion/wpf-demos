#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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
    /// Interaction logic for ExternalFormula.xaml
    /// </summary>
    public partial class ExternalFormula : DemoControl
    {
        #region Constants
        private const string DEFAULTPATH = @"Assets\XlsIO\";
        #endregion

        # region Constructor
        /// <summary>
        /// ExternalFormula constructor
        /// </summary>
        public ExternalFormula()
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
        /// Writes formula to spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWrite_Click(object sender, RoutedEventArgs e)
        {
            #region Workbook Initialize
            ////New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            ////The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            //Open the workbook
            IWorkbook workbook = application.Workbooks.Create(1);

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet worksheet = workbook.Worksheets[0];
            #endregion

            string fullPath = System.IO.Path.GetFullPath(DEFAULTPATH);

            //External formula from another workboook
            worksheet.Range["A1"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$A$1";
            worksheet.Range["A2"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$A$2";
            worksheet.Range["A3"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$A$3";
            worksheet.Range["A4"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$A$4";
            worksheet.Range["A5"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$A$5";
            worksheet.Range["A6"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$A$6";
            worksheet.Range["A7"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$A$7";
            worksheet.Range["B1"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$B$1";
            worksheet.Range["B2"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$B$2";
            worksheet.Range["B3"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$B$3";
            worksheet.Range["B4"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$B$4";
            worksheet.Range["B5"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$B$5";
            worksheet.Range["B6"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$B$6";
            worksheet.Range["C1"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$C$1";
            worksheet.Range["C2"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$C$2";
            worksheet.Range["C3"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$C$3";
            worksheet.Range["C4"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$C$4";
            worksheet.Range["C5"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$C$5";
            worksheet.Range["C6"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$C$6";
            worksheet.Range["D1"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$D$1";
            worksheet.Range["D2"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$D$2";
            worksheet.Range["D3"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$D$3";
            worksheet.Range["D4"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$D$4";
            worksheet.Range["D5"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$D$5";
            worksheet.Range["D6"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$D$6";
            worksheet.Range["E1"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$E$1";
            worksheet.Range["E2"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$E$2";
            worksheet.Range["E3"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$E$3";
            worksheet.Range["E4"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$E$4";
            worksheet.Range["E5"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$E$5";
            worksheet.Range["E6"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$E$6";
            worksheet.Range["F1"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$F$1";
            worksheet.Range["B7"].Formula = "=SUM(B2:B6)";
            worksheet.Range["C7"].Formula = "=SUM(C2:C6)";
            worksheet.Range["D7"].Formula = "=SUM(D2:D6)";
            worksheet.Range["E7"].Formula = "=SUM(E2:E6)";
            worksheet.Range["F7"].Formula = "=SUM(F2:F6)";
            worksheet.Range["F2"].Formula = "=B2*C2+D2-E2";
            worksheet.Range["F3"].Formula = "=B3*C3+D3-E3";
            worksheet.Range["F4"].Formula = "=B4*C4+D4-E4";
            worksheet.Range["F5"].Formula = "=B5*C5+D5-E5";
            worksheet.Range["F6"].Formula = "=B6*C6+D6-E6";
            worksheet.Range["A1:F7"].CellStyle.Font.FontName = "Verdana";
            worksheet.Range["C2:F7"].NumberFormat = "_($* #,##0.00_)";
            worksheet.Range["A1:F1"].CellStyle.Color = System.Drawing.Color.FromArgb(0, 0, 112, 192);
            worksheet.Range["A7:F7"].CellStyle.Color = System.Drawing.Color.FromArgb(0, 0, 112, 192);
            worksheet.Range["A1:F1"].CellStyle.Font.Bold = true;
            worksheet.Range["A1:F1"].CellStyle.Font.Size = 11;
            worksheet.Columns[0].ColumnWidth = 17;
            worksheet.Columns[1].ColumnWidth = 13;
            worksheet.Columns[2].ColumnWidth = 11;
            worksheet.Columns[3].ColumnWidth = 11;
            worksheet.Columns[4].ColumnWidth = 13;
            worksheet.Columns[5].ColumnWidth = 13;

            worksheet.Calculate();
            #region Workbook Save
            string filename = "ExternalFormula.xlsx";
            //Saving the workbook to disk.
            workbook.SaveAs(filename);
            #endregion

            #region Workbook Close and Dispose
            //Close the workbook.
            workbook.Close();

            //No exception will be thrown if there are unsaved workbooks.
            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();
            #endregion
            try
            {
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
        /// Reads formula from spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            #region Workbook Initialize
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            //Open the workbook
            IWorkbook workbook = application.Workbooks.Create(1);

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet worksheet = workbook.Worksheets[0];
            #endregion

            string fullPath = System.IO.Path.GetFullPath(DEFAULTPATH);

            //External formula from another workboook
            worksheet.Range["A1"].Formula = @"='" + fullPath + "[External_Input.xlsx]Sheet1'!$A$1";

            worksheet.EnableSheetCalculations();

            #region Formula and Computed value
            //Read computed Formula Value. 
            this.txtboxFormula.Text = worksheet.Range["A1"].Formula;
            this.txtboxFormula.TextWrapping = TextWrapping.Wrap;

            //Read Formula
            this.txtboxValue.Text = worksheet.Range["A1"].CalculatedValue;
            #endregion

            #region Workbook Close and Dispose
            //Close the workbook.
            workbook.Close();

            //No exception will be thrown if there are unsaved workbooks.
            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();
            #endregion
        }
        # endregion
    }
}