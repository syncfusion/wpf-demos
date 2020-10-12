#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Scroll;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.GridCommon;
using Microsoft.Xaml.Behaviors;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for VirtualGrid.xaml
    /// </summary>
    /// 
    public partial class VirtualGrid : DemoControl
    {
        public VirtualGrid()
        {
            InitializeComponent();
            this.DataContext = new Dictionary<RowColumnIndex, object>();
            InitializeGridControl();
        }
        public VirtualGrid(string themename) : base(themename)
        {
            InitializeComponent();
            this.DataContext = new Dictionary<RowColumnIndex, object>();
            InitializeGridControl();
        }
        private void InitializeGridControl()
        {
            // a really large row and column count.
            grid.Model.RowCount = 99000000; // 99 million
            grid.Model.ColumnCount = 1000000; // 1 million
            // Resize millions of rows instantly - pixel scrolling is updated accordingly.
            grid.Model.RowHeights.SetRange(10, 1999999, 28);
            grid.Model.RowHeights.SetRange(21111111, 21999999, 36);
            grid.Model.TableStyle.CellType = "Static"; 
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
