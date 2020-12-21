#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapgriddemos.wpf
{
    using System.Windows.Controls;
    using Microsoft.Xaml.Behaviors;
    using Syncfusion.Windows.Grid.Olap;

    public class GridSelectionChangedTriggerAction : TargetedTriggerAction<ListBox>
    {
        protected override void Invoke(object parameter)
        {
            OlapGridSelectionChangedEventArgs eventArgs = parameter as OlapGridSelectionChangedEventArgs;
            if (eventArgs != null)
                this.Target.ItemsSource = eventArgs.SelectedItems;
        }
    }
}
