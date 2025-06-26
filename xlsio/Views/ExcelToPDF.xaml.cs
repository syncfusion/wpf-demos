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
    /// Interaction logic for ExcelToPDF1.xaml
    /// </summary>
    public partial class ExcelToPDF : DemoControl
    {
        
        # region Constructor
        /// <summary>
        /// ExcelToPDF constructor
        /// </summary>
        public ExcelToPDF()
        {
            InitializeComponent();                     
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
        string inputPath = @"Assets\XlsIO\ExcelTopdfwithChart.xlsx";

        /// <summary>
        /// Convert Excel To PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertToPDF_Click(object sender, RoutedEventArgs e)
        {
            
            ExcelEngine engine = new ExcelEngine();
            IApplication application = engine.Excel;
            IWorkbook book = application.Workbooks.Open(inputPath);

            if (chkboxFontName.IsChecked.Value || chkboxFontStream.IsChecked.Value)
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

            if (this.rdbtnNoScaling.IsChecked.Value)
                settings.LayoutOptions = LayoutOptions.NoScaling;
            else if (this.rdbtnFitAllRows.IsChecked.Value)
                settings.LayoutOptions = LayoutOptions.FitAllRowsOnOnePage;
            else if (this.rdbtnFitAllCols.IsChecked.Value)
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
        
        /// <summary>
        /// Substitute Font
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubstituteFont(object sender, SubstituteFontEventArgs args)
        {
            if (chkboxFontName.IsChecked.Value && (args.OriginalFontName == "Bahnschrift Pro SemiBold" || args.OriginalFontName == "Georgia Pro Semibold"))
            {
                args.AlternateFontName = "Calibri";
            }
            if (chkboxFontStream.IsChecked.Value)
            {
                if (args.OriginalFontName == "Georgia Pro Semibold")
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var resourceName = "syncfusion.xlsiodemos.wpf.Assets.XlsIO.Fonts.georgiab.ttf";
                    Stream fileStream = assembly.GetManifestResourceStream(resourceName);
                    MemoryStream memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);
                    fileStream.Close();
                    args.AlternateFontStream = memoryStream;
                }
                else if (args.OriginalFontName == "Bahnschrift Pro SemiBold")
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var resourceName = "syncfusion.xlsiodemos.wpf.Assets.XlsIO.Fonts.bahnschrift.ttf";
                    Stream fileStream = assembly.GetManifestResourceStream(resourceName);
                    MemoryStream memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);
                    fileStream.Close();
                    args.AlternateFontStream = memoryStream;
                }
            }
        }

        /// <summary>
        /// Check the FontStream Value and set the input path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckfontStream_UnChecked(object sender, RoutedEventArgs e)
        {
            if (!chkboxFontName.IsChecked.Value && !chkboxFontStream.IsChecked.Value)
            {                
                inputPath = @"Assets\XlsIO\ExcelTopdfwithChart.xlsx";
            }
        }
        
        /// <summary>
        /// Check the FontStream Value and set the input path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckfontStream_Checked(object sender, RoutedEventArgs e)
        {
            inputPath = @"Assets\XlsIO\InvoiceTemplate.xlsx";
        }

        /// <summary>
        /// Check the Font Name and set the input path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckfontName_UnChecked(object sender, RoutedEventArgs e)
        {
            if (!chkboxFontName.IsChecked.Value && !chkboxFontStream.IsChecked.Value)
            {
                inputPath = @"Assets\XlsIO\ExcelTopdfwithChart.xlsx";
            }
        }

        /// <summary>
        /// Check the Font Name and set the input path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckfontName_Checked(object sender, RoutedEventArgs e)
        {
            inputPath = @"Assets\XlsIO\InvoiceTemplate.xlsx";
        }

        /// <summary>
        /// Creates spreadsheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInput_Click(object sender, EventArgs e)
        {            
            //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(inputPath) { UseShellExecute = true };
            process.Start();
        }
        #endregion
    }
}
