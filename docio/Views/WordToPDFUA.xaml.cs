#region Copyright Syncfusion Inc. 2001 - 2018
//
//  Copyright Syncfusion Inc. 2001 - 2018. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion
using System;
using System.Windows;
using Microsoft.Win32;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.IO;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WordToPDFUA : DemoControl
    {
        #region Fields
        private string fullPath;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        #endregion

        #region Constructor
        public WordToPDFUA()
        {
            InitializeComponent();
            string path = @"Assets\DocIO\";
            fullPath = @"Assets\DocIO\";
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            openFileDialog1.Filter = "Word Document(*.doc *.docx *.rtf)|*.doc;*.docx;*.rtf";
            this.textBox1.Text = "Word to PDF.docx";
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {           
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region Events
        private void btnTopdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.textBox1.Text != String.Empty && fullPath != string.Empty)
                {
                    if (!this.textBox1.Text.EndsWith(".doc") && !this.textBox1.Text.EndsWith(".docx") &&
                        !this.textBox1.Text.EndsWith(".rtf") && !this.textBox1.Text.EndsWith(".docm") &&
                        !this.textBox1.Text.EndsWith(".dotx") && !this.textBox1.Text.EndsWith(".dotm") &&
                        !this.textBox1.Text.EndsWith(".dot") && !this.textBox1.Text.EndsWith(".txt"))
                    {
                        MessageBox.Show("Browse a Word document to convert to PDF", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (fullPath.EndsWith("\\"))
                        fullPath += this.textBox1.Text;
                    if (File.Exists(fullPath))
                    {
                        string outputFileName = Path.GetFileNameWithoutExtension(fullPath);
                        using (WordDocument wordDoc = new WordDocument(fullPath))
                        {
                            try
                            {
                                DocToPDFConverter converter = new DocToPDFConverter();

                                //Sets true to preserve document structured tags in the converted PDF document.
                                converter.Settings.AutoTag = true;
                                //Convert word document into PDF document
                                PdfDocument pdfDoc = converter.ConvertToPDF(wordDoc);
                                //Save the pdf file
                                pdfDoc.Save(outputFileName + "_Pdf_UA.pdf");
                                pdfDoc.Close();
                                converter.Dispose();
                                //Message box confirmation to view the created document.
                                if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {
                                    try
                                    {
                                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                                        process.StartInfo = new System.Diagnostics.ProcessStartInfo(outputFileName + "_Pdf_UA.pdf") { UseShellExecute = true };
                                        process.Start();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("PDF Viewer is not installed in this system");
                                        Console.WriteLine(ex.ToString());
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                if (ex is IOException)
                                    MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\" + outputFileName + "_Pdf_UA.pdf" + ") then try generating the document.", "File is already open",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                                else
                                    MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                            MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("File doesn’t exist");
                    }
                }

                else
                    MessageBox.Show("Browse a Word document to convert to PDF", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                fullPath = openFileDialog1.FileName;

            }
        }
        #endregion
    }
}
