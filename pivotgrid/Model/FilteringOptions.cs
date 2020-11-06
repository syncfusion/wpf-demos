#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using System.Linq;
    using Microsoft.Xaml.Behaviors;
    using Syncfusion.Windows.Controls.PivotGrid;
    using System.Windows;
    using System.Windows.Controls;
    using Syncfusion.PivotAnalysis.Base;

    public class FilteringOptions : TargetedTriggerAction<PivotGridControl>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is RoutedEventArgs)
            {
                RoutedEventArgs eventArgs = parameter as RoutedEventArgs;

                Button current = eventArgs.OriginalSource as Button;
                if (current == null)
                    return;
                switch (current.Name)
                {
                    case "button1":
                        if (current.IsEnabled)
                            this.Target.Filters.Add(new FilterExpression("Product"));
                        break;

                    case "button2":
                        if (current.IsEnabled)

                            this.Target.Filters.Remove(this.Target.Filters.FirstOrDefault(i => i.DimensionName == "Product"));
                        this.Target.Filters.Remove(this.Target.Filters.FirstOrDefault(i => i.Name == "Product"));

                        break;
                    case "button3":
                        if (current.IsEnabled)
                            this.Target.Filters.Insert(0, new FilterExpression("State"));
                        break;
                    case "button4":
                        if (current.IsEnabled)
                        {
                            if (this.Target.Filters.Count > 1)
                            {
                                this.Target.Filters.RemoveAt(1);
                            }
                            else if (this.Target.GroupingBar.Filters.Count > 1)
                            {
                                this.Target.GroupingBar.Filters.RemoveAt(1);
                            }
                            else
                                MessageBox.Show("Please add the item before remove", "Warning!");
                        }

                        break;
                    case "button5":
                        if (current.IsEnabled)
                        {
                            if (this.Target.GroupingBar != null && this.Target.GroupingBar.AllowMultiFunctionalSortFilter)
                            {
                                FilterConverter filterconv = new FilterConverter();
                                for (int i = 0; i < this.Target.Filters.Count; i++)
                                {
                                    filterconv.UpdateDictionary(this.Target.Filters[i].DimensionName);
                                }
                            }
                            else
                            {
                                ImageConverter imgconv = new ImageConverter();
                                for (int i = 0; i < this.Target.Filters.Count; i++)
                                {
                                    imgconv.UpdateDictionary(this.Target.Filters[i].DimensionName);
                                }
                            }
                            this.Target.Filters.Clear();
                            this.Target.InternalGrid.Refresh(true);
                        }
                        break;
                }
            }
            this.Target.InvalidateCells();
        }
    }
}