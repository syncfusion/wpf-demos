#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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
using Syncfusion.XlsIO;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace Tables_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Constructor
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string file = @"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
        }
        # endregion

        # region Events
        /// <summary>
        /// Create spreadsheet with Table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            if (this.rdButtonxlsx.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel2007;               
            }
            else if (this.rdButtonexcel2010.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel2010;               
            }
            else if (this.rdButtonexcel2013.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel2013;
            }

            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet sheet = workbook.Worksheets[0];

            # region Table data
            // Create data
            sheet[1, 1].Text = "Products";
            sheet[1, 2].Text = "Qtr1";
            sheet[1, 3].Text = "Qtr2";

            sheet[2, 1].Text = "Alfreds Futterkiste";
            sheet[2, 2].Number = 744.6;
            sheet[2, 3].Number = 162.56;

            sheet[3, 1].Text = "Antonio Moreno Taqueria";
            sheet[3, 2].Number = 5079.6;
            sheet[3, 3].Number = 1249.2;

            sheet[4, 1].Text = "Around the Horn";
            sheet[4, 2].Number = 1267.5;
            sheet[4, 3].Number = 1062.5;

            sheet[5, 1].Text = "Bon app";
            sheet[5, 2].Number = 1418;
            sheet[5, 3].Number = 756;

            sheet[6, 1].Text = "Eastern Connection";
            sheet[6, 2].Number = 4728;
            sheet[6, 3].Number = 4547.92;

            sheet[7, 1].Text = "Ernst Handel";
            sheet[7, 2].Number = 943.89;
            sheet[7, 3].Number = 349.6;
            # endregion

            // Create style for table number format
            IStyle style1 = workbook.Styles.Add("CurrencyFormat");
            style1.NumberFormat = "_($* #,##0.00_);_($* (#,##0.00);_($* \" - \"??_);_(@_)";

            // Apply number format
            sheet["B2:C8"].CellStyleName = "CurrencyFormat";

            // Create table
            IListObject table1 = sheet.ListObjects.Create("Table1", sheet["A1:C7"]);

            // Apply builtin style
            table1.BuiltInTableStyle = TableBuiltInStyles.TableStyleMedium9;

            // Total row
table1.ShowTotals = true;
            table1.Columns[0].TotalsRowLabel = "Total";
            table1.Columns[1].TotalsCalculation = ExcelTotalsCalculation.Sum;
            table1.Columns[2].TotalsCalculation = ExcelTotalsCalculation.Sum;

            sheet.UsedRange.AutofitColumns();
            sheet.SetColumnWidth(2, 12.43);

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
                        System.Diagnostics.Process.Start("Table.xlsx");
                        //Exit
                        this.Close();
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("Excel 2007 is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
                else
                    // Exit
                    this.Close();
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }
        # endregion
    }
}
