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
using System.ComponentModel;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;

namespace SortableGridControl
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        public Window1()
        {
            InitializeComponent();
            AssignRandomData(gridControl1);
            gridControl1.Model.TableStyle.HorizontalAlignment = HorizontalAlignment.Right;
            gridControl1.Model.ColumnWidths.DefaultLineSize = 60;
            gridControl1.Model.TableStyle.ReadOnly = true;
            //add sorting support...
            new GridControlSortHelper(gridControl1);
        }

        private void AssignRandomData(Syncfusion.Windows.Controls.Grid.GridControl grid)
        {
            int rows = 35;
            int cols = 25;

            grid.Model.RowCount = rows;
            grid.Model.ColumnCount = cols;

            Random r = new Random(1231123);
            GridCellData cellData = grid.Model.Data;

            for (int i = 1; i < rows; ++i)
            {
                GridStyleInfo style = new GridStyleInfo();
                style.CellValue = i;
                cellData[i, 1] = style.Store;
                style = new GridStyleInfo();
                style.CellValue = i;
                cellData[i, 2] = style.Store;
            }

            for (int i = 1; i < rows; ++i)
            {
                for (int j = 3; j < cols; ++j)
                {
                    GridStyleInfo style = new GridStyleInfo();
                    style.CellValue = r.Next(1000);
                    cellData[i, j] = style.Store;
                }
            }
        }
    }
}
