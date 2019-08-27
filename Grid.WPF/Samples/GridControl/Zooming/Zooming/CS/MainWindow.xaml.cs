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
using Syncfusion.Windows.GridCommon;
using Zooming.Model;
using System.Collections;
using Syncfusion.Windows.Shared;

namespace Zooming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            this.DataContext = Orders.LoadOrders();
            grid.Model.RowCount = (this.DataContext as IEnumerable<Order>).Count() + 1;
            grid.Model.ColumnCount = 14;
            grid.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
        }


    }
}
