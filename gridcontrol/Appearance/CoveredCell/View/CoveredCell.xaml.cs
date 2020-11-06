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
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for CoveredCell.xaml
    /// </summary>
    public partial class CoveredCell : DemoControl
    {
        public CoveredCell()
        {
            InitializeComponent();
            GridSettings();
        }

        public CoveredCell(string themename) : base(themename)
        {
            InitializeComponent();
            GridSettings();
        }

        private void GridSettings()
        {

            grid.Model.RowCount = 35;
            grid.Model.ColumnCount = 25;

            this.grid.QueryBaseStyles += new GridQueryBaseStylesEventHandler(grid_QueryBaseStyles);

            grid.Model[1, 1].CellValue = "FirstName";

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(1, 2, 1, 3));
            this.grid.Model[1, 2].CellValue = "Title";

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(1, 4, 1, 5));
            this.grid.Model[1, 4].CellValue = "Home Phone";

            this.grid.Model[1, 6].CellValue = "Extension";

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(1, 7, 1, 8));
            this.grid.Model[1, 7].CellValue = "Address";

            this.grid.Model[1, 9].CellValue = "Region";
            this.grid.Model[2, 1].CellValue = "Photo";

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(2, 2, 2, 3));
            this.grid.Model[2, 2].CellValue = "Title of courtesy";

            this.grid.Model[2, 4].CellValue = "Reports To";
            this.grid.Model[2, 5].CellValue = "Birth Date";

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(3, 1, 5, 8));
            var cell = grid.Model[3, 1];
            cell.CellValue = "This sample represents how cells can be easily merged.Cells can be spanned in rows or in columns or in both ways as shown above.";
            cell.HorizontalAlignment = HorizontalAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.Font.FontWeight = FontWeights.Bold;

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(6, 4, 7, 4));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(6, 6, 7, 6));

            cell = this.grid.Model[6, 4];
            cell.CellValue = "Row spanned cell";
            cell.Background = Brushes.BlanchedAlmond;
            cell.HorizontalAlignment = HorizontalAlignment.Center;

            cell = this.grid.Model[6, 6];
            cell.CellValue = "Row spanned cell";
            cell.HorizontalAlignment = HorizontalAlignment.Center;
            cell.Background = Brushes.BlanchedAlmond;

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(9, 4, 11, 6));
            cell = this.grid.Model[9, 4];
            cell.CellValue = "Column and row spanned cell";
            cell.HorizontalAlignment = HorizontalAlignment.Center;
            cell.Background = Brushes.BlanchedAlmond;

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(13, 4, 13, 6));
            cell = this.grid.Model[13, 4];
            cell.CellValue = "Column  spanned cell";
            cell.Background = Brushes.BlanchedAlmond;
            cell.HorizontalAlignment = HorizontalAlignment.Center;
        }
        void grid_QueryBaseStyles(object sender, Syncfusion.Windows.Controls.Grid.GridQueryBaseStylesEventArgs e)
        {
            if (e.Cell.RowIndex > 0 && e.Cell.ColumnIndex > 0 && !this.grid.CurrentCell.IsEditing)
            {
                if (e.Cell.RowIndex == 1 || e.Cell.RowIndex == 2)
                    e.Style.Background = Brushes.LightBlue;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (this.grid != null)
            {
                this.grid.Dispose();
                this.grid = null;
            }
            base.Dispose(disposing);
        }
    }
}


