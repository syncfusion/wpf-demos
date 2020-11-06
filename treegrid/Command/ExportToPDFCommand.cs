#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.UI.Xaml.TreeGrid.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.treegriddemos.wpf
{
    public static class ExportToPDFCommand
    {
        static ExportToPDFCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfTreeGrid), new CommandBinding(ExportToPDF, OnExecuteExportToPDF, OnCanExecuteExportToPDF));
        }

        #region ExportToExcel Command

        public static RoutedCommand ExportToPDF = new RoutedCommand("ExportToPDF", typeof(SfTreeGrid));

        private static void OnExecuteExportToPDF(object sender, ExecutedRoutedEventArgs args)
        {
            var treeGrid = args.Source as SfTreeGrid;
            var optionsettings = args.Parameter as PDFExportingOptionsWrapper;

            if (treeGrid == null || optionsettings == null) return;
            try
            {
                var options = new TreeGridPdfExportingOptions();

                options.AutoRowHeight = optionsettings.IsAutoRowHeight ? true : false;
                options.AutoColumnWidth = optionsettings.IsAutoColumnWidth ? true : false;
                options.ExportFormat = optionsettings.CanExportFormat ? true : false;
                options.CanExportHyperLink = optionsettings.CanExportLink ? true : false;
                options.RepeatHeaders = optionsettings.CanRepeatHeader ? true : false; 
                options.FitAllColumnsInOnePage = optionsettings.IsFitAllColumns ? true : false;
               
                if (optionsettings.CanCustomizeColumns)
                    options.CellsExportingEventHandler = CellsExportingEventHandler;
                if (optionsettings.CanAddHeaderAndFooter)
                    options.PageHeaderFooterEventHandler = PdfHeaderFooterEventHandler;
                var document = treeGrid.ExportToPdf(options);

                saveFile(document);
            }
            catch (Exception ex)
            {

            }
        }

        private static void saveFile(PdfDocument document)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files(*.pdf)|*.pdf",
                FileName = "document1"
            };

            if (sfd.ShowDialog() == true)
            {
                using (Stream stream = sfd.OpenFile())
                {
                    document.Save(stream);
                }

                //Message box confirmation to view the created Pdf file.
                if (MessageBox.Show("Do you want to view the Pdf file?", "Pdf file has been created",
                                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    //Launching the Pdf file using the default Application.
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(sfd.FileName);
                    info.UseShellExecute = true;
                    System.Diagnostics.Process.Start(info);
                }
            }
        }

        #region ExportToPdf Event Handlers

        private static void OnCanExecuteExportToPDF(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }
        private static void PdfHeaderFooterEventHandler(object sender, TreeGridPdfHeaderFooterEventArgs e)
        {
            var width = e.PdfPage.GetClientSize().Width;
            PdfPageTemplateElement header = new PdfPageTemplateElement(width, 38);
            Assembly assembly = typeof(ExportToPDFCommand).Assembly;
            Stream headerImgStream = assembly.GetManifestResourceStream("syncfusion.treegriddemos.wpf.Assets.treegrid.Header.png");
            PdfImage headerImg = PdfImage.FromStream(headerImgStream) as PdfImage;
            header.Graphics.DrawImage(headerImg, 155, 5, width / 3f, 34); 

            e.PdfDocumentTemplate.Top = header;
            PdfPageTemplateElement footer = new PdfPageTemplateElement(width, 30);
            Stream footerImgStream = assembly.GetManifestResourceStream("syncfusion.treegriddemos.wpf.Assets.treegrid.Footer.png");
            PdfImage footerImg = PdfImage.FromStream(footerImgStream) as PdfImage;
            footer.Graphics.DrawImage(footerImg, 0, 0); 
            e.PdfDocumentTemplate.Bottom = footer;
        }

        static void CellsExportingEventHandler(object sender, TreeGridCellPdfExportingEventArgs e)
        {
            if (e.CellType == TreeGridCellType.RecordCell && e.ColumnName == "Title")
            {
                var cellstyle = new PdfGridCellStyle();
                cellstyle.BackgroundBrush = PdfBrushes.LightGreen;
                e.PdfGridCell.Style = cellstyle;
            }
        }

        #endregion 
       

        #endregion
    }
}
