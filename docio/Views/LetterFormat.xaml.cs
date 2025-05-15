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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.Data;
using System.ComponentModel;
using System.IO;
using Syncfusion.Windows.Shared;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LetterFormat : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public LetterFormat()
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
        /// Creates word document and executes mail merge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            // Get Template document and database path.
            string dataPath = @"Assets\DocIO\";

            try
            {
                // Create a new document.
                using (WordDocument document = new WordDocument())
                {

                    // Loading Template.                
                    document.Open(System.IO.Path.Combine(dataPath, @"Letter Formatting.doc"), FormatType.Doc);
                    //Gets the data table.
                    DataTable table = GetDataTable();
                    // Checks if data field mapping should be enabled
                    if (checkBoxChoose.IsChecked.Value)
                    {
                        //Removes paragraph that contains only empty fields.
                        document.MailMerge.RemoveEmptyParagraphs = true;
                        //To clear the fields with empty value
                        document.MailMerge.ClearFields = true;
                        //Clear the map fields
                        document.MailMerge.MappedFields.Clear();
                        //Update the mapping fields
                        document.MailMerge.MappedFields.Add("Contact Name", "ContactName");
                        document.MailMerge.MappedFields.Add("Company Name", "CompanyName");
                        document.MailMerge.MappedFields.Add("CompanyAddress", "Address");
                        document.MailMerge.MappedFields.Add("Residing City", "City");
                        document.MailMerge.MappedFields.Add("Current Region", "Region");
                        document.MailMerge.MappedFields.Add("Home Country", "Country");
                    }
                    //Mailmerge can be performed with the input as either DataRow, DataField, DataView, IDataReader 
                    //or a set of merge field names and values. Here, one particular row is extraced from the table and used.
                    DataRow dr = table.Rows[0];
                    //Executes mail merge for the selected record or row.
                    document.MailMerge.Execute(dr);

                    //Save as doc format
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            document.Save("Letter Format.doc");

                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Letter Format.doc") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Letter Format.doc" + ") then try generating the document.", "File is already open",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //Save as docx format
                    else if (worddocx.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document as .docx
                            document.Save("Letter Format.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Letter Format.docx") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Letter Format.doc" + ") then try generating the document.", "File is already open",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
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
                            PdfDocument pdfDoc = converter.ConvertToPDF(document);
                            //Save the pdf file
                            pdfDoc.Save("Letter Format.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Letter Format.pdf") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Letter Format.doc" + ") then try generating the document.", "File is already open",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSubmit_Click1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to view the template document?", "Template document", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"Assets\DocIO\Letter Formatting.doc") { UseShellExecute = true };
                process.Start();
            }
        }

        #endregion
        #region Helper Methods
        private DataTable GetDataTable()
        {
            //Data source.
            DataSet ds = new DataSet();
            ds.ReadXml(@"Assets\DocIO\Customers.xml");
            DataTable table = ds.Tables[0];
            return table;
        }
        #endregion
    }
}