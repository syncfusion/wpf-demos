#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace PivotGridCustomization.Action
{
    using System.Linq;
    using System.Windows.Interactivity;
    using Syncfusion.Windows.Controls.PivotGrid;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    class SubtotalVisibilityChangedAction : TargetedTriggerAction<Grid>
    {
        static int count;

        protected override void Invoke(object parameter)
        {
            RoutedEventArgs eventArgs = parameter as RoutedEventArgs;
            CheckBox current = eventArgs != null ? eventArgs.OriginalSource as CheckBox : null;
            PivotGridControl pivot = (this.Target.Children[1] is Grid) ? (this.Target.Children[1] as Grid).Children[0] as PivotGridControl : null;
            TabControl TabControlExt = VisualTreeHelper.GetChild(Target.Children[1], 2) as TabControl;
            GroupBox subtotalGroupBox = TabControlExt != null ? TabControlExt.FindName("ShowSubTotalGroupBox") as GroupBox : null;
            CheckBox showAllSubTotals = subtotalGroupBox != null ? subtotalGroupBox.FindName("chkShowSubTotals") as CheckBox : null;
            CheckBox showProductSubTotals = subtotalGroupBox != null ? subtotalGroupBox.FindName("chkShowProductSubTotals") as CheckBox : null;
            CheckBox showDateSubTotals = subtotalGroupBox != null ? subtotalGroupBox.FindName("chkShowDateSubTotals") as CheckBox : null;
            CheckBox showCountrySubTotals = subtotalGroupBox != null ? subtotalGroupBox.FindName("chkShowCountrySubTotals") as CheckBox : null;
            CheckBox showStateSubTotals =subtotalGroupBox != null ? subtotalGroupBox.FindName("chkShowStateSubTotals") as CheckBox : null;
            CheckBox showRowSubTotals = subtotalGroupBox != null ? subtotalGroupBox.FindName("chkShowRowSubTotals") as CheckBox : null;
            CheckBox showColumnSubTotals =subtotalGroupBox != null ? subtotalGroupBox.FindName("chkShowColumnSubTotals") as CheckBox : null;

            ComboBox cmbBox = eventArgs != null ? eventArgs.OriginalSource as ComboBox : null;
            CheckBox showCalculationAsColumnsCheckBox = TabControlExt.FindName("chkShowCalculationsAsColumns") as CheckBox;

            if (cmbBox != null)
            {
                switch(cmbBox.SelectedItem.ToString())
                {
                    case "Normal":
                        pivot.GridLayout = Syncfusion.PivotAnalysis.Base.GridLayout.Normal;
                        if (subtotalGroupBox != null && showCalculationAsColumnsCheckBox != null)
                        {
                            subtotalGroupBox.IsEnabled = true;
                            showCalculationAsColumnsCheckBox.IsEnabled = true;
                        }
                        break;
                    case "Top Summary":
                        pivot.GridLayout = Syncfusion.PivotAnalysis.Base.GridLayout.TopSummary;
                        if (subtotalGroupBox != null && showCalculationAsColumnsCheckBox != null)
                        {
                            subtotalGroupBox.IsEnabled = true;
                            showCalculationAsColumnsCheckBox.IsEnabled = true;
                        }
                        break;
                    case "Excel Like Layout":
                        pivot.GridLayout = Syncfusion.PivotAnalysis.Base.GridLayout.ExcelLikeLayout;
                        if (subtotalGroupBox != null && showCalculationAsColumnsCheckBox != null)
                        {
                            subtotalGroupBox.IsEnabled = false;
                            showCalculationAsColumnsCheckBox.IsEnabled = false;
                        }
                        break;
                }
            }

            if (pivot != null && current != null && current.Content != null)
            {
                int index;
                switch (current.Content.ToString())
                {
                    case "Show Product Subtotals":

                        if (current.IsChecked == true)
                        {
                            if (pivot.PivotCalculations.Any(i => i.FieldName == "Product"))
                            {
                                pivot.ShowSubTotals = true;
                                count--;
                            }
                            if (pivot.GroupingBar.Filters.Any(i => i.Name == "Product"))
                            {
                                index =
                                    pivot.GroupingBar.Filters.IndexOf(
                                        pivot.GroupingBar.Filters.FirstOrDefault(x => x.Name == "Product"));
                                if (index >= 0)
                                {
                                    pivot.ShowSubTotals = true;
                                    pivot.GroupingBar.Filters[index].ShowSubTotal = true;
                                    count--;
                                }
                            }
                            index =
                                pivot.PivotRows.IndexOf(
                                    pivot.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Product"));
                            if (index >= 0)
                            {
                                pivot.ShowSubTotals = true;
                                pivot.PivotRows[index].ShowSubTotal = true;
                                count--;
                            }
                            else
                            {
                                index =
                                    pivot.PivotColumns.IndexOf(
                                        pivot.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Product"));
                                if (index >= 0)
                                {
                                    pivot.ShowSubTotals = true;
                                    pivot.PivotColumns[index].ShowSubTotal = true;
                                    count--;
                                }
                            }
                        }
                        else
                        {
                            index =
                                pivot.PivotRows.IndexOf(
                                    pivot.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Product"));
                            if (index >= 0)
                            {
                                pivot.PivotRows[index].ShowSubTotal = false;
                                count++;
                            }
                            else
                            {
                                index =
                                    pivot.PivotColumns.IndexOf(
                                        pivot.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Product"));
                                if (index >= 0)
                                {
                                    pivot.PivotColumns[index].ShowSubTotal = false;
                                    count++;
                                }
                            }
                        }
                        pivot.InvalidateCells();

                        break;
                    case "Show Country Subtotals":
                        if (current.IsChecked == true)
                        {
                            if (pivot.PivotCalculations.Any(i => i.FieldName == "Country"))
                            {
                                pivot.ShowSubTotals = true;
                                count--;
                            }
                            if (pivot.GroupingBar.Filters.Any(i => i.Name == "Country"))
                            {
                                index =
                                    pivot.GroupingBar.Filters.IndexOf(
                                        pivot.GroupingBar.Filters.FirstOrDefault(x => x.Name == "Country"));
                                if (index >= 0)
                                {
                                    pivot.ShowSubTotals = true;
                                    pivot.GroupingBar.Filters[index].ShowSubTotal = true;
                                    count--;
                                }
                            }
                            index =
                                pivot.PivotColumns.IndexOf(
                                    pivot.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Country"));
                            if (index >= 0)
                            {
                                pivot.ShowSubTotals = true;
                                pivot.PivotColumns[index].ShowSubTotal = true;
                                count--;
                            }
                            else
                            {
                                index =
                                    pivot.PivotRows.IndexOf(
                                        pivot.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Country"));
                                if (index >= 0)
                                {
                                    pivot.ShowSubTotals = true;
                                    pivot.PivotRows[index].ShowSubTotal = true;
                                    count--;
                                }
                            }
                        }
                        else
                        {
                            index =
                                pivot.PivotColumns.IndexOf(
                                    pivot.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Country"));
                            if (index >= 0)
                            {
                                pivot.PivotColumns[index].ShowSubTotal = false;
                                count++;
                            }
                            else
                            {
                                index =
                                    pivot.PivotRows.IndexOf(
                                        pivot.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Country"));
                                if (index >= 0)
                                {
                                    pivot.PivotRows[index].ShowSubTotal = false;
                                    count++;
                                }
                            }
                        }
                        pivot.InvalidateCells();
                        break;
                    case "Show Date Subtotals":
                        if (current.IsChecked == true)
                        {
                            if (pivot.PivotCalculations.Any(i => i.FieldName == "Date"))
                            {
                                pivot.ShowSubTotals = true;
                                count--;
                            }
                            if (pivot.GroupingBar.Filters.Any(i => i.Name == "Date"))
                            {
                                index =
                                    pivot.GroupingBar.Filters.IndexOf(
                                        pivot.GroupingBar.Filters.FirstOrDefault(x => x.Name == "Date"));
                                if (index >= 0)
                                {
                                    pivot.ShowSubTotals = true;
                                    pivot.GroupingBar.Filters[index].ShowSubTotal = true;
                                    count--;
                                }
                            }
                            index =
                                pivot.PivotRows.IndexOf(pivot.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Date"));
                            if (index >= 0)
                            {
                                pivot.ShowSubTotals = true;
                                pivot.PivotRows[index].ShowSubTotal = true;
                                count--;
                            }
                            else
                            {
                                index =
                                    pivot.PivotColumns.IndexOf(
                                        pivot.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Date"));
                                if (index >= 0)
                                {
                                    pivot.ShowSubTotals = true;
                                    pivot.PivotColumns[index].ShowSubTotal = true;
                                    count--;
                                }
                            }
                        }
                        else
                        {
                            index =
                                pivot.PivotRows.IndexOf(pivot.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Date"));
                            if (index >= 0)
                            {
                                pivot.PivotRows[index].ShowSubTotal = false;
                                count++;
                            }
                            else
                            {
                                index =
                                    pivot.PivotColumns.IndexOf(
                                        pivot.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Date"));
                                if (index >= 0)
                                {
                                    pivot.PivotColumns[index].ShowSubTotal = false;
                                    count++;
                                }
                            }
                        }
                        pivot.InvalidateCells();
                        break;
                    case "Show State Subtotals":
                        if (current.IsChecked == true)
                        {
                            if (pivot.PivotCalculations.Any(i => i.FieldName == "State"))
                            {
                                pivot.ShowSubTotals = true;
                                count--;
                            }
                            if (pivot.GroupingBar.Filters.Any(i => i.Name == "State"))
                            {
                                index =
                                    pivot.GroupingBar.Filters.IndexOf(
                                        pivot.GroupingBar.Filters.FirstOrDefault(x => x.Name == "State"));
                                if (index >= 0)
                                {
                                    pivot.ShowSubTotals = true;
                                    pivot.GroupingBar.Filters[index].ShowSubTotal = true;
                                    count--;
                                }
                            }
                            index =
                                pivot.PivotColumns.IndexOf(
                                    pivot.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "State"));
                            if (index >= 0)
                            {
                                pivot.ShowSubTotals = true;
                                pivot.PivotColumns[index].ShowSubTotal = true;
                                count--;
                            }
                            else
                            {
                                index =
                                    pivot.PivotRows.IndexOf(
                                        pivot.PivotRows.FirstOrDefault(x => x.FieldMappingName == "State"));
                                if (index >= 0)
                                {
                                    pivot.ShowSubTotals = true;
                                    pivot.PivotRows[index].ShowSubTotal = true;
                                    count--;
                                }
                            }
                        }
                        else
                        {
                            index =
                                pivot.PivotColumns.IndexOf(
                                    pivot.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "State"));
                            if (index >= 0)
                            {
                                pivot.PivotColumns[index].ShowSubTotal = false;
                                count++;
                            }
                            else
                            {
                                index =
                                    pivot.PivotRows.IndexOf(
                                        pivot.PivotRows.FirstOrDefault(x => x.FieldMappingName == "State"));
                                if (index >= 0)
                                {
                                    pivot.PivotRows[index].ShowSubTotal = false;
                                    count++;
                                }
                            }
                        }
                        pivot.InvalidateCells();

                        break;
                    case "Show Row Subtotals":
                        if (current.IsChecked == true)
                        {
                            pivot.ShowRowSubTotals = true;
                            showProductSubTotals.IsChecked = true;
                            showDateSubTotals.IsChecked = true;
                            for (int i = 0; i < pivot.PivotRows.Count; i++)
                                pivot.PivotRows[i].ShowSubTotal = true;
                            count = 0;
                        }
                        else
                        {
                            pivot.ShowRowSubTotals = false;
                            showProductSubTotals.IsChecked = false;
                            showDateSubTotals.IsChecked = false;
                        }
                        break;
                    case "Show Column Subtotals":
                        if (current.IsChecked == true)
                        {
                            pivot.ShowColumnSubTotals = true;
                            showCountrySubTotals.IsChecked = true;
                            showStateSubTotals.IsChecked = true;
                            for (int i = 0; i < pivot.PivotColumns.Count; i++)
                                pivot.PivotColumns[i].ShowSubTotal = true;
                            count = 0;
                        }
                        else
                        {
                            pivot.ShowColumnSubTotals = false;
                            showCountrySubTotals.IsChecked = false;
                            showStateSubTotals.IsChecked = false;
                        }
                        break;
                    case "Show Subtotals":
                        if (current.IsChecked == true)
                        {
                            pivot.ShowSubTotals = true;
                            showProductSubTotals.IsChecked = true;
                            showCountrySubTotals.IsChecked = true;
                            showDateSubTotals.IsChecked = true;
                            showStateSubTotals.IsChecked = true;
                            showRowSubTotals.IsChecked = true;
                            showColumnSubTotals.IsChecked = true;
                            for (int i = 0; i < pivot.PivotRows.Count; i++)
                                pivot.PivotRows[i].ShowSubTotal = true;
                            for (int i = 0; i < pivot.PivotColumns.Count; i++)
                                pivot.PivotColumns[i].ShowSubTotal = true;

                            count = 0;
                        }
                        else
                        {
                            pivot.ShowSubTotals = false;
                            showProductSubTotals.IsChecked = false;
                            showCountrySubTotals.IsChecked = false;
                            showDateSubTotals.IsChecked = false;
                            showStateSubTotals.IsChecked = false;
                            showRowSubTotals.IsChecked = false;
                            showColumnSubTotals.IsChecked = false;
                            for (int i = 0; i < pivot.PivotRows.Count; i++)
                                pivot.PivotRows[i].ShowSubTotal = false;
                            for (int i = 0; i < pivot.PivotColumns.Count; i++)
                                pivot.PivotColumns[i].ShowSubTotal = false;

                            count = 4;
                        }
                        pivot.InvalidateCells();
                        break;
                    case "Show Expander for Single Pivot":
                        pivot.ShowExpanderForSinglePivot = current.IsChecked == true;
                        pivot.InvalidateCells();
                        break;
                }
                if (count == 0)
                    showAllSubTotals.IsChecked = true;
                else if (count < 4)
                    showAllSubTotals.IsChecked = null;
                else if (count == 4)
                    showAllSubTotals.IsChecked = false;
            }
        }
    }
}
