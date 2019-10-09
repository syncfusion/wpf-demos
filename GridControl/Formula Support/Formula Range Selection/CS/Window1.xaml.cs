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
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;

namespace FormulaRangeSelections
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {

        FormulaSupportWithRangeSelectionsHelper helper;
        public Window1()
        {
            InitializeComponent();
            InitializeGrid();   
        }

        private void InitializeGrid()
        {
            grid.Model.RowCount = 35;
            grid.Model.ColumnCount = 25;
            grid.Model.ColumnWidths[4] = 90;
            //put some random values in column 1 & 2
            Random r = new Random();
            for (int row = 1; row <= 40; ++row)
            {
                for (int col = 1; col <= 2; ++col)
                {
                    this.grid.Model[row, col].CellValue = r.Next(1000);
                    this.grid.Model[row, col].CellValueType = typeof(int);
                }
            }
            helper = new FormulaSupportWithRangeSelectionsHelper(grid);
        }

        protected override void OnClosed(EventArgs e)
        {
            helper.Dispose();
            base.OnClosed(e);
        }
    }
}
