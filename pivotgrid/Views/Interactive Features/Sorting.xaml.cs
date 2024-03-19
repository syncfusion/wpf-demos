#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using System.Windows;
    using syncfusion.demoscommon.wpf;
    using Syncfusion.Windows.Controls.PivotGrid;

    public partial class Sorting : DemoControl
    {
        public Sorting()
        {
            InitializeComponent();
            this.pivotGrid1.Loaded += PivotGrid1_Loaded;
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            this.btnSortAll.Click -= btnSortAll_Click;
            this.btnSortNone.Click -= btnSortNone_Click;
            this.btnSortColumn.Click -= btnSortColumn_Click;
            this.btnSortGrandTotal.Click -= btnSortGrandTotal_Click;
            this.btnSortTotal.Click -= btnSortTotal_Click;
            if (this.pivotGrid1 != null)
            {
                this.pivotGrid1.Loaded -= PivotGrid1_Loaded;
                this.pivotGrid1.Dispose();
                this.pivotGrid1 = null;
            }
            base.Dispose(disposing);
        }

        private void PivotGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            this.SchemaDesigner.PivotControl = this.pivotGrid1;
        }

        void btnSortTotal_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.PivotEngine.ClearSorts();
            this.pivotGrid1.InvalidateCells();
            this.pivotGrid1.SortOption = PivotSortOption.TotalSorting;
            this.pivotGrid1.InvalidateCells();
        }

        void btnSortGrandTotal_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.PivotEngine.ClearSorts();
            this.pivotGrid1.InvalidateCells();
            this.pivotGrid1.SortOption = PivotSortOption.GrandTotalSorting;
            this.pivotGrid1.InvalidateCells();
        }

        void btnSortColumn_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.PivotEngine.ClearSorts();
            this.pivotGrid1.InvalidateCells();
            this.pivotGrid1.SortOption = PivotSortOption.ColumnSorting;
            this.pivotGrid1.InvalidateCells();
        }

        void btnSortNone_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.PivotEngine.ClearSorts();
            this.pivotGrid1.InvalidateCells();
            this.pivotGrid1.SortOption = PivotSortOption.None;
            this.pivotGrid1.InvalidateCells();
        }

        void btnSortAll_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.PivotEngine.ClearSorts();
            this.pivotGrid1.InvalidateCells();
            this.pivotGrid1.SortOption = PivotSortOption.All;
            this.pivotGrid1.InvalidateCells();
        }
    }
}
