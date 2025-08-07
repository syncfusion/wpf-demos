#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using System.Diagnostics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Portfolio : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Portfolio()
        {
            InitializeComponent();
        }
        #endregion
        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        # endregion
        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of PdfDocument class.
            PdfDocument document = new PdfDocument();

            //Creating new portfoili
            document.PortfolioInformation = new PdfPortfolioInformation();

            //setting the view mode of the portfolio
            document.PortfolioInformation.ViewMode = PdfPortfolioViewMode.Tile;

            //Creating the attachment
            PdfAttachment pdfFile = new PdfAttachment(@"Assets\PDF\CorporateBrochure.pdf");
            pdfFile.FileName = "CorporateBrochure.pdf";

            //Creating the attachement
            PdfAttachment wordfile = new PdfAttachment(@"Assets\PDF\Stock.docx");
            wordfile.FileName = "Stock.docx";

            //Creating the attachement
            PdfAttachment excelfile = new PdfAttachment(@"Assets\PDF\Chart.xlsx");
            excelfile.FileName = "Chart.xlsx";

            //Setting the startup document to view
            document.PortfolioInformation.StartupDocument = pdfFile;

            //Adding the attachment into document
            document.Attachments.Add(pdfFile);
            document.Attachments.Add(wordfile);
            document.Attachments.Add(excelfile);

            //Adding new page into the document
            document.Pages.Add();
          


            // Save and close the document.
            document.Save("Portfolio.pdf");
            document.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Portfolio.pdf") { UseShellExecute = true };
                process.Start();

            }

        }

        # endregion
    }
}
