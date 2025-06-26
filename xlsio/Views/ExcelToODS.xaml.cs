#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Diagnostics;
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
    /// Interaction logic for ExcelToODS.xaml
    /// </summary>
    public partial class ExcelToODS : DemoControl
    {
        #region Constants
        private const string DEFAULTPATH = @"Assets\XlsIO\{0}";      
        #endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public ExcelToODS()
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
        private void btnExcelToODS_Click(object sender, RoutedEventArgs e)
        {
            #region Initialize Workbook
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;
            string inputPath = GetFullTemplatePath("ExcelToODS.xlsx");

            IWorkbook workbook = application.Workbooks.Open(inputPath, ExcelOpenType.Automatic);
            #endregion

            try
            {
                #region Workbook Save
                string filename = "ExcelToODS.ods";
                workbook.SaveAs(filename);
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