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
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for InteractiveFeatures.xaml
    /// </summary>
    public partial class InteractiveFeatures : DemoControl
    {
        private string filename;

        # region Constructor
        /// <summary>
        /// InteractiveFeatures constructor
        /// </summary>
        public InteractiveFeatures()
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
                filename = "InteractivityFeatures.xls";
            }
            else if (this.rdbtnXLSX.IsChecked.Value)
            {
                application.DefaultVersion = ExcelVersion.Xlsx;
                filename = "InteractivityFeatures.xlsx";
            }

            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 3 worksheets
            IWorkbook workbook = application.Workbooks.Create(3);
            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];

            sheet.IsGridLinesVisible = false;

            sheet.Range["B2"].Text = "Interactive features";
            sheet.Range["B2"].CellStyle.Font.Bold = true;
            sheet.Range["B2"].CellStyle.Font.Size = 14;

            sheet.Range["A4"].Text = "Some Useful links";
            sheet.Range["A4"].CellStyle.Font.Bold = true;
            sheet.Range["A4"].CellStyle.Font.Size = 12;

            sheet.Range["A20"].Text = "Comments";
            sheet.Range["A20"].CellStyle.Font.Bold = true;
            sheet.Range["A20"].CellStyle.Font.Size = 12;

            sheet.Range["B5"].Text = "Feature page";
            sheet.Range["B7"].Text = "Support Email Id";
            sheet.Range["B9"].Text = "Samples";
            sheet.Range["B11"].Text = "Read the comment about XlsIO";
            sheet.Range["B13"].Text = "Read the Comment about Interactive features";
            sheet.Range["B20"].Text = "XlsIO";
            sheet.Range["B22"].Text = "Interactive features";

            #region Hyperlink
            //Creating Hyperlink for a Website
            IHyperLink hyperlink = sheet.HyperLinks.Add(sheet.Range["C5"]);
            hyperlink.Type = ExcelHyperLinkType.Url;
            hyperlink.Address = "http://www.syncfusion.com/products/windows-forms/xlsio";
            hyperlink.ScreenTip = "To know more About XlsIO go through this link";

            //Creating Hyperlink for e-mail
            IHyperLink hyperlink1 = sheet.HyperLinks.Add(sheet.Range["C7"]);
            hyperlink1.Type = ExcelHyperLinkType.Url;
            hyperlink1.Address = "mailto:support@syncfusion.com";
            hyperlink1.ScreenTip = "Send Mail to this id for your queries";

            //Creating Hyperlink for Opening Files using type as  File
            IHyperLink hyperlink2 = sheet.HyperLinks.Add(sheet.Range["C9"]);
            hyperlink2.Type = ExcelHyperLinkType.File;

            hyperlink2.Address = @"..\";
            hyperlink2.ScreenTip = "File path";
            hyperlink2.TextToDisplay = "Hyperlink for files using File as type";

            //Creating Hyperlink to another cell using type as Workbook
            IHyperLink hyperlink4 = sheet.HyperLinks.Add(sheet.Range["C11"]);
            hyperlink4.Type = ExcelHyperLinkType.Workbook;
            hyperlink4.Address = "Sheet1!B20";
            hyperlink4.ScreenTip = "Click here";
            hyperlink4.TextToDisplay = "Click here to move to the cell with Comments about XlsIO";

            IHyperLink hyperlink5 = sheet.HyperLinks.Add(sheet.Range["C13"]);
            hyperlink5.Type = ExcelHyperLinkType.Workbook;
            hyperlink5.Address = "Sheet1!B22";
            hyperlink5.ScreenTip = "Click here";
            hyperlink5.TextToDisplay = "Click here to move to the cell with Comments about this sample";

            #endregion

            #region Comments

            //Insert Comments
            //Adding comments to a cell.
            sheet.Range["B20"].AddComment().Text = "XlsIO is a Backoffice product with high performance!";

            //Add RichText Comments
            IRange range = sheet.Range["B22"];
            range.AddComment().RichText.Text = "Great Sample!";
            IRichTextString rtf = range.Comment.RichText;

            //Formatting first 4 characters
            IFont greyFont = workbook.CreateFont();
            greyFont.Bold = true;
            greyFont.Italic = true;
            greyFont.RGBColor = System.Drawing.Color.FromArgb(333365);
            rtf.SetFont(0, 3, greyFont);

            //Formatting last 4 characters
            IFont greenFont = workbook.CreateFont();
            greenFont.Bold = true;
            greenFont.Italic = true;
            greenFont.RGBColor = System.Drawing.Color.FromArgb(0x85, 0xbf, 0x75);
            rtf.SetFont(4, 7, greenFont);

            //Set column width
            sheet.Columns[0].ColumnWidth = 30;

            #endregion

            sheet.UsedRange.AutofitColumns();
            sheet.UsedRange.AutofitRows();

            try
            {
                //Saving the workbook to disk.
                workbook.SaveAs(filename);

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
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(filename) { UseShellExecute = true };
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