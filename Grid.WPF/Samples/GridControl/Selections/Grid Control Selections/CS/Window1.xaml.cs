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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.GridCommon;

namespace GridControlSelections
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        public Window1()
        {
            InitializeComponent();

            //set up the initial state of the GridControl
            radioButton1.IsChecked = true;
            checkBox1.IsChecked = false;
            checkBox2.IsChecked = false;
            grid.Model.RowCount = 30;
            grid.Model.ColumnCount = 15;
            //grid.Model.ColumnWidths[0] = 25;

            //SetRangeSelections();
            //mark cell 3,3 - depending upone checkbox, this cell is cannot be in a selection
            grid.Model[3, 3].Background = Brushes.AliceBlue;

            //use this event to handle special selection requirements...
            grid.Model.SelectionChanging += new GridSelectionChangingEventHandler(Model_SelectionChanging);

            //dynamically size the grid to fill lower area
            grid.Model.QueryCellInfo += new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
        }

        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if (e.Cell.RowIndex == 0 && e.Cell.ColumnIndex > 0)
            {
                e.Style.Text = GridRangeInfo.GetAlphaLabel(e.Cell.ColumnIndex);
            }
            else if (e.Cell.RowIndex > 0 && e.Cell.ColumnIndex == 0)
            {
                e.Style.Text = e.Cell.RowIndex.ToString();
            }
        }

        #region SelectionChanging event

        void Model_SelectionChanging(object sender, GridSelectionChangingEventArgs e)
        {
            if ((bool)checkBox1.IsChecked &&
                e.Range != GridRangeInfo.Empty &&
                e.Range.Contains(GridRangeInfo.Cell(3, 3)))
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region radio buttons code

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            HandleButtonCheck((RadioButton)e.Source);

        }

        private void HandleButtonCheck(RadioButton radio)
        {
            grid.Model.Selections.Clear();
            grid.Model.Options.ListBoxSelectionMode = GridSelectionMode.None;

            if (radio != radioButton1)
                radioButton1.IsChecked = false;
            else
                SetRangeSelections();

            if (radio != radioButton2)
                radioButton2.IsChecked = false;
            else
                SetRowsOnly();

            if (radio != radioButton3)
                radioButton3.IsChecked = false;
            else
                SetColumnsOnly();

            if (radio != radioButton4)
                radioButton4.IsChecked = false;
            else
                SetRowsColumnsOnly();

            if (radio != radioButton5)
                radioButton5.IsChecked = false;
            else
                SetListBoxMode();

        }

        private void SetRangeSelections()
        {
            grid.Model.Options.AllowSelection = GridSelectionFlags.Any;
        }
        private void SetRowsOnly()
        {
            grid.Model.Options.AllowSelection = GridSelectionFlags.Any & ~GridSelectionFlags.Column & ~GridSelectionFlags.Table; // & GridSelectionFlags.Cell
        }
        private void SetColumnsOnly()
        {
            grid.Model.Options.AllowSelection = GridSelectionFlags.Any & ~GridSelectionFlags.Row & ~GridSelectionFlags.Table; // & GridSelectionFlags.Cell
        }
        private void SetRowsColumnsOnly()
        {
            grid.Model.Options.AllowSelection = GridSelectionFlags.Any & ~GridSelectionFlags.Table; // & ~GridSelectionFlags.Cell
        }
        private void SetListBoxMode()
        {
            grid.Model.Options.ListBoxSelectionMode = GridSelectionMode.MultiExtended;
            grid.Model.Options.AllowSelection = GridSelectionFlags.Any & ~GridSelectionFlags.Cell & ~GridSelectionFlags.Column & ~GridSelectionFlags.Table;
        }
        #endregion

        #region show selections code

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string outPut = "";
            foreach (GridRangeInfo range1 in grid.Model.Selections.Ranges)
            {
                outPut += "===== " + range1.ToString() + Environment.NewLine;
                int row, col;
                int trackRow = -1;

                GridRangeInfo range = range1.ExpandRange(0, 0, grid.Model.RowCount, grid.Model.ColumnCount);
                if (range.GetFirstCell(out row, out col))
                {
                    // Console.Write("row{0},col{1}    ", row, col);
                    outPut += string.Format("row{0},col{1}    ", row, col);
                    trackRow = row;
                    while (range.GetNextCell(ref row, ref col))
                    {
                        if (row != trackRow)
                        {
                            trackRow = row;
                            //  Console.WriteLine("");
                            outPut += Environment.NewLine;
                        }
                        //  Console.Write("row{0},col{1}    ", row, col);  
                        outPut += string.Format("row{0},col{1}    ", row, col);
                    }
                    // Console.WriteLine("");
                    outPut += Environment.NewLine;
                }
                outPut += Environment.NewLine;
            }

            this.textBox1.Text = outPut;
            //  this.scrollViewer1.Content = outPut;
        }
        #endregion

        #region ExcelLike CurrentCell
        //excellike currentcell means CurrentCell is part of the selections.
        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            grid.Model.Options.ExcelLikeCurrentCell = (bool)checkBox2.IsChecked;
            grid.Model.Options.ExcelLikeSelectionFrame = (bool)checkBox2.IsChecked;

            grid.Model.Selections.Clear();
            //  grid.InvalidateVisual(false);

        }
        #endregion
    }
}
