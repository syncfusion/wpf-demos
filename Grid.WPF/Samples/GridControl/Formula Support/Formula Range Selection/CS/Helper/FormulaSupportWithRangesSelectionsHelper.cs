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
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using Syncfusion.Windows.Controls.Scroll;
using System.Windows.Media;
using Syncfusion.Windows.GridCommon;
using System.Windows.Controls;
using Syncfusion.Windows.Controls.Cells;
using System.Windows.Input;

namespace FormulaRangeSelections
{
    /// <summary>
    /// Supports selecting ranges and cells while editing a formulacell to insert
    /// range references and cell references into the editing formula text. You
    /// can use either the mouse or the keyboard arrow keys to select the range
    /// to be inserted.
    /// </summary>
    public class FormulaSupportWithRangeSelectionsHelper : IDisposable
    {
        GridControl grid;
       
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="grid">The GridControl.</param>
        public FormulaSupportWithRangeSelectionsHelper(GridControl grid)
        {
            this.grid = grid;

            if (this.grid.Parent == null || !(this.grid.Parent is Control))
            {
                throw new Exception("The GridControl.Parent must be set to a non-null Control before you instanciate a FormulaSupportWithRangeSelectionsHelper object.");
            }

            this.grid.Model.TableStyle.CellType = "FormulaCell";
            SizeColumnZero(); //auto sizes row header column width
            this.grid.Model.ColumnWidths.DefaultLineSize = 65;

            this.grid.Model.Options.ExcelLikeSelectionFrame = true;
            this.grid.Model.Options.ExcelLikeCurrentCell = true;

            this.grid.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;

            //used to set header text and align numbers
            this.grid.Model.QueryCellInfo += new GridQueryCellInfoEventHandler(Model_QueryCellInfo);

            //used to autosize row header column
            this.grid.VScrollBar.ValueChanging += new ValueChangingEventHandler(VScrollBar_ValueChanging);

            //used color headers for current cell and formula range selections
            this.grid.PrepareRenderCell += new GridPrepareRenderCellEventHandler(grid_PrepareRenderCell);

            //used to keep current cell headers marked.
            this.grid.SelectionChanged += new GridSelectionChangedEventHandler(grid_SelectionChanged);

            //used to catch keys and mouse before the grid can process them to check whether the RangeSelectionHelper should process them instead of the grid.
            ((Control)this.grid.Parent).PreviewKeyDown += new KeyEventHandler(FormulaSupportWithRangeSelectionsHelper_PreviewKeyDown);
            ((Control)this.grid.Parent).PreviewMouseLeftButtonDown += new MouseButtonEventHandler(FormulaSupportWithRangeSelectionsHelper_PreviewMouseLeftButtonDown);
            ((Control)this.grid.Parent).PreviewMouseMove += new MouseEventHandler(FormulaSupportWithRangeSelectionsHelper_PreviewMouseMove);
            ((Control)this.grid.Parent).PreviewMouseUp += new MouseButtonEventHandler(FormulaSupportWithRangeSelectionsHelper_PreviewMouseUp);
                     
            this.grid.InvalidateCells();
        }

        #region mouse handling code

        private bool inRangeSelection = false;
        bool usingMouse = false;
        private GridRangeInfo selectedRange = GridRangeInfo.Empty;
        private string validPrecedingChars = " (+-*/^&<>=,:";

        void FormulaSupportWithRangeSelectionsHelper_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (inRangeSelection)
            {
                inRangeSelection = false;
                usingMouse = false;
                e.Handled = true;
                TextBox gtb = grid.CurrentCell.Renderer.CurrentCellUIElement as TextBox;
                gtb.Focus();
            }
        }

