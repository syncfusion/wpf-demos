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
using System.IO;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.ComponentModel;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using syncfusion.demoscommon.wpf;
using System.Reflection;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class HeaderandFooter : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public HeaderandFooter()
        {
            InitializeComponent();
            foreach (String str in Enum.GetNames(typeof(PageNumberStyle)))
                this.comboBoxFormat.Items.Add(str);
            this.comboBoxFormat.SelectedIndex = 2;
            for (int i = 1; i < 101; i++)
                this.comboBoxStart.Items.Add(i);
            this.comboBoxStart.SelectedIndex = 0;
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region Helper Methods
        #region InsertFirstPageHeaderFooter
        private void InsertFirstPageHeaderFooter(WordDocument doc, IWSection section)
        {
            // Add a new paragraph for header to the document.
            IWParagraph headerPar = new WParagraph(doc);

            // Add a new table to the header.
            IWTable table = section.HeadersFooters.FirstPageHeader.AddTable();

            RowFormat format = new RowFormat();

            // Setting cleared table border style.
            format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Cleared;

            // Inserting table with a row and two columns.
            table.ResetCells(1, 2, format, 265);

            // Inserting logo image to the table first cell.
            headerPar = table[0, 0].AddParagraph() as WParagraph;
            headerPar.AppendPicture(System.Drawing.Image.FromStream(GetFileStream("Northwind_logo.png")));
            //Set Image size
            (headerPar.Items[0] as WPicture).Width = 232.5f;
            (headerPar.Items[0] as WPicture).Height = 54.75f;
            // Inserting text to the table second cell.
            headerPar = table[0, 1].AddParagraph() as WParagraph;
            IWTextRange txt = headerPar.AppendText("Company Headquarters,\n2501 Aerial Center Parkway,\nSuite 110, Morrisville, NC 27560,\nTEL 1-888-936-8638.");
            txt.CharacterFormat.FontSize = 12;
            txt.CharacterFormat.CharacterSpacing = 1.7f;
            headerPar.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
            // Add a new paragraph to the header with address text.
            headerPar = new WParagraph(doc);
            headerPar.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            txt = headerPar.AppendText("\nFirst Page Header");
            txt.CharacterFormat.CharacterSpacing = 1.7f;
            section.HeadersFooters.FirstPageHeader.Paragraphs.Add(headerPar);

            // Add a footer paragraph text to the document.
            WParagraph footerPar = new WParagraph(doc);
            footerPar.ParagraphFormat.Tabs.AddTab(523f, TabJustification.Right, TabLeader.NoLeader);
            // Add text.
            footerPar.AppendText("Copyright Northwind Inc. 2001 - 2017");
            // Add page and Number of pages field to the document.
            footerPar.AppendText("\tFirst Page ");
            footerPar.AppendField("Page", FieldType.FieldPage);
            section.HeadersFooters.FirstPageFooter.Paragraphs.Add(footerPar);
            #region Page Number Settings
            section.PageSetup.RestartPageNumbering = true;
            section.PageSetup.PageStartingNumber = (int)this.comboBoxStart.SelectedValue;
            section.PageSetup.PageNumberStyle = (PageNumberStyle)Enum.Parse(typeof(PageNumberStyle), this.comboBoxFormat.SelectedItem.ToString(), true);
            #endregion
        }
        #endregion

        #region InsertPageHeaderFooter
        private void InsertPageHeaderFooter(WordDocument doc, IWSection section1)
        {
            // Add a new paragraph for header to the document.
            IWParagraph headerPar = new WParagraph(doc);

            // Add a new table to the header
            IWTable table = section1.HeadersFooters.Header.AddTable();

            RowFormat format = new RowFormat();

            // Setting cleared table border style.
            format.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;

            // Inserting table with a row and two columns.
            table.ResetCells(1, 2, format, 265);

            // Inserting logo image to the table first cell.
            headerPar = table[0, 0].AddParagraph() as WParagraph;
            headerPar.AppendPicture(System.Drawing.Image.FromStream(GetFileStream("Northwind_logo.png")));
            //Set Image size.
            (headerPar.Items[0] as WPicture).Width = 232.5f;
            (headerPar.Items[0] as WPicture).Height = 54.75f;
            // Inserting text to the table second cell.
            headerPar = table[0, 1].AddParagraph() as WParagraph;
            IWTextRange txt = headerPar.AppendText("Company Headquarters,\n2501 Aerial Center Parkway,\nSuite 110, Morrisville, NC 27560,\nTEL 1-888-936-8638.");
            txt.CharacterFormat.FontSize = 12;
            txt.CharacterFormat.CharacterSpacing = 1.7f;
            headerPar.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;

            // Add a footer paragraph text to the document.
            WParagraph footerPar = new WParagraph(doc);
            footerPar.ParagraphFormat.Tabs.AddTab(523f, TabJustification.Right, TabLeader.NoLeader);
            // Add text.
            footerPar.AppendText("Copyright Northwind Inc. 2001 - 2017");
            // Add page and Number of pages field to the document.
            footerPar.AppendText("\tPage ");
            IWField ff = footerPar.AppendField("Page", FieldType.FieldPage);

            section1.HeadersFooters.Footer.Paragraphs.Add(footerPar);

            #region Page Number Settings
            section1.PageSetup.RestartPageNumbering = true;
            section1.PageSetup.PageStartingNumber = (int)this.comboBoxStart.SelectedValue;
            section1.PageSetup.PageNumberStyle = (PageNumberStyle)Enum.Parse(typeof(PageNumberStyle), this.comboBoxFormat.SelectedItem.ToString(), true);
            #endregion
        }
        #endregion
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
                // Creating a new document.
                using (WordDocument doc = new WordDocument())
                {

                    // Add a new section to the document.
                    IWSection section1 = doc.AddSection();

                    #region Header Footer
                    //Add different Header Footer for first and other pages
                    if (checkBoxFirst.IsChecked.Value && checkBoxAll.IsChecked.Value)
                    {
                        // Set the header/footer setup.
                        section1.PageSetup.DifferentFirstPage = true;
                        // Inserting Header Footer to first page
                        InsertFirstPageHeaderFooter(doc, section1);
                        // Inserting Header Footer to all pages
                        InsertPageHeaderFooter(doc, section1);
                    }
                    //Add Header Footer only for first page
                    if (checkBoxFirst.IsChecked.Value && !checkBoxAll.IsChecked.Value)
                    {
                        // Set the header/footer setup.
                        section1.PageSetup.DifferentFirstPage = true;
                        // Inserting Header Footer to first page
                        InsertFirstPageHeaderFooter(doc, section1);
                    }
                    //Add same Header Footer for all the pages
                    if (checkBoxAll.IsChecked.Value && !checkBoxFirst.IsChecked.Value)
                    {
                        // Inserting Header Footer to all pages
                        InsertPageHeaderFooter(doc, section1);
                    }
                    #endregion

                    // Add text to the document body section.
                    IWParagraph par;
                    par = section1.AddParagraph();
                    //Insert Text into the word Document.
                    StreamReader reader = new StreamReader(@"Assets\DocIO\WinFAQ.txt", System.Text.Encoding.ASCII);

                    string text = reader.ReadToEnd();
                    par.AppendText(text);

                    //Save as doc format
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            doc.Save("Header and Footer.doc");

                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Header and Footer.doc") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Header and Footer.doc" + ") then try generating the document.", "File is already open",
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
                            doc.Save("Header and Footer.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Header and Footer.docx") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Header and Footer.doc" + ") then try generating the document.", "File is already open",
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
                            pdfDoc.Save("Header and Footer.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Header and Footer.pdf") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Header and Footer.doc" + ") then try generating the document.", "File is already open",
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

        /// <summary>
        /// Get the file as stream from assets
        /// </summary>
        private Stream GetFileStream(string fileName)
        {
            Assembly assembly = typeof(HeaderandFooter).Assembly;
            return assembly.GetManifestResourceStream("syncfusion.dociodemos.wpf.Assets.DocIO." + fileName);
        }

        # endregion
    }
}