#region Copyright Syncfusion Inc. 2001 - 2021
// Copyright Syncfusion Inc. 2001 - 2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using Syncfusion.PivotAnalysis.Base;
    using Syncfusion.Windows.Controls.PivotGrid;
    using System.Windows;
    using System.Windows.Controls;

    public partial class PivotEditing : DemoControl
    {
        #region Constructor
        public PivotEditing()
        {
            InitializeComponent();
            this.pivotGrid1.Loaded += PivotGrid1_Loaded;
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            this.chkShowSubTotals.Click -= chkShowSubTotals_Click;
            this.chkShowGrandTotal.Click -= chkShowGrandTotal_Click;
            this.chkEnableEdit.Click -= chkEnableEdit_Click;
            this.chkEnableEditTotal.Click -= chkEnableEditTotal_Click;
            this.chkHideExpanders.Click -= chkHideExpanders_Click;
            this.rdBtnCustom.Click -= rdBtnCustom_Click;
            this.rdBtnBuiltIn.Click -= rdBtnBuiltIn_Click;
            this.rdBtnListDataSource.Click -= rdBtnListDataSource_Click;
            this.rdBtnDataTableDataSource.Click -= rdBtnDataTableDataSource_Click;
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

        private void chkShowSubTotals_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.ShowSubTotals = (sender as CheckBox).IsChecked ?? false;
        }

        private void chkShowGrandTotal_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.ShowGrandTotals = (sender as CheckBox).IsChecked ?? false;
        }

        private void rdBtnListDataSource_Click(object sender, RoutedEventArgs e)
        {
            LoadList();
        }

        private void rdBtnDataTableDataSource_Click(object sender, RoutedEventArgs e)
        {
            LoadDataTable();
        }

        private void rdBtnCustom_Click(object sender, RoutedEventArgs e)
        {
            this.chkEnableEditTotal.IsChecked = false;
            this.pivotGrid1.EditManager.Dispose();
            this.pivotGrid1.EditManager = new CustomEditManager(this.pivotGrid1) { HideExpanders = this.pivotGrid1.EditManager.HideExpanders };
        }

        private void rdBtnBuiltIn_Click(object sender, RoutedEventArgs e)
        {
            this.chkEnableEditTotal.IsChecked = false;
            this.pivotGrid1.EditManager.Dispose();
            this.pivotGrid1.EditManager = new PivotEditingManager(this.pivotGrid1) { HideExpanders = this.pivotGrid1.EditManager.HideExpanders };
        }

        private void chkEnableEdit_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                this.pivotGrid1.EnableValueEditing = true;
                this.pivotGrid1.EditManager.AllowEditingOfTotalCells = true;
            }
            else
                this.pivotGrid1.EnableValueEditing = false;
            this.pivotGrid1.InvalidateCells();
        }

        private void chkEnableEditTotal_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
                this.pivotGrid1.EditManager.AllowEditingOfTotalCells = true;
            else
                this.pivotGrid1.EditManager.AllowEditingOfTotalCells = false;
            this.pivotGrid1.InvalidateCells();
        }

        private void chkHideExpanders_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
                this.pivotGrid1.EditManager.HideExpanders = true;
            else
                this.pivotGrid1.EditManager.HideExpanders = false;
            this.pivotGrid1.InvalidateCells();
        }

        #region DataSource
        /// <summary>
        /// Loads the DataTable as DataSource for PivotGridControl
        /// </summary>
        private void LoadDataTable()
        {
            this.pivotGrid1.ItemSource = null;
            this.pivotGrid1.ResetPivotData();
            this.pivotGrid1.ItemSource = BusinessObjectsDataView.GetDataTable(200);

            this.pivotGrid1.PivotRows.Add(new PivotItem() { FieldMappingName = "Fruit", FieldHeader = "Fruit", TotalHeader = "Total" });
            this.pivotGrid1.PivotRows.Add(new PivotItem() { FieldMappingName = "Color", FieldHeader = "Color", TotalHeader = "Total" });

            this.pivotGrid1.PivotColumns.Add(new PivotItem() { FieldMappingName = "Shape", FieldHeader = "Shape", TotalHeader = "Total" });
            this.pivotGrid1.PivotColumns.Add(new PivotItem() { FieldMappingName = "Even", FieldHeader = "Even", TotalHeader = "Total" });

            this.pivotGrid1.PivotCalculations.Add(new PivotComputationInfo() { FieldName = "Count", FieldHeader = "Count", SummaryType = SummaryType.DoubleTotalSum });
            this.pivotGrid1.PivotCalculations.Add(new PivotComputationInfo() { FieldName = "Section", FieldHeader = "Section", SummaryType = SummaryType.DoubleTotalSum });
            this.pivotGrid1.PivotCalculations.Add(new PivotComputationInfo() { FieldName = "Weight", FieldHeader = "Weight", SummaryType = SummaryType.DoubleTotalSum });
        }

        /// <summary>
        /// Loads the List as DataSource for PivotGridControl
        /// </summary>
        private void LoadList()
        {
            this.pivotGrid1.ItemSource = null;
            this.pivotGrid1.ResetPivotData();
            this.pivotGrid1.ItemSource = BusinessObjectCollection.GetList(200);

            this.pivotGrid1.PivotRows.Add(new PivotItem() { FieldMappingName = "Fruit", FieldHeader = "Fruit", TotalHeader = "Total" });
            this.pivotGrid1.PivotRows.Add(new PivotItem() { FieldMappingName = "Color", FieldHeader = "Color", TotalHeader = "Total" });

            this.pivotGrid1.PivotColumns.Add(new PivotItem() { FieldMappingName = "Shape", FieldHeader = "Shape", TotalHeader = "Total" });
            this.pivotGrid1.PivotColumns.Add(new PivotItem() { FieldMappingName = "Even", FieldHeader = "Even", TotalHeader = "Total" });

            this.pivotGrid1.PivotCalculations.Add(new PivotComputationInfo() { FieldName = "Count", FieldHeader = "Count", SummaryType = SummaryType.DoubleTotalSum });
            this.pivotGrid1.PivotCalculations.Add(new PivotComputationInfo() { FieldName = "Section", FieldHeader = "Section", SummaryType = SummaryType.DoubleTotalSum });
            this.pivotGrid1.PivotCalculations.Add(new PivotComputationInfo() { FieldName = "Weight", FieldHeader = "Weight", SummaryType = SummaryType.DoubleTotalSum });

        }
        #endregion
    }
}