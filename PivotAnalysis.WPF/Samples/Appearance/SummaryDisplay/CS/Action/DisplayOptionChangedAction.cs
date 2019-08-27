#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace SummaryDisplayOption.Action
{
    using System.Windows.Interactivity;
    using Syncfusion.Windows.Controls.PivotGrid;
    using System.Windows;
    using System.Windows.Controls;
    using Syncfusion.PivotAnalysis.Base;
    using System.Linq;

    class DisplayOptionChangedAction : TargetedTriggerAction<Grid>
    {
        protected override void Invoke(object parameter)
        {
            RoutedEventArgs eventArgs = parameter as RoutedEventArgs;
            if (eventArgs != null)
            {
                ComboBox current = eventArgs.OriginalSource as ComboBox;
                string calcName = "";
                Grid parentGrid = this.Target.Children.Count > 1 ? this.Target.Children[1] as Grid : null;
                PivotGridControl pivot = parentGrid != null ? parentGrid.Children[0] as PivotGridControl : null;
                int index = current.Name == "DisplayOptionBox" ? 1 : 0;
                calcName = index == 0 ? "Amount" : "Quantity";
                if (pivot != null && current != null)
                {
                    index = pivot.PivotCalculations.IndexOf(pivot.PivotCalculations.FirstOrDefault(x => x.FieldName == calcName));
                    if (index != -1)
                    {
                        switch (current.SelectedItem.ToString())
                        {
                            case "None":
                                pivot.PivotCalculations[index].DisplayOption = DisplayOption.None;
                                break;
                            case "All":
                                pivot.PivotCalculations[index].DisplayOption = DisplayOption.All;
                                break;
                            case "Calculations":
                                pivot.PivotCalculations[index].DisplayOption = DisplayOption.Calculations;
                                break;
                            case "Summaries":
                                pivot.PivotCalculations[index].DisplayOption = DisplayOption.Summary;
                                break;
                            case "GrandTotals":
                                pivot.PivotCalculations[index].DisplayOption = DisplayOption.GrandTotals;
                                break;
                            case "Summaries and Calculations":
                                pivot.PivotCalculations[index].DisplayOption = DisplayOption.Calculations | DisplayOption.Summary;
                                break;
                            case "Summaries and GrandTotals":
                                pivot.PivotCalculations[index].DisplayOption = DisplayOption.Summary | DisplayOption.GrandTotals;
                                break;
                            case "Calculations and GrandTotals":
                                pivot.PivotCalculations[index].DisplayOption = DisplayOption.Calculations | DisplayOption.GrandTotals;
                                break;
                        }
                        pivot.InternalGrid.Refresh(true);
                    }
                    else
                        current.SelectedIndex = 1;
                }
            }
        }
    }
}