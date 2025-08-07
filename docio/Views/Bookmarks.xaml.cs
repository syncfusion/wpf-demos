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
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.Drawing;
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
    public partial class Bookmarks : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Bookmarks()
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Creating a new document.
                using (WordDocument document = new WordDocument())
                {

                    // Adding a section to the document.
                    IWSection section = document.AddSection();

                    //Set page margins to the section.
                    section.PageSetup.Margins.All = 72;

                    // Adding a new paragraph to the section.
                    IWParagraph paragraph = section.AddParagraph();

                    // Writing text
                    paragraph.AppendText("This document demonstrates Essential DocIO's Bookmark functionality.").CharacterFormat.FontSize = 14f;

                    // Adding paragraph to the section.
                    section.AddParagraph();
                    paragraph = section.AddParagraph();
                    paragraph.AppendText("1. Inserting Bookmark Text").CharacterFormat.FontSize = 12f;

                    // Adding paragraph to the section.
                    section.AddParagraph();
                    paragraph = section.AddParagraph();

                    // BookmarkStart.
                    paragraph.AppendBookmarkStart("Bookmark");
                    // Write bookmark
                    paragraph.AppendText("Bookmark Text");
                    paragraph.AppendComment("This is a simple bookmark");
                    // BookmarkEnd.
                    paragraph.AppendBookmarkEnd("Bookmark");

                    // Adding paragraph to the section.
                    section.AddParagraph();
                    paragraph = section.AddParagraph();
                    // Indicating hidden bookmark text start.
                    paragraph.AppendBookmarkStart("_HiddenText");
                    // Writing bookmark text
                    paragraph.AppendText("2. Hidden Bookmark Text").CharacterFormat.Font = new Font("Comic Sans MS", 10);
                    // Indicating hidden bookmark text end.
                    paragraph.AppendBookmarkEnd("_HiddenText");
                    paragraph.AppendComment("This is hidden bookmark");

                    section.AddParagraph();
                    paragraph = section.AddParagraph();
                    paragraph.AppendText("3. Nested Bookmarks").CharacterFormat.FontSize = 12f;

                    // Writing nested bookmarks
                    section.AddParagraph();
                    paragraph = section.AddParagraph();
                    paragraph.AppendBookmarkStart("Main");
                    paragraph.AppendText(" Main data ");
                    paragraph.AppendBookmarkStart("Nested");
                    paragraph.AppendText(" Nested data ");
                    paragraph.AppendComment("This is a nested bookmark");
                    paragraph.AppendBookmarkStart("NestedNested");
                    paragraph.AppendText(" Nested Nested ");
                    paragraph.AppendBookmarkEnd("NestedNested");
                    paragraph.AppendText(" data Nested ");
                    paragraph.AppendBookmarkEnd("Nested");
                    paragraph.AppendText(" Data Main ");
                    paragraph.AppendBookmarkEnd("Main");

                    //Save as doc format
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            document.Save("Bookmarks.doc");

                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Bookmarks.doc") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Bookmarks.doc" + ") then try generating the document.", "File is already open",
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
                            document.Save("Bookmarks.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Bookmarks.docx") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Bookmarks.doc" + ") then try generating the document.", "File is already open",
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
                            pdfDoc.Save("Bookmarks.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Bookmarks.pdf") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Bookmarks.doc" + ") then try generating the document.", "File is already open",
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
#endregion
    }
}