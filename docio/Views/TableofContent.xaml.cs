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
using System.ComponentModel;
using Syncfusion.DocIO;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.IO;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TableofContent : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public TableofContent()
        {
            InitializeComponent();
            for (int i = 1; i < 10; i++)
                comboBoxLower.Items.Add(i);
            for (int i = 9; i > 0; i--)
                comboBoxUpper.Items.Add(i);
            comboBoxLower.SelectedIndex = 0;
            comboBoxUpper.SelectedIndex = 7;
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
                using (WordDocument doc = new WordDocument())
                {
                    doc.EnsureMinimal();

                    WParagraph para = doc.LastParagraph;
                    para.AppendText("Essential DocIO - Table of Contents");
                    para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    para.ApplyStyle(BuiltinStyle.Heading4);

                    para = doc.LastSection.AddParagraph() as WParagraph;
                    para.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
                    para.ApplyStyle(BuiltinStyle.Heading4);

                    if (!this.checkBox6.IsChecked.Value)
                        para.AppendText("Select TOC and press F9 to update the Table of Contents").CharacterFormat.HighlightColor = System.Drawing.Color.Yellow;

                    para = doc.LastSection.AddParagraph() as WParagraph;
                    string title = this.textBoxTitle.Text + "\n";
                    para.AppendText(title);
                    para.ApplyStyle(BuiltinStyle.Heading4);

                    //Insert TOC
                    TableOfContent toc = para.AppendTOC(1, 3);

                    para.ApplyStyle(BuiltinStyle.Heading4);

                    //Apply built-in paragraph formatting
                    WSection section = doc.LastSection;

                    if (radioDefault.IsChecked.Value)
                    {
                        #region Default Styles
                        WParagraph newPara = section.AddParagraph() as WParagraph;
                        newPara = section.AddParagraph() as WParagraph;
                        newPara.AppendBreak(BreakType.PageBreak);
                        WTextRange text = newPara.AppendText("Document with Default styles") as WTextRange;
                        newPara.ApplyStyle(BuiltinStyle.Heading1);
                        newPara = section.AddParagraph() as WParagraph;
                        newPara.AppendText("This is the heading1 of built in style. This sample demonstrates the TOC insertion in a word document. Note that DocIO can only insert TOC field in a word document. It can not refresh or create TOC field. MS Word refreshes the TOC field after insertion. Please update the field or press F9 key to refresh the TOC.");

                        section.AddParagraph();
                        newPara = section.AddParagraph() as WParagraph;
                        text = newPara.AppendText("Section1") as WTextRange;
                        newPara.ApplyStyle(BuiltinStyle.Heading2);
                        newPara = section.AddParagraph() as WParagraph;
                        newPara.AppendText("This is the heading2 of built in style. A document can contain any number of sections. Sections are used to apply same formatting for a group of paragraphs. You can insert sections by inserting section breaks.");

                        section.AddParagraph();
                        newPara = section.AddParagraph() as WParagraph;
                        text = newPara.AppendText("Paragraph1") as WTextRange;
                        newPara.ApplyStyle(BuiltinStyle.Heading3);
                        newPara = section.AddParagraph() as WParagraph;
                        newPara.AppendText("This is the heading3 of built in style. Each section contains any number of paragraphs. A paragraph is a set of statements that gives a meaning for the text.");

                        section.AddParagraph();
                        newPara = section.AddParagraph() as WParagraph;
                        text = newPara.AppendText("Paragraph2") as WTextRange;
                        newPara.ApplyStyle(BuiltinStyle.Heading3);
                        newPara = section.AddParagraph() as WParagraph;
                        newPara.AppendText("This is the heading3 of built in style. This demonstrates the paragraphs at the same level and style as that of the previous one. A paragraph can have any number formatting. This can be attained by formatting each text range in the paragraph.");

                        section.AddParagraph();
                        section = doc.AddSection() as WSection;
                        section.BreakCode = SectionBreakCode.NewPage;
                        newPara = section.AddParagraph() as WParagraph;
                        text = newPara.AppendText("Section2") as WTextRange;
                        newPara.ApplyStyle(BuiltinStyle.Heading2);
                        newPara = section.AddParagraph() as WParagraph;
                        newPara.AppendText("This is the heading2 of built in style. A document can contain any number of sections. Sections are used to apply same formatting for a group of paragraphs. You can insert sections by inserting section breaks.");

                        section.AddParagraph();
                        newPara = section.AddParagraph() as WParagraph;
                        text = newPara.AppendText("Paragraph1") as WTextRange;
                        newPara.ApplyStyle(BuiltinStyle.Heading3);
                        newPara = section.AddParagraph() as WParagraph;
                        newPara.AppendText("This is the heading3 of built in style. Each section contains any number of paragraphs. A paragraph is a set of statements that gives a meaning for the text.");

                        section.AddParagraph();
                        newPara = section.AddParagraph() as WParagraph;
                        text = newPara.AppendText("Paragraph2") as WTextRange;
                        newPara.ApplyStyle(BuiltinStyle.Heading3);
                        newPara = section.AddParagraph() as WParagraph;
                        newPara.AppendText("This is the heading3 of built in style. This demonstrates the paragraphs at the same level and style as that of the previous one. A paragraph can have any number formatting. This can be attained by formatting each text range in the paragraph.");
                        #endregion
                    }
                    else
                    {
                        #region Custom styles

                        //Custom styles.
                        WParagraphStyle pStyle1 = (WParagraphStyle)doc.AddParagraphStyle("MyStyle1");
                        WParagraphStyle pStyle2 = (WParagraphStyle)doc.AddParagraphStyle("MyStyle2");
                        WParagraphStyle pStyle3 = (WParagraphStyle)doc.AddParagraphStyle("MyStyle3");

                        //Set the Heading Styles to false in order to define custom levels to TOC.
                        toc.UseHeadingStyles = false;

                        //Set the TOC level style which determines; based on which the TOC should be created.
                        toc.SetTOCLevelStyle(1, "MyStyle1");
                        toc.SetTOCLevelStyle(2, "MyStyle2");
                        toc.SetTOCLevelStyle(3, "MyStyle3");
                        section = doc.AddSection() as WSection;

                        pStyle1.CharacterFormat.FontName = "Cambria";
                        pStyle1.CharacterFormat.FontSize = 30f;

                        para = section.AddParagraph() as WParagraph;

                        WTextRange text = para.AppendText("Document with Custom Styles") as WTextRange;
                        para.ApplyStyle("MyStyle1");
                        para = doc.LastSection.AddParagraph() as WParagraph;
                        para.AppendText("This is the heading1 of built in style. This sample demonstrates the TOC insertion in a word document. Note that DocIO can only insert TOC field in a word document. It can not refresh or create TOC field. MS Word refreshes the TOC field after insertion. Please update the field or press F9 key to refresh the TOC.");

                        pStyle2.CharacterFormat.FontName = "Cambria";
                        pStyle2.CharacterFormat.FontSize = 20f;

                        doc.LastSection.AddParagraph();

                        para = doc.LastSection.AddParagraph() as WParagraph;
                        text = para.AppendText("Section1") as WTextRange;
                        para.ApplyStyle("MyStyle2");
                        para = doc.LastSection.AddParagraph() as WParagraph;
                        para.AppendText("This is the heading2 of built in style. A document can contain any number of sections. Sections are used to apply same formatting for a group of paragraphs. You can insert sections by inserting section breaks.");

                        pStyle3.CharacterFormat.FontName = "Cambria";
                        pStyle3.CharacterFormat.FontSize = 14f;

                        doc.LastSection.AddParagraph();

                        para = doc.LastSection.AddParagraph() as WParagraph;
                        text = para.AppendText("Section2") as WTextRange;
                        para.ApplyStyle("MyStyle3");
                        para = doc.LastSection.AddParagraph() as WParagraph;
                        para.AppendText("This is the heading2 of built in style. A document can contain any number of sections. Sections are used to apply same formatting for a group of paragraphs. You can insert sections by inserting section breaks.");

                        #endregion
                    }

                    if ((int)comboBoxUpper.SelectedValue < (int)comboBoxLower.SelectedValue)
                        MessageBox.Show("Not a valid heading level range. UpperHeadingLevel must be greater than LowerHeadingLevel");
                    else
                    {
                        toc.IncludePageNumbers = checkBox1.IsChecked.Value;
                        toc.RightAlignPageNumbers = checkBox2.IsChecked.Value;
                        toc.UseHyperlinks = checkBox3.IsChecked.Value;
                        toc.LowerHeadingLevel = Convert.ToInt32(this.comboBoxLower.SelectedValue);
                        toc.UpperHeadingLevel = Convert.ToInt32(this.comboBoxUpper.SelectedValue);

                        //Right click text. Select Paragraph option. Set OutlineLevel. Update TOC to see the text added in TOC.
                        toc.UseOutlineLevels = this.checkBox4.IsChecked.Value;

                        //Select the text that should be marked as Table of contents.
                        //Press ALT+SHIFT+O. A dialog box will appear with options to enter the text, select the table identifier and level.
                        //Choose the table identifier and level for the test and click ‘Mark’. Update TOC to see the text added in TOC.
                        //Sets the Table Identifier if necessary.
                        //toc.TableID = "B";              
                        toc.UseTableEntryFields = this.checkBox5.IsChecked.Value;
                        //Updates the table of contents.
                        if (this.checkBox6.IsChecked.Value)
                            doc.UpdateTableOfContents();
                        //Save as doc format
                        if (worddoc.IsChecked.Value)
                        {
                            try
                            {
                                //Saving the document to disk.
                                doc.Save("Table of Content.doc");

                                //Message box confirmation to view the created document.
                                if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    try
                                    {
                                        //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Table of Content.doc") { UseShellExecute = true };
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
                                    MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Table of Content.doc" + ") then try generating the document.", "File is already open",
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
                                doc.Save("Table of Content.docx", FormatType.Docx);
                                //Message box confirmation to view the created document.
                                if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    try
                                    {
                                        //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Table of Content.docx") { UseShellExecute = true };
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
                                    MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Table of Content.doc" + ") then try generating the document.", "File is already open",
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
                                pdfDoc.Save("Table of Content.pdf");
                                pdfDoc.Close();
                                converter.Dispose();
                                //Message box confirmation to view the created document.
                                if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {
                                    try
                                    {
                                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Table of Content.pdf") { UseShellExecute = true };
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
                                    MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Table of Content.doc" + ") then try generating the document.", "File is already open",
                                             MessageBoxButton.OK, MessageBoxImage.Error);
                                else
                                    MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                             MessageBoxButton.OK, MessageBoxImage.Error);
                            }
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
        /// Disable the checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtnCustom_Checked(object sender, RoutedEventArgs e)
        {
            this.checkBox4.IsEnabled = false;
        }
        /// <summary>
        /// Disable the checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBtnDefault_Checked(object sender, RoutedEventArgs e)
        {
            if (this.checkBox4 != null)
            {
                this.checkBox4.IsEnabled = true;
            }
        }
        #endregion
    }
}
