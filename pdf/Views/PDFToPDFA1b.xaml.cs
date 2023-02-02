#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PDFToPDFA1b : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public PDFToPDFA1b()
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
            int conformanceValue = this.comboBox.SelectedIndex;
            //Load an existing PDF.
            PdfLoadedDocument doc = new PdfLoadedDocument(@"Assets\PDF\StandardFont.pdf");

            //Set the conformance for PDF/A-1b conversion.
            switch (conformanceValue)
            {
                case 0:
                    doc.Conformance = PdfConformanceLevel.Pdf_A1B;
                    break;

                case 1:
                    doc.Conformance = PdfConformanceLevel.Pdf_A2B;
                    break;

                case 2:
                    doc.Conformance = PdfConformanceLevel.Pdf_A3B;
                    break;
                case 3:
                    doc.Conformance = PdfConformanceLevel.Pdf_A4;
                    break;
            }

            doc.Save("PDFToPDFA.pdf");
			doc.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("PDFToPDFA.pdf") { UseShellExecute = true };
                process.Start();
            }
        }
        # endregion
    }
}
