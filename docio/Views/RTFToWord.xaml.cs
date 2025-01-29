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
using System.Windows.Media;
using Microsoft.Win32;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIO;
using System.IO;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class RTFToWord : DemoControl
    {
        #region Private Members
        private string fullPath;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        #endregion

        #region Constructor
        public RTFToWord()
        {
            InitializeComponent();
            string path = @"Assets\DocIO\";
            fullPath = @"Assets\DocIO\";
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            openFileDialog1.Filter = "Rtf Document(*.rtf)|*.rtf";
            this.textBox1.Text = "RTF to Word.rtf";
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region Events
        private void btnRTFToWord_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.textBox1.Text != String.Empty && fullPath != string.Empty)
                {
                    if (!this.textBox1.Text.EndsWith(".rtf"))
                    {
                        MessageBox.Show("Browse an RTF file to convert to Word document", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (fullPath.EndsWith("\\"))
                        fullPath += this.textBox1.Text;
                    if (File.Exists(fullPath))
                    {
                        string outputFileName = Path.GetFileNameWithoutExtension(fullPath);
                        try
                        {
                            using (WordDocument document = new WordDocument())
                            {
                                document.Open((string)fullPath, FormatType.Rtf);
                                //Saving the document to disk.
                                document.Save(outputFileName + ".docx");

                                //Message box confirmation to view the created document.
                                if (MessageBox.Show("Do you want to view the generated Word document?", "Document has been created", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                {
                                    try
                                    {
                                        //Launching the MS Word file using the default Application.[MS Word Or Free WordViewer]
                                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                                        process.StartInfo = new System.Diagnostics.ProcessStartInfo(outputFileName + ".docx") { UseShellExecute = true };
                                        process.Start();
                                    }
                                    catch (Win32Exception ex)
                                    {
                                        MessageBox.Show("Microsoft Word Viewer or Microsoft Word is not installed in this system");
                                        Console.WriteLine(ex.ToString());
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex is IOException)
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\"+outputFileName + ".docx" + ") then try generating the document.", "File is already open",
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
                    MessageBox.Show("Browse an RTF file to convert to Word document", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
