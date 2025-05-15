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
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for OleObject.xaml
    /// </summary>
    public partial class OleObject : DemoControl
    {
        # region Constructor
        /// <summary>
        /// OleObject constructor
        /// </summary>
        public OleObject()
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
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;
            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet sheet = workbook.Worksheets[0];

            sheet.IsGridLinesVisible = false;
            sheet.Pictures.AddPicture(2, 5, @"Assets\XlsIO\header.gif");

            sheet["E5:M6"].Merge();
            sheet[5, 5].Text = "Syncfusion accept fax orders from customers worldwide. You can also order online through our secure web server.";
            sheet[5, 5].WrapText = true;

            sheet[8, 6].Text = "PDF Order Form";

            IOleObject oleObject1 = sheet.OleObjects.Add(@"Assets\XlsIO\FaxOrderForm.pdf", System.Drawing.Image.FromFile(@"Assets\XlsIO\pdfIcon.jpg"), OleLinkType.Embed);
            oleObject1.Location = sheet[8, 11];
            oleObject1.Size = new System.Drawing.Size(100, 100);

            sheet[17, 6].Text = "Word Order Form";

            IOleObject oleObject2 = sheet.OleObjects.Add(@"Assets\XlsIO\FaxOrderForm.doc", System.Drawing.Image.FromFile(@"Assets\XlsIO\wordIcon.jpg"), OleLinkType.Embed);
            oleObject2.Location = sheet[17, 11];
            oleObject2.Size = new System.Drawing.Size(100, 100);

            sheet[25, 5].Text = "Download the order form, print it out and fill in the required information.";

            try
            {
                string filename = "OleObject.xlsx";
                workbook.SaveAs(filename);
                workbook.Close();
                excelEngine.Dispose();

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
                        MessageBox.Show("Excel 2007 is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }
        #endregion
    }
}
