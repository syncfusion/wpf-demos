#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Media;
using Syncfusion.XlsIO;
using System.ComponentModel;
using System.Globalization;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for CreateSpreadsheet.xaml
    /// </summary>
    public partial class CreateSpreadsheet : DemoControl
    {
        #region Constants
        private const string DEFAULTPATH = @"Assets\XlsIO\{0}";
        #endregion

        # region Constructor
        /// <summary>
        /// CreateSpreadsheet constructor
        /// </summary>
        public CreateSpreadsheet()
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
            #region Initialize Workbook
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 1 worksheets
            IWorkbook workbook;
            string inputPath = GetFullTemplatePath("MacroTemplate.xltm");
            if (rdbXltm.IsChecked.Value)
                workbook = application.Workbooks.Open(inputPath, ExcelOpenType.Automatic);
            else
                workbook = application.Workbooks.Create(1);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet worksheet = workbook.Worksheets[0];
            #endregion

            try
            {
                #region Workbook Save
                if (rdbXltm.IsChecked.Value)
                {
                    worksheet.IsGridLinesVisible = false;
                    worksheet[1, 1].Text = "Essential XlsIO supports opening of XLTM (Excel 2007 Macro Enabled Template) file and save it in either XLTM or XLSM formats.";
                    worksheet[3, 1].Text = "You can run the macro by triggering the click event of the button placed in this worksheet.";
                }
                else if (rdbCsv.IsChecked.Value)
                {
                    //Inserting sample text into the first cell of the first worksheet.
                    worksheet.Range["A1:N30"].Text = "Hello World";
                }
                else
                {
                    #region Generate Excel
                    worksheet.Range["A2"].ColumnWidth = 30;
                    worksheet.Range["B2"].ColumnWidth = 30;
                    worksheet.Range["C2"].ColumnWidth = 30;
                    worksheet.Range["D2"].ColumnWidth = 30;

                    worksheet.Range["A2:D2"].Merge(true);

                    //Inserting sample text into the first cell of the first worksheet.
                    worksheet.Range["A2"].Text = "EXPENSE REPORT";
                    worksheet.Range["A2"].CellStyle.Font.FontName = "Verdana";
                    worksheet.Range["A2"].CellStyle.Font.Bold = true;
                    worksheet.Range["A2"].CellStyle.Font.Size = 28;
                    worksheet.Range["A2"].CellStyle.Font.RGBColor = System.Drawing.Color.FromArgb(0, 0, 112, 192);
                    worksheet.Range["A2"].HorizontalAlignment = ExcelHAlign.HAlignCenter;

                    worksheet.Range["A4"].Text = "Employee";
                    worksheet.Range["B4"].Text = "Roger Federer";
                    worksheet.Range["A4:B7"].CellStyle.Font.FontName = "Verdana";
                    worksheet.Range["A4:B7"].CellStyle.Font.Bold = true;
                    worksheet.Range["A4:B7"].CellStyle.Font.Size = 11;
                    worksheet.Range["A4:A7"].CellStyle.Font.RGBColor = System.Drawing.Color.FromArgb(0, 128, 128, 128);
                    worksheet.Range["A4:A7"].HorizontalAlignment = ExcelHAlign.HAlignLeft;
                    worksheet.Range["B4:B7"].CellStyle.Font.RGBColor = System.Drawing.Color.FromArgb(0, 174, 170, 170);
                    worksheet.Range["B4:B7"].HorizontalAlignment = ExcelHAlign.HAlignRight;

                    worksheet.Range["A9:D20"].CellStyle.Font.FontName = "Verdana";
                    worksheet.Range["A9:D20"].CellStyle.Font.Size = 11;

                    worksheet.Range["A5"].Text = "Department";
                    worksheet.Range["B5"].Text = "Administration";

                    worksheet.Range["A6"].Text = "Week Ending";
                    worksheet.Range["B6"].NumberFormat = "m/d/yyyy";
                    worksheet.Range["B6"].DateTime = DateTime.Parse("10/20/2012", CultureInfo.InvariantCulture);

                    worksheet.Range["A7"].Text = "Mileage Rate";
                    worksheet.Range["B7"].NumberFormat = "$#,##0.00";
                    worksheet.Range["B7"].Number = 0.70;

                    worksheet.Range["A10"].Text = "Miles Driven";
                    worksheet.Range["A11"].Text = "Miles Reimbursement";
                    worksheet.Range["A12"].Text = "Parking and Tolls";
                    worksheet.Range["A13"].Text = "Auto Rental";
                    worksheet.Range["A14"].Text = "Lodging";
                    worksheet.Range["A15"].Text = "Breakfast";
                    worksheet.Range["A16"].Text = "Lunch";
                    worksheet.Range["A17"].Text = "Dinner";
                    worksheet.Range["A18"].Text = "Snacks";
                    worksheet.Range["A19"].Text = "Others";
                    worksheet.Range["A20"].Text = "Total";
                    worksheet.Range["A20:D20"].CellStyle.Color = System.Drawing.Color.FromArgb(0, 0, 112, 192);
                    worksheet.Range["A20:D20"].CellStyle.Font.Color = ExcelKnownColors.White;
                    worksheet.Range["A20:D20"].CellStyle.Font.Bold = true;

                    IStyle style = worksheet["B9:D9"].CellStyle;
                    style.VerticalAlignment = ExcelVAlign.VAlignCenter;
                    style.HorizontalAlignment = ExcelHAlign.HAlignRight;
                    style.Color = System.Drawing.Color.FromArgb(0, 0, 112, 192);
                    style.Font.Bold = true;
                    style.Font.Color = ExcelKnownColors.White;

                    worksheet.Range["A9"].Text = "Expenses";
                    worksheet.Range["A9"].CellStyle.Color = System.Drawing.Color.FromArgb(0, 0, 112, 192);
                    worksheet.Range["A9"].CellStyle.Font.Color = ExcelKnownColors.White;
                    worksheet.Range["A9"].CellStyle.Font.Bold = true;
                    worksheet.Range["B9"].Text = "Day 1";
                    worksheet.Range["B10"].Number = 100;
                    worksheet.Range["B11"].NumberFormat = "$#,##0.00";
                    worksheet.Range["B11"].Formula = "=(B7*B10)";
                    worksheet.Range["B12"].NumberFormat = "$#,##0.00";
                    worksheet.Range["B12"].Number = 0;
                    worksheet.Range["B13"].NumberFormat = "$#,##0.00";
                    worksheet.Range["B13"].Number = 0;
                    worksheet.Range["B14"].NumberFormat = "$#,##0.00";
                    worksheet.Range["B14"].Number = 0;
                    worksheet.Range["B15"].NumberFormat = "$#,##0.00";
                    worksheet.Range["B15"].Number = 9;
                    worksheet.Range["B16"].NumberFormat = "$#,##0.00";
                    worksheet.Range["B16"].Number = 12;
                    worksheet.Range["B17"].NumberFormat = "$#,##0.00";
                    worksheet.Range["B17"].Number = 13;
                    worksheet.Range["B18"].NumberFormat = "$#,##0.00";
                    worksheet.Range["B18"].Number = 9.5;
                    worksheet.Range["B19"].NumberFormat = "$#,##0.00";
                    worksheet.Range["B19"].Number = 0;
                    worksheet.Range["B20"].NumberFormat = "$#,##0.00";
                    worksheet.Range["B20"].Formula = "=SUM(B11:B19)";

                    worksheet.Range["C9"].Text = "Day 2";
                    worksheet.Range["C10"].Number = 145;
                    worksheet.Range["C11"].NumberFormat = "$#,##0.00";
                    worksheet.Range["C11"].Formula = "=(B7*C10)";
                    worksheet.Range["C12"].NumberFormat = "$#,##0.00";
                    worksheet.Range["C12"].Number = 15;
                    worksheet.Range["C13"].NumberFormat = "$#,##0.00";
                    worksheet.Range["C13"].Number = 0;
                    worksheet.Range["C14"].NumberFormat = "$#,##0.00";
                    worksheet.Range["C14"].Number = 45;
                    worksheet.Range["C15"].NumberFormat = "$#,##0.00";
                    worksheet.Range["C15"].Number = 9;
                    worksheet.Range["C16"].NumberFormat = "$#,##0.00";
                    worksheet.Range["C16"].Number = 12;
                    worksheet.Range["C17"].NumberFormat = "$#,##0.00";
                    worksheet.Range["C17"].Number = 15;
                    worksheet.Range["C18"].NumberFormat = "$#,##0.00";
                    worksheet.Range["C18"].Number = 7;
                    worksheet.Range["C19"].NumberFormat = "$#,##0.00";
                    worksheet.Range["C19"].Number = 0;
                    worksheet.Range["C20"].NumberFormat = "$#,##0.00";
                    worksheet.Range["C20"].Formula = "=SUM(C11:C19)";

                    worksheet.Range["D9"].Text = "Day 3";
                    worksheet.Range["D10"].Number = 113;
                    worksheet.Range["D11"].NumberFormat = "$#,##0.00";
                    worksheet.Range["D11"].Formula = "=(B7*D10)";
                    worksheet.Range["D12"].NumberFormat = "$#,##0.00";
                    worksheet.Range["D12"].Number = 17;
                    worksheet.Range["D13"].NumberFormat = "$#,##0.00";
                    worksheet.Range["D13"].Number = 8;
                    worksheet.Range["D14"].NumberFormat = "$#,##0.00";
                    worksheet.Range["D14"].Number = 45;
                    worksheet.Range["D15"].NumberFormat = "$#,##0.00";
                    worksheet.Range["D15"].Number = 7;
                    worksheet.Range["D16"].NumberFormat = "$#,##0.00";
                    worksheet.Range["D16"].Number = 11;
                    worksheet.Range["D17"].NumberFormat = "$#,##0.00";
                    worksheet.Range["D17"].Number = 16;
                    worksheet.Range["D18"].NumberFormat = "$#,##0.00";
                    worksheet.Range["D18"].Number = 7;
                    worksheet.Range["D19"].NumberFormat = "$#,##0.00";
                    worksheet.Range["D19"].Number = 5;
                    worksheet.Range["D20"].NumberFormat = "$#,##0.00";
                    worksheet.Range["D20"].Formula = "=SUM(D11:D19)";

                    worksheet.UsedRange.AutofitRows();
                    #endregion
                }

                string filename = "";
                if (rdbXls.IsChecked.Value)
                {
                    filename = "CreateSpreadsheet.xls";
                    workbook.SaveAs(filename);
                }
                else if (rdbXlsx.IsChecked.Value)
                {
                    filename = "CreateSpreadsheet.xlsx";
                    workbook.Version = ExcelVersion.Xlsx;
                    workbook.SaveAs(filename);
                }
                else if (rdbCsv.IsChecked.Value)
                {
                    filename = "CreateSpreadsheet.csv";
                    worksheet.SaveAs(filename, ",");
                }
                else if (rdbXml.IsChecked.Value)
                {
                    filename = "CreateSpreadsheet.xml";
                    workbook.SaveAsXml(filename, ExcelXmlSaveType.MSExcel);
                }
                else if (rdbXltx.IsChecked.Value)
                {
                    filename = "CreateSpreadsheet.xltx";
                    workbook.Version = ExcelVersion.Excel2007;
                    workbook.SaveAs(filename, ExcelSaveType.SaveAsTemplate);
                }
                else if (rdbXltm.IsChecked.Value)
                {
                    filename = "CreateSpreadsheet.xltm";
                    workbook.Version = ExcelVersion.Excel2007;
                    workbook.SaveAs(filename, ExcelSaveType.SaveAsTemplate);
                }
                #endregion

                #region Workbook Close and Dispose
                //Close the workbook.
                workbook.Close();
                excelEngine.Dispose();
                #endregion

                #region View the Workbook
                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo(filename) { UseShellExecute = true };
                        process.Start();
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("MS Excel is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
                #endregion
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }
        # endregion

        #region HelperMethods
        /// <summary>
        /// Get the input file and return the path of input file
        /// </summary>
        /// <param name="inputFile"></param>
        /// <returns></returns>
        private string GetFullTemplatePath(string inputFile)
        {
            return string.Format(DEFAULTPATH, inputFile);
        }
        #endregion

    }
}