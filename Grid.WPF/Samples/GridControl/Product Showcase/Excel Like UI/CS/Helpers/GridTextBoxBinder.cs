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
using System.Windows.Controls;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace EXCEL.Helpers
{
    public class GridTextBoxBinder : IDisposable
    {
        public GridTextBoxBinder()
        {

        }

        private List<GridControlBase> grids = null;
        private TextBox formulaBox = null;
        private GridControlBase lastGridWithFocus = null;

        public TextBox FormulaBox
        {
            get { return formulaBox; }
         }

        public List<GridControlBase> Grids
        {
            get 
            {
                if (grids == null)
                {
                    grids = new List<GridControlBase>();
                }
                return grids; 
            }
        }

        public void Wire(GridControlBase grid, TextBox tb)
        {
            Unwire();
            Hook(grid);
            HookTextBox(tb);
        }

        public void Wire(IEnumerable<GridControlBase> grids, TextBox tb)
        {
            Unwire();
            foreach (GridControlBase grid in grids)
            {
                Hook(grid);
            }
            HookTextBox(tb);
        }
        public void Unwire()
        {
            GridControlBase[] allGrids = new GridControlBase[Grids.Count];
            allGrids = Grids.ToArray();
            foreach(GridControlBase grid in allGrids)
            {
                Unhook(grid);
            }
            UnhookTextBox();
        }

        private void HookTextBox(TextBox tb)
        {
            this.formulaBox = tb;
            this.formulaBox.AcceptsReturn = false;
            tb.GotFocus += new RoutedEventHandler(tb_GotFocus);
            tb.LostFocus += new RoutedEventHandler(tb_LostFocus);
            tb.TextChanged += new TextChangedEventHandler(tb_TextChanged);
            tb.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(tb_PreviewKeyDown);
        }
        
        private void Hook(GridControlBase grid)
        {
            if (!Grids.Contains(grid))
            {
                Grids.Add(grid);
                 grid.CurrentCellChanged += new GridRoutedEventHandler(grid_CurrentCellChanged);
                 grid.CurrentCellMoved += new GridCurrentCellMovedEventHandler(grid_CurrentCellMoved);
                 grid.IsVisibleChanged += new DependencyPropertyChangedEventHandler(grid_IsVisibleChanged);
             }
        }

        private void UnhookTextBox()
        {
            if (FormulaBox != null)
            {
                FormulaBox.GotFocus -= new RoutedEventHandler(tb_GotFocus);
                FormulaBox.LostFocus -= new RoutedEventHandler(tb_LostFocus);
                FormulaBox.TextChanged -= new TextChangedEventHandler(tb_TextChanged);
                FormulaBox.PreviewKeyDown -= new System.Windows.Input.KeyEventHandler(tb_PreviewKeyDown);
            }
        }
        private void Unhook(GridControlBase grid)
        {
            if (Grids.Contains(grid))
            {
                Grids.Remove(grid);
                grid.CurrentCellChanged -= new GridRoutedEventHandler(grid_CurrentCellChanged);
                grid.CurrentCellMoved -= new GridCurrentCellMovedEventHandler(grid_CurrentCellMoved);
                grid.IsVisibleChanged -= new DependencyPropertyChangedEventHandler(grid_IsVisibleChanged);
              }
        }

        private bool inCurrentCellChanged = false;
        void grid_CurrentCellChanged(object sender, SyncfusionRoutedEventArgs args)
        {
            if (inTextChanged || inCurrentCellMoved)
                return;
            inCurrentCellChanged = true;
            GridControlBase grid = args.Source as GridControlBase;
            if (grid != null)
            {
                lastGridWithFocus = grid;
                GridCurrentCell cc = grid.CurrentCell;
                FormulaBox.Text = cc.Renderer.ControlText;
            }
            inCurrentCellChanged = false;
        }

        private bool inCurrentCellMoved = false;
        void grid_CurrentCellMoved(object sender, GridCurrentCellMovedEventArgs e)
        {
            inCurrentCellMoved = true;
            GridControlBase grid = sender as GridControlBase;
            if (grid != null)
            {
                lastGridWithFocus = grid;
                GridCurrentCell cc = grid.CurrentCell;
                FormulaBox.Text = grid.Model[cc.CellRowColumnIndex.RowIndex, cc.CellRowColumnIndex.ColumnIndex].Text;
            }
            inCurrentCellMoved = false;
        }

        void grid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            GridControlBase grid = sender as GridControlBase;
            if (grid != null)
            {
                lastGridWithFocus = grid;
                GridCurrentCell cc = grid.CurrentCell;
                FormulaBox.Text = grid.Model[cc.CellRowColumnIndex.RowIndex, cc.CellRowColumnIndex.ColumnIndex].Text;
            }
        }

        
        void tb_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            GridControlBase grid = lastGridWithFocus;
            if (grid != null)
            {
                GridCurrentCell cc = grid.CurrentCell;
                cc.BeginEdit();
            }
        }

        private bool inTextChanged = false;

        void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (inCurrentCellChanged || inCurrentCellMoved)
                return;

            inTextChanged = true;

            GridControlBase grid = lastGridWithFocus;
            if (grid != null)
            {
                GridCurrentCell cc = grid.CurrentCell;

                if (grid.CurrentCell.HasCurrentCell)
                    cc.Renderer.SetControlText(FormulaBox.Text, false);
            }

            inTextChanged = false;
        }

        void tb_LostFocus(object sender, RoutedEventArgs e)
        {
            GridControlBase grid = lastGridWithFocus;
            if (grid != null)
            {
                GridCurrentCell cc = grid.CurrentCell;
                cc.EndEdit();
            }
        }

        void tb_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                e.Handled = true;
                lastGridWithFocus.CurrentCell.MoveDown();
            }
        }
       

        #region IDisposable Members

        public void Dispose()
        {
            Unwire();
        }

        #endregion
    }
}
