#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for WorksheetToHTML.xaml
    /// </summary>
    public partial class WorksheetToHTML : DemoControl
    {
        # region Constructor
        /// <summary>
        /// WorksheetToHTML constructor
        /// </summary>
        public WorksheetToHTML()
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

        #region Events
        /// <summary>
        /// Converts spreadsheet to HTML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertToHTML_Click(object sender, RoutedEventArgs e)
        {
            // New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            // The instantiation process consists of two steps.

            // Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();

            // Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            // An existing workbook is opened.
            IWorkbook workbook = application.Workbooks.Open(@"Assets\XlsIO\NorthwindTemplate.xls");

            // The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            string fileName = string.Empty;

            if (rdbtnWorksheet.IsChecked.Value)
            {
                fileName = "WorksheetToHTML.html";
                sheet.SaveAsHtml(fileName);

                //// We may also explicitly set Image path and Text mode
                //HtmlSaveOptions options = new HtmlSaveOptions();
                //options.TextMode = HtmlSaveOptions.GetText.DisplayText;
                //options.ImagePath = @"..\..\Output\";

                //// Specify the HtmlSaveOptions when saving the sheet as Html
                //sheet.SaveAsHtml("Sample.html", options);
            }
            else
            {
                fileName = "WorkbookToHTML.html";
                workbook.SaveAsHtml(fileName, HtmlSaveOptions.Default);
            }

            //Close the workbook.
            workbook.Close();
            excelEngine.Dispose();

            //Message box confirmation to view the created spreadsheet.
            if (MessageBox.Show("Do you want to view the HTML?", "Conversion successful",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                try
                {
                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName)
                    {
                        UseShellExecute = true
                    };
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
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\XlsIO\NorthwindTemplate.xls") { UseShellExecute = true };
            process.Start();
        }
        #endregion
    }
}
