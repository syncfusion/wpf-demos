#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Syncfusion.PdfToImageConverter;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for PDFToImage.xaml
    /// </summary>
    public partial class PDFToImage : DemoControl
    {
        string filePath;
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public PDFToImage()
        {

            InitializeComponent();
            filePath = @"Assets\PDF\imageDoc.pdf";
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
            if (this.textBoxSource.Text == "")
            {
                System.Windows.MessageBox.Show("Please select a PDF document");
                textBoxSource.Focus();
            }
            else
            {
                if (textBoxSource.Text != string.Empty && filePath != string.Empty)
                {
                    if (textBoxSource.Text.Contains("\\"))
                        filePath = textBoxSource.Text;
                }
                // Load an existing PDF
                FileStream inputStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
                PdfToImageConverter imageConverter = new PdfToImageConverter(inputStream);
                Stream[] outputStream = new Stream[imageConverter.PageCount];
                // Convert all the PDF pages to images
                if (imageConverter.PageCount > 1)
                {
                    outputStream = imageConverter.Convert(0, imageConverter.PageCount - 1, false, false);
                }
                else if(imageConverter.PageCount == 1)
                {
                    outputStream[0] = imageConverter.Convert(0, false, false);
                }

                if (!Directory.Exists("PdfToImage"))
                {
                    Directory.CreateDirectory("PdfToImage");
                }
                // Saves the images to destination folder
                foreach (Stream stream in outputStream)
                {
                    if (stream != null)
                    {
                        System.Drawing.Bitmap image = new System.Drawing.Bitmap(stream);
                        image.Save(@"PdfToImage\Image" + Guid.NewGuid().ToString() + ".png", ImageFormat.Png);
                    }
                }

                imageConverter.Dispose();

                //Message box confirmation to view the created PDF document.
                if (System.Windows.MessageBox.Show("Do you want to view the converted image files?", "Image Converted",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the PDF file using the default Application.[Acrobat Reader]
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(System.IO.Directory.GetCurrentDirectory() + @"\PdfToImage\") { UseShellExecute = true };
                    process.Start();
                }

            }
        }
        /// <summary>
        /// Gets the source document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSource_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog file = new Microsoft.Win32.OpenFileDialog();
            file.Filter = "PDF Documents (*.pdf)|*.PDF";

            //file.InitialDirectory = System.Windows.Application.ResourceAssembly.Location + @"..\..\..\..\..\..\..\Common\Data\PDF\";
            file.RestoreDirectory = true;
            if (file.ShowDialog().Value)
                textBoxSource.Text = file.FileName;
        }

        # endregion        
    }
}
