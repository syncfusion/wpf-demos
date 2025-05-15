#region Copyright Syncfusion Inc. 2001 - 2016
// Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
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
    /// Interaction logic for TableFormula.xaml
    /// </summary>
    public partial class TableFormula : DemoControl
    {
        # region Constructor
        public TableFormula()
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
        /// Create spreadsheet with Table formula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
			#region Workbook Initialize
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;

            //Set the default version as Excel 2013
            application.DefaultVersion = ExcelVersion.Excel2013;

            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet sheet = workbook.Worksheets[0];
            #endregion

            #region Create Table
            // Create table
            IListObject table1 = sheet.ListObjects.Create("Table1", sheet["A1:F6"]);

            # region Table data
            // Fill table data
            sheet[1, 1].Text = "Product ID";
            sheet[1, 2].Text = "Quantity";
            sheet[1, 3].Text = "Rate";
            sheet[1, 4].Text = "Tax";
            sheet[1, 5].Text = "Discount";
            sheet[1, 6].Text = "Amount";

            sheet[2, 1].Text = "ProductA";
            sheet[2, 2].Number = 2;
            sheet[2, 3].Number = 16.80;
            sheet[2, 4].Number = 9.83;
            sheet[2, 5].Number = 10;

            sheet[3, 1].Text = "ProductB";
            sheet[3, 2].Number = 3;
            sheet[3, 3].Number = 15.60;
            sheet[3, 4].Number = 9.83;
            sheet[3, 5].Number = 5;

            sheet[4, 1].Text = "ProductC";
            sheet[4, 2].Number = 2;
            sheet[4, 3].Number = 20.10;
            sheet[4, 4].Number = 9.83;
            sheet[4, 5].Number = 8;

            sheet[5, 1].Text = "ProductD";
            sheet[5, 2].Number = 1;
            sheet[5, 3].Number = 40.50;
            sheet[5, 4].Number = 9.83;
            sheet[5, 5].Number = 20;

            sheet[6, 1].Text = "ProductE";
            sheet[6, 2].Number = 2;
            sheet[6, 3].Number = 30.70;
            sheet[6, 4].Number = 9.83;
            sheet[6, 5].Number = 15;
            # endregion

            // Create style for table number format
            IStyle style1 = workbook.Styles.Add("CurrencyFormat");
            style1.NumberFormat = "_($* #,##0.00_);_($* (#,##0.00);_($* \" - \"??_);_(@_)";

            // Apply number format
            sheet["C2:F6"].CellStyleName = "CurrencyFormat";

            // Apply builtin table style
            table1.BuiltInTableStyle = TableBuiltInStyles.TableStyleMedium9;

            //Set table column calculated formula
            table1.Columns[5].CalculatedFormula = "[@Quantity]*[@Rate]+[@Tax]-[@Discount]";

            //Show Total row and set total calculation
            table1.ShowTotals = true;
            table1.Columns[0].TotalsRowLabel = "Total";
            table1.Columns[1].TotalsCalculation = ExcelTotalsCalculation.Sum;
            table1.Columns[2].TotalsCalculation = ExcelTotalsCalculation.Sum;
            table1.Columns[3].TotalsCalculation = ExcelTotalsCalculation.Sum;
            table1.Columns[4].TotalsCalculation = ExcelTotalsCalculation.Sum;
            table1.Columns[5].TotalsCalculation = ExcelTotalsCalculation.Sum;

            sheet.SetColumnWidth(1, 11.71);
            sheet.SetColumnWidth(2, 10.29);
            sheet.SetColumnWidth(3, 8.29);
            sheet.SetColumnWidth(4, 7.29);
            sheet.SetColumnWidth(5, 10.29);
            sheet.SetColumnWidth(6, 9.71);

            #endregion

            try
            {
                string filename = "TableFormula.xlsx";
                #region Workbook save
                // Save and close the document
                workbook.SaveAs(filename);
				#endregion

				#region Workbook Close and Dispose
				workbook.Close();
				excelEngine.Dispose();
				#endregion

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
                        MessageBox.Show("Excel is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
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
