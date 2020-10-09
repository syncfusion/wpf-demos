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
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for HiddenRowColumnResizing.xaml
    /// </summary>
    public partial class HiddenRowColumnResizing : DemoControl
    {
        public HiddenRowColumnResizing()
        {
            InitializeComponent();
            GridSettings();
        }
        public HiddenRowColumnResizing(string themename) : base(themename)
        {
            InitializeComponent();
            GridSettings();
        }
        void GridSettings()
        {
            this.gridControl.Model.RowCount = 30;
            this.gridControl.Model.ColumnCount = 25;
            this.gridControl.Model.Options.ExcelLikeCurrentCell = true;
            this.gridControl.Model.Options.ExcelLikeSelectionFrame = true;
            this.gridControl.Model.Options.HiddenBorderBrush = Brushes.Black;
            this.gridControl.Model.Options.HiddenBorderThickness = 4;
            this.gridControl.Model.Options.AllowExcelLikeResizing = true;

            for (int i = 1; i < 30; i++)
            {
                for (int j = 1; j < 25; j++)
                {
                    this.gridControl.Model[i, j].CellValue = string.Format("R{0}C{1}", i, j);
                }
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            if (bt.Content.ToString().Equals("Hide Rows and Columns"))
            {
                bt.Content = "Show Rows and Columns";
                this.gridControl.ColumnWidths.SetHidden(3, 4, true);
                this.gridControl.RowHeights.SetHidden(3, 4, true);

            }
            else
            {
                bt.Content = "Hide Rows and Columns";
                this.gridControl.ColumnWidths.SetHidden(3, 4, false);
                this.gridControl.RowHeights.SetHidden(3, 4, false);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (this.gridControl != null)
            {
                this.gridControl.Dispose();
                this.gridControl = null;
            }
            base.Dispose(disposing);
        }
    }
}
