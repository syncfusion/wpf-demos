#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.TreeGrid;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.treegriddemos.wpf
{
    public delegate void TreeGridRequestTreeItemsHandler(object sender, RoutedEventArgs args);

    /// <summary>
    ///  Handles the cell merging in SfTreeGrid.
    /// </summary>
    public class QueryCoveredRangeBehavior : Behavior<SfTreeGrid>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {             
            this.AssociatedObject.QueryCoveredRange += AssociatedObject_QueryCoveredRange;
            base.OnAttached();
        } 
       
        public void AssociatedObject_QueryCoveredRange(object sender, TreeGridQueryCoveredRangeEventArgs e)
        {
            var treeNode = this.AssociatedObject.GetNodeAtRowIndex(e.RowColumnIndex.RowIndex);
            if (treeNode != null && treeNode.HasChildNodes)
            {
                if (e.RowColumnIndex.ColumnIndex >= 1 && e.RowColumnIndex.ColumnIndex <= this.AssociatedObject.Columns.Count)
                {
                    e.Range = new TreeGridCoveredCellInfo(0, this.AssociatedObject.Columns.Count, e.RowColumnIndex.RowIndex);
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            this.AssociatedObject.QueryCoveredRange -= AssociatedObject_QueryCoveredRange;
            base.OnDetaching();
        }
    }
}
