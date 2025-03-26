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
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for Tables.xaml
    /// </summary>
    public partial class Tables : DemoControl
    {
        # region Constructor
        public Tables()
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
        /// Create spreadsheet with Table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;

            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet worksheet = workbook.Worksheets[0];

            #region Table data
            // Create data
            worksheet[1, 1].Text = "Products";
            worksheet[1, 2].Text = "Qtr1";
            worksheet[1, 3].Text = "Qtr2";
            worksheet[1, 4].Text = "Qtr3";
            worksheet[1, 5].Text = "Qtr4";

            worksheet[2, 1].Text = "Alfreds Futterkiste";
            worksheet[2, 2].Number = 744.6;
            worksheet[2, 3].Number = 162.56;
            worksheet[2, 4].Number = 5079.6;
            worksheet[2, 5].Number = 1249.2;

            worksheet[3, 1].Text = "Antonio Moreno Taqueria";
            worksheet[3, 2].Number = 5079.6;
            worksheet[3, 3].Number = 1249.2;
            worksheet[3, 4].Number = 943.89;
            worksheet[3, 5].Number = 349.6;

            worksheet[4, 1].Text = "Around the Horn";
            worksheet[4, 2].Number = 1267.5;
            worksheet[4, 3].Number = 1062.5;
            worksheet[4, 4].Number = 744.6;
            worksheet[4, 5].Number = 162.56;

            worksheet[5, 1].Text = "Bon app";
            worksheet[5, 2].Number = 1418;
            worksheet[5, 3].Number = 756;
            worksheet[5, 4].Number = 1267.5;
            worksheet[5, 5].Number = 1062.5;

            worksheet[6, 1].Text = "Eastern Connection";
            worksheet[6, 2].Number = 4728;
            worksheet[6, 3].Number = 4547.92;
            worksheet[6, 4].Number = 1418;
            worksheet[6, 5].Number = 756;

            worksheet[7, 1].Text = "Ernst Handel";
            worksheet[7, 2].Number = 943.89;
            worksheet[7, 3].Number = 349.6;
            worksheet[7, 4].Number = 4728;
            worksheet[7, 5].Number = 4547.92;
            # endregion

            // Create style for table number format
            IStyle style1 = workbook.Styles.Add("CurrencyFormat");
            style1.NumberFormat = "_($* #,##0.00_);_($* (#,##0.00);_($* \" - \"??_);_(@_)";

            // Apply number format
            worksheet["B2:E8"].CellStyleName = "CurrencyFormat";

            // Create table
            IListObject table1 = worksheet.ListObjects.Create("Table1", worksheet["A1:E7"]);

            if (chkboxApplyCustomStyle.IsChecked.Value)
            {
                // Apply custom table style
                table1.TableStyleName = CreateCustomStyle(workbook).Name;
            }
            else
            {
                // Apply builtin style
                table1.BuiltInTableStyle = TableBuiltInStyles.TableStyleMedium9;
            }

            // Total row
            table1.ShowTotals = true;
            table1.ShowFirstColumn = true;
            table1.ShowTableStyleColumnStripes = true;
            table1.ShowTableStyleRowStripes = true;
            table1.Columns[0].TotalsRowLabel = "Total";
            table1.Columns[1].TotalsCalculation = ExcelTotalsCalculation.Sum;
            table1.Columns[2].TotalsCalculation = ExcelTotalsCalculation.Sum;
            table1.Columns[3].TotalsCalculation = ExcelTotalsCalculation.Sum;
            table1.Columns[4].TotalsCalculation = ExcelTotalsCalculation.Sum;

            worksheet.UsedRange.AutofitColumns();
            worksheet.SetColumnWidth(2, 12.43);
            worksheet.SetColumnWidth(4, 12.43);

            try
            {
                // Save and close the document
                workbook.SaveAs("Table.xlsx");
                workbook.Close();
                excelEngine.Dispose();

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]                        
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Table.xlsx")
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
        #endregion

        #region Helper Method
        //Create a custom table style
        private ITableStyle CreateCustomStyle(IWorkbook workbook)
        {
            string tableStyleName = "Table Style 1";

            ITableStyles tableStyles = workbook.TableStyles;
            ITableStyle tableStyle = tableStyles.Add(tableStyleName);
            ITableStyleElements tableStyleElements = tableStyle.TableStyleElements;
            ITableStyleElement tableStyleElement = tableStyleElements.Add(ExcelTableStyleElementType.SecondColumnStripe);
            tableStyleElement.BackColorRGB = System.Drawing.Color.FromArgb(217, 225, 242);

            ITableStyleElement tableStyleElement1 = tableStyleElements.Add(ExcelTableStyleElementType.FirstColumn);
            tableStyleElement1.FontColorRGB = System.Drawing.Color.FromArgb(128, 128, 128);

            ITableStyleElement tableStyleElement2 = tableStyleElements.Add(ExcelTableStyleElementType.HeaderRow);
            tableStyleElement2.Bold = true;
            tableStyleElement2.FontColor = ExcelKnownColors.White;
            tableStyleElement2.BackColorRGB = System.Drawing.Color.FromArgb(0, 112, 192);

            ITableStyleElement tableStyleElement3 = tableStyleElements.Add(ExcelTableStyleElementType.TotalRow);
            tableStyleElement3.BackColorRGB = System.Drawing.Color.FromArgb(0, 112, 192);
            tableStyleElement3.Bold = true;
            tableStyleElement3.FontColor = ExcelKnownColors.White;


            return tableStyle;
        }
        #endregion
    }
}

