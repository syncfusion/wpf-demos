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
using Microsoft.Win32;
using Syncfusion.Windows.Shared;
using Syncfusion.ExcelChartToImageConverter;
using Syncfusion.ExcelToPdfConverter;
using Syncfusion.XlsIO;
using syncfusion.demoscommon.wpf;
using Syncfusion.Pdf;
using Syncfusion.XlsIO.Implementation;
using System.Reflection;

namespace syncfusion.xlsiodemos.wpf
{
    /// <summary>
    /// Interaction logic for ExcelToPDFUA.xaml
    /// </summary>
    public partial class ExcelToPDFUA : DemoControl
    {
        #region Fields
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        #endregion

        #region Constructor
        /// <summary>
        /// ExcelToPDF constructor
        /// </summary>
        public ExcelToPDFUA()
        {
            InitializeComponent();
            this.textBox1.Text = "ExcelToPdf-UA.xlsx";
            this.textBox1.Tag = @"Assets\XlsIO\ExcelToPdf-UA.xlsx";
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

        /// <summary>
        /// Convert Excel To PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertToPDF_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text != String.Empty && (string)this.textBox1.Tag != string.Empty)
            {
                if (File.Exists((string)this.textBox1.Tag))
                {
                    ExcelEngine engine = new ExcelEngine();
                    IApplication application = engine.Excel;
                    IWorkbook book = application.Workbooks.Open(this.textBox1.Tag.ToString());



                    application.ChartToImageConverter = new ChartToImageConverter();
                    //Set the Quality of chart Image
                    application.ChartToImageConverter.ScalingMode = ScalingMode.Best;
                    //Open the Excel Document to Convert
                    ExcelToPdfConverter converter = new ExcelToPdfConverter(book);

                    //Intialize the PDFDocument
                    PdfDocument pdfDoc = new PdfDocument();

                    //Intialize the ExcelToPdfConverter Settings
                    ExcelToPdfConverterSettings settings = new ExcelToPdfConverterSettings();

                    settings.AutoTag = true;


                    //Convert Excel Document into PDF document
                    pdfDoc = converter.Convert(settings);

                    //Save the PDF file
                    pdfDoc.Save("ExceltoPdf.pdf");

                    //Message box confirmation to view the created document.
                    if (MessageBox.Show("Conversion Successful. Do you want to view the PDF File?", "Status", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            process.StartInfo = new System.Diagnostics.ProcessStartInfo(@"ExceltoPdf.pdf") { UseShellExecute = true };
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

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Excel|*.xls;*.xlsx";
            if (openFileDialog1.ShowDialog().Value)
            {
                this.textBox1.Text = openFileDialog1.SafeFileName;
                this.textBox1.Tag = openFileDialog1.FileName;
            }
        }

        #endregion
    }
}
