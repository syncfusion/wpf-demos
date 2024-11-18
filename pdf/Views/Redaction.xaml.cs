#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.IO;
using Syncfusion.Windows.Shared;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Redaction : DemoControl
    {
        #region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Redaction()
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
        #region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Load a PDF document.
            PdfLoadedDocument document = new PdfLoadedDocument(@"Assets\PDF\Redaction.pdf");
            //Get first page from document
            PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;
            //Create PDF redaction for the page to redact text
			PdfRedaction textRedaction = new PdfRedaction(new RectangleF(86.998f,39.565f,62.709f,20.802f), System.Drawing.Color.Black);
			//Create PDF redaction for the page to redact text
			PdfRedaction pathRedaction = new PdfRedaction(new RectangleF(83.7744f,576.066f,210.0746f,104.155f), System.Drawing.Color.Black);
			//Create PDF redaction for the page to redact text
			PdfRedaction imageRedaction = new PdfRedaction(new RectangleF(327.848f,63.97198f,232.179f,223.429f), System.Drawing.Color.Black);
                    
            //Adds the redactions to loaded page
            page.Redactions.Add(textRedaction);
            page.Redactions.Add(pathRedaction);
            page.Redactions.Add(imageRedaction);

            //Save the PDF document
            document.Save("Redaction.pdf");
			document.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Redaction.pdf") { UseShellExecute = true };
                process.Start();

            }

        }
        #endregion
    }
}
