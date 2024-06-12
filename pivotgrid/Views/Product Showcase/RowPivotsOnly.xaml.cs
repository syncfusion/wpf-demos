#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System.Windows;
    using System.Windows.Controls;

    public partial class RowPivotsOnly : DemoControl
    {
        public RowPivotsOnly()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            this.MouseHyperLinks.Click -= MouseHyperLinks_Click;
            this.HideSummaryValue.Click -= HideSummaryValue_Click;
            this.PadString.Click -= PadString_Click;
            this.EnableContextMenu.Click -= EnableContextMenu_Click;
            this.Filtering.Click -= Filtering_Click;
            this.Sorting.Click -= Sorting_Click;
            if (this.pivotGridControl1 != null)
            {
                this.pivotGridControl1.Dispose();
                this.pivotGridControl1 = null;
            }
            base.Dispose(disposing);
        }

        private void MouseHyperLinks_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGridControl1.EnableHyperlinkOnMouseOver = (sender as CheckBox).IsChecked ?? false;
            for (int i = 0; i < this.pivotGridControl1.PivotEngine.PivotCalculations.Count; i++)
                this.pivotGridControl1.PivotEngine.PivotCalculations[i].EnableHyperlinks = (sender as CheckBox).IsChecked ?? false;
            this.pivotGridControl1.InvalidateCells();
        }

        private void HideSummaryValue_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                for (int i = 0; i < this.pivotGridControl1.PivotEngine.PivotCalculations.Count; i++)
                    this.pivotGridControl1.PivotEngine.PivotCalculations[i].InnerMostComputationsOnly = Syncfusion.PivotAnalysis.Base.SummaryDisplayLevel.InnerMostOnly;
            }
            else
            {
                for (int i = 0; i < this.pivotGridControl1.PivotEngine.PivotCalculations.Count; i++)
                    this.pivotGridControl1.PivotEngine.PivotCalculations[i].InnerMostComputationsOnly = Syncfusion.PivotAnalysis.Base.SummaryDisplayLevel.All;
            }
            this.pivotGridControl1.InvalidateCells();
        }

        private void PadString_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                for (int i = 0; i < this.pivotGridControl1.PivotCalculations.Count; i++)
                {
                    if (this.pivotGridControl1.PivotCalculations[i].PadString != "*")
                        this.pivotGridControl1.InternalGrid.Model.ColumnWidths.SetHidden((i + this.pivotGridControl1.PivotRows.Count), (i + this.pivotGridControl1.PivotRows.Count), false);
                    else
                        this.pivotGridControl1.InternalGrid.Model.ColumnWidths.SetHidden((i + this.pivotGridControl1.PivotRows.Count), (i + this.pivotGridControl1.PivotRows.Count), true);
                }
            }
            else
            {
                for (int i = 0; i < this.pivotGridControl1.PivotCalculations.Count; i++)
                {
                    if (this.pivotGridControl1.PivotCalculations[i].PadString != "*")
                        this.pivotGridControl1.InternalGrid.Model.ColumnWidths.SetHidden((i + this.pivotGridControl1.PivotRows.Count), (i + this.pivotGridControl1.PivotRows.Count), true);
                    else
                        this.pivotGridControl1.InternalGrid.Model.ColumnWidths.SetHidden((i + this.pivotGridControl1.PivotRows.Count), (i + this.pivotGridControl1.PivotRows.Count), false);
                }
            }
            this.pivotGridControl1.InvalidateCells();
        }

        private void EnableContextMenu_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGridControl1.ColumnHeaderCellStyle.EnableContextMenu = (sender as CheckBox).IsChecked ?? false;
            this.pivotGridControl1.RowHeaderCellStyle.EnableContextMenu = (sender as CheckBox).IsChecked ?? false;
            this.pivotGridControl1.InvalidateCells();
        }

        private void Filtering_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < this.pivotGridControl1.PivotEngine.PivotCalculations.Count; i++)
                this.pivotGridControl1.PivotEngine.PivotCalculations[i].AllowFilter = (sender as CheckBox).IsChecked ?? false;
            this.pivotGridControl1.InvalidateCells();
        }

        private void Sorting_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < this.pivotGridControl1.PivotEngine.PivotCalculations.Count; i++)
                this.pivotGridControl1.PivotEngine.PivotCalculations[i].AllowSort = (sender as CheckBox).IsChecked ?? false;
            if ((sender as CheckBox).IsChecked == false)
                this.pivotGridControl1.PivotEngine.ClearSorts();
            this.pivotGridControl1.InvalidateCells();
        }
    }
}
