#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.gridcontroldemos.wpf
{
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
    using Syncfusion.Windows.Controls.Cells;
    using Syncfusion.Windows.GridCommon;
    using syncfusion.demoscommon.wpf;

    /// <summary>
    /// Interaction logic for BorderPaddingCell.xaml
    /// </summary>

    public partial class BorderPaddingCell : DemoControl
    {
        public BorderPaddingCell()
        {
            InitializeComponent();
            this.InitGrid();
        }
        public BorderPaddingCell(string themename) : base(themename)
        {
            InitializeComponent();
            this.InitGrid();
        }

        /// <summary>
        /// Initialize the data to the grid.
        /// </summary>
        private void InitGrid()
        {
            this.grid.AllowDragColumns = false;
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

        /// <summary>
        /// Handles the ValueChanged event of the Slider control to change the width of cell padding.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedPropertyChangedEventArgs&lt;System.Double&gt;"/> instance containing the event data.</param>
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GridRangeInfo range = grid.Model.SelectedRanges.ActiveRange;
            for (int row = range.Top; row <= range.Bottom; row++)
            {
                for (int col = range.Left; col <= range.Right; col++)
                {
                    var style = grid.Model[row, col];
                    if (Top.IsChecked == true)
                        style.Padding = new CellMarginsInfo(style.Padding.Left, e.NewValue, style.Padding.Right, style.Padding.Bottom);

                    if (Left.IsChecked == true)
                        style.Padding = new CellMarginsInfo(e.NewValue, style.Padding.Top, style.Padding.Right, style.Padding.Bottom);

                    if (Bottom.IsChecked == true)
                        style.Padding = new CellMarginsInfo(style.Padding.Left, style.Padding.Top, style.Padding.Right, e.NewValue);

                    if (Right.IsChecked == true)
                        style.Padding = new CellMarginsInfo(style.Padding.Left, style.Padding.Top, e.NewValue, style.Padding.Bottom);
                }
            }
            grid.Model.InvalidateVisual();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            var style = grid.Model[grid.Model.SelectedRanges.ActiveRange.Top, grid.Model.SelectedRanges.ActiveRange.Left];
            switch (radioButton.Name)
            {
                case "Top":
                    slider.Value = style.Padding.Top;
                    grid.Model.InvalidateVisual();
                    break;
                case "Left":
                    slider.Value = style.Padding.Left;
                    grid.Model.InvalidateVisual();
                    break;
                case "Right":
                    slider.Value = style.Padding.Right;
                    grid.Model.InvalidateVisual();
                    break;
                case "Bottom":
                    slider.Value = style.Padding.Bottom;
                    grid.Model.InvalidateVisual();
                    break;
            }
        }

        private void BorderOptions_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            GridRangeInfo range = grid.Model.SelectedRanges.ActiveRange;
            for (int row = range.Top; row <= range.Bottom; row++)
            {
                for (int col = range.Left; col <= range.Right; col++)
                {
                    var style = grid.Model[row, col];
                    switch (radioButton.Name)
                    {
                        case "Dot":
                            style.Borders.All = new Pen() { DashStyle = DashStyles.Dot, Thickness = 2.0, Brush = Brushes.Black };
                            grid.Model.InvalidateVisual();
                            break;
                        case "Dash":
                            style.Borders.All = new Pen() { DashStyle = DashStyles.Dash, Thickness = 2.0, Brush = Brushes.Black };
                            grid.Model.InvalidateVisual();
                            break;
                        case "DashDot":
                            style.Borders.All = new Pen() { DashStyle = DashStyles.DashDot, Thickness = 2.0, Brush = Brushes.Black };
                            grid.Model.InvalidateVisual();
                            break;
                        case "DashDotDot":
                            style.Borders.All = new Pen() { DashStyle = DashStyles.DashDotDot, Thickness = 2.0, Brush = Brushes.Black };
                            grid.Model.InvalidateVisual();
                            break;
                    }
                }
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

