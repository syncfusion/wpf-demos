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
using System.Drawing.Imaging;

namespace Export.Commands
{
    public static class ExportCommand
    {
        static ExportCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfSpreadsheet), new CommandBinding(Export, OnExecuteExport, OnCanExecuteExport));
        }

     
        #region Export
        public static RoutedCommand Export = new RoutedCommand("Export", typeof(SfSpreadsheet));

        private static void OnExecuteExport(object sender, ExecutedRoutedEventArgs args)
        {
            SfSpreadsheet spreadsheetControl = args.Source as SfSpreadsheet;         
            if (args.Parameter != null)
            {
                string Option = args.Parameter.ToString();
                if (Option == "Export to PDF")
                    ExportToPDF(spreadsheetControl);
                else if (Option == "Export to HTML")
                    ExportWorkBookToHTML(spreadsheetControl);
                else if (Option == "Export to Image")
                    ExportWorksheetToBitmap(spreadsheetControl);
               
            }
            
        }
        private static void OnCanExecuteExport(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
        #endregion

        #region PDF
        private static void ExportToPDF(SfSpreadsheet spreadsheetControl)
        {
            
            ExcelToPdfConverter converter = new ExcelToPdfConverter(spreadsheetControl.Workbook);
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
            pdfDoc.Save("Sample.pdf");

            System.Diagnostics.Process.Start("Sample.pdf");

        }
        #endregion

        #region Image

        private static void ExportWorksheetToBitmap(SfSpreadsheet spreadsheetControl)
        {
            
            IWorksheet sheet = spreadsheetControl.Workbook.ActiveSheet;
            sheet.UsedRangeIncludesFormatting = false;
            int lastRow = sheet.UsedRange.LastRow + 1;
            int lastColumn = sheet.UsedRange.LastColumn + 1;
            System.Drawing.Image img = sheet.ConvertToImage(1, 1, lastRow, lastColumn, ImageType.Bitmap, null);
            img.Save("Sample.png", ImageFormat.Png);
            System.Diagnostics.Process.Start("Sample.png");

        }

        #endregion

        #region HTML

        private static void ExportWorkBookToHTML(SfSpreadsheet spreadsheetControl)
        {           
            spreadsheetControl.Workbook.SaveAsHtml("Sample.html", HtmlSaveOptions.Default);
            System.Diagnostics.Process.Start("Sample.html");
        }
        #endregion

    }
}
