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
    public partial class FormatText : DemoControl
    {
        #region Fields
        string[] products = { "Mango", "Orange", "Grape", "Banana", "Apple", "Green Apple", "Water Melon", "Pine apple", "Guava" };
        string[] forms = { "Delicious", "Frequent Item" };
        IWParagraph paragraph = null;
        IWTextRange textRange = null;
        IWSection section1 = null;
        #endregion

        #region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public FormatText()
        {
            InitializeComponent();
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (products != null)
                products = null;
            if (forms != null)
                forms = null;
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
                //Random number generator.
                Random r = new Random();

                // List of FontNames.
                string[] fontNames = { "Arial", "Times New Roman", "Monotype Corsiva", " Book Antiqua ", "Bitstream Vera Sans", "Comic Sans MS", "Microsoft Sans Serif", "Batang" };

                // Create a new document.
                using (WordDocument document = new WordDocument())
                {

                    // Adding a new section to the document.
                    IWSection section = document.AddSection();
                    // Set Margins to the section added.
                    section.PageSetup.Margins.All = 72;
                    // Adding a new paragraph to the section.
                    IWParagraph paragraph = section.AddParagraph();

                    paragraph.AppendText("This sample demonstrates various text and paragraph formatting support.");
                    section.AddParagraph();
                    section.AddParagraph();

                    section = document.AddSection();
                    section.BreakCode = SectionBreakCode.NoBreak;
                    //Adding two columns to the section.
                    section.AddColumn(250, 20);
                    section.AddColumn(250, 20);

                    #region Text Formatting
                    //Creates a TextRange
                    IWTextRange text = null;

                    // Writing Text with different Formatting styles.
                    for (int i = 8, j = 0, k = 0; i <= 20; i++, j++, k++)
                    {
                        if (j >= fontNames.Length) j = 0;
                        paragraph = section.AddParagraph();
                        text = paragraph.AppendText("This is " + "[" + fontNames[j] + "] Font");
                        text.CharacterFormat.FontName = fontNames[j];
                        text.CharacterFormat.UnderlineStyle = (UnderlineStyle)k;
                        text.CharacterFormat.FontSize = i;
                        text.CharacterFormat.TextColor = System.Drawing.Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
                    }

                    // More formatting options.
                    section.AddParagraph();
                    paragraph.ParagraphFormat.ColumnBreakAfter = true;
                    paragraph = section.AddParagraph();
                    text = paragraph.AppendText("More formatting Options List...");
                    text.CharacterFormat.FontName = fontNames[2];
                    text.CharacterFormat.FontSize = 18;

                    section.AddParagraph();
                    paragraph = section.AddParagraph();
                    paragraph.AppendText("AllCaps \n\n").CharacterFormat.AllCaps = true;
                    paragraph.AppendText("Bold \n\n").CharacterFormat.Bold = true;
                    paragraph.AppendText("DoubleStrike \n\n").CharacterFormat.DoubleStrike = true;
                    paragraph.AppendText("Emboss \n\n").CharacterFormat.Emboss = true;
                    paragraph.AppendText("Engrave \n\n").CharacterFormat.Engrave = true;
                    paragraph.AppendText("Italic \n\n").CharacterFormat.Italic = true;
                    paragraph.AppendText("Shadow \n\n").CharacterFormat.Shadow = true;
                    paragraph.AppendText("SmallCaps \n\n").CharacterFormat.SmallCaps = true;
                    paragraph.AppendText("Strikeout \n\n").CharacterFormat.Strikeout = true;
                    paragraph.AppendText("Some Text");
                    paragraph.AppendText("SubScript \n\n").CharacterFormat.SubSuperScript = SubSuperScript.SubScript;
                    paragraph.AppendText("Some Text");
                    paragraph.AppendText("SuperScript \n\n").CharacterFormat.SubSuperScript = SubSuperScript.SuperScript;
                    paragraph.AppendText("TextBackgroundColor \n\n").CharacterFormat.TextBackgroundColor = System.Drawing.Color.LightBlue;
                    #endregion

                    #region Paragraph formattings
                    section = document.AddSection();
                    section.BreakCode = SectionBreakCode.NewPage;
                    paragraph = section.AddParagraph();
                    paragraph.AppendText("Following paragraphs illustrates various paragraph formattings");

                    paragraph = section.AddParagraph();
                    paragraph.AppendText("This paragraph demonstrates several paragraph formats. It will be used to illustrate Space Before, Space After, and Line Spacing. Space Before tells Microsoft Word how much space to leave before the paragraph. Space After tells Microsoft Word how much space to leave after the paragraph. Line Spacing sets the space between lines within a paragraph.It also explains about first line indentation,backcolor and paragraph border.");
                    paragraph.ParagraphFormat.BeforeSpacing = 20f;
                    paragraph.ParagraphFormat.AfterSpacing = 30f;
                    paragraph.ParagraphFormat.BackColor = System.Drawing.Color.LightGray;
                    paragraph.ParagraphFormat.Borders.BorderType = Syncfusion.DocIO.DLS.BorderStyle.Single;
                    paragraph.ParagraphFormat.FirstLineIndent = 20f;
                    paragraph.ParagraphFormat.LineSpacing = 20f;

                    paragraph = section.AddParagraph();
                    paragraph.AppendText("This is a sample paragraph. It is used to illustrate alignment. Left-justified text is aligned on the left. Right-justified text is aligned with on the right. Centered text is centered between the left and right margins. You can use Center to center your titles. Justified text is flush on both sides.");
                    paragraph.ParagraphFormat.LineSpacing = 20f;
                    paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Right;
                    paragraph.ParagraphFormat.LineSpacingRule = LineSpacingRule.Exactly;

                    section.AddParagraph();

                    //Adding a new paragraph to the section.
                    paragraph = section.AddParagraph();
                    paragraph.ParagraphFormat.Keep = true;
                    paragraph.AppendText("KEEP TOGETHER ").CharacterFormat.Bold = true;
                    paragraph.AppendText("This is a sample paragraph. It is used to illustrate Keep together of MsWord. You can control where Microsoft Word positions automatic page breaks (page break: The point at which one page ends and another begins. Microsoft Word inserts an 'automatic' (or soft) page break for you, or you can force a page break at a specific location by inserting a 'manual' (or hard) page break.) by setting pagination options.It keeps the lines in a paragraph together when there is page break ").CharacterFormat.FontSize = 12f;
                    for (int i = 0; i < 10; i++)
                    {
                        paragraph.AppendText("Text Body_Text Body_Text Body_Text Body_Text Body_Text Body_Text Body").CharacterFormat.FontSize = 12f;
                        paragraph.ParagraphFormat.LineSpacing = 20f;
                    }
                    paragraph.AppendText(" KEEP TOGETHER END").CharacterFormat.Bold = true;
                    #endregion

                    #region Bullets and Numbering
                    // Adding a new section to the document.
                    section = document.AddSection();
                    //Set Margins of the document
                    section.PageSetup.Margins.Top = 20;
                    section.PageSetup.Margins.Bottom = 20;
                    section.PageSetup.Margins.Left = 50;
                    section.PageSetup.Margins.Right = 20;
                    // Adding a new paragraph to the document.
                    paragraph = section.AddParagraph();
                    // Writing text to the current paragraph.
                    paragraph.AppendText("This document demonstrates the Bullets and Numbering functionality. Here fruits are taken as an example to demonstrate the lists. \n\n\n\n");

                    //Add a new section
                    section1 = document.AddSection();
                    //Adding two columns to the section.
                    section1.Columns.Add(new Column(document));
                    section1.Columns.Add(new Column(document));
                    //Set the columns to be of equal width.
                    section1.MakeColumnsEqual();

                    // Set section break code as NoBreak. 
                    section1.BreakCode = SectionBreakCode.NoBreak;

                    // Set formatting.
                    ProductDetailsInBullets();

                    // Set Formatting.
                    ProductDetailsInNumbers();
                    #endregion  Bullets and Numbering

                    #region Saving the Document
                    //Save as doc format
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            document.Save("Format Text.doc");

                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Format Text.doc") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Format Text.doc" + ") then try generating the document.", "File is already open",
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
                            document.Save("Format Text.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Format Text.docx") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Format Text.doc" + ") then try generating the document.", "File is already open",
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
                            pdfDoc.Save("Format Text.pdf");
                            pdfDoc.Close();
                            converter.Dispose();
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Format Text.pdf") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Format Text.doc" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    #endregion
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #region ProductDetailsInBullets
        private void ProductDetailsInBullets()
        {
            // Adding a new paragraph to the document.
            section1.AddParagraph();
            paragraph = section1.AddParagraph();

            // Writing text to the document with formatting.
            textRange = paragraph.AppendText("List of Fruits.");
            paragraph.ListFormat.ApplyDefBulletStyle();
            textRange.CharacterFormat.FontName = "Monotype Corsiva";
            textRange.CharacterFormat.FontSize = 15;

            // Writing Product details to the document with the specified list type.
            section1.AddParagraph();
            foreach (string s in products)
            {
                section1.AddParagraph();
                paragraph = section1.AddParagraph();
                paragraph.AppendText(s);
                paragraph.ListFormat.ContinueListNumbering();
                paragraph.ListFormat.ListLevelNumber = 1;

                section1.AddParagraph();
                foreach (string s1 in forms)
                {
                    if (String.Equals(s, "Plums"))
                    {
                        paragraph = section1.AddParagraph();
                        paragraph.AppendText(s1);
                        paragraph.ListFormat.ContinueListNumbering();
                        paragraph.ListFormat.ListLevelNumber = 2;
                        break;
                    }
                    else
                    {
                        paragraph = section1.AddParagraph();
                        paragraph.AppendText(s1);
                        paragraph.ListFormat.ContinueListNumbering();
                        paragraph.ListFormat.ListLevelNumber = 2;
                    }
                }
            }
        }
        #endregion

        #region ProductDetailsInNumbers
        private void ProductDetailsInNumbers()
        {
            // Adding a new paragraph to the document.
            section1.AddParagraph();
            paragraph = section1.AddParagraph();

            // Writing text to the document with formatting.
            textRange = paragraph.AppendText("List of Fruits.");
            paragraph.ListFormat.ApplyDefNumberedStyle();
            textRange.CharacterFormat.FontName = "Monotype Corsiva";
            textRange.CharacterFormat.FontSize = 15;

            // Writing Product details to the document with the specified list type.
            section1.AddParagraph();
            foreach (string s in products)
            {
                section1.AddParagraph();
                paragraph = section1.AddParagraph();
                paragraph.AppendText(s);
                paragraph.ListFormat.ContinueListNumbering();

                paragraph.ListFormat.ListLevelNumber = 1;
                section1.AddParagraph();
                foreach (string s1 in forms)
                {
                    if (String.Equals(s, "Plums"))
                    {
                        paragraph = section1.AddParagraph();
                        paragraph.AppendText(s1);
                        paragraph.ListFormat.ContinueListNumbering();
                        paragraph.ListFormat.ListLevelNumber = 2;
                        break;
                    }
                    else
                    {
                        paragraph = section1.AddParagraph();
                        paragraph.AppendText(s1);
                        paragraph.ListFormat.ContinueListNumbering();
                        paragraph.ListFormat.ListLevelNumber = 2;
                    }
                }
            }
        }
        # endregion
        # endregion
    }
}