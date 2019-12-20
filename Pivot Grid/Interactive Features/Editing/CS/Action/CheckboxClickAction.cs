#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace PivotEditing.Action
{
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    using System.Windows;
    using Syncfusion.Windows.Controls.PivotGrid;

    public class CheckboxClickAction : TargetedTriggerAction<PivotGridControl>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is RoutedEventArgs)
            {
                RoutedEventArgs eventArgs = parameter as RoutedEventArgs;
                CheckBox sourceObject = eventArgs.OriginalSource as CheckBox;
                if (sourceObject != null)
                {
                    switch (sourceObject.Content.ToString())
                    {
                        case "Edit Value Cells":
                            if (sourceObject.IsChecked.HasValue && sourceObject.IsChecked.Value)
                            {
                                this.Target.EnableValueEditing = true;                                
                                this.Target.EditManager.AllowEditingOfTotalCells = true;
                            }
                            else
                                this.Target.EnableValueEditing = false;
                            break;
                        case "Edit Total Cells":
                            if (sourceObject.IsChecked.HasValue && sourceObject.IsChecked.Value)
                                this.Target.EditManager.AllowEditingOfTotalCells = true;
                            else
                                this.Target.EditManager.AllowEditingOfTotalCells = false;
                            break;
                        case "HideExpanders":
                            if (sourceObject.IsChecked.HasValue && sourceObject.IsChecked.Value)
                                this.Target.EditManager.HideExpanders = true;
                            else
                                this.Target.EditManager.HideExpanders = false;
                            break;
                    }
                    this.Target.InvalidateCells();
                }
            }
        }
    }
}