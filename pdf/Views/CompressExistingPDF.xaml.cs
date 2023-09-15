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
using System.Drawing;
using Syncfusion.Pdf;
using System.IO;
using Syncfusion.Pdf.Graphics;
using System.Diagnostics;
using Syncfusion.Windows.Shared;
using Microsoft.Win32;
using Syncfusion.Pdf.Parsing;
using syncfusion.demoscommon.wpf;

namespace syncfusion.pdfdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CompressExistingPDF : DemoControl
    {
        # region Fields   
        # endregion

        # region Constructor
        public CompressExistingPDF()
        {
		   
            InitializeComponent();
            for (int i = 1; i <= 100; i++)
                this.imageQuality.Items.Add(i);
            this.imageQuality.SelectedIndex = 49;
            this.optimizeFont.IsChecked = true;
            this.compressPageContents.IsChecked = true;
            this.removeMetadata.IsChecked = true;
            this.compressImage.IsChecked = true;
            //this.Height = 440;
            textBox.Tag = @"Assets\PDF\jQuery_Succinctly.pdf";
            textBox.Text = "jQuery_Succinctly.Pdf";
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Height = 440;
            if (textBox.Tag != null)
            {
                string extension = System.IO.Path.GetExtension(textBox.Tag.ToString());
                if (extension.ToLower() == ".pdf")
                {
                    byte[] inputFile = File.ReadAllBytes(textBox.Tag.ToString());

                    //Load a existing PDF document
                    PdfLoadedDocument ldoc = new PdfLoadedDocument(inputFile);

                    //Create a new PDF compression options
                    PdfCompressionOptions options = new PdfCompressionOptions();

                    if (compressImage.IsChecked == true)
                    {
                        //Compress image.
                        options.CompressImages = true;
                        options.ImageQuality = int.Parse((imageQuality.SelectedIndex +1).ToString());
                    }
                    else
                        options.CompressImages = false;

                    //Compress the font data
                    if (optimizeFont.IsChecked == true)
                        options.OptimizeFont = true;
                    else
                        options.OptimizeFont = false;

                    //Compress the page contents
                    if (compressPageContents.IsChecked == true)
                        options.OptimizePageContents = true;
                    else
                        options.OptimizePageContents = false;

                    //Remove the metadata information.
                    if (removeMetadata.IsChecked == true)
                        options.RemoveMetadata = true;
                    else
                        options.RemoveMetadata = false;

                    //Set the options to loaded PDF document
                    ldoc.CompressionOptions = options;

                    //Save the document 
                    MemoryStream ms = new MemoryStream();
                    ldoc.Save(ms);
					ldoc.Close(true);

                    //this.ods.Content = (inputFile.Length / 1024).ToString() + " KB ";
                    //this.cds.Content = (ms.Length / 1024).ToString() + " KB ";
                    //this.Height = 562;

                    //Message box confirmation to view the created PDF document.
                    if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                        MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        File.WriteAllBytes("CompressExistingPDF.pdf", ms.ToArray());
                        ms.Dispose();
                        //Launching the PDF file using the default Application.[Acrobat Reader]
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("CompressExistingPDF.pdf") { UseShellExecute = true };
                        process.Start();
                    }

                }
                else
                    MessageBox.Show("Please select the valid PDF file.");
            }
            else
                MessageBox.Show("Please select the PDF file.");           
        }
        private void selectBtn_Click(object sender, RoutedEventArgs e)
        {
            FileDialog file = new OpenFileDialog();
            file.Filter = "(*.pdf) | *.PDF";
            if (file.ShowDialog() == true)
            {
                textBox.Text = file.SafeFileName;
                textBox.Tag = file.FileName;
                //this.Height = 440;
            }
        }
        #endregion

        private void compressImage_Checked(object sender, RoutedEventArgs e)
        {
            if (compressImage.IsChecked == true)
                this.imageQuality.IsEnabled = true;
            else
                this.imageQuality.IsEnabled = false;
        }      
    }
}
