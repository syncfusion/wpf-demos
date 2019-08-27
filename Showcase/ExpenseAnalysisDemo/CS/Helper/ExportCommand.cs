#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.XlsIO;
using System.Windows;
using Syncfusion.UI.Xaml.Grid.Converter;
using System.Windows.Media;
using Microsoft.Win32;
using System.IO;

namespace ExpenseAnalysisDemo
{
    class ExportCommand:ICommand
    {


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var dataGrid = parameter as SfDataGrid;
            if (dataGrid == null) return;
            try
            {
                ExcelEngine excelEngine = dataGrid.ExportCollectionToExcel(dataGrid.View, ExcelVersion.Excel2007, exportingHandler, cellsExportingHandler, true);
                IWorkbook workBook = excelEngine.Excel.Workbooks[0];
                SaveFileDialog sfd = new SaveFileDialog
                {
                    FilterIndex = 1,
                    Filter = "Excel 2007 to 2010 Files(*.xlsx)|*.xlsx|Excel 97 to 2003 Files(*.xls)|*.xls"
                };

                if (sfd.ShowDialog() == true)
                {
                    using (Stream stream = sfd.OpenFile())
                    {
                        if (sfd.FilterIndex == 1)
                            workBook.Version = ExcelVersion.Excel2010;                            
                        else
                            workBook.Version = ExcelVersion.Excel97to2003;
                        workBook.SaveAs(stream);
                    }

                    //Message box confirmation to view the created spreadsheet.
                    if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                                        MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
            catch (Exception)
            {

            }  
        }

        public void exportingHandler(object sender, GridExcelExportingEventArgs args)
        {
            if (args.CellType == ExportCellType.HeaderCell)
            {
                args.CellStyle.BackGroundBrush = new SolidColorBrush(Colors.OrangeRed);
                args.CellStyle.ForeGroundBrush = new SolidColorBrush(Colors.White);
                args.CellStyle.FontInfo.Bold = true;
                args.CellStyle.FontInfo.FontName = "Segoe UI";
            }
        }
        public void cellsExportingHandler(object sender, GridCellExcelExportingEventArgs args)
        {
            if (args.CellType == ExportCellType.RecordCell)
            {
                args.Range.CellStyle.Font.FontName = "Segoe UI";

                if (args.ColumnName == "DateTime")
                {
                    args.Range.Text = Convert.ToDateTime(args.CellValue).ToString(@"MMM dd yyyy");
                    args.Range.HorizontalAlignment = ExcelHAlign.HAlignRight;
                    args.Handled = true;
                }
                else if (args.ColumnName == "Amount")
                {
                    args.Range.Number = (double)args.CellValue;
                    args.Range.CellStyle.NumberFormatIndex = 5;
                    args.Handled = true;
                }
            }
        }
    }    
}
