#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;

namespace ExcelLikeSelection
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        public Window1()
        {
            InitializeComponent();
            InitializeGridControl();
        }

        private void InitializeGridControl()
        {
            gridControl1.Model.ColumnCount = 50;
            gridControl1.Model.RowCount = 50;
            this.gridControl1.Model.ColumnWidths[0] = 40;
            gridControl1.Model.Options.ExcelLikeSelectionFrame = true;
            gridControl1.Model.Options.ExcelLikeSelection = true;
            GridFillSeriesMouseController controller = new GridFillSeriesMouseController(this.gridControl1);
            this.gridControl1.MouseControllerDispatcher.Add(controller);
        }
    }
}
