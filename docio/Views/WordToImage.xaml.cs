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
using System.IO;
using System.Drawing.Imaging;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dociodemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WordToImage : DemoControl
    {
        #region Private Members
        private string fullPath;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        #endregion

        #region Constructor
        public WordToImage()
        {
            InitializeComponent();
            string path = @"Assets\DocIO\";
            fullPath = @"Assets\DocIO\";
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            openFileDialog1.Filter = "Word Document(*.doc *.docx *.rtf)|*.doc;*.docx;*.rtf";
            this.textBox1.Text = "Word to Image.docx";
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {           
            //Release all resources
            base.Dispose(disposing);
        }
        #endregion

        #region Event
        private void btnToImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.textBox1.Text != String.Empty && fullPath != string.Empty)
                {
                    if (!this.textBox1.Text.EndsWith(".doc") && !this.textBox1.Text.EndsWith(".docx") &&
                    !this.textBox1.Text.EndsWith(".rtf") && !this.textBox1.Text.EndsWith(".docm") &&
                    !this.textBox1.Text.EndsWith(".dotx") && !this.textBox1.Text.EndsWith(".dotm") &&
                    !this.textBox1.Text.EndsWith(".dot") && !this.textBox1.Text.EndsWith(".txt"))
                    {
                        MessageBox.Show("Browse a Word document to convert to Image", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (fullPath.EndsWith("\\"))
                        fullPath += this.textBox1.Text;
                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            // Loads the Document
                            using (WordDocument wordDoc = new WordDocument(fullPath))
                            {
                                // Converts the Word Document into image
                                System.Drawing.Image[] image = wordDoc.RenderAsImages(ImageType.Metafile);
                                int pageNumber = 0;
                                //Save as Bitmap image
                                if (bmpRadioBtn.IsChecked == true)
                                {
                                    for (int i = 0; i < image.Length; i++)
                                    {
                                        image[i].Save(@"WordToImage_" + ++pageNumber + ".bmp", ImageFormat.Bmp);
                                    }
                                    if (MessageBox.Show("Conversion Successful. Do you want to view the Image File?", "Status", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                    {
                                        try
                                        {
                                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                                            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"WordToImage_1.bmp") { UseShellExecute = true };
                                            process.Start();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                                        }
                                    }
                                }
                                //Save as PNG image
                                else if (pngRadioBtn.IsChecked == true)
                                {
                                    for (int i = 0; i < image.Length; i++)
                                    {
                                        image[i].Save(@"WordToImage_" + ++pageNumber + ".png", ImageFormat.Png);
                                    }
                                    if (MessageBox.Show("Conversion Successful. Do you want to view the Image File?", "Status", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                    {
                                        try
                                        {
                                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                                            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"WordToImage_1.png") { UseShellExecute = true };
                                            process.Start();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                                        }
                                    }
                                }
                                //Save as JPEG image
                                else if (jpegRadioBtn.IsChecked == true)
                                {
                                    for (int i = 0; i < image.Length; i++)
                                    {
                                        image[i].Save(@"WordToImage_" + ++pageNumber + ".jpeg", ImageFormat.Jpeg);
                                    }
                                    if (MessageBox.Show("Conversion Successful. Do you want to view the Image File?", "Status", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                    {
                                        try
                                        {
                                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                                            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"WordToImage_1.jpeg") { UseShellExecute = true };
                                            process.Start();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                                        }
                                    }
                                }
                                //Save as EMF image
                                else if (emfRadioBtn.IsChecked == true)
                                {
                                    for (int i = 0; i < image.Length; i++)
                                    {
                                        MemoryStream stream = (MemoryStream)wordDoc.RenderAsImages(i, ImageFormat.Emf);
                                        using (FileStream fstream = new FileStream(@"WordToImage_" + ++pageNumber + ".emf", FileMode.OpenOrCreate))
                                        {
                                            stream.WriteTo(fstream);
                                        }
                                    }
                                    if (MessageBox.Show("Conversion Successful. Do you want to view the Image File?", "Status", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                    {
                                        try
                                        {
                                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                                            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"WordToImage_1.emf") { UseShellExecute = true };
                                            process.Start();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("File doesn’t exist");
                    }
                }
                else
                    MessageBox.Show("Browse a Word document to convert to Image", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);

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
