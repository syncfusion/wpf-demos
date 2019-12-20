#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace CustomSummary.Action
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    using ViewModel;
    using Syncfusion.PivotAnalysis.Base;
    using Syncfusion.Windows.Controls.PivotGrid;

    class SummariesAction : TargetedTriggerAction<PivotGridControl>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is RoutedEventArgs)
            {
                RoutedEventArgs eventArgs = parameter as RoutedEventArgs;
                if (eventArgs.OriginalSource is CheckBox)
                {
                    CheckBox sourceObject = eventArgs.OriginalSource as CheckBox;
                    MyCustomSummaryBase1 me = new MyCustomSummaryBase1();
                    switch (sourceObject.Content.ToString())
                    {
                        case "CustomSummary":
                            if (sourceObject.IsChecked.HasValue && sourceObject.IsChecked.Value)
                                this.Target.PivotCalculations.Insert(0, new PivotComputationInfo { FieldHeader = "Shipped!", FieldName = "Value1", SummaryType = SummaryType.Custom, Format = "#,##0.00", Summary = me });
                            else
                            {
                                if (this.Target.PivotRows.Any(i => i.FieldMappingName == "Value1"))
                                    this.Target.PivotRows.Remove(this.Target.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Value1"));
                                if (this.Target.PivotColumns.Any(i => i.FieldMappingName == "Value1"))
                                    this.Target.PivotColumns.Remove(this.Target.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Value1"));
                                if (this.Target.GroupingBar.Filters.Any(i => i.Name == "Value1"))
                                    this.Target.GroupingBar.Filters.Remove(this.Target.GroupingBar.Filters.FirstOrDefault(x => x.Name == "Value1"));
                                if (this.Target.PivotCalculations.Any(x => x.FieldName == "Value1"))
                                    this.Target.PivotCalculations.Remove(this.Target.PivotCalculations.FirstOrDefault(x => x.FieldName == "Value1"));
                            }
                            break;
                        case "Display if Discrete Values are Equal":
                            var comboBox = Common.FindVisualChild<ComboBox>(sourceObject.Parent);
                            if (sourceObject.IsChecked.HasValue && sourceObject.IsChecked.Value && comboBox != null)
                            {                       
                                this.Target.PivotCalculations.Insert(1, new PivotComputationInfo
                                {
                                    FieldHeader = "Scrap!",
                                    FieldName = "Value3",
                                    SummaryType = SummaryType.DisplayIfDiscreteValuesEqual,
                                    PadString = comboBox.SelectedIndex == 0 ? "***" : "999"
                                });
                            }
                            else
                            {
                                if (this.Target.PivotRows.Any(i => i.FieldMappingName == "Value3"))
                                    this.Target.PivotRows.Remove(this.Target.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Value3"));
                                if (this.Target.PivotColumns.Any(i => i.FieldMappingName == "Value3"))
                                    this.Target.PivotColumns.Remove(this.Target.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Value3"));
                                if (this.Target.GroupingBar.Filters.Any(i => i.Name == "Value3"))
                                    this.Target.GroupingBar.Filters.Remove(this.Target.GroupingBar.Filters.FirstOrDefault(x => x.Name == "Value3"));
                                if (this.Target.PivotCalculations.Any(x => x.FieldName == "Value3"))
                                    this.Target.PivotCalculations.Remove(this.Target.PivotCalculations.FirstOrDefault(x => x.FieldName == "Value3"));
                            }
                            break;
                    }
                }
                else
                {
                    ComboBox sourceObject = eventArgs.OriginalSource as ComboBox;
                    switch (sourceObject.SelectedIndex)
                    {
                        case 0:
                            this.Target.PivotCalculations[1].PadString = "***";
                            break;
                        case 1:
                            this.Target.PivotCalculations[1].PadString = "999";
                            break;
                    }
                    if (this.Target.InternalGrid != null)
                        this.Target.InternalGrid.Refresh(true);
                }
            }
        }
    }
}