#region Copyright Syncfusion Inc. 2001 - 2017
//
//  Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
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
using System.IO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class HTMLToWord : DemoControl
    {
        # region Private Members
        private string errorMessage = null;
        private string fullPath;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public HTMLToWord()
        {
            InitializeComponent();
            string path = @"Assets\DocIO\";
            fullPath = @"Assets\DocIO\";
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            openFileDialog1.Filter = "HTML files (*.htm *.html)|*.htm;*.html";
            this.textBox1.Text = "HTMLToWord.html";
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            
                errorMessage = null;
                fullPath = null;
                openFileDialog1 = null;
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        # region Events
        /// <summary>
        /// Gets the source html document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                fullPath = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Converts the input html file to a word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToWord_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.textBox1.Text != String.Empty && fullPath != string.Empty)
                {
                    if (!this.textBox1.Text.EndsWith(".htm") && !this.textBox1.Text.EndsWith(".html"))
                    {
                        MessageBox.Show("Browse an HTML file to convert to Word document", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (fullPath.EndsWith("\\"))
                        fullPath += this.textBox1.Text;
                    if (File.Exists(fullPath))
                    {
                        StreamReader read = new StreamReader((string)fullPath);
                        string htmlText = read.ReadToEnd();

                        if (htmlText != string.Empty)
                        {
                            using (WordDocument document = new WordDocument())
                            { 
                            IWSection section = document.AddSection();
                            IWParagraph para = section.AddParagraph();

                            bool valid = false;

                            // This manual validation check is Transitional. We do this here only for instructional purpose.
                            if (section.Body.IsValidXHTML(htmlText, XHTMLValidationType.Transitional, out errorMessage))
                            {
                                valid = true;
                                document.XHTMLValidateOption = XHTMLValidationType.Transitional;
                            }
                            // This manual validation check is Strict. We do this here only for instructional purpose
                            else if (section.Body.IsValidXHTML(htmlText, XHTMLValidationType.Strict, out errorMessage))
                            {
                                valid = true;
                                document.XHTMLValidateOption = XHTMLValidationType.Strict;
                            }
                            // This manual validation check is None. We do this here only for instructional purpose
                            else
                            {
                                valid = true;
                                document.XHTMLValidateOption = XHTMLValidationType.None;
                            }

                            if (!valid)
                            {
                                MessageBox.Show("Content is not a welformatted XHTML content.\nError message:\n" + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                // By default, the input html will be validated for XHTML format. This will provide you understandable error messages, if the format is invalid.
                                // However, if you are sure that the input html is valid, then you can skip the validation step to improve performance. However, any error messages 
                                //you might get here will not be very useful as to where exactly in your html, the issue is.

                                section.Body.InsertXHTML(htmlText);

                                #region Save and open Document
                                //Save as doc format
                                if (worddoc.IsChecked.Value)
                                {
                                    try
                                    {
                                        //Saving the document to disk.
                                        document.Save("HTMLToWord.doc");

                                        //Message box confirmation to view the created document.
                                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                        {
                                            try
                                            {
                                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("HTMLToWord.doc") { UseShellExecute = true };
                                                process.Start();
                                            }
                                            catch (Win32Exception ex)
                                            {
                                                MessageBox.Show("Microsoft Word Viewer or Microsoft Word is not installed in this system");
                                                Console.WriteLine(ex.ToString());
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        if (ex is IOException)
                                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\HTMLToWord.doc" + ") then try generating the document.", "File is already open",
                                                 MessageBoxButton.OK, MessageBoxImage.Error);
                                        else
                                            MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                                    MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                //Save as docx format
                                else if (worddocx.IsChecked.Value)
                                {
                                    try
                                    {
                                        //Saving the document as .docx
                                        document.Save("HTMLToWord.docx", FormatType.Word2013);
                                        //Message box confirmation to view the created document.
                                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                        {
                                            try
                                            {
                                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("HTMLToWord.docx") { UseShellExecute = true };
                                                process.Start();
                                            }
                                            catch (Win32Exception ex)
                                            {
                                                MessageBox.Show("Microsoft Word Viewer or Microsoft Word is not installed in this system");
                                                Console.WriteLine(ex.ToString());
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        if (ex is IOException)
                                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\HTMLToWord.docx" + ") then try generating the document.", "File is already open",
                                                 MessageBoxButton.OK, MessageBoxImage.Error);
                                        else
                                            MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                                    MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                    else
                        MessageBox.Show("File cannot be read", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("File doesn�t exist");
                    }
                }
                else
                {
                    MessageBox.Show("Browse an HTML file to convert to Word document", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        # endregion
    }
}
