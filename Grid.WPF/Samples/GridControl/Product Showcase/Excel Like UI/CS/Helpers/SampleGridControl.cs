#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;

namespace EXCEL.Helpers
{
    public class SampleGridControl : GridControl
    {
        public SampleGridControl()
        {
            RowHeights.DefaultLineSize = 20;
            RowHeights.LineCount = 65535;
            ColumnWidths.DefaultLineSize = 65;
            ColumnWidths.LineCount = 100;
            Model.TableStyle.CellType = "FormulaCell";
            Model.TableStyle.Borders = new CellBordersInfo()
            {
                All = new Pen(Brushes.Gray, 0.15d)
            };
            Model.ColumnWidths[0] = 35d;
            Model.Options.ExcelLikeSelectionFrame = true;
            Model.Options.ExcelLikeCurrentCell = true;
            Model.TableStyle.VerticalAlignment = VerticalAlignment.Bottom;
            // Model.TableStyle.BorderMargins.Bottom = 2;
            Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
            Model.ActiveGridView.PreviewKeyDown += ActiveGridView_PreviewKeyDown;
        }

        void ActiveGridView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && CurrentCell != null && CurrentCell.HasCurrentCell )
            {
                foreach (GridRangeInfo SelectedRange in this.Model.SelectedRanges)
                {
                    GridRangeInfo ExpandedRange = ExpandSelectedCellsRange(SelectedRange);
                    for (int row = ExpandedRange.Top; row <= ExpandedRange.Bottom; row++)
                    {
                        for (int col = ExpandedRange.Left; col <= ExpandedRange.Right; col++)
                        {
                            var style = this.Model[row, col];
                            if (!style.ReadOnly && style.Enabled)
                                style.ResetCellValue();
                        }
                    }                 
                }
                Model.ActiveGridView.InvalidateCells();
            }
        }
        protected override void OnPrepareRenderCell(GridPrepareRenderCellEventArgs e)
        {
            base.OnPrepareRenderCell(e);
            if (e.Cell.RowIndex == 0 && Model.SelectedRanges.AnyRangeIntersects(GridRangeInfo.Col(e.Cell.ColumnIndex)))
            {
                e.Style.Background = Brushes.LightGray;
                e.Style.Font.FontWeight = FontWeights.Bold;
            }
            else if (e.Cell.ColumnIndex == 0 && Model.SelectedRanges.AnyRangeIntersects(GridRangeInfo.Row(e.Cell.RowIndex)))
            {
                e.Style.Background = Brushes.LightGray;
                e.Style.Font.FontWeight = FontWeights.Bold;
            }
        }

        private Brush excelOrange = new LinearGradientBrush(new GradientStopCollection()
        {
            new GradientStop(GridUtil.GetXamlConvertedValue<Color>("#F7D594"),0.085d),
            new GradientStop(GridUtil.GetXamlConvertedValue<Color>("#F5CD7F"),0.317d),
            new GradientStop(GridUtil.GetXamlConvertedValue<Color>("#F1C263"),0.732d),
        })
        {
            StartPoint = new Point(0.5, 0),
            EndPoint = new Point(0.5, 1)
        };


        protected override void OnSelectionChanged(GridSelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            if (e.Reason == GridSelectionReason.MouseDown || e.Reason == GridSelectionReason.SetCurrentCell || e.Reason == GridSelectionReason.MouseMove || e.Reason == GridSelectionReason.SelectRange || e.Reason == GridSelectionReason.MouseUp)
            {
                this.InvalidateCell(GridRangeInfo.Row(0));
                this.InvalidateCell(GridRangeInfo.Col(0));
                GridRangeInfo range = e.Range;
                if (e.Range.IsCols)
                {
                    range = GetExpandedRange(range);
                }
                if (e.Range.IsRows)
                {
                    range = GetExpandedRange(range);
                }
                if (e.Range.IsTable)
                {
                    range = GetExpandedRange(range);
                }

                if (e.Range == null || e.Range.IsEmpty)
                {
                    CellLocationText = "";
                }
                else if ((e.Range.Height == 1 && e.Range.Width == 1) || e.Reason == GridSelectionReason.MouseUp)
                {
                    CellLocationText = string.Format("{0}{1}", GridRangeInfo.GetAlphaLabel(range.Left), range.Top);
                }
                else
                {
                    CellLocationText = string.Format("{0}R x {1}C", range.Height, range.Width);
                }
            }
        }
        
        private GridRangeInfo GetExpandedRange(GridRangeInfo range)
        {

            if (range.IsCols)
            {
                range = range.ExpandRange(range.Top + 1, range.Left, Model.RowCount, range.Left);
            }

            if (range.IsRows)
            {
                range = range.ExpandRange(range.Top, range.Left + 1, range.Top, Model.ColumnCount);
            }

            if (range.IsTable)
            {
                range = range.ExpandRange(range.Top + 1, range.Left + 1,Model.RowCount, Model.ColumnCount);
            }
                return range;
        }

        protected override void OnQueryCellInfo(GridQueryCellInfoEventArgs e)
        {
            base.OnQueryCellInfo(e);
            if (e.Style.RowIndex == 0 && e.Style.ColumnIndex == 0)
            {
                e.Style.Background = new SolidColorBrush(Colors.White);
                return;
            }
            else if (e.Style.RowIndex == 0)
            {
                e.Style.CellValue = GridRangeInfo.GetAlphaLabel(e.Cell.ColumnIndex);
                e.Style.Background = new SolidColorBrush(Colors.White);
                e.Style.Foreground = Brushes.Black;
                e.Style.HorizontalAlignment = HorizontalAlignment.Center;
                e.Style.VerticalAlignment = VerticalAlignment.Center;

            }
            else if (e.Style.ColumnIndex == 0)
            {
                e.Style.CellValue = e.Style.RowIndex;
                e.Style.Background = new SolidColorBrush(Colors.White);
                e.Style.Foreground = Brushes.Black;
                e.Style.HorizontalAlignment = HorizontalAlignment.Center;
            }
        }

        public void ApplyStyle(GridStyleInfo style, GridRangeInfoList ranges)
        {
            GridCurrentCell cc = this.CurrentCell;
            foreach (GridRangeInfo range in ranges)
            {
                GridRangeInfo cellRange = range.ExpandRange(1, 1, Model.RowCount, Model.ColumnCount);
                int row, col;
                if (cellRange.GetFirstCell(out row, out col))
                {
                    ModifyFontsAndOtherStyleProperties(style, Model[row, col]);

                    while (cellRange.GetNextCell(ref row, ref col))
                    {
                        ModifyFontsAndOtherStyleProperties(style, Model[row, col]);
                    }
                    Model.ResizeRowsToFit(range, GridResizeToFitOptions.NoShrinkSize);
                }
            }
            InvalidateCells();
        }

        private void ModifyFontsAndOtherStyleProperties(GridStyleInfo sourceStyle1, GridStyleInfo targetStyle)
        {
            GridStyleInfo sourceStyle = new GridStyleInfo();
            sourceStyle.CopyFrom(sourceStyle1);
            
            GridFontInfo sourceStyleFont = sourceStyle.GetValue(GridStyleInfoStore.FontProperty) as GridFontInfo;
            GridFontInfo targetStyleFont = targetStyle.GetValue(GridStyleInfoStore.FontProperty) as GridFontInfo;
            if (sourceStyleFont.HasFontFamily)
            {
                targetStyleFont.FontFamily = sourceStyleFont.FontFamily;
            }
            if (sourceStyleFont.HasFontSize)
            {
                targetStyleFont.FontSize = sourceStyleFont.FontSize;
            }
            if (sourceStyleFont.HasFontStretch)
            {
                targetStyleFont.FontStretch = sourceStyleFont.FontStretch;
            }
            if (sourceStyleFont.HasFontStyle)
            {
                targetStyleFont.FontStyle = sourceStyleFont.FontStyle;
            }
            if (sourceStyleFont.HasFontWeight)
            {
                targetStyleFont.FontWeight = sourceStyleFont.FontWeight;
            }
            sourceStyle.ResetFont();
            targetStyle.ModifyStyle(sourceStyle, Syncfusion.Windows.Styles.StyleModifyType.Override);
        }

        public GridStyleInfo GetStyle(GridRangeInfoList ranges)
        {
            //right now will just get the style of top-left cell
            //eventually, need to get composite style for ranges.

            int row = -1, col = -1;
            if (ranges.ActiveRange != null &&
                ranges.ActiveRange.GetFirstCell(out row, out col))
                return Model[row, col];
            return null;
        }

        private string cellLocationText;

        public event EventHandler CellLocationTextChanged;
        public string CellLocationText
        {
            get { return cellLocationText; }
            set
            {
                cellLocationText = value;
                if (CellLocationTextChanged != null)
                    CellLocationTextChanged(this, EventArgs.Empty);
            }
        }

        public Brush HeaderBackgroundBrush
        {
            get
            {
                LinearGradientBrush brush = new LinearGradientBrush(new GradientStopCollection()
                {
                    new GradientStop(GridUtil.GetXamlConvertedValue<Color>("#FFE0EDFF"),0d),
                    new GradientStop(GridUtil.GetXamlConvertedValue<Color>("#FFC0DBFF"),1d),
                    new GradientStop(GridUtil.GetXamlConvertedValue<Color>("#FFC4DDFF"),0.518d),
                    new GradientStop(GridUtil.GetXamlConvertedValue<Color>("#FFAED1FF"),0.522d),
                });
                brush.StartPoint = new Point(0.5, 0);
                brush.EndPoint = new Point(0.5, 1);
                return brush;
            }
        }
    }
}