        void FormulaSupportWithRangeSelectionsHelper_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (inRangeSelection && usingMouse)
            {
                currentCell = grid.PointToCellRowColumnIndex(e);
                int top = 0, bottom = 0, left = 0, right = 0;
                grid.ScrollRows.GetVisibleSection(ScrollAxisRegion.Body, out top, out bottom);
                grid.ScrollColumns.GetVisibleSection(ScrollAxisRegion.Body, out left, out right);
                if (currentCell.RowIndex >= grid.ScrollRows.LastBodyVisibleLineIndex)
                {
                    grid.ScrollRows.ScrollToNextLine();  
                }
                else if (currentCell.RowIndex <= top)
                {
                    grid.ScrollRows.ScrollToPreviousLine();
                }
                if (currentCell.ColumnIndex >= grid.ScrollColumns.LastBodyVisibleLineIndex)
                {
                    grid.ScrollColumns.ScrollToNextLine();
                }
                else if (currentCell.ColumnIndex <= left)
                {
                    grid.ScrollColumns.ScrollToPreviousLine();
                }
                if (currentCell.RowIndex > 0 && currentCell.ColumnIndex > 0 &&
                    (currentCell.ColumnIndex != lastCol || currentCell.RowIndex != lastRow))
                {
                    lastCol = currentCell.ColumnIndex;
                    lastRow = currentCell.RowIndex;
                    GridRangeInfo range = selectedRange;
                    selectedRange = GridRangeInfo.Cell(startRow, startCol).UnionRange(GridRangeInfo.Cell(lastRow, lastCol));
                    PlaceTextInCell(false, selectedRange);
                    grid.InvalidateCell(range.UnionRange(selectedRange));
                    e.Handled = true;
                }
            }
        }
  
        void FormulaSupportWithRangeSelectionsHelper_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (grid.IsMouseOver)
            {
                currentCell = grid.PointToCellRowColumnIndex(new MouseEventArgs(e.MouseDevice, e.Timestamp));
                if (currentCell.RowIndex > 0 && currentCell.ColumnIndex > 0)
                {
                    if (grid.CurrentCell.CellRowColumnIndex != currentCell)
                    {
                        if (grid.CurrentCell.IsEditing)
                        {
                            if (OkToPlaceText())
                            {
                                startRow = currentCell.RowIndex;
                                startCol = currentCell.ColumnIndex;
                                inRangeSelection = true;
                                usingMouse = true;
                                GridRangeInfo range = selectedRange;
                                selectedRange = GridRangeInfo.Cell(startRow, startCol);

                                PlaceTextInCell(false, selectedRange);
                                grid.InvalidateCell(selectedRange.UnionRange(range));
                                e.Handled = true;
                            }
                            else
                            {
                                try
                                {
                                    if (grid.CurrentCell.Renderer.CellModel is GridCellFormulaModel)
                                    {
                                        GridFormulaEngine engine = ((GridCellFormulaModel)grid.CurrentCell.Renderer.CellModel).Engine;

                                        //check for missing right paren
                                        string s = grid.CurrentCell.Renderer.ControlText;
                                        int loc = s.LastIndexOf('(');
                                        if (loc > -1)
                                        {
                                            int loc1 = s.LastIndexOf(')');
                                            if (loc1 < loc || loc1 == -1)
                                            {
                                                grid.CurrentCell.Renderer.ControlText = s + ")";
                                            }
                                        }

                                        string message = "", val = "", parseString = "";
                                        if (!engine.IsFormulaValid(grid.CurrentCell.Renderer.ControlText, out parseString, out message, out val))
                                        {
                                            MessageBox.Show(message);
                                            e.Handled = true;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    e.Handled = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        currentCellModified = grid.CurrentCell.IsEditing;
                    }
                }
            }
        }

        private bool OkToPlaceText()
        {
            bool b = false;
            if (currentCellModified && grid.CurrentCell != null && grid.CurrentCell.Renderer != null)
            {
                TextBox gtb = grid.CurrentCell.Renderer.CurrentCellUIElement as TextBox;
                if (gtb != null)
                {
                    string s = gtb.Text;
                    b = s.StartsWith("=");
                    if (b && gtb.SelectionStart > 0)
                    {
                        b = validPrecedingChars.IndexOf(s[gtb.SelectionStart - 1]) > -1;
                    }
                }
            }
            return b;
        }

        #endregion

        #region keyboard handling code

        void FormulaSupportWithRangeSelectionsHelper_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    HandleEnterAndTab(e);
                    break;
                case Key.Escape:
                    grid.CurrentCell.CancelEdit();
                    grid.CurrentCell.RejectChanges();
                    currentCellModified = false;
                    placeTextDone = false;
                    inRangeSelection = false;
                    placeTextDone = false;
                    currentCell = RowColumnIndex.Empty;
                    e.Handled = true;
                    break;
                case Key.Tab:
                    HandleEnterAndTab(e);
                    break;
                default:
                    {
                        bool isControlKey = (e.KeyboardDevice.Modifiers & ModifierKeys.Control) != ModifierKeys.None;
                        bool isShiftKey = (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) != ModifierKeys.None;
                           
                        if (placeTextDone)
                        {
                             TextBox gtb = grid.CurrentCell.Renderer.CurrentCellUIElement as TextBox;
                            switch (e.Key)
                            {
                                case Key.Down:
                                case Key.Up:
                                case Key.Left:
                                case Key.Right:
                                    ExpandSelection(e.Key, isControlKey, isShiftKey);
                                    usingMouse = false;
                                    e.Handled = true;
                                    grid.Focus();
                                    break;
                                case Key.Back:
                                    if (gtb != null)
                                    {
                                        if (gtb.SelectionLength == 0)
                                        {
                                            gtb.SelectionLength = 1;
                                        }
                                        gtb.SelectedText = "";
                                        e.Handled = true;
                                    }
                                    ClearSelectionAndSetCursor();
                                    break;
                                case Key.Delete:
                                    if (gtb != null)
                                    {
                                        if (gtb.SelectionLength == 0)
                                        {
                                            gtb.SelectionLength = 1;
                                        }
                                        gtb.SelectedText = "";
                                        e.Handled = true;
                                    }
                                    ClearSelectionAndSetCursor();
                                    break;
                                default:
                                    if (e.Key != Key.RightShift && e.Key != Key.LeftShift
                                        && e.Key != Key.LeftCtrl && e.Key != Key.RightCtrl)
                                    {
                                        ClearSelectionAndSetCursor(true);
                                    }
                                    break;
                            }
                        }
                        else if (e.Key != Key.RightShift && e.Key != Key.LeftShift
                            && e.Key != Key.LeftCtrl && e.Key != Key.RightCtrl)
                        {
                            switch (e.Key)
                            {
                                case Key.Down:
                                case Key.Up:
                                case Key.Left:
                                case Key.Right:
                                    if (OkToPlaceText())
                                    {
                                        ExpandSelection(e.Key, isControlKey, isShiftKey);
                                        usingMouse = false;
                                        e.Handled = true;
                                        grid.Focus();
                                    }
                                    break;
                                default:
                                    ClearSelectionAndSetCursor();
                                    currentCellModified = true;
                                    break;
                            }
                        }
                    }
                    break;
            }
        }

        private void HandleEnterAndTab(KeyEventArgs e)
        {
            if (placeTextDone)
            {
                //check for missing right paren
                string s = grid.CurrentCell.Renderer.ControlText;
                int loc = s.LastIndexOf('(');
                if (loc > -1)
                {
                    int loc1 = s.LastIndexOf(')');
                    if (loc1 < loc || loc1 == -1)
                    {
                        grid.CurrentCell.Renderer.ControlText = s + ")";
                    }
                }
            }
            ConfirmChangeAndResetFlags();
            e.Handled = true;
            if (e.Key == Key.Enter)
            {
                grid.CurrentCell.MoveDown();
            }
            else
            {
                bool isShiftKey = (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) != ModifierKeys.None;
                if (isShiftKey)
                {
                    grid.CurrentCell.MoveLeft();
                }
                else
                {
                    grid.CurrentCell.MoveRight();
                }
            }

            grid.InvalidateCells();
        }

        private void ClearSelectionAndSetCursor()
        {
            ClearSelectionAndSetCursor(false);
        }

        private void ClearSelectionAndSetCursor(bool setTextCursorToEndOfSelection)
        {
            TextBox gtb = grid.CurrentCell.Renderer.CurrentCellUIElement as TextBox;
            if (gtb != null)
            {
                if (setTextCursorToEndOfSelection)
                {
                    gtb.SelectionStart += gtb.SelectionLength;
                    gtb.SelectionLength = 0;
                }
                currentCellModified = true;
                GridRangeInfo range = selectedRange;
                selectedRange = GridRangeInfo.Empty;
                grid.InvalidateCell(range);
                gtb.Focus();
            }
        }

        private void ConfirmChangeAndResetFlags()
        {
            inRangeSelection = false;
            currentCellModified = false;
            selectedRange = GridRangeInfo.Empty;
            currentCell = RowColumnIndex.Empty;
            placeTextDone = false;
            grid.Focus();

            grid.CurrentCell.ConfirmChanges();
        }

        #endregion

        #region utility methods to manage the range selection work

        private bool currentCellModified = false;
        RowColumnIndex currentCell = RowColumnIndex.Empty;
        private bool placeTextDone = false;

        int lastRow = 0;
        int lastCol = 0;
        int startRow = 0;
        int startCol = 0;

        private void ExpandSelection(Key key, bool isControlKey, bool isShiftKey)
        {
            GridRangeInfo range = selectedRange;
            int row = range.IsEmpty ? grid.CurrentCell.CellRowColumnIndex.RowIndex : range.Top;
            int col = range.IsEmpty ? grid.CurrentCell.CellRowColumnIndex.ColumnIndex : range.Left;

            if (range.Height <= 1 && range.Width <= 1)
            {
                startRow = row;
                startCol = col;
                lastRow = row;
                lastCol = col;
            }

            if (!isControlKey)
            {
                switch (key)
                {
                    case Key.Down:
                        lastRow++;
                        break;
                    case Key.Up:
                        lastRow--;
                        break;
                    case Key.Left:
                        lastCol--;
                        break;
                    case Key.Right:
                        lastCol++;
                        break;
                    default:
                        break;
                }
            }
            else
            { //// control key goes to end of row/col
                switch (key)
                {
                    case Key.Down:
                        lastRow = grid.Model.RowCount - 1;
                        break;
                    case Key.Up:
                        lastRow = 1;
                        break;
                    case Key.Left:
                        lastCol = 1;
                        break;
                    case Key.Right:
                        lastCol = grid.Model.ColumnCount - 1;
                        break;
                    default:
                        break;
                }
            }
            lastRow = Math.Min(Math.Max(1, lastRow), grid.Model.RowCount - 1);
            lastCol = Math.Min(Math.Max(1, lastCol), grid.Model.ColumnCount - 1);
            if (!isShiftKey)
            {
                startRow = lastRow;
                startCol = lastCol;
            }

            inRangeSelection = true;
            selectedRange = GridRangeInfo.Cell(startRow, startCol).UnionRange(GridRangeInfo.Cell(lastRow, lastCol));
            PlaceTextInCell(false, selectedRange);
           // grid.InvalidateCells();
            grid.InvalidateCell(selectedRange.UnionRange(range));

        }
   
        private void PlaceTextInCell(bool resetSelection, GridRangeInfo activeRange)
        {
            if (activeRange.IsEmpty )
            {
                return;
            }

            string range = GridRangeInfo.GetAlphaLabel(activeRange.Left) + GridRangeInfo.GetNumericLabel(activeRange.Top);
            if (activeRange.Top != activeRange.Bottom || activeRange.Left != activeRange.Right)
            {
                range += ':' + GridRangeInfo.GetAlphaLabel(activeRange.Right) + GridRangeInfo.GetNumericLabel(activeRange.Bottom);
            }

            TextBox gtb = grid.CurrentCell.Renderer.CurrentCellUIElement as TextBox;
            if (gtb != null)
            {

                int start = gtb.SelectionStart;
                gtb.SelectedText = range;
                if (resetSelection)
                {
                    gtb.SelectionStart = start + range.ToString().Length;
                    gtb.SelectionLength = 0;
                }
                else
                {
                    gtb.SelectionStart = start;
                    gtb.SelectionLength = range.ToString().Length;
                }
                placeTextDone = true;
                currentCellModified = true;   
                InvalidateHeaders();
            }
        }

        #endregion

        #region color headers for current cell and formula range selections
        void grid_PrepareRenderCell(object sender, GridPrepareRenderCellEventArgs e)
        {
         
             if (e.Cell.RowIndex == 0 && grid.Model.SelectedRanges.AnyRangeIntersects(GridRangeInfo.Col(e.Cell.ColumnIndex)))
            {
                e.Style.Background = this.excelOrangeColHeader;
            }
            else if (e.Cell.ColumnIndex == 0 && grid.Model.SelectedRanges.AnyRangeIntersects(GridRangeInfo.Row(e.Cell.RowIndex)))
            {
                e.Style.Background = this.excelOrangeRowHeader;
            }
             else if (inRangeSelection && selectedRange.Contains(GridRangeInfo.Cell(e.Cell.RowIndex, e.Cell.ColumnIndex)))
             {
                 e.Style.Background = formulaRangeSelectionBrush;
             }
        }

        void grid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            InvalidateHeaders();
        }

        private void InvalidateHeaders()
        {
            this.grid.InvalidateCell(GridRangeInfo.Row(0));
            this.grid.InvalidateCell(GridRangeInfo.Col(0));
        }

        private Brush excelOrangeColHeader = new LinearGradientBrush(new GradientStopCollection()
        {
            new GradientStop(GridUtil.GetXamlConvertedValue<Color>("#FFC996"),0d),
            new GradientStop(GridUtil.GetXamlConvertedValue<Color>("#FF9B68"),1d),    
        })
        {
            StartPoint = new Point(0.5, 0),
            EndPoint = new Point(0.5, 1)
        };

        private Brush excelOrangeRowHeader = new SolidColorBrush(GridUtil.GetXamlConvertedValue<Color>("#F5C795"));

        private Brush formulaRangeSelectionBrush = new SolidColorBrush(GridUtil.GetXamlConvertedValue<Color>("#F8F5CB"));//#F3B68D"));//#F5E296"));

        #endregion

        #region size row header column
        int charCount = -1;
        void VScrollBar_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            SizeColumnZero();
        }

        private void SizeColumnZero()
        {
            int count = grid.ScrollRows.GetVisibleLines().Count;
            int rowIndex = grid.ScrollRows.GetVisibleLines()[count - 1].LineIndex;
            if (rowIndex.ToString().Length != charCount)
            {
                grid.Model.ResizeColumnsToFit(GridRangeInfo.Cell(rowIndex, 0), GridResizeToFitOptions.IncludeHeaders);
                charCount = rowIndex.ToString().Length;
            }
        }
        #endregion

        #region provide header values and align numbers

        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if (e.Cell.RowIndex == 0 && e.Cell.ColumnIndex > 0)
            {
                e.Style.Text = GridRangeInfo.GetAlphaLabel(e.Cell.ColumnIndex);
                e.Style.HorizontalAlignment = HorizontalAlignment.Center;
                e.Style.VerticalAlignment = VerticalAlignment.Center;
            }
            else if (e.Cell.ColumnIndex == 0 && e.Cell.RowIndex > 0)
            {
                e.Style.Text = e.Cell.RowIndex.ToString();
                e.Style.HorizontalAlignment = HorizontalAlignment.Center;
                e.Style.VerticalAlignment = VerticalAlignment.Center;
            }
            else if (e.Style.CellValueType == typeof(double) ||
                 e.Style.CellValueType == typeof(int) ||
                 e.Style.CellValueType == typeof(float) ||
                 e.Style.CellValueType == typeof(decimal))
            {
                e.Style.HorizontalAlignment = HorizontalAlignment.Right;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.grid.Model.QueryCellInfo -= new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
            this.grid.VScrollBar.ValueChanging -= new ValueChangingEventHandler(VScrollBar_ValueChanging);
            this.grid.PrepareRenderCell -= new GridPrepareRenderCellEventHandler(grid_PrepareRenderCell);
            this.grid.SelectionChanged -= new GridSelectionChangedEventHandler(grid_SelectionChanged);
            ((Control)this.grid.Parent).PreviewKeyDown -= new KeyEventHandler(FormulaSupportWithRangeSelectionsHelper_PreviewKeyDown);
            ((Control)this.grid.Parent).PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(FormulaSupportWithRangeSelectionsHelper_PreviewMouseLeftButtonDown);
            ((Control)this.grid.Parent).PreviewMouseMove -= new MouseEventHandler(FormulaSupportWithRangeSelectionsHelper_PreviewMouseMove);
            ((Control)this.grid.Parent).PreviewMouseUp -= new MouseButtonEventHandler(FormulaSupportWithRangeSelectionsHelper_PreviewMouseUp);
        }

        #endregion
    }

}
