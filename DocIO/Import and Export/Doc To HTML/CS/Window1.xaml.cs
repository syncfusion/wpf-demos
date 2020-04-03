#region Copyright Syncfusion Inc. 2001 - 2020
//
//  Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using Syncfusion.DocIO.DLS;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using Syncfusion.Windows.Shared;

namespace DocToPDF_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        # region Private Members
        private string strHtml;
        #endregion
        private string fullPath;
        OpenFileDialog openFileDialog1;
        # region Constructor
        /// <summary>
        /// Window constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();                        
#if NETCORE
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
            string path = @"..\..\..\..\..\..\..\Common\Data\DocIO\";
            fullPath = @"..\..\..\..\..\..\..\Common\Data\DocIO\";
#else
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\DocIO\docio_header.png");
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\DocIO\sfLogo.ico");
            string path = @"..\..\..\..\..\..\Common\Data\DocIO\";
            fullPath = @"..\..\..\..\..\..\Common\Data\DocIO\";
#endif
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            this.textBox1.Text = "Doc to HTML.doc";           
        }
        # endregion

        # region Events

        /// <summary>
        /// Converts the Word document to HTML file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToHTML_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text != String.Empty && fullPath != string.Empty)
            {
                if (!this.textBox1.Text.EndsWith(".doc") && !this.textBox1.Text.EndsWith(".docx") &&
                    !this.textBox1.Text.EndsWith(".rtf") && !this.textBox1.Text.EndsWith(".docm") &&
                    !this.textBox1.Text.EndsWith(".dotx") && !this.textBox1.Text.EndsWith(".dotm") &&
                    !this.textBox1.Text.EndsWith(".dot") && !this.textBox1.Text.EndsWith(".txt"))
                {
                    MessageBox.Show("Browse a Word document to convert to HTML", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (fullPath.EndsWith("\\"))
                    fullPath += this.textBox1.Text;
                if (File.Exists(fullPath))
                {
                    try
                    {
                        //Open the document to convert from word to HTML
                        WordDocument doc = new WordDocument(fullPath);

                        //Using HTMLExport for conversion
                        HTMLExport htmlExport = new HTMLExport();

                        //Filename and the location
                        strHtml = "doctohtml.html";

                        //Exports the doc to HTML and save as .html file
                        htmlExport.SaveAsXhtml(doc, strHtml);

                        if (MessageBox.Show("Conversion Successful. Do you want to view the HTML File?", "Status", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
#if NETCORE
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo("doctohtml.html") { UseShellExecute = true };
                            process.Start();
#else
                            System.Diagnostics.Process.Start("doctohtml.html");
#endif
                            this.Close();
                        }
                    }
                    catch(Exception ex)
                    {
                        if (ex is IOException)
                            MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\doctohtml.html" + ") then try generating the document.", "File is already open",
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
                MessageBox.Show("Browse a Word document to convert to HTML", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Gets the source word document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Doc files (*.DOC)|*.doc";

            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                fullPath = openFileDialog1.FileName;
                this.textBox1.IsReadOnly = true;

            }
        }
        # endregion
    }
}
