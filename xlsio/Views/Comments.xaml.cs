#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
using Syncfusion.ExcelToPdfConverter;
using Syncfusion.Pdf;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for Comments.xaml
    /// </summary>
    public partial class Comments : DemoControl
    {
        # region Constructor
        /// <summary>
        /// WhatIfAnalysis constructor
        /// </summary>
        public Comments()
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

        #region Create the Document
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //Initialize ExcelEngine
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Initialize IApplication and set the default application version
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                //Load the Excel template into IWorkbook and get the worksheet into IWorksheet
                IWorkbook workbook = application.Workbooks.Open(@"Assets\XlsIO\CommentsTemplate.xlsx");
                IWorksheet worksheet = workbook.Worksheets[0];

                //Add Comments
                AddComments(worksheet);

                string filename = "ExcelComments.xlsx";
                workbook.SaveAs(filename);

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the Workbook?", "Creation successful",
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
        }
        #endregion 

        #region Convert the Document
        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            //Initialize ExcelEngine
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Initialize IApplication and set the default application version
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                //Load the Excel template into IWorkbook and get the worksheet into IWorksheet
                IWorkbook workbook = application.Workbooks.Open(@"Assets\XlsIO\CommentsTemplate.xlsx");
                IWorksheet worksheet = workbook.Worksheets[0];

                //Add Comments
                AddComments(worksheet);

                //Set print location of comments
                worksheet.PageSetup.PrintComments = ExcelPrintLocation.PrintSheetEnd;

                //Initialize ExcelToPdfConverter and PdfDocument
                ExcelToPdfConverter converter = new ExcelToPdfConverter(workbook);
                PdfDocument pdfDocument = new PdfDocument();

                //Convert Excel document to PDF
                pdfDocument = converter.Convert();

                string filename = "ExcelComments.pdf";
                pdfDocument.Save(filename);

                //Message box confirmation to view the created document.
                if (MessageBox.Show("Do you want to view the Document?", "Conversion successful",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the PDF file using the default Application.
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
        }
        #endregion 

        #region View the Input Template
        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            //Launching the Input Template using the default Application.[MS Excel Or Free ExcelViewer]
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\XlsIO\CommentsTemplate.xlsx") { UseShellExecute = true };
            process.Start();
        }
        #endregion

        #region Helper Methods
        private void AddComments(IWorksheet worksheet)
        {
            //Add Comments (Notes)
            IComment comment = worksheet.Range["H1"].AddComment();
            comment.Text = "This Total column comment will be printed at the end of sheet.";
            comment.IsVisible = true;

            //Add Threaded Comments
            IThreadedComment threadedComment = worksheet.Range["H16"].AddThreadedComment("What is the reason for the higher total amount of \"desk\"  in the west region?", "User1", DateTime.Now);
            threadedComment.AddReply("The unit cost of desk is higher compared to other items in the west region. As a result, the total amount is elevated.", "User2", DateTime.Now);
            threadedComment.AddReply("Additionally, Wilson sold 31 desks in the west region, which is also a contributing factor to the increased total amount.", "User3", DateTime.Now);
        }
        #endregion
    }
}
