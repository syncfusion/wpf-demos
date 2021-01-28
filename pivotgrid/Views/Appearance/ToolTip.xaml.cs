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
    using Syncfusion.Windows.Shared;
    using System.Windows;
    using System.Windows.Controls;

    public partial class ToolTip : DemoControl
    {
        public ToolTip()
        {
            InitializeComponent();
            this.pivotGrid1.Loaded += PivotGrid1_Loaded;
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            this.chkBoxToolTipEnabled.Click -= chkBoxToolTipEnabled_Click;
            this.chkBoxColHeader.Click -= chkBoxColHeader_Click;
            this.chkBoxRowHeader.Click -= chkBoxRowHeader_Click;
            this.chkBoxValCell.Click -= chkBoxValCell_Click;
            this.chkBoxSumHeader.Click -= chkBoxSumHeader_Click;
            this.chkBoxSumCell.Click -= chkBoxSumCell_Click;
            this.chkBoxEnableCustom_All.Click -= chkBoxEnableCustom_All_Click;
            this.chkBoxCustomColHeader.Click -= chkBoxCustomColHeader_Click;
            this.chkBoxCustomRowHeader.Click -= chkBoxCustomRowHeader_Click;
            this.chkBoxCustomValCell.Click -= chkBoxCustomValCell_Click;
            this.chkBoxCustomSumHeader.Click -= chkBoxCustomSumHeader_Click;
            this.chkBoxCustomSumCell.Click -= chkBoxCustomSumCell_Click;
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

        private void chkBoxColHeader_Click(object sender, RoutedEventArgs e)
        {
            this.chkBoxCustomColHeader.IsEnabled = (sender as CheckBox).IsChecked ?? false;
            this.pivotGrid1.ColumnHeaderCellStyle.ToolTipEnabled = (sender as CheckBox).IsChecked ?? false;
            this.pivotGrid1.InvalidateCells();
        }

        private void chkBoxRowHeader_Click(object sender, RoutedEventArgs e)
        {
            this.chkBoxCustomRowHeader.IsEnabled = (sender as CheckBox).IsChecked ?? false;
            this.pivotGrid1.RowHeaderCellStyle.ToolTipEnabled = (sender as CheckBox).IsChecked ?? false;
            this.pivotGrid1.InvalidateCells();
        }

        private void chkBoxValCell_Click(object sender, RoutedEventArgs e)
        {
            this.chkBoxCustomValCell.IsEnabled = (sender as CheckBox).IsChecked ?? false;
            this.pivotGrid1.ValueCellStyle.ToolTipEnabled = (sender as CheckBox).IsChecked ?? false;
            this.pivotGrid1.InvalidateCells();
        }

        private void chkBoxSumHeader_Click(object sender, RoutedEventArgs e)
        {
            this.chkBoxCustomSumHeader.IsEnabled = (sender as CheckBox).IsChecked ?? false;
            this.pivotGrid1.SummaryHeaderStyle.ToolTipEnabled = (sender as CheckBox).IsChecked ?? false;
            this.pivotGrid1.InvalidateCells();
        }

        private void chkBoxSumCell_Click(object sender, RoutedEventArgs e)
        {
            this.chkBoxCustomSumCell.IsEnabled = (sender as CheckBox).IsChecked ?? false;
            this.pivotGrid1.SummaryCellStyle.ToolTipEnabled = (sender as CheckBox).IsChecked ?? false;
            this.pivotGrid1.InvalidateCells();
        }

        private void chkBoxCustomColHeader_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
                this.pivotGrid1.ColumnHeaderCellStyle.CustomToolTipTemplateKey = "ColumnTemplateTooltip";
            else
            {
                this.pivotGrid1.ColumnHeaderCellStyle.CustomToolTipTemplateKey = null;
                SetCustomTooltip();
            }
            this.pivotGrid1.InvalidateCells();
        }

        private void chkBoxCustomRowHeader_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
                this.pivotGrid1.RowHeaderCellStyle.CustomToolTipTemplateKey = "RowTemplateTooltip";
            else
            {
                this.pivotGrid1.RowHeaderCellStyle.CustomToolTipTemplateKey = null;
                SetCustomTooltip();
            }
        }

        private void chkBoxCustomValCell_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
                this.pivotGrid1.ValueCellStyle.CustomToolTipTemplateKey = "ValueTemplateTooltip";
            else
            {
                this.pivotGrid1.ValueCellStyle.CustomToolTipTemplateKey = null;
                SetCustomTooltip();
            }
            this.pivotGrid1.InvalidateCells();
        }

        private void chkBoxCustomSumHeader_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
                this.pivotGrid1.SummaryHeaderStyle.CustomToolTipTemplateKey = "SummaryHeaderTemplateTooltip";
            else
            {
                this.pivotGrid1.CustomToolTipTemplateKey = null;
                SetCustomTooltip();
            }
            this.pivotGrid1.InvalidateCells();
        }

        private void chkBoxCustomSumCell_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
                this.pivotGrid1.SummaryCellStyle.CustomToolTipTemplateKey = "SummaryCellTemplateTooltip";
            else
            {
                this.pivotGrid1.CustomToolTipTemplateKey = null;
                SetCustomTooltip();
            }
            this.pivotGrid1.InvalidateCells();
        }

        private void chkBoxEnableCustom_All_Click(object sender, RoutedEventArgs e)
        {
            this.chkBoxCustomColHeader.IsChecked = (sender as CheckBox).IsChecked ?? false;
            this.chkBoxCustomRowHeader.IsChecked = (sender as CheckBox).IsChecked ?? false;
            this.chkBoxCustomValCell.IsChecked = (sender as CheckBox).IsChecked ?? false;
            this.chkBoxCustomSumHeader.IsChecked = (sender as CheckBox).IsChecked ?? false;
            this.chkBoxCustomSumCell.IsChecked = (sender as CheckBox).IsChecked ?? false;
            if ((sender as CheckBox).IsChecked == true)
                this.pivotGrid1.CustomToolTipTemplateKey = "CustomTemplateTooltip";
            else
                this.pivotGrid1.CustomToolTipTemplateKey = null;
            this.pivotGrid1.InvalidateCells();
        }

        private void SetCustomTooltip()
        {
            this.pivotGrid1.CustomToolTipTemplateKey = null;
            if (chkBoxCustomColHeader.IsChecked == true)
                this.pivotGrid1.ColumnHeaderCellStyle.CustomToolTipTemplateKey = "ColumnTemplateTooltip";
            if (chkBoxCustomRowHeader.IsChecked == true)
                this.pivotGrid1.RowHeaderCellStyle.CustomToolTipTemplateKey = "RowTemplateTooltip";
            if (chkBoxCustomValCell.IsChecked == true)
                this.pivotGrid1.ValueCellStyle.CustomToolTipTemplateKey = "ValueTemplateTooltip";
            if (chkBoxCustomSumHeader.IsChecked == true)
                this.pivotGrid1.SummaryHeaderStyle.CustomToolTipTemplateKey = "SummaryHeaderTemplateTooltip";
            if (chkBoxCustomSumCell.IsChecked == true)
                this.pivotGrid1.SummaryCellStyle.CustomToolTipTemplateKey = "SummaryCellTemplateTooltip";

        }

        private void chkBoxToolTipEnabled_Click(object sender, RoutedEventArgs e)
        {
            this.tooltipGroupBox.IsEnabled = (sender as CheckBox).IsChecked ?? false;
            this.customTooltipGroupBox.IsEnabled = (sender as CheckBox).IsChecked ?? false;
            this.chkBoxColHeader.IsChecked = (sender as CheckBox).IsChecked ?? false;
            this.chkBoxRowHeader.IsChecked = (sender as CheckBox).IsChecked ?? false;
            this.chkBoxValCell.IsChecked = (sender as CheckBox).IsChecked ?? false;
            this.chkBoxSumHeader.IsChecked = (sender as CheckBox).IsChecked ?? false;
            this.chkBoxSumCell.IsChecked = (sender as CheckBox).IsChecked ?? false;
        }
    }
}
