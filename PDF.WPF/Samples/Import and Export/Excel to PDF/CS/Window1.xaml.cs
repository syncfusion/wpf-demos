#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;
using Syncfusion.Windows.Shared;
#region file Directives
using Syncfusion.ExcelToPdfConverter;
using Syncfusion.Pdf;
#endregion


namespace ExceltoPDF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public Window1()
        {
		
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\images\PDF\pdf_header.png");
            imglabel.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\XlsIO\label8_Image.gif");
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\images\PDF\pdf_button.png");
            this.textBox1.Text = "ExcelToPdf.xlsx";
            this.textBox1.Tag = @"..\..\..\..\..\..\..\Common\Data\XlsIO\Exceltopdf.xlsx";
            this.openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx";
        }

        private void excelToPdfBtnClick(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text != String.Empty && (string)this.textBox1.Tag != string.Empty)
            {
                if (File.Exists((string)this.textBox1.Tag))
                {
                    //Open the Excel Document to Convert
                    ExcelToPdfConverter converter = new ExcelToPdfConverter((string)this.textBox1.Tag);
					
                    //Intialize the PdfDocument
                    PdfDocument pdfDoc = new PdfDocument();
					
                    //Intialize the ExcelToPdfConverter Settings
                    ExcelToPdfConverterSettings settings = new ExcelToPdfConverterSettings();

                    if ((bool)noScaleRadioBtn.IsChecked)
                        settings.LayoutOptions = LayoutOptions.NoScaling;
                    else if ((bool)allRowsRadioBtn.IsChecked)
                        settings.LayoutOptions = LayoutOptions.FitAllRowsOnOnePage;
                    else if ((bool)allColumnRadioBtn.IsChecked)
                        settings.LayoutOptions = LayoutOptions.FitAllColumnsOnOnePage;
                    else
                        settings.LayoutOptions = LayoutOptions.FitSheetOnOnePage;

                    //Assign the PdfDocument to the templateDocument property of ExcelToPdfConverterSettings
                    settings.TemplateDocument = pdfDoc;
					settings.DisplayGridLines = GridLinesDisplayStyle.Invisible;
                    //Convert Excel Document into PDF document
                    pdfDoc = converter.Convert(settings);
					
                    //Save the PDF file
                    pdfDoc.Save("ExceltoPdf.pdf");
					
                    //Message box confirmation to view the created document.
                    if (MessageBox.Show("Conversion Successful. Do you want to view the PDF File?", "Status", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(@"ExceltoPdf.pdf");
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
                MessageBox.Show("Browse an Excel document to convert to Pdf", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }



        private void browseBtnClick(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                this.textBox1.Tag = openFileDialog1.FileName;
            }
        }

    }
}
