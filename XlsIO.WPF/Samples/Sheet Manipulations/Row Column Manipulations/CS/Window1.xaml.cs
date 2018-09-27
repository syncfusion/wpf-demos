#region Copyright Syncfusion Inc. 2001 - 2012
// Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
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
using Syncfusion.Windows.Shared;

namespace RowColumnManipulations
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        private string fileName;
        # region Constructor
        /// <summary>
        /// Window Constructor
        /// </summary>
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

            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 3 worksheets

            //IWorkbook workbook = application.Workbooks.Create(3);
            IWorkbook workbook = application.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\monthly_sales.xls");
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            #region Grouping and ungrouping

            // Grouping by Rows
            sheet.Range["C5:F7"].Group(ExcelGroupBy.ByRows);

            // Grouping by Columns
            sheet.Range["C10:F10"].Group(ExcelGroupBy.ByColumns);

            #endregion

            #region Hiding unhiding

            // Hiding fifth and sixth Column
            sheet.ShowColumn(5, false);
            sheet.ShowColumn(6, false);

            //Showing the 28th row
            sheet.ShowRow(28, true);

            #endregion

            #region Insert and delete

            //Deleting Row
            sheet.DeleteRow(25);

            //Inserting Column
            sheet.InsertColumn(7, 1, ExcelInsertOptions.FormatAsBefore);
            sheet.Range["G4"].Text = "Loss/Gain";

            //Deleting Column
            sheet.DeleteColumn(8);

            #endregion

            #region ColumnWidth and RowHeight

            // Changing the Column Width
            sheet.Range["D5"].ColumnWidth = 15;

            // Changing the Row Height
            sheet.Range["D29"].RowHeight = 25;

            #endregion


            if (this.rdButtonxls.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel97to2003;
                fileName = "RCManipulations.xls";
            }
            else if (this.rdButtonxlsx.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel2007;
                fileName = "RCManipulations.xlsx";
            }
            else if (this.rdButtonexcel2010.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel2010;
                fileName = "RCManipulations.xlsx";
            }
            else if (this.rdButtonexcel2013.IsChecked.Value)
            {
                workbook.Version = ExcelVersion.Excel2013;
                fileName = "RCManipulations.xlsx";
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
                    System.Diagnostics.Process.Start(fileName);
                    //Exit
                    this.Close();
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

        /// <summary>
        /// Opens input template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Input_Click(object sender, RoutedEventArgs e)
        {
            //Launching the Input Template using the default Application.[MS Excel Or Free ExcelViewer]
            System.Diagnostics.Process.Start(@"..\..\..\..\..\..\..\Common\Data\XlsIO\monthly_sales.xls");
            //Exit
            this.Close();
        }
        # endregion
    }
}