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

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class UpdateFields : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public UpdateFields()
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
                    document.OpenReadOnly(dataPath + "TemplateUpdateFields.docx", FormatType.Automatic);
                    //Initialize DataSet object.
                    DataSet ds = new DataSet();

                    //Load data from the xml document.
                    ds.ReadXml(dataPath + "StockDetails.xml");

                    // Execute Mail Merge with groups.
                    document.MailMerge.ExecuteGroup(ds.Tables["StockDetails"]);

                    //Update fields in the document.
                    document.UpdateDocumentFields();

                    //Unlink the fields in Word document when UnlinkFields is enable.
                    if (checkBox.IsChecked.Value)
                        UnlinkFieldsInDocument(document);

                    //Save as doc format
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            document.Save("Update Fields.doc");

                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Update Fields.doc") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Update Fields.doc" + ") then try generating the document.", "File is already open",
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
                            document.Save("Update Fields.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Update Fields.docx") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Update Fields.doc" + ") then try generating the document.", "File is already open",
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
                            pdfDoc.Save("Update Fields.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Update Fields.pdf") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Update Fields.doc" + ") then try generating the document.", "File is already open",
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

        #region Iterates into document for removing field codes.       
        /// <summary>
        /// Iterates to document elements and get fields.
        /// </summary>
        /// <param name="document">Input Word document.</param>
        /// <param name="fieldType">Type of the field to find in document.</param>
        private void UnlinkFieldsInDocument(WordDocument document)
        {
            //Iterates each section and get the tables.
            foreach (WSection section in document.Sections)
            {
                RemoveFieldCodesInTextBody(section.Body);
            }
        }

        /// <summary>
        /// Iterates into body items.
        /// </summary>
        private void RemoveFieldCodesInTextBody(WTextBody textBody)
        {
            for (int i = 0; i < textBody.ChildEntities.Count; i++)
            {
                //IEntity is the basic unit in DocIO DOM.                 
                IEntity bodyItemEntity = textBody.ChildEntities[i];

                //A Text body has 3 types of elements - Paragraph, Table, and Block Content Control
                //Decides the element type by using EntityType
                switch (bodyItemEntity.EntityType)
                {
                    case EntityType.Paragraph:
                        WParagraph paragraph = bodyItemEntity as WParagraph;
                        //Iterates into paragraph items.
                        RemoveFieldCodesInParagraph(paragraph.Items);
                        break;

                    case EntityType.Table:
                        //Table is a collection of rows and cells
                        //Iterates through table's DOM                        
                        RemoveFieldCodesInTable(bodyItemEntity as WTable);
                        break;

                    case EntityType.BlockContentControl:
                        BlockContentControl blockContentControl = bodyItemEntity as BlockContentControl;
                        //Iterates to the body items of Block Content Control.
                        RemoveFieldCodesInTextBody(blockContentControl.TextBody);
                        break;
                }
            }
        }

        /// <summary>
        /// Iterates into paragraph items.
        /// </summary>
        /// <param name="paragraph">The paragraph.</param>
        /// <param name="fieldType">Type of field.</param>
        private void RemoveFieldCodesInParagraph(ParagraphItemCollection paraItems)
        {
            for (int i = 0; i < paraItems.Count; i++)
            {
                if (paraItems[i] is WField)
                {
                    WField field = paraItems[i] as WField;
                    field.Unlink();
                }
                else if (paraItems[i] is WTextBox)
                {
                    //If paragraph item is textbox, iterates into textbody of textbox.
                    WTextBox textBox = paraItems[i] as WTextBox;
                    RemoveFieldCodesInTextBody(textBox.TextBoxBody);
                }
                else if (paraItems[i] is Shape)
                {
                    //If paragraph item is shape, iterates into textbody of shape.
                    Shape shape = paraItems[i] as Shape;
                    RemoveFieldCodesInTextBody(shape.TextBody);
                }
                else if (paraItems[i] is InlineContentControl)
                {
                    //If paragraph item is inline content control, iterates into its item.
                    InlineContentControl inlineContentControl = paraItems[i] as InlineContentControl;
                    RemoveFieldCodesInParagraph(inlineContentControl.ParagraphItems);
                }
            }
        }
        /// <summary>
        /// Iterates into table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="fieldType">Type of Field.</param>
        private void RemoveFieldCodesInTable(WTable table)
        {
            //Iterates the row collection in a table
            foreach (WTableRow row in table.Rows)
            {
                //Iterates the cell collection in a table row
                foreach (WTableCell cell in row.Cells)
                {
                    RemoveFieldCodesInTextBody(cell);
                }
            }
        }
        #endregion

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
                string path = System.IO.Path.Combine(dataPath, @"TemplateUpdateFields.docx");
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