using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;

#region file Directives
using Syncfusion.ExcelToPdfConverter;
using Syncfusion.Pdf;
using Syncfusion.XlsIO;
using Syncfusion.XlsIO.Implementation;
#endregion

namespace ExceltoPDF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            image1.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png");
            imgbutton.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_button.png");
            imglabel.Source = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\XlsIO\label8_Image.gif");
            this.Icon = (ImageSource)img.ConvertFromString(@"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_button.png");
            this.textBox1.Text = "ExcelToPdf.xlsx";
            this.textBox1.Tag = @"..\..\..\..\..\..\..\Common\Data\XlsIO\Exceltopdf.xlsx";
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
            openFileDialog1.Filter = "Excel|*.xls;*.xlsx";
            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                this.textBox1.Tag = openFileDialog1.FileName;
            }
        }

    }
}
