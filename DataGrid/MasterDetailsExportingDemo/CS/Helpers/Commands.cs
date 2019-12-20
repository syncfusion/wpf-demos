#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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

namespace MasterDetailsExportingDemo
{
    public static class Commands
    {
        static Commands()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfDataGrid), new CommandBinding(ExportToExcel, OnExecuteExportToExcel, OnCanExecuteExportToExcel));
        }

        #region ExportToExcel Command

        public static RoutedCommand ExportToExcel = new RoutedCommand("ExportToExcel", typeof(SfDataGrid));

        private static void OnExecuteExportToExcel(object sender, ExecutedRoutedEventArgs args)
        {
            var dataGrid = args.Source as SfDataGrid;
            EccelOptionsConverter ExcelOption = new EccelOptionsConverter();
            if (dataGrid == null) return;
            try
            {
                //Setting the Exporting Options by craeting a instance for ExcelExportingOptions.
                var exportingOptions = args.Parameter as ExcelExportingOptions;
                exportingOptions.ExportingEventHandler = ExportingHandler;
                if (!ExcelOption.isCustomized)
                    exportingOptions.CellsExportingEventHandler = CellExportingHandler;
                else
                    exportingOptions.CellsExportingEventHandler = CustomizeCellExportingHandler;
                exportingOptions.ExportStackedHeaders = true;
                //Below code exports datagrid to excel and returns Excel Engine.
                var excelEngine = dataGrid.ExportToExcel(dataGrid.View, exportingOptions);

                var workBook = excelEngine.Excel.Workbooks[0];
                
                //saving the workbook using savefiledialog.
                SaveFileDialog sfd = new SaveFileDialog
                {
                    FilterIndex = 2,
                    Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx",
                    FileName = "Book1"
                };

                if (sfd.ShowDialog() == true)
                {
                    using (Stream stream = sfd.OpenFile())
                    {
                        if (sfd.FilterIndex == 1)
                            workBook.Version = ExcelVersion.Excel97to2003;
                        else
                            workBook.Version = ExcelVersion.Excel2010;
                        workBook.SaveAs(stream);                        
                    }

                    //Message box confirmation to view the created spreadsheet.
                    if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                                        MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        Open(sfd.FileName);
                    } 
                }                                              
            }
            catch (Exception)
            {

            }
        }
        private static void Open(string fileName)
        {
#if !NETCORE
            System.Diagnostics.Process.Start(fileName);
#else
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd",
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = "/c start " + fileName
            };
            System.Diagnostics.Process.Start(psi);
#endif
        }

        private static void CustomizeCellExportingHandler(object sender, GridCellExcelExportingEventArgs e)
        {
            if (e.ColumnName == "Discount")
            {
                e.Range.CellStyle.ColorIndex = ExcelKnownColors.Violet;
            }
        }

        private static void CellExportingHandler(object sender, GridCellExcelExportingEventArgs e)
        {
            e.Range.CellStyle.Font.Size = 12;
            e.Range.CellStyle.Font.FontName = "Segoe UI";                   
        }

        private static void ExportingHandler(object sender, GridExcelExportingEventArgs e)
        {
            if (e.CellType == ExportCellType.HeaderCell)
            {
                if (e.Level == 0)
                    e.CellStyle.BackGroundBrush = new SolidColorBrush(Color.FromArgb(255, 155, 194, 230));
                else
                    e.CellStyle.BackGroundBrush = new SolidColorBrush(Color.FromArgb(255, 146, 208, 80));

                e.CellStyle.ForeGroundBrush = new SolidColorBrush(Colors.White);
                e.CellStyle.FontInfo.Bold = true;
            }
            
            e.CellStyle.FontInfo.Size = 12;
            e.CellStyle.FontInfo.FontName = "Segoe UI";
            e.Handled = true;
        }

        private static void OnCanExecuteExportToExcel(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        #endregion

    }
}
