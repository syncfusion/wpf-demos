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
using Syncfusion.Pdf.Security;
using System.Drawing;
using Syncfusion.Pdf.Parsing;
using Microsoft.Win32;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using System.Windows.Resources;
using System.IO;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DigitalSignature : DemoControl
    {
        # region Private Members
        PdfSignature signature;
        PdfBitmap bmp;
        PdfGraphics g;
        # endregion

        # region Constructor

        /// <summary>
        /// Window Constructor
        /// </summary>
        public DigitalSignature()
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
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (this.txtSource.Text == String.Empty || this.txtCert.Text == String.Empty || !this.txtSource.Text.EndsWith(".pdf") || !this.txtCert.Text.EndsWith(".pfx"))
        //        MessageBox.Show("Please select a PDF document to sign, along with certificate and the password !!!", "Input file missing!", MessageBoxButton.OK, MessageBoxImage.Error);
        //    else
        //    {
        //        DebugBox.Clear();

        //        PdfBitmap bmp = new PdfBitmap(@"Asssets\PDF\PDFDemo.jpg");

        //        debug("Started ...");

        //        debug("Checking certificate ...");

        //        PdfPageBase page = doc.Pages[0];
        //        PdfCertificate pdfCert;
        //        try
        //        {
        //            pdfCert = new PdfCertificate(txtCert.Text, txtPassword.Password);
        //        }
        //        catch (Exception ex)
        //        {
        //            debug("Error : please make sure you entered a valid certificate file and password");
        //            debug("Exception : " + ex.ToString());
        //            return;
        //        }
        //        debug("Creating new MetaData ... ");
        //        PdfSignature signature = new PdfSignature(doc, page, pdfCert, "Signature");

        //        signature.Bounds = new RectangleF(new PointF(5, 5), bmp.PhysicalDimension);
        //        signature.ContactInfo = txtContact.Text;
        //        signature.LocationInfo = txtLocation.Text;
        //        signature.Reason = txtReason.Text;
        //        string validto = "Valid To: " + signature.Certificate.ValidTo.ToString();
        //        string validfrom = "Valid From: " + signature.Certificate.ValidFrom.ToString();

        //        UpdateSetting(signature);
        //        doc.Save("DigitalSignature.pdf");

        //        debug("Signing document ... ");

        //        debug("Done");

        //        doc.Close();

        //        //Message box confirmation to view the created PDF document.
        //        if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
        //            MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
        //        {
        //            //Launching the PDF file using the default Application.[Acrobat Reader]

        //            System.Diagnostics.Process.Start("DigitalSignature.pdf");

        //            this.Dispose();
        //        }
        //    }
        //}

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
                PdfCertificate pdfCert = new PdfCertificate( @"Assets\PDF\PDF.pfx", "password123");
                signature = new PdfSignature(page, pdfCert, "Signature");
                bmp = new PdfBitmap(GetFileStream("syncfusion_logo.gif"));
                signature.Bounds = new RectangleF(new PointF(5, 5), bmp.PhysicalDimension);
                signature.ContactInfo = "johndoe@owned.us";
                signature.LocationInfo = "Honolulu, Hawaii";
                signature.Reason = "I am author of this document.";

                if (radioBtnStandard.IsChecked.Value)
                    signature.Certificated = false;
                else
                    signature.Certificated = true;
                g = signature.Appearance.Normal.Graphics;

                UpdateSetting(signature);
            }
            catch (System.ArgumentNullException)
            {
                g = signature.Appearance.Normal.Graphics;

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
            doc.Save("DigitalSignature.pdf");
            debug("PdfDocument saved ...");

            doc.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("DigitalSignature.pdf") { UseShellExecute = true };
                process.Start();
            }
        }

        private void UpdateSetting(PdfSignature signature)
        {
            if (radioBtnCAdES.IsChecked.Value)
                signature.Settings.CryptographicStandard = CryptographicStandard.CADES;
            else
                signature.Settings.CryptographicStandard = CryptographicStandard.CMS;

            if (radioBtnStandardSHA1.IsChecked.Value)
                signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA1;
            else if (radioBtnAuthorSHA384.IsChecked.Value)
                signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA384;
            else if (radioBtnAuthorSHA512.IsChecked.Value)
                signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA512;
            else if (radioBtnAuthorRIPEMD160.IsChecked.Value)
                signature.Settings.DigestAlgorithm = DigestAlgorithm.RIPEMD160;
            else
                signature.Settings.DigestAlgorithm = DigestAlgorithm.SHA256;
        }
        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfdemos.wpf;component/Assets/PDF/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }
        /// <summary>
        /// Gets the source document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFile = new OpenFileDialog();
        //    //openFile.InitialDirectory = fileLocation;
        //    openFile.Filter = "PDF files *.pdf|*.pdf";
        //    openFile.Title = "Select a file";
        //    if (openFile.ShowDialog().Value)
        //    {
        //        txtSource.Text = openFile.FileName;
        //        doc = new PdfLoadedDocument(txtSource.Text);
        //    }
        //}

        /// <summary>
        /// Gets the certificate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFile2 = new OpenFileDialog();
        //    //openFile2.InitialDirectory = fileLocation;
        //    openFile2.Filter = "Certificate files *.pfx|*.pfx";
        //    openFile2.Title = "Select a file";
        //    if (openFile2.ShowDialog().Value)
        //    {
        //        txtCert.Text = openFile2.FileName;
        //    }
        //}
        # endregion
    }
}
