#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.ComponentModel;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for UndoRedo.xaml
    /// </summary>
    public partial class UndoRedo : DemoControl
    {
        public UndoRedo()
        {
            InitializeComponent();
            this.grid.Model.RowCount = 30;
            this.grid.Model.ColumnCount = 15;
            PopulateGrid();
            oldRedoCount = 0;
            oldUndoCount = 0;
            this.grid.LayoutUpdated += new EventHandler(grid_LayoutUpdated);
            //turn undo buffer on...
            this.grid.Model.CommandStack.Enabled = true;
        }

        public UndoRedo(string themename) : base(themename)
        {
            InitializeComponent();
            this.grid.Model.RowCount = 30;
            this.grid.Model.ColumnCount = 15;
            PopulateGrid();
            oldRedoCount = 0;
            oldUndoCount = 0;
            this.grid.LayoutUpdated += new EventHandler(grid_LayoutUpdated);
            //turn undo buffer on...
            this.grid.Model.CommandStack.Enabled = true;
        }
        private void PopulateGrid()
        {
            Random r = new Random();
            for (int i = 1; i <= this.grid.Model.RowCount; ++i)
                for (int j = 1; j <= this.grid.Model.ColumnCount; ++j)
                    this.grid.Model[i, j].CellValue = r.Next(1000);
        }

        #region DisplayUndoRedoStack
        void grid_LayoutUpdated(object sender, System.EventArgs e)
        {
            ShowStacks();
        }

        private void ShowStacks()
        {
            ShowRedoStack();
            ShowUndoStack();
        }

        private int oldRedoCount;
        private int oldUndoCount;
        private void ShowUndoStack()
        {
            int numUndos = this.grid.Model.CommandStack.UndoStack.Count;
            if (numUndos != this.oldUndoCount)
            {
                this.listBox1.Items.Clear();
                this.listBox1.Items.Add(string.Format("{0} Undo items", numUndos));

                if (numUndos > 0 || this.grid.Model.CommandStack.IsRecording)
                    DisplayCommandsInStack(this.grid.Model.CommandStack.UndoStack.ToArray(), "", listBox1, true);
                this.oldUndoCount = numUndos;
            }

        }

        private void ShowRedoStack()
        {
            int numRedos = this.grid.Model.CommandStack.RedoStack.Count;
            if (numRedos != this.oldRedoCount)
            {
                this.listBox2.Items.Clear();
                this.listBox2.Items.Add(string.Format("{0} Redo items", numRedos));
                if (numRedos > 0 || this.grid.Model.CommandStack.IsRecording)
                    DisplayCommandsInStack(this.grid.Model.CommandStack.RedoStack.ToArray(), "", listBox2, false);
                this.oldRedoCount = numRedos;
            }
        }

        private void DisplayCommandsInStack(object[] items, string indent, ListBox _listbox, bool includeCurrentCommand)
        {
            string s;
            SyncfusionCommand c;
            GridTransactionCommand tc;
            int cutOff;

            //handle the case where we are recording a transaction
            if (includeCurrentCommand && this.grid.Model.CommandStack.InTransaction)
            {
                try
                {
                    tc = this.grid.Model.CommandStack.CurrentTransactionCommand;
                    DisplayCommandsInStack(tc.Stack.ToArray(), "    > ", _listbox, false);
                }
                catch { }
            }

            foreach (object o in items)
            {
                try
                {
                    c = (SyncfusionCommand)o;
                    if (c != null && c.Description != null)
                        s = c.Description;
                    else
                        s = o.ToString();
                    cutOff = 1 + Math.Max(s.LastIndexOf("+"), s.LastIndexOf("."));
                    _listbox.Items.Add(indent + s.Substring(cutOff));
                }
                catch { }

                //check if is a transaction command
                try
                {
                    tc = o as GridTransactionCommand;
                    if (tc != null)
                    {
                        DisplayCommandsInStack(tc.Stack.ToArray(), "    > ", _listbox, false);
                    }
                }
                catch { }

            }
        }
        #endregion

        #region Button Click
        
        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (!this.grid.Model.CommandStack.InTransaction)
            {
                this.grid.Model.CommandStack.Undo();
                ShowStacks();
            }
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            if (!this.grid.Model.CommandStack.InTransaction)
            {
                this.grid.Model.CommandStack.Redo();
                ShowStacks();
            }
        }

        private void BeginTrans_Click(object sender, RoutedEventArgs e)
        {
            this.grid.Model.CommandStack.BeginTrans("Transaction beginning-");
            ShowStacks();
        }

        private void Commit_Click(object sender, RoutedEventArgs e)
        {
            if (this.grid.Model.CommandStack.InTransaction)
            {
                this.grid.Model.CommandStack.CommitTrans();
                ShowStacks();
            }
        }

        private void RollBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.grid.Model.CommandStack.InTransaction)
            {
                this.grid.Model.CommandStack.Rollback();
                ShowStacks();
            }
        }

        private void ClearUndoRedo_Click(object sender, RoutedEventArgs e)
        {
            if (!this.grid.Model.CommandStack.InTransaction)
            {
                this.grid.Model.CommandStack.UndoStack.Clear();
                this.grid.Model.CommandStack.RedoStack.Clear();
                ShowStacks();
            }
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (this.grid != null)
            {
                this.grid.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
