#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace DrillThrough.Action
{
    using Syncfusion.Windows.Controls.PivotGrid;
    using System.Windows.Interactivity;
    using Syncfusion.Windows.Controls.Grid;

    public class HyperLinkAction : TargetedTriggerAction<GridDataControl>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is HyperlinkCellClickEventArgs)
            {
                HyperlinkCellClickEventArgs eventArgs = parameter as HyperlinkCellClickEventArgs;
                this.Target.ItemsSource = (this.AssociatedObject as PivotGridControl).PivotEngine.GetRawItemsFor(eventArgs.RowColumnIndex.RowIndex, eventArgs.RowColumnIndex.ColumnIndex);
            }
        }
    }
}