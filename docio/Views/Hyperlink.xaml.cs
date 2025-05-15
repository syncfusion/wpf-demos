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
using System.Windows.Controls;
using System.Windows.Data;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Microsoft.Win32;
using System.Collections;
using System.ComponentModel;
using System.IO;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using syncfusion.demoscommon.wpf;
using System.Windows.Resources;
using System.Reflection;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Hyperlink : DemoControl
    {
        #region Private Members
        string m_outPath, path;
        WordDocument document;
        string[] file;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private ArrayList _WebLinks, _EmailLinks, _FileLinks, _Bookmarks;
        #endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Hyperlink()
        {
            InitializeComponent();

            this._WebLinks = new ArrayList();
            this._EmailLinks = new ArrayList();
            this._FileLinks = new ArrayList();
            this._Bookmarks = new ArrayList();

            file = System.Environment.CurrentDirectory.Split(':');
            path = file[0];

            m_outPath = Application.ResourceAssembly.Location + "\\..\\..\\Output\\";
            if (!Directory.Exists(m_outPath))
                Directory.CreateDirectory(m_outPath);

            InsertHyperlink();
            FindHyperLinks();
            radioWeb.IsChecked = true;
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (document != null)
            {
                document.Close();
                document = null;
            }
            _WebLinks.Clear();
            _EmailLinks.Clear();
            _FileLinks.Clear();
            _Bookmarks.Clear();
            openFileDialog1 = null;
            file = null;
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        # region Events
        /// <summary>
        /// Saves the edited hyperlink.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Save as doc format
                if (worddoc.IsChecked.Value)
                {
                    try
                    {
                        //Saving the document to disk.
                        document.Save("Hyperlink.doc");

                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Hyperlink.doc") { UseShellExecute = true };
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Hyperlink.doc" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                //Save as docx format
                else if (worddocx.IsChecked.Value)
                {
                    try
                    {
                        //Saving the document as .docx
                        document.Save("Hyperlink.docx", FormatType.Docx);
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Hyperlink.docx") { UseShellExecute = true };
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Hyperlink.doc" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
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
                        pdfDoc.Save("Hyperlink.pdf");
                        pdfDoc.Close();
                        converter.Dispose();
                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Do you want to view the generated PDF?", " Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Hyperlink.pdf") { UseShellExecute = true };
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
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Hyperlink.doc" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// The source template document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemplate_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to view the template document?", "Template document", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                string path = Application.ResourceAssembly.Location + @"..\..\Template.doc";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true };
                process.Start();
            }
        }

        /// <summary>
        /// Updates the web hyperlinks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void radioWeb_Checked(object sender, RoutedEventArgs e)
        {
            if (radioWeb.IsChecked.Value)
            {
                this.textDisplay.IsReadOnly = false;
                this.btnFile.IsEnabled = false;
                this.labelDisplay.Text = "Web Text";
                this.labelLink.Text = "Uri";
            }
            this.UpdateListBindings(this._WebLinks, "Uri");
        }

        /// <summary>
        /// Updates the mail hyperlinks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioEmail_Click(object sender, RoutedEventArgs e)
        {
            if (radioEmail.IsChecked.Value)
            {
                this.textDisplay.IsReadOnly = false;
                this.btnFile.IsEnabled = false;
                this.labelDisplay.Text = "Email Text";
                this.labelLink.Text = "Uri";
            }
            this.UpdateListBindings(this._EmailLinks, "Uri");
        }

        /// <summary>
        /// Updates the file hyperlinks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioFile_Click(object sender, RoutedEventArgs e)
        {
            if (radioFile.IsChecked.Value)
            {
                this.textDisplay.IsReadOnly = false;
                this.btnFile.IsEnabled = true;
                this.labelDisplay.Text = "File Text";
                this.labelLink.Text = "File Path";
            }
            this.UpdateListBindings(this._FileLinks, "FilePath");
        }

        /// <summary>
        /// Updates the bookmark hyperlinks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioBookmark_Click(object sender, RoutedEventArgs e)
        {
            if (radioBookmark.IsChecked.Value)
            {
                this.textDisplay.IsReadOnly = true;
                this.btnFile.IsEnabled = false;
                this.labelDisplay.Text = "Bookmark Name";
                this.labelLink.Text = "Bookmark Text";
            }
            this.UpdateListBindings(this._Bookmarks, "TextToDisplay");

        }

        /// <summary>
        /// The file browser used to upload in the File Hyperlink.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            this.openFileDialog1.Filter = "All files (*.*)|*.*";
            if (this.openFileDialog1.ShowDialog().Value)
            {
                this.textLink.Text = System.IO.Path.GetFullPath(this.openFileDialog1.FileName);
                this.textLink.Focus();
            }
        }
        # endregion

        # region Helper Methods

        # region InsertHyperlink

        /// <summary>
        /// This methods creates hyperlinks and insert them in the document.
        /// </summary>
        private void InsertHyperlink()
        {
            WordDocument document = new WordDocument();
            IWSection section = document.AddSection();
            IWParagraph para = section.AddParagraph();

            para.AppendText("Inserting Hyperlink");
            para.ApplyStyle(BuiltinStyle.Title);

            section.AddParagraph();

            # region Web Hyperlink
            para = section.AddParagraph();
            para.AppendText("Web Hyperlinks");
            para.ApplyStyle(BuiltinStyle.Heading3);
            para = section.AddParagraph();
            para.AppendText("Hyperlinks to web pages creates a link to a web page, email address or to a program. \nSample Links:");

            para = section.AddParagraph();
            IWField field = para.AppendField("Syncfusion", FieldType.FieldHyperlink);
            para.ApplyStyle(BuiltinStyle.Hyperlink);
            Syncfusion.DocIO.DLS.Hyperlink hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.WebLink;
            hyperLink.Uri = "http://www.syncfusion.com";

            para = section.AddParagraph();
            para.ApplyStyle(BuiltinStyle.Hyperlink);
            field = para.AppendField("Google", FieldType.FieldHyperlink);
            hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.WebLink;
            hyperLink.Uri = "http://www.google.com";

            para = section.AddParagraph();
            para.ApplyStyle(BuiltinStyle.Hyperlink);
            field = para.AppendField("MSN", FieldType.FieldHyperlink);
            hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.WebLink;
            hyperLink.Uri = "http://www.msn.com";

            para = section.AddParagraph();
            # endregion

            # region Email Hyperlinks
            para = section.AddParagraph();
            para.AppendText("E-mail Hyperlinks");
            para.ApplyStyle(BuiltinStyle.Heading3);
            para = section.AddParagraph();
            para.AppendText("Hyperlinks that links to e-mail.");

            para = section.AddParagraph();
            para.ApplyStyle(BuiltinStyle.Hyperlink);
            field = para.AppendField("John", FieldType.FieldHyperlink);
            hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.EMailLink;
            hyperLink.Uri = "mailto:john@gmail.com";

            para = section.AddParagraph();
            para.ApplyStyle(BuiltinStyle.Hyperlink);
            field = para.AppendField("Eric", FieldType.FieldHyperlink);
            hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.EMailLink;
            hyperLink.Uri = "mailto:eric@yahoo.com";

            para = section.AddParagraph();
            para.ApplyStyle(BuiltinStyle.Hyperlink);
            field = para.AppendField("David", FieldType.FieldHyperlink);
            hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.EMailLink;
            hyperLink.Uri = "mailto:david@hotmail.com";

            # endregion

            #region Image HyperLink
            para = section.AddParagraph();
            para = section.AddParagraph();
            para.AppendText("Image Hyperlink");
            para.ApplyStyle(BuiltinStyle.Heading3);
            para = section.AddParagraph();
            para.AppendText("Hyperlinks to image creates link to a web page, email address or to a program.");

            para = section.AddParagraph();
            WPicture mImage1 = new WPicture(document);

            mImage1.LoadImage(System.Drawing.Image.FromStream(GetFileStream("syncfusion_logo.gif")));
            field = para.AppendField("Hyperlink", FieldType.FieldHyperlink);
            hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.WebLink;
            hyperLink.Uri = "http://www.syncfusion.com";
            hyperLink.PictureToDisplay = mImage1;

            para = section.AddParagraph();
            WPicture mImage2 = new WPicture(document);

            mImage2.LoadImage(System.Drawing.Image.FromStream(GetFileStream("google.png")));
            field = para.AppendField("Hyperlink", FieldType.FieldHyperlink);
            hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.WebLink;
            hyperLink.Uri = "http://www.google.com";
            hyperLink.PictureToDisplay = mImage2;

            para = section.AddParagraph();
            WPicture mImage3 = new WPicture(document);
            mImage3.LoadImage(System.Drawing.Image.FromStream(GetFileStream("yahoo.gif")));
            field = para.AppendField("Hyperlink", FieldType.FieldHyperlink);
            hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.WebLink;
            hyperLink.Uri = "http://www.yahoo.com";
            hyperLink.PictureToDisplay = mImage3;
            para = section.AddParagraph();
            #endregion

            # region File Hyperlinks
            para = section.AddParagraph();
            para = section.AddParagraph();
            para.AppendText("File Hyperlinks");
            para.ApplyStyle(BuiltinStyle.Heading3);
            para = section.AddParagraph();
            para.AppendText("Hyperlinks to files creates links to other files, an image and so on.");

            para = section.AddParagraph();
            para.ApplyStyle(BuiltinStyle.Hyperlink);
            field = para.AppendField("File 1", FieldType.FieldHyperlink);
            hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.FileLink;
            //hyperLink.TextToDisplay = "File 1";

            hyperLink.FilePath = new DirectoryInfo(@"Assets\DocIO\DocIO.gif").FullName;

            para = section.AddParagraph();
            para.ApplyStyle(BuiltinStyle.Hyperlink);
            field = para.AppendField("File 2", FieldType.FieldHyperlink);
            hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.FileLink;

            hyperLink.FilePath = new DirectoryInfo(@"Assets\DocIO\XlsIO.gif").FullName;

            para = section.AddParagraph();
            para.ApplyStyle(BuiltinStyle.Hyperlink);
            field = para.AppendField("File 3", FieldType.FieldHyperlink);
            hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.FileLink;

            hyperLink.FilePath = new DirectoryInfo(@"Assets\DocIO\pdf.gif").FullName;
            # endregion

            # region BookMarks
            # region Creating BookMarks
            section = document.AddSection();
            section.BreakCode = SectionBreakCode.NewPage;

            para = section.AddParagraph();
            para.AppendBookmarkStart("Introduction");
            para.AppendText("What is Hyperlink?").CharacterFormat.Bold = true;
            para.AppendBookmarkEnd("Introduction");
            para.AppendText("\nA hyperlink is a reference or navigation element in a document to another section of the same document or to another document that may be on or part of a (different) domain.");

            para = section.AddParagraph();
            para = section.AddParagraph();
            para.AppendBookmarkStart("Insert");
            para.AppendText("How to create a Hyperlink?").CharacterFormat.Bold = true;
            para.AppendBookmarkEnd("Insert");
            para.AppendText("\nSyncfusion.DocIO.DLS.IWField field = para.AppendField(\"Syncfusion\", Syncfusion.DocIO.FieldType.FieldHyperlink);\n");
            para.AppendText("para.ApplyStyle(Syncfusion.DocIO.DLS.BuiltinStyle.Hyperlink);\n");
            para.AppendText("Syncfusion.DocIO.DLS.Hyperlink hyperLink = new Hyperlink(field as WField);\n");
            para.AppendText("hyperLink.Type = Syncfusion.DocIO.DLS.HyperlinkType.WebLink;\n");
            para.AppendText("hyperLink.Uri = \"http://www.syncfusion.com\";\n");

            para = section.AddParagraph();
            para.AppendBookmarkStart("Edit");
            para.AppendText("How to edit Hyperlink?").CharacterFormat.Bold = true;
            para.AppendBookmarkEnd("Edit");
            para.AppendText("\nSyncfusion.DocIO.DLS.Hyperlink hlink = new Hyperlink(item as WField);\n");
            para.AppendText("if(hlink.Type = Syncfusion.DocIO.DLS.HyperlinkType.WebLink)\n");
            para.AppendText("{\n");
            para.AppendText("if (hlink.TextToDisplay == \"Syncfusion\")\n");
            para.AppendText("{\n");
            para.AppendText("hlink.TextToDisplay = \"Syncfusion Support\";\n");
            para.AppendText("hlink.Uri = \"http://www.syncfusion.com/support/default.aspx\";\n");
            para.AppendText("}\n");
            para.AppendText("}\n");
            # endregion

            # region Creating BookMark Hyperlinks
            section = document.Sections[0];
            para = section.AddParagraph();
            para = section.AddParagraph();
            para.AppendText("Bookmark Hyperlinks");
            para.ApplyStyle(BuiltinStyle.Heading3);
            para = section.AddParagraph();
            para.AppendText("A bookmark is a location or selected text on a document that was marked. One can create a hyperlink to a bookmark.");

            para = section.AddParagraph();
            para.ApplyStyle(BuiltinStyle.Hyperlink);
            field = para.AppendField("What is Hyperlink?", FieldType.FieldHyperlink);
            hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.Bookmark;
            hyperLink.BookmarkName = "Introduction";

            para = section.AddParagraph();
            para.ApplyStyle(BuiltinStyle.Hyperlink);
            field = para.AppendField("How to create a Hyperlink?", FieldType.FieldHyperlink);
            hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.Bookmark;
            hyperLink.BookmarkName = "Insert";

            para = section.AddParagraph();
            para.ApplyStyle(BuiltinStyle.Hyperlink);
            field = para.AppendField("How to edit Hyperlink?", FieldType.FieldHyperlink);
            hyperLink = new Syncfusion.DocIO.DLS.Hyperlink(field as WField);
            hyperLink.Type = HyperlinkType.Bookmark;
            hyperLink.BookmarkName = "Edit";
            #endregion
            #endregion

            document.Save(Application.ResourceAssembly.Location + @"..\..\Template.doc", FormatType.Doc);
        }
        # endregion

        # region FindHyperlinks
        /// <summary>
        /// Find hyperlinks in the loaded document and updates the underlying database.
        /// </summary>
        private void FindHyperLinks()
        {
            document = new WordDocument(Application.ResourceAssembly.Location + @"..\..\Template.doc");

            foreach (Entity ent in document.ChildEntities)
            {
                if (ent is WSection)
                {
                    WSection section = ent as WSection;
                    foreach (WParagraph paragraph in section.Body.Paragraphs)
                    {
                        foreach (ParagraphItem item in paragraph.Items)
                        {
                            if (item is WField && (item as WField).FieldType == FieldType.FieldHyperlink)
                            {
                                Syncfusion.DocIO.DLS.Hyperlink hlink = new Syncfusion.DocIO.DLS.Hyperlink(item as WField);
                                switch (hlink.Type)
                                {
                                    case HyperlinkType.WebLink:
                                        if (hlink.PictureToDisplay == null)
                                            this._WebLinks.Add(hlink);
                                        break;
                                    case HyperlinkType.EMailLink:
                                        this._EmailLinks.Add(hlink);
                                        break;
                                    case HyperlinkType.FileLink:
                                        this._FileLinks.Add(hlink);
                                        break;
                                    case HyperlinkType.Bookmark:
                                        this._Bookmarks.Add(hlink);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }

        # endregion

        # region Update
        /// <summary>
        /// Updates the database with the edited texts.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="dataMember"></param>
        private void UpdateListBindings(ArrayList list, string dataMember)
        {
            Binding myBinding = new Binding();

            myBinding.Source = list;
            if (this.radioBookmark.IsChecked.Value)
                myBinding.Path = new PropertyPath("BookmarkName");
            else
                myBinding.Path = new PropertyPath("TextToDisplay");
            myBinding.Mode = BindingMode.TwoWay;
            textDisplay.SetBinding(TextBox.TextProperty, myBinding);

            Binding listBind = new Binding();
            listBind.Source = list;
            listBind.Mode = BindingMode.OneWay;
            if (this.radioBookmark.IsChecked.Value)
                listDetail.DisplayMemberPath = "BookmarkName";
            else
                listDetail.DisplayMemberPath = "TextToDisplay";
            listDetail.SetBinding(ListBox.ItemsSourceProperty, listBind);

            Binding link = new Binding();
            link.Source = list;
            link.Path = new PropertyPath(dataMember);
            link.Mode = BindingMode.TwoWay;
            textLink.SetBinding(TextBox.TextProperty, link);
        }
        # endregion

        /// <summary>
        /// Get the file as stream from assets
        /// </summary>
        private Stream GetFileStream(string fileName)
        {
            Assembly assembly = typeof(Hyperlink).Assembly;
            return assembly.GetManifestResourceStream("syncfusion.dociodemos.wpf.Assets.DocIO." + fileName);
        }

        # endregion
    }
}
