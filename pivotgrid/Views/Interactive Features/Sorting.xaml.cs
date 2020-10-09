#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
            btnSortAll.Click += new RoutedEventHandler(btnSortAll_Click);
            btnSortNone.Click += new RoutedEventHandler(btnSortNone_Click);
            btnSortColumn.Click += new RoutedEventHandler(btnSortColumn_Click);
            btnSortGrandTotal.Click += new RoutedEventHandler(btnSortGrandTotal_Click);
            btnSortTotal.Click += new RoutedEventHandler(btnSortTotal_Click);
            this.pivotGrid1.Loaded += PivotGrid1_Loaded;
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
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
            this.SchemaDesigner.VisualStyle = Syncfusion.Windows.Controls.PivotGrid.PivotGridVisualStyle.Metro;
        }

        void btnSortTotal_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.SortOption = PivotSortOption.TotalSorting;
        }

        void btnSortGrandTotal_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.SortOption = PivotSortOption.GrandTotalSorting;
        }

        void btnSortColumn_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.SortOption = PivotSortOption.ColumnSorting;
        }

        void btnSortNone_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.SortOption = PivotSortOption.None;

        }

        void btnSortAll_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.SortOption = PivotSortOption.All;
        }
    }
}
