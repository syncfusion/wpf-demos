#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace Sorting
{
    using System.Windows;
    using Syncfusion.Windows.Controls.PivotGrid;
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnSortAll.Click += new RoutedEventHandler(btnSortAll_Click);
            btnSortNone.Click += new RoutedEventHandler(btnSortNone_Click);
            btnSortColumn.Click += new RoutedEventHandler(btnSortColumn_Click);
            btnSortGrandTotal.Click += new RoutedEventHandler(btnSortGrandTotal_Click);
            btnSortTotal.Click += new RoutedEventHandler(btnSortTotal_Click);
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
