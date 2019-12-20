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
using Microsoft.Win32;
using Syncfusion.Pdf;
using System.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Syncfusion.Windows.Shared;


namespace ImageExtraction
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        string filePath;
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
		 
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
#if NETCORE
            string file = @"..\..\..\..\..\..\..\Common\images\PDF\pdf_header.png";
#else
            string file = @"..\..\..\..\..\..\Common\images\PDF\pdf_header.png";
#endif
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
#if NETCORE
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\PDF\pdf_button.png");
#else
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\PDF\pdf_button.png");
#endif
#if NETCORE
            filePath = @"..\..\..\..\..\..\..\Common\Data\PDF\imageDoc.pdf";
#else
            filePath = @"..\..\..\..\..\..\Common\Data\PDF\imageDoc.pdf";
#endif
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
                PdfLoadedDocument ldoc = new PdfLoadedDocument(filePath);

                // Loading Page collections
                PdfLoadedPageCollection loadedPages = ldoc.Pages;

                // Extract Image from PDF document pages
                foreach (PdfLoadedPage lpage in loadedPages)
                {
                    System.Drawing.Image[] img = lpage.ExtractImages();
                    if (img != null)
                    {
                        foreach (System.Drawing.Image img1 in img)
                        {
                            img1.Save("Image" + Guid.NewGuid().ToString() + ".png", ImageFormat.Png);

                        }
                    }
                }
                
                //Message box confirmation to view the created PDF document.
                if (System.Windows.MessageBox.Show("Do you want to view the exported image files?", "Image Exported",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the PDF file using the default Application.[Acrobat Reader]
#if NETCORE
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(System.IO.Directory.GetCurrentDirectory())
                {
                    UseShellExecute = true
                };
                process.Start();
#else
                    System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory());
#endif
                    this.Close();
                }
                else
                    // Exit
                    this.Close();
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
#if NETCORE
            //file.InitialDirectory = System.Windows.Application.ResourceAssembly.Location + @"..\..\..\..\..\..\..\..\Common\Data\PDF\";
#else
            //file.InitialDirectory = System.Windows.Application.ResourceAssembly.Location + @"..\..\..\..\..\..\..\Common\Data\PDF\";
#endif
            file.RestoreDirectory = true;
            if (file.ShowDialog().Value)
                textBoxSource.Text = file.FileName;
        }

        # endregion        
    }
}
