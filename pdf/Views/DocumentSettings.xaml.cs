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
using Syncfusion.Pdf.Xmp;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DocumentSettings : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public DocumentSettings()
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
        #endregion
        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Create a new PDF Document. The pdfDoc object represents the PDF document.
            //This document has one page by default and additional pages have to be added.
            PdfDocument pdfDoc = new PdfDocument();
            PdfPage page = pdfDoc.Pages.Add();

            // Get xmp object.
            XmpMetadata xmp = pdfDoc.DocumentInformation.XmpMetadata;

            // XMP Basic Schema.
            BasicSchema basic = xmp.BasicSchema;
            basic.Advisory.Add("advisory");
            basic.BaseURL = new Uri("http://google.com");
            basic.CreateDate = DateTime.Now;
            basic.CreatorTool = "creator tool";
            basic.Identifier.Add("identifier");
            basic.Label = "label";
            basic.MetadataDate = DateTime.Now;
            basic.ModifyDate = DateTime.Now;
            basic.Nickname = "nickname";
            basic.Rating.Add(-25);

            //Setting various Document properties.
            pdfDoc.DocumentInformation.Title = "Document Properties Information";
            pdfDoc.DocumentInformation.Author = "Syncfusion";
            pdfDoc.DocumentInformation.Keywords = "PDF";
            pdfDoc.DocumentInformation.Subject = "PDF demo";
            pdfDoc.DocumentInformation.Producer = "Syncfusion Software";
            pdfDoc.DocumentInformation.CreationDate = DateTime.Now;

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f);
            PdfFont boldFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;

            PdfGraphics g = page.Graphics;
            PdfStringFormat format = new PdfStringFormat();
            format.LineSpacing = 10f;

            g.DrawString("Press Ctrl+D to see Document Properties", boldFont, brush, 10, 10);
            g.DrawString("Basic Schema Xml:", boldFont, brush, 10, 50);
            g.DrawString(basic.XmlData.OuterXml, font, brush, new RectangleF(10, 70, 500, 500), format);

            //Save the PDF Document to disk.
            pdfDoc.Save("DocumentSettings.pdf");
			pdfDoc.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("DocumentSettings.pdf") { UseShellExecute = true };
                process.Start();
            }
        }
        # endregion
    }
}
