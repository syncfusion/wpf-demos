#region Copyright Syncfusion Inc. 2001 - 2019
//
//  Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using Microsoft.Win32;
using System.IO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace HTMLToDoc_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        private string text = null;
        private string errorMessage = null;
        # endregion

        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");

            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
        }
        # endregion

        # region Events
        /// <summary>
        /// Gets the source html document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string path = @"..\..\..\..\..\..\..\Common\Data\DocIO\";
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "HTML files (*.htm *.html)|*.htm;*.html";

            if (openFileDialog1.ShowDialog().Value)
            {
                StreamReader read = new StreamReader(openFileDialog1.OpenFile());
                text = read.ReadToEnd();
                this.btnToDoc.IsEnabled = true;
                this.radioOptions.IsEnabled = true;
            }
            else
            {
                this.btnToDoc.IsEnabled = false;
                this.radioOptions.IsEnabled = false;
            }

            this.htmlTextBox.Text = text;
            outputTextBox.Clear();
        }

        /// <summary>
        /// Converts the input html file to a word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToDoc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.htmlTextBox.Text != String.Empty)
                {
                    WordDocument document = new WordDocument();
                    IWSection section = document.AddSection();
                    IWParagraph para = section.AddParagraph();

                    bool valid = false;

                     // This manual validation check is Transitional. We do this here only for instructional purpose.
                    if (section.Body.IsValidXHTML(this.htmlTextBox.Text, XHTMLValidationType.Transitional, out errorMessage))
                    {
                        valid =true;
                        document.XHTMLValidateOption = XHTMLValidationType.Transitional;
                    }
                    // This manual validation check is Strict. We do this here only for instructional purpose
                    else if (section.Body.IsValidXHTML(this.htmlTextBox.Text, XHTMLValidationType.Strict, out errorMessage))
                    {
                        valid = true;
                        document.XHTMLValidateOption = XHTMLValidationType.Strict;
                    }
                    // This manual validation check is None. We do this here only for instructional purpose
                    else if (section.Body.IsValidXHTML(this.htmlTextBox.Text, XHTMLValidationType.None, out errorMessage))
                    {
                        valid = true;
                        document.XHTMLValidateOption = XHTMLValidationType.None;
                    }
					
                    if (!valid)
                    {
                        outputTextBox.Text = "Content is not a welformatted XHTML content.\nError message:\n" + errorMessage;
                        this.btnToDoc.IsEnabled = false;
                        this.radioOptions.IsEnabled = false;
                    }
                    else
                    {
                        // By default, the input html will be validated for XHTML format. This will provide you understandable error messages, if the format is invalid.
                        // However, if you are sure that the input html is valid, then you can skip the validation step to improve performance. However, any error messages 
                        //you might get here will not be very useful as to where exactly in your html, the issue is.

                        section.Body.InsertXHTML(this.htmlTextBox.Text);

                        outputTextBox.Text = "Conversion Successful";

                        #region Save and open Document
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
                                document.Save("Sample.docx", FormatType.Word2013);
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
                                    MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Sample.doc" + ") then try generating the document.", "File is already open",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                                else
                                    MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
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
                }
                else
                {
                    MessageBox.Show("Browse or type the HTML content to be converted to word document");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        # endregion
    }
}
