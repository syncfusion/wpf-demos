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
using Syncfusion.DocIO;


namespace Word_To_WordML_2008
{


    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private string fullPath;
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
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            openFileDialog1.Filter = "Word Document(*.doc *.docx)|*.doc;*.docx";
            this.textBox1.Text = "DocToWordML.doc";            
        }

        #region Browse document to export to RTF
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
        #endregion Browse document to export to RTF

        #region export to WordML
        private void btnToRTF_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text != String.Empty && fullPath != string.Empty)
            {
                if (!this.textBox1.Text.EndsWith(".doc") && !this.textBox1.Text.EndsWith(".docx") &&
                    !this.textBox1.Text.EndsWith(".rtf") && !this.textBox1.Text.EndsWith(".docm") &&
                    !this.textBox1.Text.EndsWith(".dotx") && !this.textBox1.Text.EndsWith(".dotm") &&
                    !this.textBox1.Text.EndsWith(".dot") && !this.textBox1.Text.EndsWith(".txt"))
                {
                    MessageBox.Show("Browse a Word document to convert to WordML", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                        try
                        {
                            //Export the doc file as rtf
                            doc.Save("WordToWordML.xml", FormatType.WordML);

                            if (MessageBox.Show("Conversion Successful. Do you want to view the WordML File?", "Status", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            { 
#if NETCORE
                                System.Diagnostics.Process process = new System.Diagnostics.Process();
                                process.StartInfo = new System.Diagnostics.ProcessStartInfo("WordToWordML.xml") { UseShellExecute = true };
                                process.Start();
#else
                                System.Diagnostics.Process.Start("WordToWordML.xml");
#endif
                            }
                                this.Close();
                        }
                        catch (Exception ex)
                        {
                            if (ex is IOException)
                                MessageBox.Show("Please close the file (" + Directory.GetCurrentDirectory() + "\\WordToWordML.xml" + ") then try generating the document.", "File is already open",
                                     MessageBoxButton.OK, MessageBoxImage.Error);
                            else
                                MessageBox.Show("Document could not be generated, Could you please email the error details with along input document to support@syncfusion.com for trouble shooting"+ "\r\n" + ex.ToString(), "Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Browse a Word document to convert to WordML", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }
        #endregion export to WordML
    }
}
