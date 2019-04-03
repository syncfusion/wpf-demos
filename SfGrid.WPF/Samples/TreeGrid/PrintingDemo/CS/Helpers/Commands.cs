#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Parsing;
using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.UI.Xaml.TreeGrid.Converter;
using Syncfusion.Windows.PdfViewer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PrintingDemo
{
    public static class Commands
    {
        static Commands()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfTreeGrid), new CommandBinding(PrintTreeGrid, OnExecutePrintTreeGrid));
        }

        #region ExportToExcel Command

        public static RoutedCommand PrintTreeGrid = new RoutedCommand("PrintTreeGrid", typeof(SfTreeGrid));

        private static void OnExecutePrintTreeGrid(object sender, ExecutedRoutedEventArgs args)
        {
            var treeGrid = args.Source as SfTreeGrid;
            if (treeGrid == null) return;
            try
            {
                var options = new TreeGridPdfExportingOptions();
                options.AllowIndentColumn = true;
                options.FitAllColumnsInOnePage = true;

                var document = treeGrid.ExportToPdf(options);

                PdfViewerControl pdfViewer = new PdfViewerControl();
                MemoryStream stream = new MemoryStream();
                document.Save(stream);
                PdfLoadedDocument ldoc = new PdfLoadedDocument(stream);
                pdfViewer.Load(ldoc);
                // if you want to  show the pdf viewer window. Please enable the below line,
                //MainWindow pdfPage = new MainWindow();
                //pdfPage.Content = pdfViewer;
                //pdfPage.Show();
                pdfViewer.Print(true);

            }
            catch (Exception)
            {

            }
        }

        #endregion

    }
}
