#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Scroll;
using Syncfusion.Windows.Diagnostics;
using Syncfusion.Windows.ComponentModel;
using System.Windows.Interop;
using Syncfusion.Windows.Controls.Grid;
using System.IO;
using System.Windows.Media;

namespace syncfusion.gridcontroldemos.wpf
{
    public delegate void ExcelRangeExtendedEventHandler1(object sender, ExcelRangeExtendedEventArgs1 e);

    class GridExcelMarkerMouseController : IMouseController, IDisposable
    {
        GridControlBase Grid;

        public GridExcelMarkerMouseController(GridControlBase grid)
        {
            this.Grid = grid;
            grid.Model.CellModels.Remove("TextBox");
            grid.Model.CellModels.Add("TextBox", new GridCellModel<MyGridCellTextBoxRenderer1>());
            grid.SelectionChanged += new GridSelectionChangedEventHandler(grid_SelectionChanged);
        }

        void grid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            // Grid.InvalidateCells();
        }

        #region IMouseController Members

        public string Name
        {
            get { return "ExcelMarkerMouseController"; }
        }

        Cursor cursorCross = null;


        public Cursor Cursor
        {
            get
            {
                if (cursorCross == null)
                {
                    try
                    {
                        Type type = typeof(GridExcelMarkerMouseController);
                        Stream stream = type.Module.Assembly.GetManifestResourceStream("syncfusion.gridcontroldemos.wpf.Assets.GridControl.Cross.cur");
                        cursorCross = new Cursor(stream);
                    }
                    catch (System.Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        throw exception;
                    }
                }
                return cursorCross;
            }
        }

