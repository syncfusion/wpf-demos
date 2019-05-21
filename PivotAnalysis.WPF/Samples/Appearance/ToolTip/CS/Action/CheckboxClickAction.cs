#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace ToolTip.Action
{
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    using Syncfusion.Windows.Controls.PivotGrid;
    using System.Windows;
    public class CheckboxClickAction : TargetedTriggerAction<PivotGridControl>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is RoutedEventArgs)
            {
                RoutedEventArgs eventArgs = parameter as RoutedEventArgs;

                CheckBox current = eventArgs.OriginalSource as CheckBox;
                if (current != null)
                {
                    StackPanel panelStack = current.Parent as StackPanel;
                    GroupBox grpBox = panelStack.Parent as GroupBox;
                    switch (current.Name.ToString())
                    {
                        case "chkBoxEnableCustom_All":
                            if (current.IsChecked == true)
                                this.Target.CustomToolTipTemplateKey = "CustomTemplateTooltip";
                            else
                                this.Target.CustomToolTipTemplateKey = null;
                            break;
                        case "chkBoxCustomColHeader":
                            if (current.IsChecked == true)
                                this.Target.ColumnHeaderCellStyle.CustomToolTipTemplateKey = "ColumnTemplateTooltip";
                            else
                            {
                                this.Target.ColumnHeaderCellStyle.CustomToolTipTemplateKey = null;
                                SetCustomTooltip(grpBox);
                            }
                            break;
                        case "chkBoxCustomRowHeader":
                            if (current.IsChecked == true)
                                this.Target.RowHeaderCellStyle.CustomToolTipTemplateKey = "RowTemplateTooltip";
                            else
                            {
                                this.Target.RowHeaderCellStyle.CustomToolTipTemplateKey = null;
                                SetCustomTooltip(grpBox);
                            }
                            break;
                        case "chkBoxCustomValCell":
                            if (current.IsChecked == true)
                                this.Target.ValueCellStyle.CustomToolTipTemplateKey = "ValueTemplateTooltip";
                            else
                            {
                                this.Target.ValueCellStyle.CustomToolTipTemplateKey = null;
                                SetCustomTooltip(grpBox);
                            }
                            break;
                        case "chkBoxCustomSumHeader":
                            if (current.IsChecked == true)
                                this.Target.SummaryHeaderStyle.CustomToolTipTemplateKey = "SummaryHeaderTemplateTooltip";
                            else
                            {
                                this.Target.CustomToolTipTemplateKey = null;
                                SetCustomTooltip(grpBox);
                            }
                            break;
                        case "chkBoxCustomSumCell":
                            if (current.IsChecked == true)
                                this.Target.SummaryCellStyle.CustomToolTipTemplateKey = "SummaryCellTemplateTooltip";
                            else
                            {
                                this.Target.CustomToolTipTemplateKey = null;
                                SetCustomTooltip(grpBox);
                            }
                            break;
                    }
                }
            }
            this.Target.InvalidateCells();
        }

        private void SetCustomTooltip(GroupBox grpBox)
        {
            CheckBox allGroup = grpBox.FindName("chkBoxEnableCustom_All") as CheckBox;
            CheckBox colGroup = grpBox.FindName("chkBoxCustomColHeader") as CheckBox;
            CheckBox rowGroup = grpBox.FindName("chkBoxCustomRowHeader") as CheckBox;
            CheckBox valGroup = grpBox.FindName("chkBoxCustomValCell") as CheckBox;
            CheckBox sumHeaderGroup = grpBox.FindName("chkBoxCustomSumHeader") as CheckBox;
            CheckBox sumCellGroup = grpBox.FindName("chkBoxCustomSumCell") as CheckBox;
            this.Target.CustomToolTipTemplateKey = null;
            if (colGroup != null && colGroup.IsChecked == true)
                this.Target.ColumnHeaderCellStyle.CustomToolTipTemplateKey = "ColumnTemplateTooltip";
            if (rowGroup != null && rowGroup.IsChecked == true)
                this.Target.RowHeaderCellStyle.CustomToolTipTemplateKey = "RowTemplateTooltip";
            if (valGroup != null && valGroup.IsChecked == true)
                this.Target.ValueCellStyle.CustomToolTipTemplateKey = "ValueTemplateTooltip";
            if (sumHeaderGroup != null && sumHeaderGroup.IsChecked == true)
                this.Target.SummaryHeaderStyle.CustomToolTipTemplateKey = "SummaryHeaderTemplateTooltip";
            if (sumCellGroup != null && sumCellGroup.IsChecked == true)
                this.Target.SummaryCellStyle.CustomToolTipTemplateKey = "SummaryCellTemplateTooltip";

        }
    }
}
