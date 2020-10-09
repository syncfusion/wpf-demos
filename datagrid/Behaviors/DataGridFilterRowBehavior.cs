#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using Syncfusion.UI.Xaml.ScrollAxis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Class for representing the behavior for clearing the filter and remove the default renderer and
    /// assign the custom renderer
    /// </summary>
    public class DataGridFilterRowBehavior : Behavior<SfDataGrid>
    {
        /// <summary>
        /// Called when behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += OnAssociatedObjectLoaded;
        }

        /// <summary>
        /// Called when the AssociatedObject is loaded.
        /// </summary>
        /// <param name="sender">The Associated object.</param>
        /// <param name="e">The event args.</param>
        void OnAssociatedObjectLoaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.MoveCurrentCell(new RowColumnIndex(this.AssociatedObject.GetFilterRowIndex(), this.AssociatedObject.GetFirstColumnIndex()));
            this.AssociatedObject.SelectionController.CurrentCellManager.BeginEdit();
        }

        /// <summary>
        /// Called when the behavior has been detached from the AssociatedObject.
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= OnAssociatedObjectLoaded;
        }
    }
}