        public void MouseHoverEnter(MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void MouseHover(MouseControllerEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void MouseHoverLeave(MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        bool isMouseDown = false;
        GridRangeInfo mouseDownRange = GridRangeInfo.Empty;
        Point mouseDownPoint = new Point(0, 0);
        MovingDirection moveDir = MovingDirection.None;
        public void MouseDown(MouseControllerEventArgs e)
        {
            isMouseDown = true;
            mouseDownRange = Grid.Model.SelectedCells;
            mouseDownPoint = e.Location;
            moveDir = MovingDirection.None;
            flag = 0;
        }
        int flag = 0;
        int top = 0;
        int right = 0;
        int bottom = 0;
        int left = 0;
        public void MouseMove(MouseControllerEventArgs e)
        {
            RowColumnIndex cell = Grid.PointToCellRowColumnIndex(e.Location);
            if (isMouseDown && cell.RowIndex != 0 && cell.ColumnIndex != 0)
            {

                if (cell.RowIndex < Grid.TopRowIndex && Grid.TopRowIndex > Grid.Model.FrozenRows)
                {
                    Grid.TopRowIndex = Grid.TopRowIndex - 1;
                }
                else if (cell.ColumnIndex < Grid.LeftColumnIndex && Grid.LeftColumnIndex > Grid.Model.FrozenColumns)
                {
                    Grid.LeftColumnIndex = Grid.LeftColumnIndex - 1;
                }

                Rect r = Grid.CellSpanToRect(ScrollAxisRegion.Body, ScrollAxisRegion.Body, new CellSpanInfo(cell.RowIndex, cell.ColumnIndex, cell.RowIndex, cell.ColumnIndex));


                if (flag == 0)
                {
                    top = mouseDownRange.Top;
                    bottom = mouseDownRange.Bottom;
                    left = mouseDownRange.Left;
                    right = mouseDownRange.Right;
                    // MessageBox.Show(mouseDownRange.Left.ToString());
                    flag = 1;
                }


                if (mouseDownRange.Top == top && mouseDownRange.Bottom == bottom && mouseDownRange.Right == right && mouseDownRange.Left == left && flag == 1)
                {
                    moveDir = MovingDirection.None;
                    //flag = 0;
                }

                if ((moveDir == MovingDirection.None || moveDir == MovingDirection.Down) &&
                   (cell.RowIndex > mouseDownRange.Bottom || flag == 1) && cell.RowIndex > mouseDownRange.Bottom && e.Location.Y > r.Top + r.Height / 2)
                {
                    moveDir = MovingDirection.Down;
                    Grid.Model.Selections.Clear();
                    Grid.Model.Selections.Add(mouseDownRange.UnionRange(GridRangeInfo.Cell(cell.RowIndex, mouseDownRange.Right)));
                    Grid.ScrollInView(new RowColumnIndex(Math.Min(Grid.Model.RowCount, cell.RowIndex), cell.ColumnIndex));
                }
                else if ((moveDir == MovingDirection.None || moveDir == MovingDirection.Up) &&
                    cell.RowIndex < mouseDownRange.Top && e.Location.Y < r.Top - r.Height / 2)
                {


                    moveDir = MovingDirection.Up;
                    Grid.Model.Selections.Clear();
                    Grid.Model.Selections.Add(mouseDownRange.UnionRange(GridRangeInfo.Cell(cell.RowIndex, mouseDownRange.Right)));
                    Grid.ScrollInView(new RowColumnIndex(Math.Max(Grid.Model.FrozenRows + 1, cell.RowIndex - 1), cell.ColumnIndex));
                }
                else if ((moveDir == MovingDirection.None || moveDir == MovingDirection.Right) &&
                    cell.ColumnIndex > mouseDownRange.Right && e.Location.X > r.Left + r.Width / 2)
                {
                    if (cell.RowIndex >= mouseDownRange.Top && cell.RowIndex <= mouseDownRange.Bottom)
                    {
                        moveDir = MovingDirection.Right;
                        Grid.Model.Selections.Clear();
                        Grid.Model.Selections.Add(mouseDownRange.UnionRange(GridRangeInfo.Cell(cell.RowIndex, cell.ColumnIndex)));
                        Grid.ScrollInView(new RowColumnIndex(cell.RowIndex, Math.Min(Grid.Model.ColumnCount, cell.ColumnIndex + 1)));
                    }
                }
                else if ((moveDir == MovingDirection.None || moveDir == MovingDirection.Left) &&
                    cell.ColumnIndex < mouseDownRange.Left && e.Location.X < r.Left - r.Width / 2)
                {
                    moveDir = MovingDirection.Left;
                    Grid.Model.Selections.Clear();
                    Grid.Model.Selections.Add(mouseDownRange.UnionRange(GridRangeInfo.Cell(mouseDownRange.Top, cell.ColumnIndex)));
                    Grid.ScrollInView(new RowColumnIndex(cell.RowIndex, Math.Max(Grid.Model.FrozenColumns + 1, cell.ColumnIndex - 1)));
                }

                if ((moveDir == MovingDirection.None || moveDir == MovingDirection.Down) &&
                    cell.RowIndex > mouseDownRange.Bottom && e.Location.Y > r.Bottom + r.Height / 2)
                {

                    moveDir = MovingDirection.Down;
                    Grid.Model.Selections.Clear();
                    Grid.Model.Selections.Add(mouseDownRange.UnionRange(GridRangeInfo.Cell(cell.RowIndex, mouseDownRange.Right)));
                    Grid.ScrollInView(new RowColumnIndex(Math.Min(Grid.Model.RowCount, cell.RowIndex + 1), cell.ColumnIndex));
                }
                else if ((moveDir == MovingDirection.None || moveDir == MovingDirection.Up) &&
                    cell.RowIndex < mouseDownRange.Top && e.Location.Y < r.Bottom - r.Height / 2)
                {

                    moveDir = MovingDirection.Up;
                    Grid.Model.Selections.Clear();
                    Grid.Model.Selections.Add(mouseDownRange.UnionRange(GridRangeInfo.Cell(cell.RowIndex, mouseDownRange.Right)));
                    Grid.ScrollInView(new RowColumnIndex(Math.Max(Grid.Model.FrozenRows + 1, cell.RowIndex - 1), cell.ColumnIndex));
                }
                else if ((moveDir == MovingDirection.None || moveDir == MovingDirection.Right) &&
                    cell.ColumnIndex > mouseDownRange.Right && e.Location.X > r.Right + r.Width / 2)
                {

                    moveDir = MovingDirection.Right;
                    Grid.Model.Selections.Clear();
                    Grid.Model.Selections.Add(mouseDownRange.UnionRange(GridRangeInfo.Cell(cell.RowIndex, cell.ColumnIndex)));
                    Grid.ScrollInView(new RowColumnIndex(cell.RowIndex, Math.Min(Grid.Model.ColumnCount, cell.ColumnIndex + 1)));

                }
                else if ((moveDir == MovingDirection.None || moveDir == MovingDirection.Left) &&
                    cell.ColumnIndex < mouseDownRange.Left && e.Location.X < r.Right - r.Width / 2)
                {
                    if (cell.RowIndex >= mouseDownRange.Top && cell.RowIndex <= mouseDownRange.Bottom)
                    {
                        moveDir = MovingDirection.Left;
                        Grid.Model.Selections.Clear();
                        Grid.Model.Selections.Add(mouseDownRange.UnionRange(GridRangeInfo.Cell(cell.RowIndex, cell.ColumnIndex)));
                        Grid.ScrollInView(new RowColumnIndex(cell.RowIndex, Math.Max(Grid.Model.FrozenColumns + 1, cell.ColumnIndex - 1)));
                    }
                }
            }
        }

        enum MovingDirection
        {
            None,
            Left,
            Down,
            Right,
            Up
        }

        public event ExcelRangeExtendedEventHandler1 ExcelRangeExtended;

        public void MouseUp(MouseControllerEventArgs e)
        {
            //throw new NotImplementedException();
            if (mouseDownRange != Grid.Model.SelectedCells && ExcelRangeExtended != null)
            {
                ExcelRangeExtendedEventArgs1 arg = new ExcelRangeExtendedEventArgs1(mouseDownRange, Grid.Model.SelectedCells);
                ExcelRangeExtended(Grid, arg);
            }
        }

        public void CancelMode()
        {
            //throw new NotImplementedException();
        }

        public void RestoreMode()
        {
            //throw new NotImplementedException();
        }

        private bool IsNotNested(VisibleLineInfo dragLine)
        {
            var lineSizeCollection = this.Grid.Model.RowHeights as LineSizeCollection;
            var result = lineSizeCollection.GetNestedLines(dragLine.LineIndex) != null;
            return result;
        }

        double hitTestPrecision = 4;
        private VisibleLineInfo HitRowTest(Point point)
        {
            return Grid.ScrollRows.GetLineNearCorner(point.Y, hitTestPrecision);

        }

        private VisibleLineInfo HitColTest(Point point)
        {
            return Grid.ScrollColumns.GetLineNearCorner(point.X, hitTestPrecision);

        }

        public int HitTest(MouseControllerEventArgs mouseEventArgs, IMouseController controller)
        {
            Point point = mouseEventArgs.Location;

            GridRangeInfo range = Grid.Model.SelectedCells;
            if (range == null || range.IsEmpty)
            {
                return 0;
            }

            RowColumnIndex pos = Grid.PointToCellRowColumnIndex(point, true);
            VisibleLineInfo hitRow = HitRowTest(point);
            if (hitRow != null && !this.IsNotNested(hitRow) && range.Bottom == hitRow.LineIndex)
            {
                VisibleLineInfo column = HitColTest(point);//Grid.ScrollColumns.GetVisibleLineAtPoint(point.X);

                if (column != null && range.Right == column.LineIndex)
                {
                    //  Grid.InvalidateCells();
                    return 1;
                }
            }
            return 0;
        }


        public bool SupportsCancelMouseCapture
        {
            get { return false; }// throw new NotImplementedException(); }
        }

        public bool SupportsMouseTracking
        {
            get { return false; }// throw new NotImplementedException(); }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        #endregion
    }

    public class ExcelRangeExtendedEventArgs1 : EventArgs
    {
        public ExcelRangeExtendedEventArgs1(GridRangeInfo originalRange, GridRangeInfo newRange)
        {
            this.originalRange = originalRange;
            this.newRange = newRange;
        }
        GridRangeInfo originalRange;

        public GridRangeInfo OriginalRange
        {
            get { return originalRange; }
            set { originalRange = value; }
        }

        GridRangeInfo newRange;

        public GridRangeInfo NewRange
        {
            get { return newRange; }
            set { newRange = value; }
        }
    }

    public class MyGridCellTextBoxRenderer1 : GridCellTextBoxRenderer
    {
        protected override void OnRender(System.Windows.Media.DrawingContext dc, RenderCellArgs rca, GridRenderStyleInfo style)
        {
            base.OnRender(dc, rca, style);
            GridRangeInfo range = GridControl.Model.SelectedCells;
            if (range.Bottom == rca.RowIndex && range.Right == rca.ColumnIndex)
            {
                Rect r = rca.CellRect;
                r.X = r.Right - 2;
                r.Width = 4;
                r.Y = r.Bottom - 2;
                r.Height = 4;
                dc.DrawRectangle(Brushes.Black, null, r);
            }
        }
    }
}

