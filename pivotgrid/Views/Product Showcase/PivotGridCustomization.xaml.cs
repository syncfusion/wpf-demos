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
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public partial class PivotGridCustomization : DemoControl
    {
        static int count;
        int index;

        public PivotGridCustomization()
        {
            InitializeComponent();
            this.btnCollapseAllGroup.CommandTarget = this.pivotGrid1;
            this.btnExpandAllGroup.CommandTarget = this.pivotGrid1;
            this.pivotGrid1.Loaded += PivotGrid1_Loaded;
            this.combo1.SelectionChanged += Combo1_SelectionChanged;
            this.comboGridLayout.SelectionChanged += ComboGridLayout_SelectionChanged;
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            this.combo1.SelectionChanged -= Combo1_SelectionChanged;
            this.comboGridLayout.SelectionChanged -= ComboGridLayout_SelectionChanged;
            this.chkShowGrandTotal.Click -= chkShowGrandTotal_Click;
            this.chkShowCalculationsAsColumns.Click -= chkShowCalculationsAsColumns_Click;
            this.chkShowSubTotals.Click -= chkShowSubTotals_Click;
            this.chkShowProductSubTotals.Click -= chkShowProductSubTotals_Click;
            this.chkShowDateSubTotals.Click -= chkShowDateSubTotals_Click;
            this.chkShowCountrySubTotals.Click -= chkShowCountrySubTotals_Click;
            this.chkShowStateSubTotals.Click -= chkShowStateSubTotals_Click;
            this.chkShowRowSubTotals.Click -= chkShowRowSubTotals_Click;
            this.chkShowColumnSubTotals.Click -= chkShowColumnSubTotals_Click;
            this.chkFreezeHeaders.Click -= chkFreezeHeaders_Click;
            this.ShowExpander.Click -= ShowExpander_Click;
            this.Resize.Click -= Resize_Click;
            if (this.pivotGrid1 != null)
            {
                this.pivotGrid1.Loaded -= PivotGrid1_Loaded;
                this.pivotGrid1.Dispose();
                this.pivotGrid1 = null;
            }
            base.Dispose(disposing);
        }

        private void ComboGridLayout_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmbBox = sender as ComboBox;
            switch (cmbBox.SelectedItem.ToString())
            {
                case "Normal":
                    pivotGrid1.GridLayout = Syncfusion.PivotAnalysis.Base.GridLayout.Normal;
                    if (ShowSubTotalGroupBox != null && chkShowCalculationsAsColumns != null)
                    {
                        ShowSubTotalGroupBox.IsEnabled = true;
                        chkShowCalculationsAsColumns.IsEnabled = true;
                    }
                    break;
                case "Top Summary":
                    pivotGrid1.GridLayout = Syncfusion.PivotAnalysis.Base.GridLayout.TopSummary;
                    if (ShowSubTotalGroupBox != null && chkShowCalculationsAsColumns != null)
                    {
                        ShowSubTotalGroupBox.IsEnabled = true;
                        chkShowCalculationsAsColumns.IsEnabled = true;
                    }
                    break;
                case "Excel Like Layout":
                    pivotGrid1.GridLayout = Syncfusion.PivotAnalysis.Base.GridLayout.ExcelLikeLayout;
                    if (ShowSubTotalGroupBox != null && chkShowCalculationsAsColumns != null)
                    {
                        ShowSubTotalGroupBox.IsEnabled = false;
                        chkShowCalculationsAsColumns.IsEnabled = false;
                    }
                    break;
            }
        }

        private void Combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.pivotGrid1.GridLineStroke = (SolidColorBrush)new BrushConverter().ConvertFromString(combo1.SelectedItem.ToString());
        }

        private void PivotGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            this.SchemaDesigner.PivotControl = this.pivotGrid1;
        }

        private void chkShowSubTotals_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                this.pivotGrid1.ShowSubTotals = true;
                chkShowProductSubTotals.IsChecked = true;
                chkShowCountrySubTotals.IsChecked = true;
                chkShowDateSubTotals.IsChecked = true;
                chkShowStateSubTotals.IsChecked = true;
                chkShowRowSubTotals.IsChecked = true;
                chkShowColumnSubTotals.IsChecked = true;
                for (int i = 0; i < this.pivotGrid1.PivotRows.Count; i++)
                    this.pivotGrid1.PivotRows[i].ShowSubTotal = true;
                for (int i = 0; i < this.pivotGrid1.PivotColumns.Count; i++)
                    this.pivotGrid1.PivotColumns[i].ShowSubTotal = true;

                count = 0;
            }
            else
            {
                this.pivotGrid1.ShowSubTotals = false;
                chkShowProductSubTotals.IsChecked = false;
                chkShowCountrySubTotals.IsChecked = false;
                chkShowDateSubTotals.IsChecked = false;
                chkShowStateSubTotals.IsChecked = false;
                chkShowRowSubTotals.IsChecked = false;
                chkShowColumnSubTotals.IsChecked = false;
                for (int i = 0; i < this.pivotGrid1.PivotRows.Count; i++)
                    this.pivotGrid1.PivotRows[i].ShowSubTotal = false;
                for (int i = 0; i < this.pivotGrid1.PivotColumns.Count; i++)
                    this.pivotGrid1.PivotColumns[i].ShowSubTotal = false;

                count = 4;
            }
            this.pivotGrid1.InvalidateCells();
            if (count == 0)
                chkShowSubTotals.IsChecked = true;
            else if (count < 4)
                chkShowSubTotals.IsChecked = null;
            else if (count == 4)
                chkShowSubTotals.IsChecked = false;
        }

        private void chkShowProductSubTotals_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                if (this.pivotGrid1.PivotCalculations.Any(i => i.FieldName == "Product"))
                {
                    this.pivotGrid1.ShowSubTotals = true;
                    count--;
                }
                if (this.pivotGrid1.GroupingBar.Filters.Any(i => i.Name == "Product"))
                {
                    index =
                        this.pivotGrid1.GroupingBar.Filters.IndexOf(
                            this.pivotGrid1.GroupingBar.Filters.FirstOrDefault(x => x.Name == "Product"));
                    if (index >= 0)
                    {
                        this.pivotGrid1.ShowSubTotals = true;
                        this.pivotGrid1.GroupingBar.Filters[index].ShowSubTotal = true;
                        count--;
                    }
                }
                index =
                    this.pivotGrid1.PivotRows.IndexOf(
                        this.pivotGrid1.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Product"));
                if (index >= 0)
                {
                    this.pivotGrid1.ShowSubTotals = true;
                    this.pivotGrid1.PivotRows[index].ShowSubTotal = true;
                    count--;
                }
                else
                {
                    index =
                        this.pivotGrid1.PivotColumns.IndexOf(
                            this.pivotGrid1.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Product"));
                    if (index >= 0)
                    {
                        this.pivotGrid1.ShowSubTotals = true;
                        this.pivotGrid1.PivotColumns[index].ShowSubTotal = true;
                        count--;
                    }
                }
            }
            else
            {
                index =
                    this.pivotGrid1.PivotRows.IndexOf(
                        this.pivotGrid1.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Product"));
                if (index >= 0)
                {
                    this.pivotGrid1.PivotRows[index].ShowSubTotal = false;
                    count++;
                }
                else
                {
                    index =
                        this.pivotGrid1.PivotColumns.IndexOf(
                            this.pivotGrid1.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Product"));
                    if (index >= 0)
                    {
                        this.pivotGrid1.PivotColumns[index].ShowSubTotal = false;
                        count++;
                    }
                }
            }
            this.pivotGrid1.InvalidateCells();
            if (count == 0)
                chkShowSubTotals.IsChecked = true;
            else if (count < 4)
                chkShowSubTotals.IsChecked = null;
            else if (count == 4)
                chkShowSubTotals.IsChecked = false;
        }

        private void chkShowDateSubTotals_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                if (this.pivotGrid1.PivotCalculations.Any(i => i.FieldName == "Date"))
                {
                    this.pivotGrid1.ShowSubTotals = true;
                    count--;
                }
                if (this.pivotGrid1.GroupingBar.Filters.Any(i => i.Name == "Date"))
                {
                    index =
                        this.pivotGrid1.GroupingBar.Filters.IndexOf(
                            this.pivotGrid1.GroupingBar.Filters.FirstOrDefault(x => x.Name == "Date"));
                    if (index >= 0)
                    {
                        this.pivotGrid1.ShowSubTotals = true;
                        this.pivotGrid1.GroupingBar.Filters[index].ShowSubTotal = true;
                        count--;
                    }
                }
                index =
                    this.pivotGrid1.PivotRows.IndexOf(this.pivotGrid1.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Date"));
                if (index >= 0)
                {
                    this.pivotGrid1.ShowSubTotals = true;
                    this.pivotGrid1.PivotRows[index].ShowSubTotal = true;
                    count--;
                }
                else
                {
                    index =
                        this.pivotGrid1.PivotColumns.IndexOf(
                            this.pivotGrid1.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Date"));
                    if (index >= 0)
                    {
                        this.pivotGrid1.ShowSubTotals = true;
                        this.pivotGrid1.PivotColumns[index].ShowSubTotal = true;
                        count--;
                    }
                }
            }
            else
            {
                index =
                    this.pivotGrid1.PivotRows.IndexOf(this.pivotGrid1.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Date"));
                if (index >= 0)
                {
                    this.pivotGrid1.PivotRows[index].ShowSubTotal = false;
                    count++;
                }
                else
                {
                    index =
                        this.pivotGrid1.PivotColumns.IndexOf(
                            this.pivotGrid1.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Date"));
                    if (index >= 0)
                    {
                        this.pivotGrid1.PivotColumns[index].ShowSubTotal = false;
                        count++;
                    }
                }
            }
            this.pivotGrid1.InvalidateCells();
            if (count == 0)
                chkShowSubTotals.IsChecked = true;
            else if (count < 4)
                chkShowSubTotals.IsChecked = null;
            else if (count == 4)
                chkShowSubTotals.IsChecked = false;
        }

        private void chkShowCountrySubTotals_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                if (this.pivotGrid1.PivotCalculations.Any(i => i.FieldName == "Country"))
                {
                    this.pivotGrid1.ShowSubTotals = true;
                    count--;
                }
                if (this.pivotGrid1.GroupingBar.Filters.Any(i => i.Name == "Country"))
                {
                    index =
                        this.pivotGrid1.GroupingBar.Filters.IndexOf(
                            this.pivotGrid1.GroupingBar.Filters.FirstOrDefault(x => x.Name == "Country"));
                    if (index >= 0)
                    {
                        this.pivotGrid1.ShowSubTotals = true;
                        this.pivotGrid1.GroupingBar.Filters[index].ShowSubTotal = true;
                        count--;
                    }
                }
                index =
                    this.pivotGrid1.PivotColumns.IndexOf(
                        this.pivotGrid1.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Country"));
                if (index >= 0)
                {
                    this.pivotGrid1.ShowSubTotals = true;
                    this.pivotGrid1.PivotColumns[index].ShowSubTotal = true;
                    count--;
                }
                else
                {
                    index =
                        this.pivotGrid1.PivotRows.IndexOf(
                            this.pivotGrid1.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Country"));
                    if (index >= 0)
                    {
                        this.pivotGrid1.ShowSubTotals = true;
                        this.pivotGrid1.PivotRows[index].ShowSubTotal = true;
                        count--;
                    }
                }
            }
            else
            {
                index =
                    this.pivotGrid1.PivotColumns.IndexOf(
                        this.pivotGrid1.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Country"));
                if (index >= 0)
                {
                    this.pivotGrid1.PivotColumns[index].ShowSubTotal = false;
                    count++;
                }
                else
                {
                    index =
                        this.pivotGrid1.PivotRows.IndexOf(
                            this.pivotGrid1.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Country"));
                    if (index >= 0)
                    {
                        this.pivotGrid1.PivotRows[index].ShowSubTotal = false;
                        count++;
                    }
                }
            }
            this.pivotGrid1.InvalidateCells();
            if (count == 0)
                chkShowSubTotals.IsChecked = true;
            else if (count < 4)
                chkShowSubTotals.IsChecked = null;
            else if (count == 4)
                chkShowSubTotals.IsChecked = false;
        }

        private void chkShowStateSubTotals_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                if (this.pivotGrid1.PivotCalculations.Any(i => i.FieldName == "State"))
                {
                    this.pivotGrid1.ShowSubTotals = true;
                    count--;
                }
                if (this.pivotGrid1.GroupingBar.Filters.Any(i => i.Name == "State"))
                {
                    index =
                        this.pivotGrid1.GroupingBar.Filters.IndexOf(
                            this.pivotGrid1.GroupingBar.Filters.FirstOrDefault(x => x.Name == "State"));
                    if (index >= 0)
                    {
                        this.pivotGrid1.ShowSubTotals = true;
                        this.pivotGrid1.GroupingBar.Filters[index].ShowSubTotal = true;
                        count--;
                    }
                }
                index =
                    this.pivotGrid1.PivotColumns.IndexOf(
                        this.pivotGrid1.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "State"));
                if (index >= 0)
                {
                    this.pivotGrid1.ShowSubTotals = true;
                    this.pivotGrid1.PivotColumns[index].ShowSubTotal = true;
                    count--;
                }
                else
                {
                    index =
                        this.pivotGrid1.PivotRows.IndexOf(
                            this.pivotGrid1.PivotRows.FirstOrDefault(x => x.FieldMappingName == "State"));
                    if (index >= 0)
                    {
                        this.pivotGrid1.ShowSubTotals = true;
                        this.pivotGrid1.PivotRows[index].ShowSubTotal = true;
                        count--;
                    }
                }
            }
            else
            {
                index =
                    this.pivotGrid1.PivotColumns.IndexOf(
                        this.pivotGrid1.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "State"));
                if (index >= 0)
                {
                    this.pivotGrid1.PivotColumns[index].ShowSubTotal = false;
                    count++;
                }
                else
                {
                    index =
                        this.pivotGrid1.PivotRows.IndexOf(
                            this.pivotGrid1.PivotRows.FirstOrDefault(x => x.FieldMappingName == "State"));
                    if (index >= 0)
                    {
                        this.pivotGrid1.PivotRows[index].ShowSubTotal = false;
                        count++;
                    }
                }
            }
            this.pivotGrid1.InvalidateCells();
            if (count == 0)
                chkShowSubTotals.IsChecked = true;
            else if (count < 4)
                chkShowSubTotals.IsChecked = null;
            else if (count == 4)
                chkShowSubTotals.IsChecked = false;
        }

        private void chkShowRowSubTotals_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                this.pivotGrid1.ShowRowSubTotals = true;
                chkShowProductSubTotals.IsChecked = true;
                chkShowDateSubTotals.IsChecked = true;
                for (int i = 0; i < this.pivotGrid1.PivotRows.Count; i++)
                    this.pivotGrid1.PivotRows[i].ShowSubTotal = true;
                count = 0;
            }
            else
            {
                this.pivotGrid1.ShowRowSubTotals = false;
                chkShowProductSubTotals.IsChecked = false;
                chkShowDateSubTotals.IsChecked = false;
            }
            if (count == 0)
                chkShowSubTotals.IsChecked = true;
            else if (count < 4)
                chkShowSubTotals.IsChecked = null;
            else if (count == 4)
                chkShowSubTotals.IsChecked = false;
        }

        private void chkShowColumnSubTotals_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                this.pivotGrid1.ShowColumnSubTotals = true;
                chkShowCountrySubTotals.IsChecked = true;
                chkShowStateSubTotals.IsChecked = true;
                for (int i = 0; i < this.pivotGrid1.PivotColumns.Count; i++)
                    this.pivotGrid1.PivotColumns[i].ShowSubTotal = true;
                count = 0;
            }
            else
            {
                this.pivotGrid1.ShowColumnSubTotals = false;
                chkShowCountrySubTotals.IsChecked = false;
                chkShowStateSubTotals.IsChecked = false;
            }
            if (count == 0)
                chkShowSubTotals.IsChecked = true;
            else if (count < 4)
                chkShowSubTotals.IsChecked = null;
            else if (count == 4)
                chkShowSubTotals.IsChecked = false;
        }

        private void Resize_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.ResizePivotGridToFit = (sender as CheckBox).IsChecked ?? false;
        }

        private void ShowExpander_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.ShowExpanderForSinglePivot = (sender as CheckBox).IsChecked ?? false;
            this.pivotGrid1.InvalidateCells();
        }

        private void chkFreezeHeaders_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.FreezeHeaders = (sender as CheckBox).IsChecked ?? false;
        }

        private void chkShowGrandTotal_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.ShowGrandTotals = (sender as CheckBox).IsChecked ?? false;
        }

        private void chkShowCalculationsAsColumns_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.ShowCalculationsAsColumns = (sender as CheckBox).IsChecked ?? false;
        }
    }
}
