#region Copyright Syncfusion Inc. 2001-2021
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    public partial class ContextMenu : DemoControl
    {
        public ContextMenu()
        {
            InitializeComponent();
            this.pivotGrid1.Loaded += PivotGrid1_Loaded;
        }

        public List<string> ProductList
        {
            get
            {
                return new List<string> { "Bike", "Car" };
            }
        }

        public List<string> CountryList
        {
            get
            {
                return new List<string> { "Canada", "France" };
            }
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            this.chkEnableContextMenuRow.Click -= chkEnableContextMenuRow_Click;
            this.chkEnableContextMenuCol.Click -= chkEnableContextMenuCol_Click;
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
            this.btnCollapseRow.CommandParameter = this.btnCollapseRow.Tag;
            this.btnCollapseRow.CommandTarget = this.pivotGrid1;
            this.btnCollapseCol.CommandParameter = this.btnCollapseCol.Tag;
            this.btnCollapseCol.CommandTarget = this.pivotGrid1;
            this.btnCollapseRowList.CommandParameter = ProductList;
            this.btnCollapseRowList.CommandTarget = this.pivotGrid1;
            this.btnCollapseColList.CommandParameter = CountryList;
            this.btnCollapseColList.CommandTarget = this.pivotGrid1;
            this.btnExpandRow.CommandParameter = this.btnExpandRow.Tag;
            this.btnExpandRow.CommandTarget = this.pivotGrid1;
            this.btnExpandCol.CommandParameter = this.btnCollapseCol.Tag;
            this.btnExpandCol.CommandTarget = this.pivotGrid1;
            this.btnExpandRowList.CommandParameter = ProductList;
            this.btnExpandRowList.CommandTarget = this.pivotGrid1;
            this.btnExpandColList.CommandParameter = CountryList;
            this.btnExpandColList.CommandTarget = this.pivotGrid1;
            this.SchemaDesigner.PivotControl = this.pivotGrid1;
        }

        private void chkEnableContextMenuRow_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.RowHeaderCellStyle.EnableContextMenu = (sender as CheckBox).IsChecked ?? false;
        }

        private void chkEnableContextMenuCol_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.ColumnHeaderCellStyle.EnableContextMenu = (sender as CheckBox).IsChecked ?? false;
        }
    }
}