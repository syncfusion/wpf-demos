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
using Syncfusion.XlsIO;
using Syncfusion.ExcelChartToImageConverter;
using Syncfusion.XlsIO.Implementation;
using System.Reflection;
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
#if NETCORE
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png");
            imglabel.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\XlsIO\label8_Image.gif");
            this.textBox1.Text = "ExcelTopdfwithChart.xlsx";
            this.textBox1.Tag = @"..\..\..\..\..\..\..\Common\Data\XlsIO\ExcelTopdfwithChart.xlsx";
#else
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png");
            imglabel.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\Common\Images\XlsIO\label8_Image.gif");
            this.textBox1.Text = "ExcelTopdfwithChart.xlsx";
            this.textBox1.Tag = @"..\..\..\..\..\..\Common\Data\XlsIO\ExcelTopdfwithChart.xlsx";
#endif
        }

        private void excelToPdfBtnClick(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text != String.Empty && (string)this.textBox1.Tag != string.Empty)
            {
                if (File.Exists((string)this.textBox1.Tag))
                {
                    ExcelEngine engine = new ExcelEngine();
                    IApplication application = engine.Excel;
                    IWorkbook book = application.Workbooks.Open((string)textBox1.Tag);

                    if (checkfontName.IsChecked.Value || checkfontStream.IsChecked.Value)
                    {
                        application.SubstituteFont += new SubstituteFontEventHandler(SubstituteFont);
                    }

                    application.ChartToImageConverter = new ChartToImageConverter();
                    //Set the Quality of chart Image
                    application.ChartToImageConverter.ScalingMode = ScalingMode.Best;
                    //Open the Excel Document to Convert
                    ExcelToPdfConverter converter = new ExcelToPdfConverter(book);

                    //Intialize the PDFDocument
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
                    if (MessageBox.Show("Conversion Successful. Do you want to view the PDF File?", "Status", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
#if NETCORE
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"ExceltoPdf.pdf")
                            {
                                UseShellExecute = true
                            };
                            process.Start();
#else
                            System.Diagnostics.Process.Start(@"ExceltoPdf.pdf");
#endif                            
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
            openFileDialog1.Filter = "Excel|*.xls;*.xlsx";
            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                this.textBox1.Tag = openFileDialog1.FileName;
            }
        }

        private void SubstituteFont(object sender, SubstituteFontEventArgs args)
        {
            if (checkfontName.IsChecked.Value && (args.OriginalFontName == "Bahnschrift Pro SemiBold" || args.OriginalFontName == "Georgia Pro Semibold"))
            {
                args.AlternateFontName = "Calibri";
            }
            if (checkfontStream.IsChecked.Value)
            {
                if (args.OriginalFontName == "Georgia Pro Semibold")
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var resourceName = "ExceltoPDF.Fonts.georgiab.ttf";
                    Stream fileStream = assembly.GetManifestResourceStream(resourceName);
                    MemoryStream memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);
                    fileStream.Close();
                    args.AlternateFontStream = memoryStream;
                }
                else if (args.OriginalFontName == "Bahnschrift Pro SemiBold")
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var resourceName = "ExceltoPDF.Fonts.bahnschrift.ttf";
                    Stream fileStream = assembly.GetManifestResourceStream(resourceName);
                    MemoryStream memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);
                    fileStream.Close();
                    args.AlternateFontStream = memoryStream;
                }
            }
        }
        private void CheckfontStream_UnChecked(object sender, RoutedEventArgs e)
        {
            if (!checkfontName.IsChecked.Value && !checkfontStream.IsChecked.Value)
            {
                this.textBox1.Text = "ExcelTopdfwithChart.xlsx";
#if NETCORE
                this.textBox1.Tag = @"..\..\..\..\..\..\..\Common\Data\XlsIO\ExcelTopdfwithChart.xlsx";
#else
                this.textBox1.Tag = @"..\..\..\..\..\..\Common\Data\XlsIO\ExcelTopdfwithChart.xlsx";
#endif
            }
        }
        private void CheckfontStream_Checked(object sender, RoutedEventArgs e)
        {
            this.textBox1.Text = "InvoiceTemplate.xlsx";
#if NETCORE
            this.textBox1.Tag = @"..\..\..\..\..\..\..\Common\Data\XlsIO\InvoiceTemplate.xlsx";
#else
            this.textBox1.Tag = @"..\..\..\..\..\..\Common\Data\XlsIO\InvoiceTemplate.xlsx";
#endif
        }
        private void CheckfontName_UnChecked(object sender, RoutedEventArgs e)
        {
            if (!checkfontName.IsChecked.Value && !checkfontStream.IsChecked.Value)
            {
                this.textBox1.Text = "ExcelTopdfwithChart.xlsx";
#if NETCORE
                this.textBox1.Tag = @"..\..\..\..\..\..\..\Common\Data\XlsIO\ExcelTopdfwithChart.xlsx";
#else
                this.textBox1.Tag = @"..\..\..\..\..\..\Common\Data\XlsIO\ExcelTopdfwithChart.xlsx";
#endif
            }
        }
        private void CheckfontName_Checked(object sender, RoutedEventArgs e)
        {
            this.textBox1.Text = "InvoiceTemplate.xlsx";
#if NETCORE
            this.textBox1.Tag = @"..\..\..\..\..\..\..\Common\Data\XlsIO\InvoiceTemplate.xlsx";
#else
            this.textBox1.Tag = @"..\..\..\..\..\..\Common\Data\XlsIO\InvoiceTemplate.xlsx";
#endif

        }
        private void inputBtnClick(object sender, EventArgs e)
        {
            //Get the path of the input file
            string inputPath = this.textBox1.Tag.ToString();
            //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
#if NETCORE
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(inputPath)
            {
                UseShellExecute = true
            };
            process.Start();
#else
            System.Diagnostics.Process.Start(inputPath);
#endif             
        }
    }
}
