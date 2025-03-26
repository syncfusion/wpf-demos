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
using Syncfusion.DocIO.DLS;
using Microsoft.Win32;
using System.ComponentModel;
using Syncfusion.DocIO;
using System.IO;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FindAndReplace : DemoControl
    {
        # region Private Members
        string docFileName = null;
        bool matchCase, wholeWord;
        WordDocument doc;
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public FindAndReplace()
        {
            InitializeComponent();
            // Initialize variables.
            matchCase = false;
            wholeWord = false;
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (doc != null)
            {
                doc.Close();
                doc = null;
            }
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        # region Events
        /// <summary>
        /// Replaces the text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplace_Click(object sender, RoutedEventArgs e)
        {
            // Checking whether the find and replacement text boxes are filled.
            if (textLook.Text.Trim() == "")
            {
                MessageBox.Show("Browse a file to perform find and replace functionality", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (textFind.Text.Trim() == "" && textReplace.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the find and replacement text in appropriate textboxes...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (textFind.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the find text in the appropriate textbox.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (textReplace.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the replace text in the appropriate textbox.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                // Open an existing word document.
                doc = new WordDocument(docFileName);
                    // Replace the text.
                    doc.Replace(textFind.Text, textReplace.Text, matchCase, wholeWord);

                    #region Save Document
                    //Save as doc format
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            doc.Save("Find and Replace.doc");

                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]   
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Find and Replace.doc") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Find and Replace.doc" + ") then try generating the document.", "File is already open",
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
                            doc.Save("Find and Replace.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Find and Replace.docx") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Find and Replace.docx" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //Save as pdf format
                    else if (pdf.IsChecked.Value)
                    {
                        try
                        {
                            DocToPDFConverter converter = new DocToPDFConverter();
                            //Convert word document into PDF document
                            PdfDocument pdfDoc = converter.ConvertToPDF(doc);
                            //Save the pdf file
                            pdfDoc.Save("Find and Replace.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Find and Replace.pdf") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Find and Replace.pdf" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    #endregion
            }

            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Gets the input file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            // Create a openfile dialog box for open an existing word document.
            OpenFileDialog file = new OpenFileDialog();
            // set the file filter type as document.
            file.Filter = "Document Files (*.doc)|*.docx";
            // Show the open file dialog box.
            if (file.ShowDialog().Value)
            {
                docFileName = file.FileName;
                textLook.Text = System.IO.Path.GetFileName(docFileName);
                // Make controls enable state.
                textLook.IsEnabled = false;
                textFind.IsEnabled = true;
                textReplace.IsEnabled = true;
                groupMatch.IsEnabled = true;
                btnReplace.IsEnabled = true;
            }
        }

        /// <summary>
        /// Toggles between case sensitive and insensitive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxCase_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxCase.IsChecked.Value)
                matchCase = true;
            else
                matchCase = false;
        }

        /// <summary>
        /// Toggles whole word.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxWord_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxWord.IsChecked.Value)
                wholeWord = true;
            else
                wholeWord = false;
        }
#endregion
    }
}