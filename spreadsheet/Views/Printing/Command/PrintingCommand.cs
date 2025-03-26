#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using Syncfusion.XlsIO.Implementation;
using Syncfusion.XlsIO;
using Syncfusion.ExcelToPdfConverter;
using Syncfusion.Pdf;
using Syncfusion.UI.Xaml.Spreadsheet;
using System.IO;
using Syncfusion.Windows.PdfViewer;
using System.Threading;
using syncfusion.spreadsheetdemos.wpf;
using Syncfusion.Windows.Shared;

namespace syncfusion.spreadsheetdemos.wpf
{
    public static class PrintingCommand
    {
        private static IWorkbook workbook;
        static MemoryStream pdfstream;
        static PrintingCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfSpreadsheet), new CommandBinding(PrintPreview, OnExecutePrintPreview, OnCanExecutePrintPreview));
            CommandManager.RegisterClassCommandBinding(typeof(SfSpreadsheet), new CommandBinding(DirectPrint, OnExecuteDirectPrint, OnCanExecuteDirectPrint));
        }

     
        #region PrintPreview

        public static RoutedCommand PrintPreview = new RoutedCommand("PrintPreview", typeof(SfSpreadsheet));

        private static void OnExecutePrintPreview(object sender, ExecutedRoutedEventArgs args)
        {
            SfSpreadsheet spreadsheetControl = args.Source as SfSpreadsheet;
            PrintPreviewWindow previewwindow = new PrintPreviewWindow() { Spreadsheet = spreadsheetControl };
            previewwindow.ShowDialog();
        }

        private static void OnCanExecutePrintPreview(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        #endregion

        #region DirectPrint

        public static RoutedCommand DirectPrint = new RoutedCommand("DirectPrint", typeof(SfSpreadsheet));

        private static void OnExecuteDirectPrint(object sender, ExecutedRoutedEventArgs args)
        {
            SfSpreadsheet spreadsheetControl = args.Source as SfSpreadsheet;
            workbook = spreadsheetControl.Workbook.Clone();
            workbook.Worksheets[0].EnableSheetCalculations();
            workbook.Worksheets[0].CalcEngine.AllowShortCircuitIFs = true;
            workbook.Worksheets[0].CalcEngine.UseFormulaValues = true;
            workbook.Worksheets[0].CalcEngine.MaximumRecursiveCalls = 10000;
            //Create the pdfviewer for load the document.
            PdfViewerControl pdfviewer = new PdfViewerControl();

            // PdfDocumentViewer
            pdfstream = new MemoryStream();

            //Load the document to pdfviewer
            pdfviewer.Load(pdfstream);

            //Initialize the PdfDocument
            PdfDocument pdfDoc = new PdfDocument();
            MemoryStream pdfStream = new MemoryStream();
            ExcelToPdfConverter converter = new ExcelToPdfConverter(workbook);

            //Intialize the ExcelToPdfConverter Settings
            ExcelToPdfConverterSettings settings = new ExcelToPdfConverterSettings();
            settings.LayoutOptions = LayoutOptions.NoScaling;

            //Assign the PdfDocument to the templateDocument property of ExcelToPdfConverterSettings  
            settings.TemplateDocument = pdfDoc;
            settings.DisplayGridLines = GridLinesDisplayStyle.Invisible;

            //Convert Excel Document into PDF document
            pdfDoc = converter.Convert(settings);

            //Save the PDF file     
            pdfDoc.Save(pdfStream);

            //Load the document to pdf viewer
            pdfviewer.Load(pdfStream);

            //Print the doc
            pdfviewer.Print(true);
        }

        private static void OnCanExecuteDirectPrint(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        #endregion

        #region Direct print through PdfViewer

        private static void PrintFromPdfViewer()
        {
            workbook.Worksheets[0].EnableSheetCalculations();
            workbook.Worksheets[0].CalcEngine.AllowShortCircuitIFs = true;
            workbook.Worksheets[0].CalcEngine.MaximumRecursiveCalls = 10000;
            ExcelToPdfConverter converter = new ExcelToPdfConverter(workbook);
            //Intialize the PdfDocument
            PdfDocument pdfDoc = new PdfDocument();

            //Intialize the ExcelToPdfConverter Settings
            ExcelToPdfConverterSettings settings = new ExcelToPdfConverterSettings();
            settings.LayoutOptions = LayoutOptions.NoScaling;

            //Assign the PdfDocument to the templateDocument property of ExcelToPdfConverterSettings
            settings.TemplateDocument = pdfDoc;
            settings.DisplayGridLines = GridLinesDisplayStyle.Invisible;

            //Convert Excel Document into PDF document
            pdfDoc = converter.Convert(settings);

            //Save the PDF file
            pdfDoc.Save(pdfstream);

        }
        #endregion

       
    }
}
