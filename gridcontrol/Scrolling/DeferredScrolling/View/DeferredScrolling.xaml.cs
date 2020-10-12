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
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for DeferredScrolling.xaml
    /// </summary>
    public partial class DeferredScrolling : DemoControl
    {
        public DeferredScrolling()
        {
            InitializeComponent();
            GridSettings();
        }
        public DeferredScrolling(string themename) : base(themename)
        {
            InitializeComponent();
            GridSettings();
        }
        void GridSettings()
        {

            gridControl1.Model.ColumnCount = 400;
            gridControl1.Model.RowCount = 400;
            this.gridControl1.Model.Options.ExcelLikeCurrentCell = true;
            this.gridControl1.Model.Options.ExcelLikeSelectionFrame = true;

            Random r = new Random();

            for (int row = 1; row < 400; row++)
            {
                for (int col = 1; col < 400; col++)
                {
                    if (r.Next(100) > 60)
                        gridControl1.Model[row, col].Text = r.Next(5000, 10000).ToString();
                }
            }
        }
        private void Deferered_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox ck = sender as CheckBox;
            if (ck.IsChecked == true)
            {
                this.scrollViewer.IsDeferredScrollingEnabled = true;
            }
            else
            {
                this.scrollViewer.IsDeferredScrollingEnabled = false;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (this.gridControl1 != null)
            {
                this.gridControl1.Dispose();
                this.gridControl1 = null;
            }
            base.Dispose(disposing);
        }
    }
}
