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
using System.ComponentModel;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.IO;
using syncfusion.demoscommon.wpf;
using System.Reflection;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FootnotesandEndnotes : DemoControl
    {
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public FootnotesandEndnotes()
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
                //A new document is created.
                using (WordDocument document = new WordDocument())
                {
                    //Create footnotes at the bottom of the page
                    CreateFootNote(document);

                //Create endnotes at the end of the section
                CreateEndNote(document);

                    //Save as doc format
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            document.Save("Footnotes and Endnotes.doc");

                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Footnotes and Endnotes.doc") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Footnotes and Endnotes.doc" + ") then try generating the document.", "File is already open",
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
                            document.Save("Footnotes and Endnotes.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Footnotes and Endnotes.docx") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Footnotes and Endnotes.doc" + ") then try generating the document.", "File is already open",
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
        # endregion

        #region Helper Methods

        #region CreateFootNote
        /// <summary>
        /// Creates footnote
        /// </summary>
        /// <param name="document"></param>
        void CreateFootNote(WordDocument document)
        {
            //Add a new section to the document.
            IWSection section = document.AddSection();
            // Set Margin of the document
            section.PageSetup.Margins.All = 72;
            //Adding a new paragraph to the section.
            IWParagraph paragraph = section.AddParagraph();

            IWTextRange textRange = paragraph.AppendText("\t\t\t\t\tDemo for Footnote");
            textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;
            textRange.CharacterFormat.Bold = true;
            textRange.CharacterFormat.FontSize = 20;

            section.AddParagraph();
            section.AddParagraph();
            paragraph = section.AddParagraph();
            WFootnote footnote = new WFootnote(document);
            footnote = paragraph.AppendFootnote(FootnoteType.Footnote);
            footnote.MarkerCharacterFormat.SubSuperScript = SubSuperScript.SuperScript;

            //Insert Text into the paragraph
            paragraph.AppendText("Google").CharacterFormat.Bold = true;
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            paragraph.AppendPicture(System.Drawing.Image.FromStream(GetFileStream(@"google.png")));

            paragraph = footnote.TextBody.AddParagraph();
            paragraph.AppendText(" Google is the most famous search engines in the Word ");

            //Adding a new paragraph to the section.
            paragraph = section.AddParagraph();

            paragraph = section.AddParagraph();
            footnote = paragraph.AppendFootnote(FootnoteType.Footnote);
            footnote.MarkerCharacterFormat.SubSuperScript = SubSuperScript.SuperScript;


            //Insert Text into the paragraph
            paragraph.AppendText("Yahoo").CharacterFormat.Bold = true;
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            paragraph.AppendPicture(System.Drawing.Image.FromStream(GetFileStream("yahoo.gif")));

            paragraph = footnote.TextBody.AddParagraph();
            paragraph.AppendText(" Yahoo experience makes it easier to discover the news and information that you care about most.  ");

            //Adding a new paragraph to the section.
            paragraph = section.AddParagraph();

            paragraph = section.AddParagraph();
            footnote = paragraph.AppendFootnote(FootnoteType.Footnote);
            footnote.MarkerCharacterFormat.SubSuperScript = SubSuperScript.SuperScript;

            //Insert Text into the paragraph
            paragraph.AppendText("Northwind Traders").CharacterFormat.Bold = true;
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            paragraph.AppendPicture(System.Drawing.Image.FromStream(GetFileStream("Northwind_logo.png")));
            paragraph = footnote.TextBody.AddParagraph();
            paragraph.AppendText(" The Northwind sample database (Northwind.mdb) is included with all versions of Access. It provides data you can experiment with and database objects that demonstrate features you might want to implement in your own databases. ");

            //Setting number format for Footnote
            document.FootnoteNumberFormat = FootEndNoteNumberFormat.Arabic;

            //Setting Footnote position
            document.FootnotePosition = FootnotePosition.PrintAtBottomOfPage;
        }
        #endregion

        #region CreateEndNote
        /// <summary>
        /// Creates end note
        /// </summary>
        /// <param name="document"></param>
        void CreateEndNote(WordDocument document)
        {
            //Add a new section to the document.
            IWSection section = document.AddSection();

            //Adding a new paragraph to the section.
            IWParagraph paragraph = section.AddParagraph();

            IWTextRange textRange = paragraph.AppendText("\t\t\t\t\tDemo for Endnote");
            textRange.CharacterFormat.TextColor = System.Drawing.Color.Black;
            textRange.CharacterFormat.Bold = true;
            textRange.CharacterFormat.FontSize = 20;

            section.AddParagraph();
            section.AddParagraph();
            paragraph = section.AddParagraph();
            WFootnote footnote = new WFootnote(document);
            footnote = paragraph.AppendFootnote(FootnoteType.Endnote);
            footnote.MarkerCharacterFormat.SubSuperScript = SubSuperScript.SuperScript;

            //Insert Text into the paragraph
            paragraph.AppendText("Google").CharacterFormat.Bold = true;
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            paragraph.AppendPicture(System.Drawing.Image.FromStream(GetFileStream("google.png")));

            paragraph = footnote.TextBody.AddParagraph();
            paragraph.AppendText(" Google is the most famous search engines in the Word ");

            section = document.AddSection();
            section.BreakCode = SectionBreakCode.NoBreak;
            //Adding a new paragraph to the section.
            paragraph = section.AddParagraph();

            paragraph = section.AddParagraph();
            footnote = paragraph.AppendFootnote(FootnoteType.Endnote);
            footnote.MarkerCharacterFormat.SubSuperScript = SubSuperScript.SuperScript;

            //Insert Text into the paragraph
            paragraph.AppendText("Yahoo").CharacterFormat.Bold = true;
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            paragraph.AppendPicture(System.Drawing.Image.FromStream(GetFileStream("yahoo.gif")));

            paragraph = footnote.TextBody.AddParagraph();
            paragraph.AppendText(" Yahoo experience makes it easier to discover the news and information that you care about most. ");

            section = document.AddSection();
            section.BreakCode = SectionBreakCode.NoBreak;
            //Adding a new paragraph to the section.
            paragraph = section.AddParagraph();

            paragraph = section.AddParagraph();
            footnote = paragraph.AppendFootnote(FootnoteType.Endnote);
            footnote.MarkerCharacterFormat.SubSuperScript = SubSuperScript.SuperScript;

            //Insert Text into the paragraph
            paragraph.AppendText("Northwind Traders").CharacterFormat.Bold = true;
            paragraph = section.AddParagraph();
            paragraph.ParagraphFormat.HorizontalAlignment = Syncfusion.DocIO.DLS.HorizontalAlignment.Center;
            paragraph.AppendPicture(System.Drawing.Image.FromStream(GetFileStream("Northwind_logo.png")));
            paragraph = footnote.TextBody.AddParagraph();
            paragraph.AppendText(" The Northwind sample database (Northwind.mdb) is included with all versions of Access. It provides data you can experiment with and database objects that demonstrate features you might want to implement in your own databases ");

            //Set the number format for the Endnote.
            document.EndnoteNumberFormat = Syncfusion.DocIO.FootEndNoteNumberFormat.LowerCaseRoman;
            document.RestartIndexForEndnote = Syncfusion.DocIO.EndnoteRestartIndex.DoNotRestart;
            //Set the Endnote position.
            document.EndnotePosition = Syncfusion.DocIO.EndnotePosition.DisplayEndOfSection;
        }
        #endregion

        /// <summary>
        /// Get the file as stream from assets
        /// </summary>
        private Stream GetFileStream(string fileName)
        {
            Assembly assembly = typeof(FootnotesandEndnotes).Assembly;
            return assembly.GetManifestResourceStream("syncfusion.dociodemos.wpf.Assets.DocIO." + fileName);
        }

        #endregion
    }
}