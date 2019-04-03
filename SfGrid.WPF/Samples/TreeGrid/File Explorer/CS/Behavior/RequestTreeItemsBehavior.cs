#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using FileExplorer;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;

namespace FileExplorer
{
    internal class RequestTreeItemsBehavior : Behavior<SfTreeGrid>
    {
        ViewModel viewModel;
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            viewModel = this.AssociatedObject.DataContext as ViewModel;
            this.AssociatedObject.RequestTreeItems += AssociatedObject_RequestTreeItems;
        }

        void AssociatedObject_RequestTreeItems(object sender, TreeGridRequestTreeItemsEventArgs e)
        {
            //when ParentItem is null, you need to set args.ChildList to be the root items...
            if (e.ParentItem == null)
            {
                e.ChildItems = (IEnumerable)viewModel.DriveDetails;
            }
            else  //if ParentItem not null, then set args.ChildList to the child items for the given ParentItem.
            {
                FileInfoModel item = e.ParentItem as FileInfoModel;
                e.ChildItems = viewModel.GetChildFolderContent(item);
            }
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.RequestTreeItems -= AssociatedObject_RequestTreeItems;
        }
    }
}
