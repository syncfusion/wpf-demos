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
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for DataValidation.xaml
    /// </summary>
    public partial class DataValidation : DemoControl
    {
        private string filename;
        # region Constructor
        /// <summary>
        /// DataValidation constructor
        /// </summary>
        public DataValidation()
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
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;
            if (this.rdbtnXLS.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel97to2003;
                filename = "DataValidation.xls";
            }
            else if (this.rdbtnXLSX.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Xlsx;
                filename = "DataValidation.xlsx";
            }
          
            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 3 worksheets
            IWorkbook workbook = application.Workbooks.Create(3);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            //Data validation to list the values in the first cell
            IDataValidation validation = sheet.Range["C7"].DataValidation;
            sheet.Range["B7"].Text = "Select an item from the validation list";
            validation.ListOfValues = new string[] { "PDF", "XlsIO", "DocIO" };
            validation.PromptBoxText = "Data Validation list";
            validation.IsPromptBoxVisible = true;
            validation.ShowPromptBox = true;

            sheet.Range["C7"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
            sheet.Range["C7"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            sheet.Range["C7"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

            // Data Validation for Numbers
            IDataValidation validation1 = sheet.Range["C9"].DataValidation;
            sheet.Range["B9"].Text = "Enter a Number to validate";
            validation1.AllowType = ExcelDataType.Integer;
            validation1.CompareOperator = ExcelDataValidationComparisonOperator.Between;
            validation1.FirstFormula = "0";
            validation1.SecondFormula = "10";
            validation1.ShowErrorBox = true;
            validation1.ErrorBoxText = "Enter Value between 0 to 10";
            validation1.ErrorBoxTitle = "ERROR";
            validation1.PromptBoxText = "Data Validation using Condition for Numbers";
            validation1.ShowPromptBox = true;
            sheet.Range["C9"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
            sheet.Range["C9"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            sheet.Range["C9"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

            // Data Validation for Date
            IDataValidation validation2 = sheet.Range["C11"].DataValidation;
            sheet.Range["B11"].Text = "Enter the Date to validate";
            validation2.AllowType = ExcelDataType.Date;
            validation2.CompareOperator = ExcelDataValidationComparisonOperator.Between;
            validation2.FirstDateTime = new DateTime(2003, 5, 10);
            validation2.SecondDateTime = new DateTime(2004, 5, 10);
            validation2.ShowErrorBox = true;
            validation2.ErrorBoxText = "Enter Value between 10/5/2003 to 10/5/2004";
            validation2.ErrorBoxTitle = "ERROR";
            validation2.PromptBoxText = "Data Validation using Condition for Date";
            validation2.ShowPromptBox = true;
            sheet.Range["C11"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
            sheet.Range["C11"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            sheet.Range["C11"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

            // Data Validation for TextLength
            IDataValidation validation3 = sheet.Range["C13"].DataValidation;
            sheet.Range["B13"].Text = "Enter the Text to validate";
            validation3.AllowType = ExcelDataType.TextLength;
            validation3.CompareOperator = ExcelDataValidationComparisonOperator.Between;
            validation3.FirstFormula = "1";
            validation3.SecondFormula = "6";
            validation3.ShowErrorBox = true;
            validation3.ErrorBoxText = "Retype text length to 6 character";
            validation3.ErrorBoxTitle = "ERROR";
            validation3.PromptBoxText = "Data Validation using Condition for TextLength";
            validation3.ShowPromptBox = true;
            sheet.Range["C13"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
            sheet.Range["C13"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            sheet.Range["C13"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;

            // Data Validation for Time
            IDataValidation validation4 = sheet.Range["C15"].DataValidation;
            sheet.Range["B15"].Text = "Enter the Time to validate";
            validation4.AllowType = ExcelDataType.Time;
            validation4.CompareOperator = ExcelDataValidationComparisonOperator.Between;
             validation4.FirstFormula = "10";
            validation4.SecondFormula = "12";
            validation4.ShowErrorBox = true;
            validation4.ErrorBoxText = "Enter the Correct time between 10 to 12 ";
            validation4.ErrorBoxTitle = "ERROR";
            validation4.PromptBoxText = "Data Validation using Condition for Time";
            validation4.ShowPromptBox = true;
            sheet.Range["C15"].CellStyle.Borders.LineStyle = ExcelLineStyle.Medium;
            sheet.Range["C15"].CellStyle.Borders[ExcelBordersIndex.DiagonalDown].ShowDiagonalLine = false;
            sheet.Range["C15"].CellStyle.Borders[ExcelBordersIndex.DiagonalUp].ShowDiagonalLine = false;
            sheet.Range["B2:C2"].Merge();
            sheet.Range["B2"].Text = "Simple Data validation";
            sheet.Range["B5"].Text = "Validation criteria";
            sheet.Range["C5"].Text = "Validation";
            sheet.Range["B5"].CellStyle.Font.Bold = true;
            sheet.Range["C5"].CellStyle.Font.Bold = true;
            sheet.Range["B2"].CellStyle.Font.Bold = true;
            sheet.Range["B2"].CellStyle.Font.Size = 16;
            sheet.Range["B2"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            sheet.UsedRange.AutofitColumns();
            sheet.UsedRange.AutofitRows();

            try
            {
                //Saving the workbook to disk
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
        # endregion
    }
}