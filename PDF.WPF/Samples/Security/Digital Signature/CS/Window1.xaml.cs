#region Copyright Syncfusion Inc. 2001 - 2018
// Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
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
using Syncfusion.Pdf.Security;
using System.Drawing;
using Syncfusion.Pdf.Parsing;
using Microsoft.Win32;
using Syncfusion.Windows.Shared;


namespace DigitalSignature
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        PdfLoadedDocument doc;
        PdfSignature signature;
        PdfBitmap bmp;
        PdfGraphics g;
        string fileLocation = @"..\..\..\..\..\..\..\Common\Data\PDF\";
        # endregion

        # region Constructor

        /// <summary>
        /// Window Constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            this.image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\PDF\" + "pdf_header.png");
            this.image2.ToolTip = "For the PDF.pfx certificate in\nthe Application folder 'syncfusion' is\nthe password.";
            this.Width = 445;
			this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\images\PDF\pdf_button.png");
        }
        # endregion

        # region Helpher Methods
        private void debug(string txt)
        {
            DebugBox.AppendText(txt + System.Environment.NewLine);
        }
        # endregion

        # region Events
        /// <summary>
        /// Opens existing PDF and signs it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtSource.Text == String.Empty || this.txtCert.Text == String.Empty || !this.txtSource.Text.EndsWith(".pdf") || !this.txtCert.Text.EndsWith(".pfx"))
                MessageBox.Show("Please select a PDF document to sign, along with certificate and the password !!!", "Input file missing!", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                DebugBox.Clear();
                fileLocation = @"..\..\Common\Data\PDF\";

                PdfBitmap bmp = new PdfBitmap(@"..\..\..\..\..\..\..\Common\Images\PDF\" + "PDFDemo.jpg");
                debug("Started ...");

                debug("Checking certificate ...");

                PdfPageBase page = doc.Pages[0];
                PdfCertificate pdfCert;
                try
                {
                    pdfCert = new PdfCertificate(txtCert.Text, txtPassword.Password);
                }
                catch (Exception ex)
                {
                    debug("Error : please make sure you entered a valid certificate file and password");
                    debug("Exception : " + ex.ToString());
                    return;
                }
                debug("Creating new MetaData ... ");
                PdfSignature signature = new PdfSignature(doc, page, pdfCert, "Signature");

                signature.Bounds = new RectangleF(new PointF(5, 5), bmp.PhysicalDimension);
                signature.ContactInfo = txtContact.Text;
                signature.LocationInfo = txtLocation.Text;
                signature.Reason = txtReason.Text;
                string validto = "Valid To: " + signature.Certificate.ValidTo.ToString();
                string validfrom = "Valid From: " + signature.Certificate.ValidFrom.ToString();

                doc.Save("SignedPdfSample.pdf");

                debug("Signing document ... ");

                debug("Done");

                doc.Close();

                //Message box confirmation to view the created PDF document.
                if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the PDF file using the default Application.[Acrobat Reader]
                    System.Diagnostics.Process.Start("SignedPdfSample.pdf");
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Creates new PDF and signs it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewPDF_Click(object sender, RoutedEventArgs e)
        {
            DebugBox.Clear();
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.Pages.Add();
            PdfSolidBrush brush = new PdfSolidBrush(System.Drawing.Color.Black);
            PdfPen pen = new PdfPen(brush, 0.2f);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Courier, 12, PdfFontStyle.Regular);

            debug("PdfDocument created ...");

            try
            {
                PdfCertificate pdfCert = new PdfCertificate(fileLocation + "PDF.pfx", "syncfusion");
                signature = new PdfSignature(page, pdfCert, "Signature");
                bmp = new PdfBitmap(@"..\..\..\..\..\..\..\Common\Images\PDF\"+"syncfusion_logo.gif");

                signature.Bounds = new RectangleF(new PointF(5, 5), bmp.PhysicalDimension);
                signature.ContactInfo = "johndoe@owned.us";
                signature.LocationInfo = "Honolulu, Hawaii";
                signature.Reason = "I am author of this document.";

                if (radioBtnStandard.IsChecked.Value)
                    signature.Certificated = false;
                else
                    signature.Certificated = true;
                g = signature.Appearence.Normal.Graphics;

            }
            catch (System.ArgumentNullException)
            {
                g = signature.Appearence.Normal.Graphics;

                MessageBox.Show("Warning Certificate not found \"Cannot sign This Document\"", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //Draw the Text at specified location.
                g.DrawString("Warning this document is not signed", font, brush, new PointF(0, 20));
                g.DrawString("Create a self signed Digital ID to sign this document", font, brush, new PointF(20, 40));
                g.DrawLine(pen, new PointF(0, 100), new PointF(page.GetClientSize().Width, 200));
                g.DrawLine(pen, new PointF(0, 200), new PointF(page.GetClientSize().Width, 100));

            }
            string validto = "Valid To: " + signature.Certificate.ValidTo.ToString();
            string validfrom = "Valid From: " + signature.Certificate.ValidFrom.ToString();

            g.DrawImage(bmp, 0, 0);

            doc.Pages[0].Graphics.DrawString(validfrom, font, pen, brush, 0, 90);
            doc.Pages[0].Graphics.DrawString(validto, font, pen, brush, 0, 110);

            doc.Pages[0].Graphics.DrawString(" Protected Document. Digitally signed Document.", font, pen, brush, 0, 130);
            doc.Pages[0].Graphics.DrawString("* To validate Signature click on the signature on this page \n * To check Document Status \n click document status icon on the bottom left of the acrobat reader.", font, pen, brush, 0, 150);

            debug("PdfDocument signed ...");

            // Save the PDF file.
            doc.Save("Sample.pdf");
            debug("PdfDocument saved ...");

            doc.Close();

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process.Start("Sample.pdf");
                this.Close();
            }
        }

        /// <summary>
        /// Gets the source document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            //openFile.InitialDirectory = fileLocation;
            openFile.Filter = "PDF files *.pdf|*.pdf";
            openFile.Title = "Select a file";
            if (openFile.ShowDialog().Value)
            {
                txtSource.Text = openFile.FileName;
                doc = new PdfLoadedDocument(txtSource.Text);
            }
        }

        /// <summary>
        /// Gets the certificate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile2 = new OpenFileDialog();
            //openFile2.InitialDirectory = fileLocation;
            openFile2.Filter = "Certificate files *.pfx|*.pfx";
            openFile2.Title = "Select a file";
            if (openFile2.ShowDialog().Value)
            {
                txtCert.Text = openFile2.FileName;
            }
        }
        # endregion
    }
}