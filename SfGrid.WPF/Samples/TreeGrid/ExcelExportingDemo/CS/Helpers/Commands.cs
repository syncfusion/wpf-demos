using Microsoft.Win32;
using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.UI.Xaml.TreeGrid.Converter;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ExcelExportingDemo
{
    public static class Commands
    {
        static Commands()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfTreeGrid), new CommandBinding(ExportToExcel, OnExecuteExportToExcel, OnCanExecuteExportToExcel));
        }

        #region ExportToExcel Command

        public static RoutedCommand ExportToExcel = new RoutedCommand("ExportToExcel", typeof(SfTreeGrid));

        private static void OnExecuteExportToExcel(object sender, ExecutedRoutedEventArgs args)
        {
            ExcelOptionsConverter excelOptions = new ExcelOptionsConverter();
            var treeGrid = args.Source as SfTreeGrid;        
            if (treeGrid == null) return;
            try
            {
                ExcelEngine excelEngine = null;          
                var options = args.Parameter as TreeGridExcelExportingOptions;
                options.ExcelVersion = ExcelVersion.Excel2013;
                options.ExportingEventHandler = ExportingHandler;             
                if(excelOptions.IsCutomized)
                    options.CellsExportingEventHandler = CustomizeCellExportingHandler;
                else
                    options.CellsExportingEventHandler = CellExportingHandler;
                excelEngine = new ExcelEngine();
                IWorkbook workBook = excelEngine.Excel.Workbooks.Create();
                treeGrid.ExportToExcel(workBook, options);
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
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        #region ExportingExcelEventHandler
        private static void CustomizeCellExportingHandler(object sender, TreeGridCellExcelExportingEventArgs e)
        {
            if (e.CellType == TreeGridCellType.RecordCell && e.ColumnName == "Salary")
                e.Range.CellStyle.ColorIndex = ExcelKnownColors.Sky_blue;
        }
        private static void CellExportingHandler(object sender, TreeGridCellExcelExportingEventArgs e)
        {
            if (e.CellType == TreeGridCellType.RecordCell && e.ColumnName == "Title")
                e.Range.CellStyle.Font.FontName = "Segoe UI";
        }
        private static void ExportingHandler(object sender, TreeGridExcelExportingEventArgs e)
        {
            if (e.CellType == TreeGridCellType.HeaderCell)
            {
                e.Style.ColorIndex = ExcelKnownColors.Light_yellow;
                e.Style.Font.Color = ExcelKnownColors.Dark_red;
                e.Style.Font.Bold = true;
                e.Style.Font.Size = 12;
                e.Style.Font.FontName = "Segoe UI";
                e.Handled = true;
            }

            else if (e.CellType == TreeGridCellType.RecordCell)
            {
                e.Style.Font.Color = ExcelKnownColors.Dark_red;
                e.Handled = true;
            }
        }

        #endregion

        private static void OnCanExecuteExportToExcel(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        #endregion

    }
}
