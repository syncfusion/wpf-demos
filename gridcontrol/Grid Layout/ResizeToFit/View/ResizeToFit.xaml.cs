#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
    using Syncfusion.Windows.Shared;
    using Syncfusion.Windows.Controls.Grid;
    using Syncfusion.Windows.GridCommon;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for ResizeToFit.xaml
    /// </summary>
    public partial class ResizeToFit : DemoControl
    {
        public ResizeToFit()
        {
            InitializeComponent();
            this.InitGrid();
        }
        public ResizeToFit(string themename) : base(themename)
        {
            InitializeComponent();
            this.InitGrid();
        }
        private void InitGrid()
        {
            this.grid.AllowDragColumns = true;
            this.grid.Model.RowCount = 35;
            this.grid.Model.ColumnCount = 25;
            for (int i = 1; i < 35; i++)
            {
                for (int j = 1; j < 25; j++)
                {
                    this.grid.Model[i, j].CellValue = string.Format("Row{0} Col{1}", i, j);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.grid.Model.ResizeColumnsToFit(GridRangeInfo.Table(), GridResizeToFitOptions.None);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.grid.Model.ResizeRowsToFit(GridRangeInfo.Table(), GridResizeToFitOptions.None);
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