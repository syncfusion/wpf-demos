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
using Syncfusion.XlsIO.Implementation;
using Syncfusion.Windows.Shared;
using System.IO;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for ImportHTMLTable.xaml
    /// </summary>
    public partial class ImportHTMLTable : DemoControl
    {
        # region Constructor
        /// <summary>
        /// ImportHTMLTable constructor
        /// </summary>
        public ImportHTMLTable()
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
        /// Imports spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            // New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            // The instantiation process consists of two steps.

            // Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();

            // Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            // A workbook is created.
            IWorkbook workbook = application.Workbooks.Create(1);

            workbook.Version = ExcelVersion.Excel2016;

            // The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];
            if (chkboxImportHTMLformula.IsChecked.Value)
            {
                sheet.ImportHtmlTable(@"Assets\XlsIO\HTMLwithFormulaToExcel.html", 1, 1, HtmlImportOptions.DetectFormulas);
                sheet.Range["E2:F25"].NumberFormat = "_($* #,##0.00_);_($* (#,##0.00)";
                sheet.Range["H2:I25"].NumberFormat = "_($* #,##0.00_);_($* (#,##0.00)";
            }
            else
            {
                sheet.ImportHtmlTable(@"Assets\XlsIO\HTMLToExcel.html", 1, 1);
            }
            sheet.UsedRange.AutofitColumns();
			
			sheet.UsedRange.AutofitRows();

            string filename = "Import-HTML-Table.xlsx";

            workbook.SaveAs(filename);

            //Close the excel engine.
            excelEngine.Dispose();

            //Message box confirmation to view the created spreadsheet.
            if (MessageBox.Show("Do you want to view the Workbook?", "Conversion successful",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                try
                {
                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(filename) { UseShellExecute = true };
                    process.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
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
            if(chkboxImportHTMLformula.IsChecked.Value)
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\XlsIO\HTMLwithFormulaToExcel.html") { UseShellExecute = true };
            else
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\XlsIO\HTMLToExcel.html") { UseShellExecute = true };
            process.Start();
        }
        #endregion
    }
}
