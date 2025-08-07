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
using Microsoft.Win32;
using System.IO;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EncryptandDecrypt : DemoControl
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        #region Constructor
        public EncryptandDecrypt()
        {
            InitializeComponent();
            string path = @"Assets\DocIO\";
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            openFileDialog1.Filter = "Word Document(*.doc *.docx *.rtf)|*.doc;*.docx;*.rtf";
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (openFileDialog1 != null)
                openFileDialog1 = null;
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region Events
        /// <summary>
        /// Encrypt the word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void encrypt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.textBox1.Text != null && this.textBox1.Text != string.Empty)
                {
                    using (WordDocument document = new WordDocument(this.textBox1.Text))
                    {
                        // Getting last section of the document.
                        IWSection section = document.LastSection;

                        // Adding a paragraph to the section.
                        IWParagraph paragraph = section.AddParagraph();

                        // Writing text
                        IWTextRange text = paragraph.AppendText("This document was encrypted with password");
                        text.CharacterFormat.FontSize = 16f;
                        text.CharacterFormat.FontName = "Bitstream Vera Serif";

                        // Encrypt the document by giving password
                        document.EncryptDocument(this.passwordBox1.Password);

                        #region Save Document
                        //Save as doc format
                        if (worddoc.IsChecked.Value)
                        {
                            try
                            {
                                //Saving the document to disk.
                                document.Save("Encrypt.doc");

                                //Message box confirmation to view the created document.
                                if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    try
                                    {
                                        //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Encrypt.doc") { UseShellExecute = true };
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
                                    MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Encrypt.doc" + ") then try generating the document.", "File is already open",
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
                                document.Save("Encrypt.docx", FormatType.Docx);
                                //Message box confirmation to view the created document.
                                if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    try
                                    {
                                        //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                                        process.StartInfo = new System.Diagnostics.ProcessStartInfo("Encrypt.docx") { UseShellExecute = true };
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
                                    MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Encrypt.doc" + ") then try generating the document.", "File is already open",
                                             MessageBoxButton.OK, MessageBoxImage.Error);
                                else
                                    MessageBox.Show("Document could not be generated, Could you please email the error details to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                             MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        #endregion
                    }
                }
                else
                    MessageBox.Show("Please browse a Word document to encrypt");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Decrypt the word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void decrpt_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBox2.Text != null && this.textBox2.Text != string.Empty)
            {
                try
                {
                    // Open an encrypted document.
                    WordDocument document = new WordDocument(this.textBox2.Text, this.passwordBox2.Password);
                    // Getting last section of the document.
                    IWSection section = document.LastSection;

                    // Adding a paragraph to the section.
                    IWParagraph paragraph = section.AddParagraph();

                    // Writing text
                    IWTextRange text = paragraph.AppendText("\nDemo For Document Decryption with Essential DocIO");
                    text.CharacterFormat.FontSize = 16f;
                    text.CharacterFormat.FontName = "Bitstream Vera Serif";

                    text = paragraph.AppendText("\nThis document is Decrypted");
                    text.CharacterFormat.FontSize = 16f;
                    text.CharacterFormat.FontName = "Bitstream Vera Serif";

#region Save Document
                    //Save as doc format
                    if (worddoc.IsChecked.Value)
                    {
                        try
                        {
                            //Saving the document to disk.
                            document.Save("Decrypt.doc");

                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Decrypt.doc") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Decrypt.doc" + ") then try generating the document.", "File is already open",
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
                            document.Save("Decrypt.docx", FormatType.Docx);
                            //Message box confirmation to view the created document.
                            if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo("Decrypt.docx") { UseShellExecute = true };
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
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Decrypt.doc" + ") then try generating the document.", "File is already open",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                         MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
#endregion
                }
                catch
                {
                    MessageBox.Show("Password wrong");
                }
            }
            else
                MessageBox.Show("Please browse a Word document to decrypt");
        }
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.FileName;
            }
        }
        private void btnBrowse1_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox2.Text = openFileDialog1.FileName;
            }
        }
#endregion
    }
}
