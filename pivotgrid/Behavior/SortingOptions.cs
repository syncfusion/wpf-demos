#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using Microsoft.Xaml.Behaviors;
    using Syncfusion.Windows.Controls.PivotGrid;
    using System.Windows;
    using System.Windows.Controls;

    public class SortingOptions :TargetedTriggerAction<PivotGridControl>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is RoutedEventArgs)
            {
                RoutedEventArgs eventArgs = parameter as RoutedEventArgs;

                RadioButton current = eventArgs.OriginalSource as RadioButton;
                if (current == null)
                    return;
                switch (current.Name)
                {     
                    case "btnSortAll":
                        if (current.IsEnabled)
                            this.Target.SortOption = PivotSortOption.All;
                        break;
                       
                    case "btnSortColumn":
                        if (current.IsEnabled)
                            this.Target.SortOption = PivotSortOption.ColumnSorting;
                        break;
                    case "btnSortTotal":
                        if (current.IsEnabled)
                            this.Target.SortOption = PivotSortOption.TotalSorting;
                        break;
                    case "btnSortGrandTotal":
                        if (current.IsEnabled)
                            this.Target.SortOption = PivotSortOption.GrandTotalSorting;
                        break;
                    case "btnSortNone":
                        if (current.IsEnabled)
                            this.Target.SortOption = PivotSortOption.None;
                            break;
                }
            }
            this.Target.InvalidateCells();
        }
    }
}