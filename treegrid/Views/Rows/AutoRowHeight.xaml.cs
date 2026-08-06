#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.UI.Xaml.TreeGrid.Helpers;
using Syncfusion.Windows.Shared;

namespace syncfusion.treegriddemos.wpf
{
    /// <summary>
    /// Interaction logic for AutoRowHeightDemo.xaml
    /// </summary>
    public partial class AutoRowHeightDemo : DemoControl
    {
        GridRowSizingOptions gridRowResizingOptions = new GridRowSizingOptions();
        //To get the calculated height from GetAutoRowHeight method.    
        double autoHeight = double.NaN;

        /// <summary>
        /// Initializes a new instance of the AutoRowHeightDemo class.
        /// </summary>
        public AutoRowHeightDemo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the AutoRowHeightDemo class with a theme name.
        /// </summary>
        /// <param name="themename">The theme name.</param>
        public AutoRowHeightDemo(string themename) : base(themename)
        {
            InitializeComponent();
            this.treeGrid.QueryRowHeight += TreeGrid_QueryRowHeight;
            this.treeGrid.CurrentCellEndEdit += TreeGrid_CurrentCellEndEdit;
        }

        private void TreeGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
        {
            treeGrid.InvalidateRowHeight(e.RowColumnIndex.RowIndex);
            treeGrid.GetTreePanel().InvalidateMeasureInfo();
        }

        private void TreeGrid_QueryRowHeight(object sender, TreeGridQueryRowHeightEventArgs e)
        {
            if (this.treeGrid.TreeGridColumnSizer.GetAutoRowHeight(e.RowIndex, gridRowResizingOptions, out autoHeight))
            {
                if (autoHeight > 24)
                {
                    e.Height = autoHeight;
                    e.Handled = true;
                }
                else
                {
                    e.Height = 24;
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Disposes resources used by the control.
        /// </summary>
        /// <param name="disposing">Whether to dispose managed resources.</param>
        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            // Release all managed resources
            if (this.treeGrid != null)
            {
                this.treeGrid.Dispose();
                this.treeGrid = null;
            }

            if (this.DataContext != null)
            {
                var viewModel = this.DataContext as AutoRowHeightViewModel;
                if (viewModel != null)
                {
                    viewModel.Dispose();
                }
                this.DataContext = null;
            }

            base.Dispose(disposing);
        }
    }
}
