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
using Syncfusion.XlsIO;
using System.Windows;
using Microsoft.Win32;

namespace syncfusion.datagriddemos.wpf
{
    public static class ExportSelectedCommand
    {
        static ExportSelectedCommand()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfDataGrid), new CommandBinding(ExportToExcel, OnExecuteExportToExcel, OnCanExecuteExportToExcel));
        }

        public static RoutedCommand ExportToExcel = new RoutedCommand("ExportToExcel", typeof(SfDataGrid));

        private static void OnExecuteExportToExcel(object sender, ExecutedRoutedEventArgs args)
        {
            var dataGrid = args.Source as SfDataGrid;
            var optionsettings = args.Parameter as ExcelExportingOptionsWrapper;
            if (dataGrid == null || optionsettings == null)
                return;

            var options = new ExcelExportingOptions();
            options.ExcelVersion = ExcelVersion.Excel2010;
            if (!optionsettings.CanCustomizeStyle)
               options.ExportingEventHandler = ExportingHandler;
            else
               options.ExportingEventHandler = CustomizeExportingHandler;

            options.CellsExportingEventHandler = CellExportingHandler;
            
            ExcelEngine excelEngine = new ExcelEngine();
            IWorkbook workBook = excelEngine.Excel.Workbooks.Create();
            workBook.Worksheets.Create();

            dataGrid.ExportToExcel(dataGrid.SelectedItems, options, workBook.Worksheets[0]);
            ExcelExportCommand.SaveFile(workBook);
        }

        private static void CustomizeExportingHandler(object sender, GridExcelExportingEventArgs e)
        {
            if (e.CellType == ExportCellType.RecordCell)
            {
                e.CellStyle.BackGroundBrush = new SolidColorBrush(Colors.Violet);
                e.Handled = true;
            }
        }

        private static void CellExportingHandler(object sender, GridCellExcelExportingEventArgs e)
        {
            e.Range.CellStyle.Font.Size = 12;
            e.Range.CellStyle.Font.FontName = "Segoe UI";

            if (e.ColumnName == "UnitPrice" || e.ColumnName == "Quantity")
            {
                double value = 0;
                if (double.TryParse(e.CellValue.ToString(), out value))
                {
                    e.Range.Number = value;
                }
                e.Handled = true;
            }
        }

        private static void ExportingHandler(object sender, GridExcelExportingEventArgs e)
        {
            if (e.CellType == ExportCellType.HeaderCell)
            {
                e.CellStyle.BackGroundBrush = new SolidColorBrush(Colors.LightSteelBlue);
                e.CellStyle.ForeGroundBrush = new SolidColorBrush(Colors.DarkRed);
                e.CellStyle.FontInfo.Bold = true;
            }
            e.CellStyle.FontInfo.Size = 12;
            e.CellStyle.FontInfo.FontName = "Segoe UI";
            e.Handled = true;
        }

        private static void OnCanExecuteExportToExcel(object sender, CanExecuteRoutedEventArgs args)
        {
            var grid = args.Source as SfDataGrid;
            if (grid.SelectedItems != null && grid.SelectedItems.Any())
                args.CanExecute = true;
            else
                args.CanExecute = false;
        }
    }
}
