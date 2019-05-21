#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace ExcelExport
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using ExcelExport.ViewModel;
    using Syncfusion.Windows.Controls.Grid;
    using Syncfusion.Windows.Controls.Grid.Converter;
    using Syncfusion.Windows.GridCommon;
    using Syncfusion.XlsIO;
    using Syncfusion.Windows.Shared;

    //using Syncfusion
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow, IMainView
    {
        public Window1()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(this);
        }

        public void Initialize()
        {
            gridControl.Model.RowCount = 30;
            gridControl.Model.ColumnCount = 25;
            gridControl.Model.RowHeights[1] = 50;
            gridControl.Model.ColumnWidths[2] = 100;
            gridControl.Model.CoveredCells.Add(new Syncfusion.Windows.Controls.Cells.CoveredCellInfo(4, 4, 6, 6));
            gridControl.Model.CoveredCells.Add(new Syncfusion.Windows.Controls.Cells.CoveredCellInfo(8, 10, 12, 12));
            gridControl.Model.ColumnWidths[7] = 100;
            gridControl.Model.ColumnWidths[8] = 100;
        }

        public void FillData()
        {
            Random r = new Random();
            for (int row = 1; row < 30; row++)
            {
                for (int col = 1; col < 25; col++)
                {
                    if (col > 7)
                    {
                        continue;
                    }

                    if (r.Next(1, 4) == 2)
                    {
                        gridControl.Model[row, col].CellValue = r.Next(10, 100);
                    }
                    else if (r.Next(1, 4) == 3)
                    {
                        gridControl.Model[row, col].CellValue = "Text" + r.Next(10, 100).ToString();
                    }
                    else
                    {
                        gridControl.Model[row, col].CellValue = (r.Next(1000, 10000) * .01);
                    }

                    if (r.Next(10, 14) == 12)
                    {
                        gridControl.Model[row, col].Font.FontStyle = FontStyles.Italic;
                        gridControl.Model[row, col].Font.FontWeight = FontWeights.Bold;
                        gridControl.Model[row, col].Font.FontSize = 13;
                    }

                    if (r.Next(10, 14) == 11)
                    {
                        gridControl.Model[row, col].Borders.Bottom = new Pen(Brushes.Blue, 3);
                        gridControl.Model[row, col].Borders.Top = new Pen(Brushes.Pink, 3);
                        gridControl.Model[row, col].Borders.Right = new Pen(Brushes.Salmon, 3);
                        gridControl.Model[row, col].Borders.Left = new Pen(Brushes.SpringGreen, 3);
                    }

                    if (r.Next(10, 14) == 13)
                    {
                        gridControl.Model[row, col].Background = Brushes.Orange;
                        gridControl.Model[row, col].Foreground = Brushes.Blue;
                    }

                    if (r.Next(10, 14) == 13)
                    {
                        gridControl.Model[row, col].HorizontalAlignment = HorizontalAlignment.Right;
                        // gridControl.Model[row, col].VerticalAlignment = VerticalAlignment.Top;
                    }
                }
            }

            for (int row = 1; row <= gridControl.Model.RowCount; row++)
            {
                gridControl.Model[row, 7].CellType = "DateTimeEdit";
                gridControl.Model[row, 7].CellValue = DateTime.Now;
            }

            for (int row = 1; row <= gridControl.Model.RowCount; row++)
            {
                gridControl.Model[row, 8].CellType = "CurrencyEdit";
                gridControl.Model[row, 8].CellValue = "1010154";
                gridControl.Model[row, 8].NumberFormat = new System.Globalization.NumberFormatInfo();
                gridControl.Model[row, 8].NumberFormat.CurrencySymbol = "$";
            }
        }

        public void ExportFullRange()
        {
            try
            {
                gridControl.Model.ExportToExcel(@"Sample.xls", ExcelVersion.Excel97to2003);
                System.Diagnostics.Process.Start(@"Sample.xls");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void ExportSelectedRange()
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            IWorkbook workbook = excelEngine.Excel.Workbooks.Add();
            workbook.Version = ExcelVersion.Excel2007;
            IWorksheet workSheet = workbook.Worksheets[0];

            GridRangeInfoList rangeList = gridControl.Model.SelectedRanges;

            if (rangeList.Count > 0)
            {
                GridRangeInfo range = rangeList[0];
                gridControl.Model.ExportToExcel(range, excelEngine, 0, workSheet.Range[1, 1]);
                try
                {
                    workbook.SaveAs("Sample.xlsx");
                    excelEngine.ThrowNotSavedOnDestroy = false;
                    excelEngine.Dispose();
                    System.Diagnostics.Process.Start("Sample.xlsx");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Select the range first");
            }
        }

        public void ExportWithChart()
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            IWorkbook workbook = excelEngine.Excel.Workbooks.Add();
            workbook.Version = ExcelVersion.Excel97to2003;
            IWorksheet workSheet = workbook.Worksheets[0];
            IChart chartShape = workSheet.Charts.Add();
            IChartSerie series1 = chartShape.Series.Add();
            series1.SerieType = ExcelChartType.Column_Clustered;
            chartShape.ChartTitle = "Column_Clustered";
            series1.Values = workSheet.Range["B1:B5"];
            series1.CategoryLabels = workSheet.Range["A1:A5"];
            Random r = new Random();
            for (int i = 1; i <= 4; i++)
            {
                workSheet.Range[i, 1].Number = i;
                workSheet.Range[i, 2].Number = r.Next(4000, 6000);
            }
            for (int i = 1; i <= 4; i++)
            {
                workSheet.Range[i + 5, 1].Number = i;
                workSheet.Range[i + 5, 2].Number = r.Next(4000, 6000);
            }
            gridControl.CurrentCell.EndEdit();
            IRange excelRange = workSheet.Range[21, 5];
            GridRangeInfoList rangeList = gridControl.Model.SelectedRanges;

            if (rangeList.Count > 0)
            {
                GridRangeInfo range = rangeList[0];
                gridControl.Model.ExportToExcel(range, workSheet, excelRange);
                try
                {
                    workbook.SaveAs("Sample.xls");
                    excelEngine.ThrowNotSavedOnDestroy = false;
                    excelEngine.Dispose();
                    System.Diagnostics.Process.Start("Sample.xls");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
            else
            {
                MessageBox.Show("Select the range first");
            }
        }

        public void ExportUsingEngine()
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            IWorkbook workbook = excelEngine.Excel.Workbooks.Add();
            workbook.Version = ExcelVersion.Excel2007;
            IWorksheet workSheet = workbook.Worksheets[0];
            GridRangeInfoList rangeList = gridControl.Model.SelectedRanges;

            if (rangeList.Count > 0)
            {
                GridRangeInfo range = rangeList[0];
                gridControl.Model.ExportToExcel(range, excelEngine, 0, workSheet.Range[21, 5]);
                try
                {
                    workbook.SaveAs("Sample.xlsx");
                    excelEngine.ThrowNotSavedOnDestroy = false;
                    excelEngine.Dispose();
                    System.Diagnostics.Process.Start("Sample.xlsx");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Select the range first");
            }
        }
    }
}