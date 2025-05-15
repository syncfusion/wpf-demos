#region Copyright Syncfusion Inc. 2001 - 2012
// Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
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
using System.Data;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for DocumentSettings.xaml
    /// </summary>
    public partial class DocumentSettings : DemoControl
    {
        private string fileName;
        # region Constructor
        /// <summary>
        /// DocumentSettings constructor
        /// </summary>
        public DocumentSettings()
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
            //New instance of XlsIO is created.[Equivalent to launching MS Excel with no workbooks open].
            //The instantiation process consists of two steps.

            //Step 1 : Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new ExcelEngine();
            //Step 2 : Instantiate the excel application object.
            IApplication application = excelEngine.Excel;

            if (this.rdbtnXLS.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Excel97to2003;
                fileName = "Settings.xls";
            }
            else if (this.rdbtnXLSX.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Xlsx;
                fileName = "Settings.xlsx";
            }

            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 3 worksheets
            IWorkbook workbook = application.Workbooks.Create(3);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            //Get order details 
            DataSet northwindData = new DataSet();
            northwindData.ReadXml(@"Assets\XlsIO\Orders.xml", XmlReadMode.Auto);
            sheet.ImportDataTable(northwindData.Tables["Orders"], true, 6, 1, -1, 9, false);

            # region Document Properties

            //Setting Builtin document Properties     
            workbook.Author = "Essential XlsIO";
            workbook.BuiltInDocumentProperties.ApplicationName = "Essential XlsIO";
            workbook.BuiltInDocumentProperties.Category = "Excel Generator";
            workbook.BuiltInDocumentProperties.Comments = "This document was generated using Essential XlsIO";
            workbook.BuiltInDocumentProperties.Company = "Syncfusion Inc.";
            workbook.BuiltInDocumentProperties.Subject = "Native Excel Generator";
            workbook.BuiltInDocumentProperties.Keywords = "Syncfusion";
            workbook.BuiltInDocumentProperties.Manager = "Sync Manager";
            workbook.BuiltInDocumentProperties.Title = "Essential XlsIO";

            //Setting Custom document Properties.
            ICustomDocumentProperties customProperites = workbook.CustomDocumentProperties;
            customProperites["Author"].Text = "Test Author";
            customProperites["Comments"].Text = "XlsIO support Custom document properties";
            customProperites["Double"].Double = 120.2;
            customProperites["Choice"].Boolean = true;
            customProperites["Today"].DateTime = DateTime.Today;
            customProperites["Integer"].Int32 = 1234;
            #endregion

            # region Header and Footer

            // Setting the Page number in the Center Header
            sheet.PageSetup.CenterHeader = "&P";

            // Setting the Date in the Right Header
            sheet.PageSetup.LeftHeader = "&D";
            // Setting the file name in the Center Footer
            sheet.PageSetup.CenterFooter = "&F";
            // Setting the Sheet Name in the Left Footer
            sheet.PageSetup.LeftFooter = "&A";

            System.Drawing.Image img = System.Drawing.Image.FromFile(@"Assets\XlsIO\logo.jpg");
            // Right Header Image
            sheet.PageSetup.RightHeaderImage = img;
            sheet.PageSetup.RightHeader = "&G";

            sheet.PageSetup.AutoFirstPageNumber = false;
            sheet.PageSetup.FirstPageNumber = 2;

            #endregion

            # region Margin

            //Setting page Margins
            sheet.PageSetup.LeftMargin = 2;
            sheet.PageSetup.RightMargin = 2;
            sheet.PageSetup.TopMargin = 2;
            sheet.PageSetup.BottomMargin = 2;

            #endregion

            #region Page setup

            // Setting the Page Orientation as Portrait or Landscape	
            sheet.PageSetup.Orientation = ExcelPageOrientation.Landscape;

            // Setting the Paper Type
            sheet.PageSetup.PaperSize = ExcelPaperSize.PaperA4;

            #endregion

            # region Page break

            // Giving Horizontal pagebreaks 
            sheet.HPageBreaks.Add(sheet.Range["A105"]);
            sheet.HPageBreaks.Add(sheet.Range["A200"]);

            // Giving Vertical pagebreaks
            sheet.VPageBreaks.Add(sheet.Range["H100"]);

            #endregion

            #region Format Header rows
            sheet.Range["D2"].Text = "Order Details";
            sheet.Range["D2:E2"].Merge();
            sheet.Range["D2"].CellStyle.Font.Size = 10;
            sheet.Range["D2"].CellStyle.Font.Bold = true;
            sheet.Range["D2"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;

            sheet.Rows[4].CellStyle.Color = System.Drawing.Color.FromArgb(182, 189, 218);
            sheet.Rows[4].CellStyle.Font.Size = 10;
            sheet.Rows[4].CellStyle.Font.Bold = true;

            sheet.UsedRange.AutofitColumns();
            sheet.IsGridLinesVisible = false;

            sheet.Range["A4"].Text = "Note: Please check File->Properties for document properties and File->PageSetUp for page set up options";
            sheet.Range["A4"].CellStyle.Font.Bold = true;

            #endregion


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
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(fileName)
                    {
                        UseShellExecute = true
                    };
                    process.Start();
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