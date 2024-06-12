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
using System.Drawing.Imaging;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for WorksheetToImage.xaml
    /// </summary>
    public partial class WorksheetToImage : DemoControl
    {
        #region
        /// <summary>
        /// File Name
        /// </summary>
        string filename;
        #endregion

        # region Constructor
        /// <summary>
        /// WorksheetToImage constructor
        /// </summary>
        public WorksheetToImage()
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
        /// Converts spreadsheet to Image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertToImage_Click(object sender, RoutedEventArgs e)
        {
            // New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            // The instantiation process consists of two steps.

            // Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();

            // Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2007;

            // An existing workbook is opened.
            IWorkbook workbook = application.Workbooks.Open(@"Assets\XlsIO\WorkSheetToImage.xlsx");

            // The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets["Sheet1"];

            sheet.UsedRangeIncludesFormatting = false;
            int lastRow = sheet.UsedRange.LastRow + 1;
            int lastColumn = sheet.UsedRange.LastColumn + 1;

            // Save the image.
            if (this.rdbtnBitmap.IsChecked.Value)
            {
                // Convert the worksheet to image
                System.Drawing.Image img = sheet.ConvertToImage(1, 1, lastRow, lastColumn, ImageType.Bitmap, null);

                filename = "Sample.png";
                img.Save(filename, ImageFormat.Png);
            }
            else
            {
                // Convert the worksheet to image
                System.Drawing.Image img = sheet.ConvertToImage(1, 1, lastRow, lastColumn, ImageType.Metafile, null);

                filename = "Sample.emf";
                img.Save(filename, ImageFormat.Emf);
            }

            //Close the workbook.
            workbook.Close();
            excelEngine.Dispose();

            //Message box confirmation to view the created spreadsheet.
            if (MessageBox.Show("Do you want to view the image?", "Image has been created",
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
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\XlsIO\WorkSheetToImage.xlsx") { UseShellExecute = true };
            process.Start();
        }
        #endregion
    }
}
