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
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.IO;
using syncfusion.demoscommon.wpf;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TableOfFigures : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public TableOfFigures()
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
        /// Creates word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get Template document and database path.
                string dataPath = @"Assets\DocIO\";

                //Loads the template document.
                using (WordDocument document = new WordDocument())
                {
                    document.OpenReadOnly(dataPath + "TableOfFiguresInput.docx", FormatType.Docx);

                    #region Add Table of Figures
                    //Create a new paragraph.
                    WParagraph paragraph = new WParagraph(document);
                    paragraph.AppendText("List of Figures");
                    //Apply Heading1 style for paragraph.
                    paragraph.ApplyStyle(BuiltinStyle.Heading1);
                    //Insert the paragraph. 
                    document.LastSection.Body.ChildEntities.Insert(0, paragraph);

                    //Create new paragraph and append TOC.
                    paragraph = new WParagraph(document);
                    TableOfContent tableOfContent = paragraph.AppendTOC(1, 3);
                    //Disable a flag to exclude heading style paragraphs in TOC entries.
                    tableOfContent.UseHeadingStyles = false;
                    //Set the name of SEQ field identifier for table of figures.
                    tableOfContent.TableOfFiguresLabel = "Figure";
                    if (checkBox.IsChecked.Value)
                        //Disable the flag, to exclude caption's label and number in TOC entries.
                        tableOfContent.IncludeCaptionLabelsAndNumbers = false;

                    //Insert the paragraph to the text body.
                    document.LastSection.Body.ChildEntities.Insert(1, paragraph);
                    #endregion

                    #region Add caption for pictures
                    //Find all pictures from the document.
                    List<Entity> pictures = document.FindAllItemsByProperty(EntityType.Picture, null, null);
                    // Iterate each picture and add caption.
                    foreach (WPicture picture in pictures)
                    {
                        //Set alternate text as caption for picture.
                        WParagraph captionPara = picture.AddCaption("Figure", CaptionNumberingFormat.Number, CaptionPosition.AfterImage) as WParagraph;
                        captionPara.AppendText(" " + picture.AlternativeText);
                        //Apply formatting to the caption.
                        captionPara.ApplyStyle(BuiltinStyle.Caption);
                        captionPara.ParagraphFormat.BeforeSpacing = 8;
                        captionPara.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    }
                    #endregion


                    #region Add Table of Tables
                    // Create a new paragraph.
                    paragraph = new WParagraph(document);
                    paragraph.AppendText("List of Tables");
                    // Apply Heading1 style for paragraph.
                    paragraph.ApplyStyle(BuiltinStyle.Heading1);
                    // Insert the paragraph.
                    document.LastSection.Body.ChildEntities.Insert(2, paragraph);

                    //Create a new paragraph and append TOC.
                    paragraph = new WParagraph(document);
                    tableOfContent = paragraph.AppendTOC(1, 3);
                    //Disable a flag to exclude heading style paragraphs in TOC entries.
                    tableOfContent.UseHeadingStyles = false;
                    //Set the name of SEQ field identifier for table of tables.
                    tableOfContent.TableOfFiguresLabel = "Table";
                    if (checkBox.IsChecked.Value)
                        //Disable the flag, to exclude caption's label and number in TOC entries.
                        tableOfContent.IncludeCaptionLabelsAndNumbers = false;
                    // Insert the paragraph to the text body.
                    document.LastSection.Body.ChildEntities.Insert(3, paragraph);
                    #endregion

                    #region Add caption for tables
                    // Find all tables from the document.
                    List<Entity> tables = document.FindAllItemsByProperty(EntityType.Table, null, null);
                    //Iterate each table and add caption.
                    foreach (WTable table in tables)
                    {
                        //Gets the table index.
                        int tableIndex = table.OwnerTextBody.ChildEntities.IndexOf(table);
                        //Create a new paragraph and appends the sequence field to use as a caption.
                        WParagraph captionPara = new WParagraph(document);
                        captionPara.AppendText("Table ");
                        captionPara.AppendField("Table", FieldType.FieldSequence);
                        //Set alternate text as caption for table.
                        captionPara.AppendText(" " + table.Description);
                        // Apply formatting to the paragraph.
                        captionPara.ApplyStyle(BuiltinStyle.Caption);
                        captionPara.ParagraphFormat.BeforeSpacing = 8;
                        captionPara.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                        //Insert the paragraph next to the table.
                        table.OwnerTextBody.ChildEntities.Insert(tableIndex + 1, captionPara);
                    }
                    #endregion

                    #region Update
                    //Update all document fields to update SEQ fields.
                    document.UpdateDocumentFields();
                    //Update the table of contents.
                    document.UpdateTableOfContents();
                    #endregion

                    //Save as doc format.
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            document.Save("TableOfFigures.doc");

                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("TableOfFigures.doc") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\TableOfFigures.doc" + ") then try generating the document.", "File is already open",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //Save as docx format.
                    else if (worddocx.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document as .docx.
                            document.Save("TableOfFigures.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("TableOfFigures.docx") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\TableOfFigures.docx" + ") then try generating the document.", "File is already open",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    //Save as pdf format.
                    else if (pdf.IsChecked.Value)
                    {
                        try
                        {
                            DocToPDFConverter converter = new DocToPDFConverter();
                            //Convert word document into PDF document.
                            PdfDocument pdfDoc = converter.ConvertToPDF(document);
                            //Save the pdf file.
                            pdfDoc.Save("TableOfFigures.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("TableOfFigures.pdf") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\TableOfFigures.pdf" + ") then try generating the document.", "File is already open",
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
                MessageBox.Show(Ex.Message);
            }
        }

        /// <summary>
        /// Opens the template document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to view the template document?", "Template document", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //Get Template document and database path.            
                string dataPath = @"Assets\DocIO\";
                string path = System.IO.Path.Combine(dataPath, @"TableOfFiguresInput.docx");
                //Opens the template document.
                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true };
                process.Start();
            }
        }
        # endregion
    }
}