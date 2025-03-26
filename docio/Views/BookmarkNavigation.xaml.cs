#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.IO;
using System.Reflection;
using System.Windows;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for BookmarkNavigation.xaml
    /// </summary>
    public partial class BookmarkNavigation : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public BookmarkNavigation()
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
        /// Create word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Creating a new document.
            using (WordDocument document = new WordDocument())
            {
                //Adds section with one empty paragraph to the Word document
                document.EnsureMinimal();
                //sets the page margins
                document.LastSection.PageSetup.Margins.All = 72f;
                //Appends bookmark to the paragraph
                document.LastParagraph.AppendBookmarkStart("NorthwindDatabase");
                document.LastParagraph.AppendText("Northwind database with normalization concept");
                document.LastParagraph.AppendBookmarkEnd("NorthwindDatabase");
                // Open an existing template document with single section to get Northwind.information
                WordDocument nwdInformation = new WordDocument(@"Assets\DocIO\Bookmark_Template.docx");
                // Open an existing template document with multiple section to get Northwind data.
                WordDocument templateDocument = new WordDocument(@"Assets\DocIO\BkmkDocumentPart_Template.docx");
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
                #region Bookmark selection for table
                // Creating a bookmark navigator. Which help us to navigate through the 
                // bookmarks in the Northwind information document.
                bk = new BookmarksNavigator(nwdInformation);
                bk.MoveToBookmark("SuppliersTable");
                //Sets the column index where the bookmark starts within the table
                bk.CurrentBookmark.FirstColumn = 1;
                //Sets the column index where the bookmark ends within the table
                bk.CurrentBookmark.LastColumn = 5;
                // Get the content of suppliers table bookmark.
                bodyPart = bk.GetBookmarkContent();
                // Creating a bookmark navigator. Which help us to navigate through the 
                // bookmarks in the destination document.
                bk = new BookmarksNavigator(document);
                bk.MoveToBookmark("Table");
                bk.ReplaceBookmarkContent(bodyPart);
                #endregion
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
                pic.LoadImage(System.Drawing.Image.FromStream(GetFileStream("Northwind.png")));
                pic.WidthScale = 50f;  // It reduce the image size because it doesn't fit 
                pic.HeightScale = 75f; // in document page.

                #region Save Document
                //Save as doc format
                if (worddoc.IsChecked.Value)
                {
                    //Saving the document to disk.
                    document.Save("Bookmark Navigation.doc");

                    //Message box confirmation to view the created document.
                    if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Bookmark Navigation.doc") { UseShellExecute = true };
                        process.Start();
                    }
                }
                //Save as docx format
                else if (worddocx.IsChecked.Value)
                {
                    //Saving the document as .docx
                    document.Save("Bookmark Navigation.docx", FormatType.Docx);
                    //Message box confirmation to view the created document.
                    if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Bookmark Navigation.docx") { UseShellExecute = true };
                        process.Start();
                    }
                }
                //Save as pdf format
                else if (pdf.IsChecked.Value)
                {
                    DocToPDFConverter converter = new DocToPDFConverter();
                    //Convert word document into PDF document
                    PdfDocument pdfDoc = converter.ConvertToPDF(document);
                    //Save the pdf file
                    pdfDoc.Save("Bookmark Navigation.pdf");
                    pdfDoc.Close();
                    converter.Dispose();
                    //Message box confirmation to view the created document.
                    if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Bookmark Navigation.pdf") { UseShellExecute = true };
                        process.Start();
                    }
                }
                #endregion
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
                //Opens the template document.
                string path = System.IO.Path.Combine(@"Assets\DocIO\Bookmark_Template.docx");
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true };
                process.Start();
            }
        }
        
        /// <summary>
        /// Get the file as stream from assets
        /// </summary>
        private Stream GetFileStream(string fileName)
        {
            Assembly assembly = typeof(BookmarkNavigation).Assembly;
            return assembly.GetManifestResourceStream("syncfusion.dociodemos.wpf.Assets.DocIO." + fileName);
        }


        #endregion
    }
}
