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
using Microsoft.Win32;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WordToEPUB : DemoControl
    {
        #region Fields
        private string fullPath;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {            
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region Constructor
        public WordToEPUB()
        {
            InitializeComponent();
            string path = @"Assets\DocIO\";
            fullPath = @"Assets\DocIO\";
            openFileDialog1.Filter = "Word 97 to 2003 Document (*.doc)|*.doc|Word 2007 Document(*.docx)|*.docx";
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            this.textBox1.Text = "Word to EPUB.doc";
        }
        #endregion

        #region Events
        private void btnToEPub_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text != String.Empty && fullPath != string.Empty)
            {
                if (!this.textBox1.Text.EndsWith(".doc") && !this.textBox1.Text.EndsWith(".docx") &&
                   !this.textBox1.Text.EndsWith(".rtf") && !this.textBox1.Text.EndsWith(".docm") &&
                   !this.textBox1.Text.EndsWith(".dotx") && !this.textBox1.Text.EndsWith(".dotm") &&
                   !this.textBox1.Text.EndsWith(".dot") && !this.textBox1.Text.EndsWith(".txt"))
                {
                    MessageBox.Show("Browse a Word document to convert to EPUB", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (fullPath.EndsWith("\\"))
                    fullPath += this.textBox1.Text;
                if (File.Exists(fullPath))
                {
                    try
                    {
                        WordDocument document = new WordDocument(fullPath);
                        document.SaveOptions.EPubExportFont = this.chkBox1.IsChecked.Value;
                        document.Save("Word to EPUB.epub", FormatType.EPub);
                        document.Close();

                        //Message box confirmation to view the created document.
                        if (MessageBox.Show("Conversion Successful. Do you want to view the EPUB File?", "Status", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            try
                            {
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("Word to EPUB.epub") { UseShellExecute = true };
                                process.Start();
                            }
                            catch (System.ComponentModel.Win32Exception)
                            {
                                MessageBox.Show("EPUB viewer is not installed in this system!", "Status");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is IOException)
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\Word to EPUB.epub" + ") then try generating the document.", "File is already open",
                                 MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                            MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting" + "\r\n" + ex.ToString(), "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("File doesn’t exist");
                }
            }
            else
                MessageBox.Show("Browse a Word document to convert to EPUB", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                fullPath = openFileDialog1.FileName;
            }
        }
        #endregion
    }
}