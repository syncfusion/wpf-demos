#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Syncfusion.UI.Xaml.Grid.Converter;
using System.Windows;
using Microsoft.Win32;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Drawing;
using Syncfusion.Pdf;
using System.Windows.Media.Imaging;

namespace syncfusion.datagriddemos.wpf
{
    public static class ExportToPdfCommands
    {
        static PdfGridCellStyle cellstyle = new PdfGridCellStyle();
        static ExportToPdfCommands()
        {
            cellstyle = new PdfGridCellStyle();
            cellstyle.StringFormat = new PdfStringFormat() { Alignment = PdfTextAlignment.Right };
            var font = new Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular);
            cellstyle.Font = new PdfTrueTypeFont(font, true);
            CommandManager.RegisterClassCommandBinding(typeof(SfDataGrid), new CommandBinding(ExportToPdf, OnExecuteExportToPdf, OnCanExecuteExportToPDF));
        }

        #region ExportToPdf Command

        public static RoutedCommand ExportToPdf = new RoutedCommand("ExportToPdf", typeof(SfDataGrid));

        private static void OnCanExecuteExportToPDF(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        private static void OnExecuteExportToPdf(object sender, ExecutedRoutedEventArgs args)
        {
            var dataGrid = args.Source as SfDataGrid;
            var optionsettings = args.Parameter as PDFExportingOptionsWrapper;
            if (dataGrid == null || optionsettings == null) return;
            try
            {
                var options = new PdfExportingOptions();
                options.CellsExportingEventHandler = GridCellPdfExportingEventhandler;
                options.ExportingEventHandler = GridPdfExportingEventhandler;
                options.PageHeaderFooterEventHandler = PdfHeaderFooterEventHandler;
                var document = dataGrid.ExportToPdf(options);
               
                SaveFile(document);
            }
            catch (Exception)
            {

            }
        }

        public static void SaveFile(PdfDocument document)
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
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
        }         

        #endregion

        #region ExportToPdf Event Handlers

        static void GridPdfExportingEventhandler(object sender, GridPdfExportingEventArgs e)
        {
            if (e.CellType == ExportCellType.HeaderCell)
            {
                e.CellStyle.BackgroundBrush = PdfBrushes.LightSteelBlue;
            }
            else if (e.CellType == ExportCellType.GroupCaptionCell)
            {
                e.CellStyle.BackgroundBrush = PdfBrushes.LightGray;
            }
            else if (e.CellType == ExportCellType.GroupSummaryCell)
            {
                e.CellStyle.BackgroundBrush = PdfBrushes.Azure;
            }
            else if (e.CellType == ExportCellType.TableSummaryCell)
            {
                e.CellStyle.BackgroundBrush = PdfBrushes.LightSlateGray;
                e.CellStyle.TextBrush = PdfBrushes.White;
            }
        }

        static void GridCellPdfExportingEventhandler(object sender, GridCellPdfExportingEventArgs e)
        {
            if ((e.ColumnName == "OrderID" || e.ColumnName == "EmployeeID" || e.ColumnName == "OrderDate" || e.ColumnName == "Freight")
                && e.CellType == ExportCellType.RecordCell)
            {
                e.PdfGridCell.Style = cellstyle;
            }
            e.PdfGridCell.Style.Borders.All = new PdfPen(PdfBrushes.DarkGray, 1.0f);
        }

        static void PdfHeaderFooterEventHandler(object sender, PdfHeaderFooterEventArgs e)
        {
            var width = e.PdfPage.GetClientSize().Width;

            PdfPageTemplateElement header = new PdfPageTemplateElement(width, 38);
            string filePath = "";
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries"))
            {
                filePath = System.IO.Path.GetFullPath(@"..\..\datagrid\Assets\datagrid\Header.jpg");
            }
            else
            {
                filePath = System.IO.Path.GetFullPath(@"..\..\..\datagrid\Assets\datagrid\Header.jpg");
            }
            PdfBitmap bitmapHeader = PdfImage.FromFile(filePath) as PdfBitmap;
            header.Graphics.DrawImage(bitmapHeader, 155, 5, width / 3f, 34);
            e.PdfDocumentTemplate.Top = header;

            PdfPageTemplateElement footer = new PdfPageTemplateElement(width, 30);
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries"))
            {
                filePath = System.IO.Path.GetFullPath(@"..\..\datagrid\Assets\datagrid\Footer.jpg");
            }
            else
            {
                filePath = System.IO.Path.GetFullPath(@"..\..\..\datagrid\Assets\datagrid\Footer.jpg");
            }

            PdfBitmap bitmapFooter = PdfImage.FromFile(filePath) as PdfBitmap;
            footer.Graphics.DrawImage(bitmapFooter, 0, 0);
            e.PdfDocumentTemplate.Bottom = footer;
        }

        #endregion
    }
}
