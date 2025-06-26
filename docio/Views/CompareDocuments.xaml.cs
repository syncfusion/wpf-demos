#region Copyright Syncfusion Inc. 2001 - 2017
//
//  Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion
using System;
using System.Data;
using System.Windows;
using System.Windows.Media;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.IO;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CompareDocuments : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public CompareDocuments()
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
        /// Compare word documents.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get Template document and database path.
                string dataPath = @"Assets\DocIO\";
                string orignalDocumentPath = dataPath + "OriginalDocument.docx";
                string revisedDocumentPath = dataPath + "RevisedDocument.docx";

                //Loads the original document 
                using (WordDocument originalDocument = new WordDocument(orignalDocumentPath, FormatType.Docx))
                {
                    //Loads the revised document 
                    using (WordDocument revisedDocument = new WordDocument(revisedDocumentPath, FormatType.Docx))
                    {
                        if (checkBox.IsChecked.Value)
                        {
                            //Compares the original document with revised document
                            originalDocument.Compare(revisedDocument, "Nancy Davolio", DateTime.Now.AddDays(-1));
                        }
                        else
                        {
                            //Disable the flag to ignore the formatting changes while comparing the documents
                            ComparisonOptions comparisonOptions = new ComparisonOptions();
                            comparisonOptions.DetectFormatChanges = false;
                            originalDocument.Compare(revisedDocument, "Nancy Davolio", DateTime.Now.AddDays(-1), comparisonOptions);
                        }
                        //Saving the document as .docx
                        originalDocument.Save("CompareDocuments.docx", FormatType.Docx);
                    } 
                }
                //Message box confirmation to view the created document.
                if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("CompareDocuments.docx") { UseShellExecute = true };
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
                    MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\CompareDocuments.docx" + ") then try generating the document.", "File is already open",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}