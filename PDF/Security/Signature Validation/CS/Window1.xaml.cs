#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.IO;
using Syncfusion.Windows.Shared;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Security;
using System.Security.Cryptography.X509Certificates;

namespace DigitalSignatureValidation
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
		    
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
#if NETCORE
            string file = @"..\..\..\..\..\..\..\Common\Images\PDF\" + "pdf_header.png";
#else
            string file = @"..\..\..\..\..\..\Common\Images\PDF\" + "pdf_header.png";
#endif
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
#if NETCORE
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\images\PDF\pdf_button.png");
#else
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\images\PDF\pdf_button.png");
#endif
        }
        # endregion
        # region Fields        
        System.Drawing.Color gray = System.Drawing.Color.FromArgb(255, 77, 77, 77);
        System.Drawing.Color black = System.Drawing.Color.FromArgb(255, 0, 0, 0);
        System.Drawing.Color white = System.Drawing.Color.FromArgb(255, 255, 255, 255);
        System.Drawing.Color violet = System.Drawing.Color.FromArgb(255, 151, 108, 174);
        #endregion
        # region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Clear();
            string filename = "DigitalSignature.pdf";
#if NETCORE
            FileStream input = File.Open(@"..\..\..\..\..\..\..\Common\Data\PDF\"+ filename, FileMode.Open);
#else
            FileStream input = File.Open(@"..\..\..\..\..\..\Common\Data\PDF\"+ filename, FileMode.Open);
#endif
           

            //Load an existing PDF document.
            PdfLoadedDocument ldoc = new PdfLoadedDocument(input);

            //Get signature field
            PdfLoadedSignatureField lSigFld = ldoc.Form.Fields[0] as PdfLoadedSignatureField;

            //Signature verfication with X509Certificate2 collection to check signer's identify
            X509CertificateCollection collection = new X509CertificateCollection();
#if NETCORE
            X509Certificate2 certificate = new X509Certificate2(@"..\..\..\..\..\..\..\Common\Data\PDF\PDF.pfx", "password123");
#else
            X509Certificate2 certificate = new X509Certificate2(@"..\..\..\..\..\..\Common\Data\PDF\PDF.pfx", "password123");
#endif
			
			//Add the certificate to the collection.
            collection.Add(certificate);
			
			 //Validate signature and get the validation result.
            PdfSignatureValidationResult result = lSigFld.ValidateSignature(collection);
             
			 WriteText("Signature is " + result.SignatureStatus);
            
            WriteTextNewLine();
            WriteText("--------Validation Summary--------");
            WriteTextNewLine();

            //Checks whether the document is modified or not.
            bool isModified = result.IsDocumentModified;
            if (isModified)
                WriteText("The document has been altered or corrupted since the signature was applied.");
            else
                WriteText("The document has not been modified since the signature was applied.");

            //Signature details
            WriteText("Digitally signed by " + lSigFld.Signature.Certificate.IssuerName);
            WriteText("Valid From : " + lSigFld.Signature.Certificate.ValidFrom);
            WriteText("Valid To : " + lSigFld.Signature.Certificate.ValidTo);
            WriteText("Signature Algorithm : " + result.SignatureAlgorithm);
            WriteText("Hash Algorithm : " + result.DigestAlgorithm);
            
            //Revocation validation details.
            WriteText("OCSP revocation status : " + result.RevocationResult.OcspRevocationStatus);
            if (result.RevocationResult.OcspRevocationStatus == RevocationStatus.None && result.RevocationResult.IsRevokedCRL)
                WriteText("CRL is revoked.");
           
            //Close the document.
            ldoc.Close(true);

        }
        private void WriteText(string txt)
        {
            ResultBox.AppendText(txt + System.Environment.NewLine);
        }
        private void WriteTextNewLine()
        {
            ResultBox.AppendText(System.Environment.NewLine);
        }

        #endregion
    }
}
