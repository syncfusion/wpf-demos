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
using Syncfusion.Pdf.Security;
using Syncfusion.Pdf.Interactive;
using System.Drawing;
using Syncfusion.Windows.Shared;
using System.IO;
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Encryption : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window Constructor
        /// </summary>
        public Encryption()
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
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;

            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 20f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;
            PdfForm form = document.Form;

            //Document security
            PdfSecurity security = document.Security;

            //Specify the key size and encryption algorithm
            if(rdButton40Bit.IsChecked == true)
            {
                //use 40 bits key in RC4 mode
                security.KeySize = PdfEncryptionKeySize.Key40Bit;
            }
            else if(rdButton128Bit.IsChecked == true)
            {                
                security.KeySize = PdfEncryptionKeySize.Key128Bit;
                if (rdButtonRc4.IsChecked == true)
                {
                    //use 128 bits key in RC4 mode
                    security.Algorithm = PdfEncryptionAlgorithm.RC4;
                }
                else if (rdButtonAes.IsChecked == true)
                {
                    //use 128 bits key in AES mode                
                    security.Algorithm = PdfEncryptionAlgorithm.AES;
                }
            }
            else if (rdButton256Bit.IsChecked == true)
            {
                //use 256 bits key
                security.KeySize = PdfEncryptionKeySize.Key256Bit;
                if (rdButtonAes.IsChecked == true)
                {
                    security.Algorithm = PdfEncryptionAlgorithm.AES;
                }
                else if (rdButtonAesGcm.IsChecked == true)
                {
                    security.Algorithm = PdfEncryptionAlgorithm.AESGCM;
                    document.FileStructure.Version = PdfVersion.Version2_0;
                }
            }
            else if (rdButton256Revision6.IsChecked == true)
            {
                //use 256 bits key in AES mode with Revision 6
                security.KeySize = PdfEncryptionKeySize.Key256BitRevision6;
                security.Algorithm = PdfEncryptionAlgorithm.AES;
            }
            if (!cmbencryptOption.IsEnabled || cmbencryptOption.SelectedIndex == 0)
                security.EncryptionOptions = PdfEncryptionOptions.EncryptAllContents;
            else if (cmbencryptOption.SelectedIndex == 1)
                security.EncryptionOptions = PdfEncryptionOptions.EncryptAllContentsExceptMetadata;
            else if (cmbencryptOption.SelectedIndex == 2)
            {
                //Read the file

                FileStream file = new FileStream(@"Assets\PDF\Products.xml", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);


                //Creates an attachment
                PdfAttachment attachment = new PdfAttachment("Products.xml", file);

                attachment.ModificationDate = DateTime.Now;

                attachment.Description = "About Syncfusion";

                attachment.MimeType = "application/txt";

                //Adds the attachment to the document
                document.Attachments.Add(attachment);

                security.EncryptionOptions = PdfEncryptionOptions.EncryptOnlyAttachments;
            }

            security.OwnerPassword = "syncfusion";
            security.Permissions = PdfPermissionsFlags.Print | PdfPermissionsFlags.FullQualityPrint;
            security.UserPassword = "password";

            string text = "Security options:\n\n" + String.Format("KeySize: {0}\n\nEncryption Algorithm: {4}\n\nOwner Password: {1}\n\nPermissions: {2}\n\n" +
                "User Password: {3}", security.KeySize, security.OwnerPassword, security.Permissions, security.UserPassword, security.Algorithm);
            if (rdButton256Revision6.IsChecked==true)
            {
                text += String.Format("\n\nRevision: {0}", "Revision6");              
            }
            else if (rdButton256Bit.IsChecked == true && rdButtonAes.IsChecked == true)
            {
                text += String.Format("\n\nRevision: {0}", "Revision5");
            }
            else if (rdButton256Bit.IsChecked == true && rdButtonAesGcm.IsChecked == true)
            {
                text += String.Format("\n\nRevision: {0}", "Revision7");
            }
            graphics.DrawString("Document is Encrypted with following settings", font, brush, PointF.Empty);
            font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16f, PdfFontStyle.Bold);
            graphics.DrawString(text, font, brush, new PointF(0, 40));

            document.Save("Encryption.pdf");
			document.Close(true);

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Encryption.pdf") { UseShellExecute = true };
                process.Start();
            }
        }
        # endregion
         
        private void rdButton40Bit_Checked(object sender, RoutedEventArgs e)
        {
            if (rdButtonRc4 != null)
            {
                rdButtonRc4.IsEnabled = true;
                rdButtonRc4.IsChecked = true;
                rdButtonAes.IsEnabled = false;
                rdButtonAesGcm.IsEnabled = false;
                cmbencryptOption.IsEnabled = false;
            }
        }

        private void rdButton256Revision6_Checked(object sender, RoutedEventArgs e)
        {
            rdButtonAes.IsEnabled = true;
            rdButtonAes.IsChecked = true;
            rdButtonRc4.IsEnabled = false;
            rdButtonAesGcm.IsEnabled = false;
            cmbencryptOption.IsEnabled = true;
        }

        private void rdButton128Bit_Checked(object sender, RoutedEventArgs e)
        {
            if (rdButton128Bit != null && rdButtonRc4 != null && rdButtonAes != null)
            {
                rdButtonRc4.IsEnabled = true;
                rdButtonAes.IsEnabled = true;
                rdButtonAesGcm.IsEnabled = false;
                cmbencryptOption.IsEnabled = !rdButtonRc4.IsChecked.Value;
            }
        }

        private void rdButtonRc4_Checked(object s, RoutedEventArgs e)
        {
            if (rdButtonRc4 != null)
            {
                cmbencryptOption.IsEnabled = !rdButtonRc4.IsChecked.Value;
            }

        }
        private void rdButtonAes_Checked(object s, RoutedEventArgs e)
        {
            if (rdButtonAes != null)
            {
                cmbencryptOption.IsEnabled = rdButtonAes.IsChecked.Value;
            }

        }
        private void rdButtonAesGcm_Checked(object s, RoutedEventArgs e)
        {
            if (rdButtonAesGcm != null)
            {
                cmbencryptOption.IsEnabled = rdButtonAesGcm.IsChecked.Value;
            }

        }
        private void rdButton256Bit_Checked(object sender, RoutedEventArgs e)
        {
            rdButtonAes.IsEnabled = true;
            rdButtonAes.IsChecked = true;
            rdButtonAesGcm.IsEnabled = true;
            rdButtonRc4.IsEnabled = false;
            cmbencryptOption.IsEnabled = true;
        }
    }
}
