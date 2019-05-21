#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.Pdf;
using System.IO;
using Syncfusion.Windows.Shared;
#if !SyncfusionFrameWork3_5
using Syncfusion.OfficeChart;
using Syncfusion.OfficeChartToImageConverter;
#endif


namespace Doc_to_PDF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        private string fullPath;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public Window1()
        {
		    
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\PDF\pdf_header.png");
            imglabel.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\DocIO\label8_Image.gif");
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\images\PDF\pdf_button.png");
            string path = @"..\..\..\..\..\..\..\Common\Data\PDF\doctopdf.doc";
            openFileDialog1.InitialDirectory = new DirectoryInfo(path).FullName;
            this.textBox1.Text = "DocToPDF.doc";
            fullPath = @"..\..\..\..\..\..\..\Common\Data\PDF\doctopdf.doc";

        }

        private void btnTopdf_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text != String.Empty && fullPath != string.Empty)
            {
                if (this.textBox1.Text.Contains("//"))
                {
                    fullPath = this.textBox1.Text;
                }

                if (File.Exists(fullPath))
                {
                    WordDocument wordDoc = new WordDocument(fullPath);
#if !SyncfusionFrameWork3_5
                    //Initializing chart to image convertor to convert charts in word to pdf conversion
                    wordDoc.ChartToImageConverter = new ChartToImageConverter();
                    wordDoc.ChartToImageConverter.ScalingMode = Syncfusion.OfficeChart.ScalingMode.Normal;
#endif
                    DocToPDFConverter converter = new DocToPDFConverter();
                    //Convert word document into PDF document
                    PdfDocument pdfDoc = converter.ConvertToPDF(wordDoc);
                    //Save the pdf file
                    pdfDoc.Save("DoctoPDF.pdf");
                    //Message box confirmation to view the created document.
                    if (MessageBox.Show("Conversion Successful. Do you want to view the PDF File?", "Status", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(@"DoctoPDF.pdf");
                            //Exit
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                }

                else
                {
                    MessageBox.Show("File doesn’t exist");
                }
            }

            else
                MessageBox.Show("Browse a Word document to convert to RTF", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }



        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Doc files (*.DOC)|*.doc";

            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                fullPath = openFileDialog1.FileName;

            }


        }
    }
}
