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
using System.Windows.Media;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.IO;

namespace Bookmark_Navigation
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
                 ImageSourceConverter img = new ImageSourceConverter();
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon =(ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
        }
        # endregion

        # region Events
        /// <summary>
        /// Create word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string dataPath = @"..\..\..\..\..\..\..\Common\Data\DocIO\";
                // Creating a new document.
                WordDocument document = new WordDocument();
                //Adds section with one empty paragraph to the Word document
                document.EnsureMinimal();
                //sets the page margins
                document.LastSection.PageSetup.Margins.All = 72f;
                //Appends bookmark to the paragraph
                document.LastParagraph.AppendBookmarkStart("NorthwindDatabase");
                document.LastParagraph.AppendText("Northwind database with normalization concept");
                document.LastParagraph.AppendBookmarkEnd("NorthwindDatabase");
                // Open an existing template document with single section to get Northwind.information
                WordDocument nwdInformation = new WordDocument(dataPath + "Bookmark_Template.doc");
                // Open an existing template document with multiple section to get Northwind data.
                WordDocument templateDocument = new WordDocument(dataPath + "BkmkDocumentPart_Template.doc");
                // Creating a bookmark navigator. Which help us to navigate through the 
                // bookmarks in the template document.
                BookmarksNavigator bk = new BookmarksNavigator(templateDocument);
                // Move to the NorthWind bookmark in template document
                bk.MoveToBookmark("NorthWind");
                //Gets the bookmark content as WordDocumentPart
                WordDocumentPart documentPart = bk.GetContent();
                // Creating a bookmark navigator, which help us to navigate through the 
                // bookmarks in the Northwind information document.
                bk = new BookmarksNavigator(nwdInformation);
                // Move to the information bookmark 
                bk.MoveToBookmark("Information");
                // Get the content of information bookmark.
                TextBodyPart bodyPart = bk.GetBookmarkContent();
                // Creating a bookmark navigator, which help us to navigate through the 
                // bookmarks in the destination document.
                bk = new BookmarksNavigator(document);
                // Move to the NorthWind database in the destination document
                bk.MoveToBookmark("NorthwindDatabase");
                //Replace the bookmark content using word document parts
                bk.ReplaceContent(documentPart);
                // Move to the Northwind_Information in the destination document
                bk.MoveToBookmark("Northwind_Information");
                // Replacing content of Northwind_Information bookmark.
                bk.ReplaceBookmarkContent(bodyPart);
                // Move to the text bookmark
                bk.MoveToBookmark("Text");
                //Deletes the bookmark content
                bk.DeleteBookmarkContent(true);
                // Inserting text inside the bookmark. This will preserve the source formatting
                bk.InsertText("Northwind Database contains the following table:");

                #region tableinsertion
                WTable tbl = new WTable(document);
                tbl.TableFormat.Borders.BorderType = BorderStyle.None;
                tbl.TableFormat.IsAutoResized = true;
                tbl.ResetCells(8, 2);
                IWParagraph paragraph;
                tbl.Rows[0].IsHeader = true;
                paragraph = tbl[0, 0].AddParagraph();
                paragraph.AppendText("Suppliers");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[0, 1].AddParagraph();
                paragraph.AppendText("1");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[1, 0].AddParagraph();
                paragraph.AppendText("Customers");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[1, 1].AddParagraph();
                paragraph.AppendText("1");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[2, 0].AddParagraph();
                paragraph.AppendText("Employees");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[2, 1].AddParagraph();
                paragraph.AppendText("3");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[3, 0].AddParagraph();
                paragraph.AppendText("Products");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[3, 1].AddParagraph();
                paragraph.AppendText("1");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[4, 0].AddParagraph();
                paragraph.AppendText("Inventory");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[4, 1].AddParagraph();
                paragraph.AppendText("2");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[5, 0].AddParagraph();
                paragraph.AppendText("Shippers");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[5, 1].AddParagraph();
                paragraph.AppendText("1");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[6, 0].AddParagraph();
                paragraph.AppendText("PO Transactions");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[6, 1].AddParagraph();
                paragraph.AppendText("3");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[7, 0].AddParagraph();
                paragraph.AppendText("Sales Transactions");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;

                paragraph = tbl[7, 1].AddParagraph();
                paragraph.AppendText("7");
                paragraph.BreakCharacterFormat.FontName = "Calibri";
                paragraph.BreakCharacterFormat.FontSize = 10;


                bk.InsertTable(tbl);
                #endregion

                //Move to image bookmark
                bk.MoveToBookmark("Image");
                //Deletes the bookmark content
                bk.DeleteBookmarkContent(true);
                // Inserting image to the bookmark.
                IWPicture pic = bk.InsertParagraphItem(ParagraphItemType.Picture) as WPicture;
                pic.LoadImage(System.Drawing.Image.FromFile(@"..\..\..\..\..\..\..\Common\Images\DocIO\Northwind.png"));
                pic.WidthScale = 50f;  // It reduce the image size because it doesn't fit 
                pic.HeightScale = 75f; // in document page.

                # region Save Document
                //Save as doc format
                if (worddoc.IsChecked.Value)
                {
                    try
                    {
                        //Saving the document to disk.
                        document.Save("Sample.doc");

                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process.Start("Sample.doc");
                                //Exit
                                this.Close();
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.doc" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting"+ "\r\n" + ex.ToString(), "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                //Save as docx format
                else if (worddocx.IsChecked.Value)
                {
                    try
                    {
                        //Saving the document as .docx
                        document.Save("Sample.docx", FormatType.Docx);
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process.Start("Sample.docx");
                                //Exit
                                this.Close();
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.docx" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting"+ "\r\n" + ex.ToString(), "Error",
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
                        pdfDoc.Save("Sample.pdf");
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                System.Diagnostics.Process.Start("Sample.pdf");
                                //Exit
                                this.Close();
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.pdf" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting"+ "\r\n" + ex.ToString(), "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    // Exit
                    this.Close();
                }
                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}