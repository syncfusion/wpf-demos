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
    /// Interaction logic for Formula.xaml
    /// </summary>
    public partial class Formula : DemoControl
    {
        #region Constructor
        /// <summary>
        /// Formulas constructor
        /// </summary>
        public Formula()
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
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 3 worksheets
            IWorkbook workbook = application.Workbooks.Create(3);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            #region Insert Array Formula

            sheet.Range["A2"].Text = "Array formulas";
            sheet.Range["B2:E2"].FormulaArray = "{10,20,30,40}";
            sheet.Names.Add("ArrayRange", sheet.Range["B2:E2"]);
            sheet.Range["B3:E3"].FormulaArray = "ArrayRange+100";
            sheet.Range["A2"].CellStyle.Font.Bold = true;
            sheet.Range["A2"].CellStyle.Font.Size = 14;

            #endregion

            #region Excel functions

            sheet.Range["A5"].Text = "Formula";
            sheet.Range["B5"].Text = "Result";

            sheet.Range["A7"].Text = "ABS(ABS(-B3))";
            sheet.Range["B7"].Formula = "ABS(ABS(-B3))";

            sheet.Range["A9"].Text = "SUM(B3,C3)";
            sheet.Range["B9"].Formula = "SUM(B3,C3)";

            sheet.Range["A11"].Text = "MIN({10,20,30;5,15,35;6,16,36})";
            sheet.Range["B11"].Formula = "MIN({10,20,30;5,15,35;6,16,36})";

            sheet.Range["A13"].Text = "LOOKUP(B3,B3:E8)";
            sheet.Range["B13"].Formula = "LOOKUP(B3,B3:E3)";

            sheet.Range["A5:B5"].CellStyle.Font.Bold = true;
            sheet.Range["A5:B5"].CellStyle.Font.Size = 14;

            #endregion

            #region Simple formulas
            sheet.Range["C7"].Number = 10;
            sheet.Range["C9"].Number = 10;
            sheet.Range["A15"].Text = "C7+C9";
            sheet.Range["B15"].Formula = "C7+C9";

            #endregion

            sheet.Range["B1"].Text = "Excel formula support";
            sheet.Range["B1"].CellStyle.Font.Bold = true;
            sheet.Range["B1"].CellStyle.Font.Size = 14;
            sheet.Range["B1:E1"].Merge();
            sheet.Range["A1:A15"].AutofitColumns();

            try
            {
                string filename = "Formula.xls";
                //Saving the workbook to disk.
                workbook.SaveAs(filename);

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
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            //Open the workbook
            IWorkbook workbook = application.Workbooks.Open(@"Assets\XlsIO\FormulaTemplate.xls");

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            //Read computed Formula Value. 
            this.txtboxValue.Text = sheet.Range["C1"].FormulaNumberValue.ToString();

            //Read Formula
            this.txtboxFormula.Text = sheet.Range["C1"].Formula;

            //Close the workbook.
            workbook.Close();

            //No exception will be thrown if there are unsaved workbooks.
            excelEngine.ThrowNotSavedOnDestroy = false;
            excelEngine.Dispose();
        }

        # endregion
    }
}