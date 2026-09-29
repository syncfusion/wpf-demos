#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using System;
    using System.Windows.Controls;
    using Microsoft.Xaml.Behaviors;
    using Syncfusion.Windows.Controls.PivotGrid;

    public class HyperlinkCellClickAction : TargetedTriggerAction<ListBox>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is HyperlinkCellClickEventArgs)
            {
                HyperlinkCellClickEventArgs eventArgs = parameter as HyperlinkCellClickEventArgs;
                this.Target.Items.Add("Value: " + Convert.ToString(eventArgs.PivotCellInfo.Value) + Environment.NewLine + "RowIndex: " + eventArgs.RowColumnIndex.RowIndex.ToString() + Environment.NewLine + "ColumnIndex: " + eventArgs.RowColumnIndex.ColumnIndex.ToString());

                this.Target.ScrollIntoView(this.Target.Items[this.Target.Items.Count - 1]);
            }
        }
    }
}