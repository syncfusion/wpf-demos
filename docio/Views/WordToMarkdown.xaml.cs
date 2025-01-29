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
using Microsoft.Win32;
using System.IO;
using Syncfusion.DocIO;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WordToMarkdown : DemoControl
    {
        #region Private Members
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private string fullPath;
        #endregion

        #region Constructor
        public WordToMarkdown()
        {
            InitializeComponent();
            string path = @"Assets\DocIO\";
            fullPath = @"Assets\DocIO\";
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            openFileDialog1.Filter = "Word Document(*.doc *.docx *.rtf)|*.doc;*.docx;*.rtf";
            this.textBox1.Text = "WordtoMD.docx";
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {           
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region Browse document to export to Markdown
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                this.textBox1.IsReadOnly = true;
                fullPath = openFileDialog1.FileName;
            }
        }
        #endregion Browse document to export to Markdown

        #region export to Markdown
        private void btnToMarkdown_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text != String.Empty && fullPath != string.Empty)
            {
                if (!this.textBox1.Text.EndsWith(".doc") && !this.textBox1.Text.EndsWith(".docx") &&
                    !this.textBox1.Text.EndsWith(".rtf") && !this.textBox1.Text.EndsWith(".docm") &&
                    !this.textBox1.Text.EndsWith(".dotx") && !this.textBox1.Text.EndsWith(".dotm") &&
                    !this.textBox1.Text.EndsWith(".dot") && !this.textBox1.Text.EndsWith(".txt"))
                {
                    MessageBox.Show("Browse a Word document to convert to Markdown", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (fullPath.EndsWith("\\"))
                    fullPath += this.textBox1.Text;
                if (File.Exists(fullPath))
                {
                    try
                    {
                        //Open the document to convert from Word to Markdown
                        using (WordDocument doc = new WordDocument(fullPath))
                        {
			string outputFileName = Path.GetFileNameWithoutExtension(fullPath);
                            try
                            {
                                //Export the doc file as WordML
                                doc.Save(outputFileName + ".md", FormatType.Markdown);

                                if (MessageBox.Show("Conversion Successful. Do you want to view the Markdown File?", "Status", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {
                                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                                    process.StartInfo = new System.Diagnostics.ProcessStartInfo(outputFileName + ".md") { UseShellExecute = true };
                                    process.Start();
                                }
                            }
                            catch (Exception ex)
                            {
                                if (ex is IOException)
                                    MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\" + outputFileName + ".md" + ") then try generating the document.", "File is already open",
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
                else
                {
                    MessageBox.Show("File doesn’t exist");
                }
            }
            else
                MessageBox.Show("Browse a Word document to convert to Markdown", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion export to Markdown
    }
}
