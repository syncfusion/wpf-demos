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


namespace TextExtraction
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
            imglab.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\PDF\label_Image.gif");
#else
            imglab.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\PDF\label_Image.gif");
#endif
#if NETCORE
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\PDF\pdf_button.png");
#else
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\PDF\pdf_button.png");
#endif
#if NETCORE
            filePath = @"..\..\..\..\..\..\..\Common\Data\PDF\Manual.pdf";
#else
            filePath = @"..\..\..\..\..\..\Common\Data\PDF\Manual.pdf";
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

                string s = "";

                // Extract text from PDF document pages
                foreach (PdfLoadedPage lpage in loadedPages)
                {
                    s += lpage.ExtractText();
                }

                //Convert the string to byte array
                byte[] b = (new UnicodeEncoding()).GetBytes(s);

                // Writing the byte array to text file
                FileStream fStream = File.Create("sample.txt");
                fStream.Write(b, 0, b.Length);
                fStream.Close();

                //Message box confirmation to view the created PDF document.
                if (System.Windows.MessageBox.Show("Do you want to view the Text file?", "Text File Created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the PDF file using the default Application.[Acrobat Reader]
#if NETCORE
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Sample.txt")
                {
                    UseShellExecute = true
                };
                process.Start();
#else
                    System.Diagnostics.Process.Start("Sample.txt");
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
            //file.InitialDirectory = System.Windows.Application.ResourceAssembly.Location + @"\..\..\..\..\Data";

            if (file.ShowDialog().Value)
                textBoxSource.Text = file.FileName;
        }

        # endregion
    }
}
