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
using Microsoft.Win32;
using Syncfusion.Pdf;
using System.Drawing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System.IO;
using System.Windows.Forms;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TextExtraction : DemoControl
    {
        string filePath;
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public TextExtraction()
        {
		  
            InitializeComponent();
            //imglab.Source = (ImageSource)img.ConvertFromString(@"Assets\PDF\label_Image.gif");
            filePath = @"Assets\PDF\Manual.pdf";

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

                string s = "";

                // Extract text from PDF document pages
                foreach (PdfLoadedPage lpage in loadedPages)
                {
                    s += lpage.ExtractText();
                }

                //Convert the string to byte array
                byte[] b = (new UnicodeEncoding()).GetBytes(s);

                // Writing the byte array to text file
                FileStream fStream = File.Create("TextExtraction.txt");
                fStream.Write(b, 0, b.Length);
                fStream.Close();
				ldoc.Close(true);

                //Message box confirmation to view the created PDF document.
                if (System.Windows.MessageBox.Show("Do you want to view the Text file?", "Text File Created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the PDF file using the default Application.[Acrobat Reader]
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("TextExtraction.txt") { UseShellExecute = true };
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
            //file.InitialDirectory = System.Windows.Application.ResourceAssembly.Location + @"\..\..\..\..\Data";

            if (file.ShowDialog().Value)
                textBoxSource.Text = file.FileName;
        }

        # endregion
    }
}
