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
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.XlsIO;
using Syncfusion.Windows.Controls.Grid.Converter;
using ImportingDemo.ViewModel;
using System.Windows.Media;
using System.Windows;
using System.Collections;
using System.Text.RegularExpressions;

namespace ImportingDemo.Behaviors
{
    public class GridCellImportingBehavior : Behavior<GridControl>
    {
        private Brush headerBackgroundBrush;
        public Brush HeaderBackgroundBrush
        {
            get
            {
                if (headerBackgroundBrush == null)
                {
                    LinearGradientBrush brush = new LinearGradientBrush(new GradientStopCollection()
                    {
                        new GradientStop(){ Color = Color.FromArgb(255, 197, 222, 255), Offset = 1d},
                        new GradientStop(){ Color = Color.FromArgb(255, 249, 252, 255) , Offset = 0d}
                    }, 0.0d);
                    brush.StartPoint = new Point(0.5, 0);
                    brush.EndPoint = new Point(0.5, 1);
                    return brush;
                }
                return headerBackgroundBrush;
            }
            set
            {
                headerBackgroundBrush = value;
            }
        }

        protected override void OnAttached()
        {
            this.AssociatedObject.Model.QueryCellInfo += new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
        }

        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            var dataContext = AssociatedObject.DataContext as MainViewModel;
            if (dataContext != null)
            {
                SetExcelLikeUI(e);
                if (e.Cell.RowIndex <= 0 || e.Cell.ColumnIndex <= 0)
                    return;
                GridModel gridModel = sender as GridModel;
                if (!e.Style.IsChanged && e.Style.IsEmpty)
                {
                    int index = dataContext.ActiveTabIndex;
                    IWorksheet sheet = dataContext.Workbook.Worksheets[index];
                    if (sheet != null)
                    {
                        IRange range = sheet.Range;
                        if (e.Cell.RowIndex >= range.Row && e.Cell.ColumnIndex >= range.Column)
                        {
                            IRange rangeToConvert = sheet.Range[e.Cell.RowIndex, e.Cell.ColumnIndex];
                            GridModelImportExtensions.ConvertExcelRangeToVirtualGrid(e.Style, sheet, rangeToConvert, null);
                            if (gridModel != null && e.Style.FormulaTag == null)
                            {
                                string s = e.Style.Text;
                                if (s.Length > 0 && s[0] == '=')
                                {
                                    s = s.Substring(1);
                                    try
                                    {
                                        gridModel.FormulaEngine.FormulaContextCell = GridRangeInfo.GetAlphaLabel(e.Cell.ColumnIndex) + e.Cell.RowIndex.ToString();
                                        e.Style.FormulaTag = new GridFormulaTag(gridModel.FormulaEngine.Parse(s), null, e.Cell.RowIndex, e.Cell.ColumnIndex);
                                        string cellvalue = rangeToConvert.DisplayText; 
                                        e.Style.FormulaTag.Text = cellvalue;
                                    }
                                    catch (Exception ex)
                                    {
                                        e.Style.FormulaTag = new GridFormulaTag(ex.Message, ex.Message, e.Cell.RowIndex, e.Cell.ColumnIndex);
                                    }
                                }
                            }
                            gridModel.Data[e.Cell.RowIndex, e.Cell.ColumnIndex] = e.Style.Store;
                        }
                    }
                }
                else
                {
                    // To save the modified value.
                    int index = dataContext.ActiveTabIndex;
                    IWorksheet changedSheet = dataContext.Workbook.Worksheets[index];
                    if (changedSheet != null)
                    {
                        IRange range = changedSheet.Range[e.Cell.RowIndex, e.Cell.ColumnIndex];
                        SetAlignment(range, e.Style);
                    }
                }
            }
        }

        private void SetExcelLikeUI(GridQueryCellInfoEventArgs e)
        {
            if (e.Style.RowIndex == 0 && e.Style.ColumnIndex == 0)
            {
#if !GraphicCellDomo
                e.Style.Background = new SolidColorBrush(Colors.White);
                e.Style.Font.FontWeight = FontWeights.Bold;
#endif
                return;
            }
            else if (e.Style.RowIndex == 0)
            {
                e.Style.CellValue = GridRangeInfo.GetAlphaLabel(e.Cell.ColumnIndex);
#if !GraphicCellDomo
                e.Style.Background = new SolidColorBrush(Colors.White);
#endif
                e.Style.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                e.Style.VerticalAlignment = VerticalAlignment.Center;
                return;
            }
            else if (e.Style.ColumnIndex == 0)
            {
                e.Style.CellValue = e.Style.RowIndex;
#if !GraphicCellDomo
                e.Style.Background = new SolidColorBrush(Colors.White);
#endif
                e.Style.Foreground = new SolidColorBrush(Colors.Black);
                e.Style.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            }
        }

        private void SetAlignment(IRange range, GridStyleInfo Style)
        {
            string cellvalue = string.Empty;
            int ivalue; double dvalue; bool bvalue;
            if (Style.CellType == "FormulaCell" && !string.IsNullOrEmpty(Style.Text) && Style.Text[0] == '=')
            {
                cellvalue = Style.FormattedText;
            }
            else if (Style.CellValue != null)
            {
                cellvalue = Style.CellValue.ToString();
            }
            if (int.TryParse(cellvalue, out ivalue))
            {
                if (Style.CellValue2 == null || Style.CellValue2.ToString() != "HAlignLeft")
                {
                    Style.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    range.CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;
                }
            }
            else if (double.TryParse(cellvalue, out dvalue))
            {
                if (Style.CellValue2 == null || Style.CellValue2.ToString() != "HAlignLeft")
                {
                    Style.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    range.CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;
                }
            }
            else if (bool.TryParse(cellvalue, out bvalue))
            {
                Style.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                range.CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.QueryCellInfo -= new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
        }
    }
}
