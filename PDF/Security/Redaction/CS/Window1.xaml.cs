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
using System.IO;
using Syncfusion.Windows.Shared;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;

namespace Hello_World
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        #region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
		    
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string file = GetFullTemplatePath("pdf_header.png", true);
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
            this.Icon = (ImageSource)img.ConvertFromString(GetFullTemplatePath("pdf_button.png", true));     
        }
        #endregion

        #region Events
        /// <summary>
        /// Creates PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Load a PDF document.
            PdfLoadedDocument document = new PdfLoadedDocument(GetFullTemplatePath("EmpDetails.pdf", false));

            //Get first page from document
            PdfLoadedPage page = document.Pages[0] as PdfLoadedPage;

            //Create PDF redaction for the page to redact text
            PdfRedaction textRedaction = new PdfRedaction(new RectangleF(343, 147, 60, 17), System.Drawing.Color.Black);
            //Create PDF redaction for the page to redact image
            PdfRedaction imageRedaction = new PdfRedaction(new RectangleF(67, 372, 178, 158), System.Drawing.Color.Black);
            
            //Adds the redactions to loaded page
            page.Redactions.Add(textRedaction);
            page.Redactions.Add(imageRedaction);

            //Save the PDF document
            document.Save("Redacted.pdf");

            //Message box confirmation to view the created PDF document.
            if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the PDF file using the default Application.[Acrobat Reader]
#if NETCORE
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Redacted.pdf")
                {
                    UseShellExecute = true
                };
                process.Start();
#else
                Process.Start("Redacted.pdf");
#endif
                this.Close();
            }
            else
                // Exit
                this.Close();
        }
        #endregion
        #region Helper Methods
        /// <summary>
        /// Gets the full path of the PDF template or image.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="image">True if image</param>
        /// <returns>Path of the file</returns>
        private string GetFullTemplatePath(string fileName, bool image)
        {
#if NETCORE
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\..\Common\";
#else
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\..\Common\";
#endif
            string folder = image ? "Images" : "Data";

            return string.Format(@"{0}{1}\PDF\{2}", fullPath, folder, fileName);
        }

        #endregion
    }
}
