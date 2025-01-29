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
using Syncfusion.DocIO;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.IO;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AdvancedReplace : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public AdvancedReplace()
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

        #region Events
        /// <summary>
        /// Creates word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region Document with formatting
                if (this.radiorelement.IsChecked == true)
                {
                    string dataPath = @"Assets\DocIO\";

                    //Load template document
                    using (WordDocument doc = new WordDocument(System.IO.Path.Combine(dataPath, "Original.doc")))
                    {

                        //Load the document to be replaced 
                        WordDocument replaceDoc = new WordDocument(System.IO.Path.Combine(dataPath, "Replace.doc"));

                        //Select a table and add it to TextBodyPart
                        TextBodyPart replacePart = new TextBodyPart(replaceDoc);
                        replacePart.BodyItems.Add(replaceDoc.Sections[0].Body.Tables[0] as WTable);

                        //Replace Text with table
                        doc.Replace("INSERT TABLE", replacePart, true, true);

                        //Select text and image
                        replacePart = new TextBodyPart(replaceDoc);
                        TextBodySelection textSel = new TextBodySelection(replaceDoc.LastSection.Body, 0, replaceDoc.LastSection.Paragraphs.Count, 0, 1);
                        replacePart.Copy(textSel);

                        //Replace Text with image and text.
                        doc.Replace("INSERT PARAGRAPH ITEMS", replacePart, false, true);
                        //Save as doc format
                        if (worddoc.IsChecked.Value)
                        {
                            try
                            {
                                //Saving the document to disk.
                                doc.Save("Advanced Replace.doc");

                                //Message box confirmation to view the created document.
                                if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    try
                                    {
                                        //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Advanced Replace.doc") { UseShellExecute = true };
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
                                    MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Advanced Replace.doc" + ") then try generating the document.", "File is already open",
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
                                doc.Save("Advanced Replace.docx", FormatType.Docx);
                                //Message box confirmation to view the created document.
                                if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    try
                                    {
                                        //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Advanced Replace.docx") { UseShellExecute = true };
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
                                    MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Advanced Replace.docx" + ") then try generating the document.", "File is already open",
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
                                PdfDocument pdfDoc = converter.ConvertToPDF(doc);
                                //Save the pdf file
                                pdfDoc.Save("Advanced Replace.pdf");
                                //Message box confirmation to view the created document.
                                if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {
                                    try
                                    {
                                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Advanced Replace.pdf") { UseShellExecute = true };
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
                                    MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Advanced Replace.pdf" + ") then try generating the document.", "File is already open",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                                else
                                    MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                            MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
                #endregion document with formatting
                else
                {
                    #region Replace with document elements
                    // Gets Template files path.
                    string dataPath = @"Assets\DocIO\";

                    // Creating new documents.
                    WordDocument docSource1 = new WordDocument();
                    WordDocument docSource2 = new WordDocument();
                    WordDocument docMaster = new WordDocument();

                    // Load Templates.
                    docSource1.Open(System.IO.Path.Combine(dataPath, "TemplateSource1.doc"), FormatType.Doc);
                    docSource2.Open(System.IO.Path.Combine(dataPath, "TemplateSource2.doc"), FormatType.Doc);
                    docMaster.Open(System.IO.Path.Combine(dataPath, "TemplateMaster.doc"), FormatType.Doc);

                    // Search for a string and store in TextSelection
                    //The TextSelection copies a text segment with formatting.
                    Syncfusion.DocIO.DLS.TextSelection selection1 = docSource1.Find("PlaceHolder text is replaced with this formatted animated text", false, false);

                    // Search for a string and store in TextSelection
                    Syncfusion.DocIO.DLS.TextSelection selection2 = docSource2.Find(new Regex("This is the second Sentence"));

                    // Replacing the placeholder inside Master Template with matches found while
                    //search the two template documents. 
                    docMaster.Replace(new Regex("PlaceHolder1"), selection1);
                    docMaster.Replace(new Regex("PlaceHolder2"), selection2);

                    # region Save Document
                    //Save as doc format
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            docMaster.Save("Advanced Replace.doc");

                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Advanced Replace.doc") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Advanced Replace.doc" + ") then try generating the document.", "File is already open",
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
                            docMaster.Save("Advanced Replace.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Advanced Replace.docx") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Advanced Replace.doc" + ") then try generating the document.", "File is already open",
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
                            PdfDocument pdfDoc = converter.ConvertToPDF(docMaster);
                            //Save the pdf file
                            pdfDoc.Save("Advanced Replace.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Advanced Replace.pdf") { UseShellExecute = true };
                                    process.Start();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("PDF is not installed in this system");
                                    Console.WriteLine(ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is IOException)
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Advanced Replace.doc" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    #endregion
                    #endregion Replace with document elements
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