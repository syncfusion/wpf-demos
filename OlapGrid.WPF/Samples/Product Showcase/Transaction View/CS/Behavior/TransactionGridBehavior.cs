#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace TransactionView.Behavior
{
    using System;
    using Syncfusion.Windows.Controls.Grid;
    using System.Windows.Interactivity;

    public class TransactionGridBehavior : Behavior<GridDataControl>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.ItemsSourceChanged += AssociatedObject_ItemsSourceChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.ItemsSourceChanged -= AssociatedObject_ItemsSourceChanged;
        }

        void AssociatedObject_ItemsSourceChanged(object sender, EventArgs e)
        {
            this.AssociatedObject.VisibleColumns.Move(this.AssociatedObject.VisibleColumns.Count - 1, 0);
        }
    }
}