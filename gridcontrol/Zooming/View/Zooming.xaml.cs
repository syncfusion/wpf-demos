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
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using syncfusion.gridcontroldemos.wpf;
using System.Collections;
using Syncfusion.Windows.Shared;
using Microsoft.Xaml.Behaviors;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for Zooming.xaml
    /// </summary>
    public partial class Zooming : DemoControl
    {
        public Zooming()
        {
            InitializeComponent();
            InitializeGrid();
        }
        public Zooming(string themename) : base(themename)
        {
            InitializeComponent();
            InitializeGrid();
        }
        private void InitializeGrid()
        {
            this.DataContext = Orders1.LoadOrders();
            grid.Model.RowCount = (this.DataContext as IEnumerable<Order>).Count() + 1;
            grid.Model.ColumnCount = 14;
            grid.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
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
