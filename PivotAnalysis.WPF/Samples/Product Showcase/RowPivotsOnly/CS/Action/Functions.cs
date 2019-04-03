#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 

#endregion

namespace RowPivotsOnly.Action
{
    using System.Windows.Interactivity;
    using System.Windows;
    using System.Windows.Controls;
    using Syncfusion.Windows.Controls.PivotGrid;

    public class Functions : TargetedTriggerAction<PivotGridControl>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is RoutedEventArgs)
            {
                RoutedEventArgs eventArgs = parameter as RoutedEventArgs;

                CheckBox current = eventArgs.OriginalSource as CheckBox;
                switch (current.Name)
                {
                    case "MouseHyperLinks":
                        this.Target.EnableHyperlinkOnMouseOver = current.IsChecked.GetValueOrDefault();
                        for (int i = 0; i < this.Target.PivotEngine.PivotCalculations.Count; i++)
                            this.Target.PivotEngine.PivotCalculations[i].EnableHyperlinks = current.IsChecked.GetValueOrDefault();
                        break;
                    case "EnableContextMenu":
                        this.Target.ColumnHeaderCellStyle.EnableContextMenu = current.IsChecked.GetValueOrDefault();
                        this.Target.RowHeaderCellStyle.EnableContextMenu = current.IsChecked.GetValueOrDefault();
                        break;
                    case "Filtering":
                        for (int i = 0; i < this.Target.PivotEngine.PivotCalculations.Count; i++)
                            this.Target.PivotEngine.PivotCalculations[i].AllowFilter = current.IsChecked.GetValueOrDefault();
                        break;
                    case "Sorting":
                        for (int i = 0; i < this.Target.PivotEngine.PivotCalculations.Count; i++)
                            this.Target.PivotEngine.PivotCalculations[i].AllowSort = current.IsChecked.GetValueOrDefault();
                        if (!current.IsChecked.GetValueOrDefault())
                            this.Target.PivotEngine.ClearSorts();
                        break;
                    case "HideSummaryValue":
                        if (current.IsChecked == true)
                        {
                            for (int i = 0; i < this.Target.PivotEngine.PivotCalculations.Count; i++)
                                this.Target.PivotEngine.PivotCalculations[i].InnerMostComputationsOnly = Syncfusion.PivotAnalysis.Base.SummaryDisplayLevel.InnerMostOnly;
                        }
                        else
                        {
                            for (int i = 0; i < this.Target.PivotEngine.PivotCalculations.Count; i++)
                                this.Target.PivotEngine.PivotCalculations[i].InnerMostComputationsOnly = Syncfusion.PivotAnalysis.Base.SummaryDisplayLevel.All;
                        }
                        break;
                    case "PadString":
                        if (current.IsChecked == true)
                        {
                            for (int i = 0; i < this.Target.PivotCalculations.Count; i++)
                            {
                                if (this.Target.PivotCalculations[i].PadString != "*")
                                    this.Target.InternalGrid.Model.ColumnWidths.SetHidden((i + Target.PivotRows.Count), (i + Target.PivotRows.Count), false);
                                else
                                    this.Target.InternalGrid.Model.ColumnWidths.SetHidden((i + Target.PivotRows.Count), (i + Target.PivotRows.Count), true);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < this.Target.PivotCalculations.Count; i++)
                            {
                                if (this.Target.PivotCalculations[i].PadString != "*")
                                    this.Target.InternalGrid.Model.ColumnWidths.SetHidden((i + Target.PivotRows.Count), (i + Target.PivotRows.Count), true);
                                else
                                    this.Target.InternalGrid.Model.ColumnWidths.SetHidden((i + Target.PivotRows.Count), (i + Target.PivotRows.Count), false);
                            }
                        }
                        break;
                }
                this.Target.InvalidateCells();
            }
        }
    }
}