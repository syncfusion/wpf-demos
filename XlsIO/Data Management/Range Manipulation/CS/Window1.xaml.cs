#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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

namespace RangeManipulation
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        private string fileName;
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
#if NETCORE
            string file = @"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
#else
            string file = @"..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
#endif
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
        }
        # endregion

        # region Events
        /// <summary>
        /// Creates spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            //Opening the Existing worksheet from a Workbook
#if NETCORE
            IWorkbook workbook = application.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\RangeManipulation.xls");
#else
            IWorkbook workbook = application.Workbooks.Open(@"..\..\..\..\..\..\Common\Data\XlsIO\RangeManipulation.xls");
#endif
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            # region AutoFilter

            //Creating an AutoFilter in the first worksheet. Specifying the Autofilter range. 
            sheet.AutoFilters.FilterRange = sheet.Range["B14:E91"];

            //Counting the auto filtered value.
            sheet.Range["D9"].Formula = "=SUBTOTAL(2,B14:B91)";

            # endregion

            # region Range copy

            // Copying a Range
            IRange source = sheet.Range["D8:D9"];
            IRange des = sheet.Range["E93"];
            source.CopyTo(des, ExcelCopyRangeOptions.CopyValueAndSourceFormatting);

            #endregion

            # region Clear Range
            source.Clear(true);
            # endregion

            # region Named Range

            //Defining the Range 
            IName lname1 = sheet.Names.Add("One");

            //Another way to refer range of cells.
            lname1.RefersToRange = sheet.Range[98, 4, 98, 5];

            #endregion

            # region Merge Cells

            sheet.Range["One"].Merge();
            sheet.Range["One"].Text = "Thank you for choosing the product";
            sheet.Range["One"].CellStyle.Font.Bold = true;

            #endregion

            # region MigrantRange

            //Optimal method for writting strings in the given range.
            IMigrantRange migrantRange = sheet.MigrantRange;
            migrantRange.ResetRowColumn(6, 4);
            migrantRange.Value = "INVENTORY REPORT";
            migrantRange.CellStyle.Font.Bold = true;
            migrantRange.CellStyle.Font.Size = 16;

            #endregion
            if (this.rdButtonxls.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel97to2003;
                fileName = "RangeManipulation.xls";
            }
            else if (this.rdButtonxlsx.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel2007;
                fileName = "RangeManipulation.xlsx";
            }
            else if (this.rdButtonexcel2010.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel2010;
                fileName = "RangeManipulation.xlsx";
            }
            else if (this.rdButtonexcel2013.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel2013;
                fileName = "RangeManipulation.xlsx";
            }

            try
            {
                //Saving the workbook to disk.
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
#if NETCORE
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName)
                    {
                        UseShellExecute = true
                    };
                    process.Start();
#else
                    Process.Start(fileName);
#endif
                    //Exit
                    this.Close();
                }
                else
                {
                    // Exit
                    this.Close();
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